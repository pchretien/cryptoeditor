using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;
using com.CryptoTools;
//using CryptoEditorWeb.CryptoEditorServiceBackup;
using CryptoEditor.Common.Interfaces;
using CryptoEditor.Common;

namespace CryptoEditor.Common
{
    public class CryptoEditorPersist
    {
        private ArrayList plugins;
        private CryptoEditorProfile currentProfile = null;

        public CryptoEditorPersist(ArrayList plugins, CryptoEditorProfile currentProfile)
        {
            this.plugins = plugins;
            this.currentProfile = currentProfile;
        }

        public CryptoEditorProfile CurrentProfile
        {
            get { return currentProfile; }
        }

        private CryptoXML Encrypt(ICryptoEditor plugin)
        {
            string data = plugin.Save();
            string xpath = plugin.EncryptionXPath;
            CryptoXML xmlRoot = new CryptoXML();

            try
            {
                xmlRoot.LoadXml(data);
            }
            catch (Exception)
            {
                xmlRoot.LoadXml("<?xml version=\"1.0\" encoding=\"utf-8\"?><CryptoEditorDefault xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"></CryptoEditorDefault>");

                XmlElement element = xmlRoot.CreateElement(plugin.ToString());
                element.InnerText = data;
                xmlRoot.DocumentElement.AppendChild(element);

                xpath = "/*";
            }

            xmlRoot.Password = CurrentProfile.Password;

#if !NO_ENCRYPT
            xmlRoot.Encrypt(xpath, true);
#endif

            return xmlRoot;
        }

        public void SaveData(bool saveAll)
        {
            if (!CurrentProfile.PasswordValidated)
                return;

            foreach (ICryptoEditor plugin in plugins)
            {
                if (!plugin.isPersistent())
                    continue;

                if (!plugin.HasChanged() && !saveAll)
                    continue;

                CryptoEditorUtils.CheckApplicationDataFolder();

                CryptoXML xmlRoot = Encrypt(plugin);
                string filename = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) +
                                  @"\CryptoEditor\" + CurrentProfile.Id + "." + plugin.ToString().ToLower() + ".data";
                
                xmlRoot.Save(filename);
                System.Diagnostics.Debug.WriteLine("Saving " + CurrentProfile.Name + "." + plugin.ToString().ToLower() + ".data");

                plugin.ClearChanges();
            }
        }

        public void LoadData()
        {
            if( !CurrentProfile.PasswordValidated )
                return;

            foreach (ICryptoEditor plugin in plugins)
            {
                CryptoXML xmlRoot = new CryptoXML();
                string filename = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) +
                                  @"\CryptoEditor\" + CurrentProfile.Id + "." + plugin.ToString().ToLower() + ".data";

                try
                {
                    xmlRoot.Load(filename);
                }
                catch (System.IO.FileNotFoundException)
                {
                    try
                    {
                        xmlRoot.Load(filename);
                    }
                    catch(System.IO.FileNotFoundException)
                    {
                        plugin.Load(null);
                        continue;
                    }
                }

                if (xmlRoot.DocumentElement.Name.Equals("CryptoEditorDefault"))
                {
                    // This is text only data or a not well formed XML document
#if !NO_ENCRYPT
                    xmlRoot.Decrypt("/*", true);
#endif
                    plugin.Load(xmlRoot.DocumentElement.InnerText);
                    continue;
                }

                xmlRoot.Password = CurrentProfile.Password;
#if !NO_ENCRYPT
                xmlRoot.Decrypt(plugin.EncryptionXPath, true);
#endif
                plugin.Load(xmlRoot.OuterXml);

                filename = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) +
                                  @"\CryptoEditor\" + CurrentProfile.Id + "." + plugin.ToString().ToLower() + ".properties";
                plugin.LoadProperties(filename);
            }
        }

        public void Synchronize(
            string serverPassword, 
            System.ComponentModel.BackgroundWorker backgroundWorker,
            out Dictionary<ICryptoEditor, string> newData)
        {
            // Create empty dict
            newData = new Dictionary<ICryptoEditor, string>();

            if(CurrentProfile.Email.Length == 0 || CurrentProfile.Name.Length == 0)
            {
                MessageBox.Show(
                    "You must provide both a profile name and an email address in order to use web synchronization",
                    "Incomplete profile!", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                return;
            }

//            BackupService client = new BackupService();

            if (!CurrentProfile.PasswordValidated)
                return;

            for (int i = 0; i < plugins.Count; i++ )
            {
                ICryptoEditor plugin = plugins[i] as ICryptoEditor;
                if (plugin == null)
                    continue;

                try
                {
                    if (!plugin.isPersistent())
                        continue;

                    // Load the XML of that plugin from the web
                    //string webData = client.Load(CurrentProfile.Email, CurrentProfile.Key, plugin.GetType().ToString());
                    string webData = "";
                    HttpServiceClient service = new HttpServiceClient(currentProfile);
                    bool ret = service.Load(plugin.GetType().ToString(), ref webData);
                    if (!ret)
                        return;

                    if (string.IsNullOrEmpty(webData))
                    {
                        // The document does not exist on the server.
                        // This will happen only at the first synchro.
                        CryptoXML xmlEncrypted = Encrypt(plugin);
                        //client.Save(CurrentProfile.Email, CurrentProfile.Key, plugin.GetType().ToString(), xmlEncrypted.OuterXml);
                        ret = service.Save(plugin.GetType().ToString(), xmlEncrypted.OuterXml);
                        if (!ret)
                            return;

                        continue;
                    }

                    CryptoXML xmlWeb = new CryptoXML();
                    xmlWeb.LoadXml(webData);

                    string localData = plugin.Save();
                    CryptoXML xmlLocal = new CryptoXML();
                    if (localData != null)
                        xmlLocal.LoadXml(localData);

                    xmlWeb.Password = serverPassword;

#if !NO_ENCRYPT
                    xmlWeb.Decrypt(plugin.EncryptionXPath, true);
#endif
                    // At this point I have the two XML documents I want to synchronize 
                    // It is important to work on the XML document at this level because 
                    // we dont have access to the definition of the Items involved. The 
                    // plugin is not forced to inherit its item from the framework's 
                    // CryptoEditorPluginItem.

                    // Step 1 
                    // Update the nodes that are found in both documents with the most
                    // recent version.
                    UpdateItems(xmlLocal, xmlWeb);

                    // Step 2
                    UpdateFolders(xmlLocal, xmlWeb);

                    // Step 3
                    // Fins all items and folders that are not present in both documents
                    UpdateMissingNodes(xmlLocal.DocumentElement, xmlWeb.DocumentElement);

                    // Delete all inactive nodes in the local document
                    DeleteInactiveNodes(xmlLocal.DocumentElement);

                    // Remove data from the inactive server document nodes
                    DeleteInactiveNodesContent(xmlWeb.DocumentElement);

                    // Remove older inactive nodes ...

                    // Load the resulting XML into the plugin
                    //plugin.Load(xmlLocal.OuterXml);
                    newData.Add(plugin, xmlLocal.OuterXml);
                    backgroundWorker.ReportProgress((i+1)*100/plugins.Count, "Merging " + plugin.Text + " ...");

                    // Publish the resulting xml on the web ...
                    xmlWeb.Password = CurrentProfile.Password;
                    xmlWeb.Encrypt(plugin.EncryptionXPath, true);
                    ret = service.Save(plugin.GetType().ToString(), xmlWeb.OuterXml);
                    if (!ret)
                        return;
                }
                finally
                {
                }
            }
        }

        private void DeleteInactiveNodesContent(XmlNode nodeIn)
        {
            XmlNode items = nodeIn.SelectNodes("Items")[0];
            XmlNodeList localItemList = items.SelectNodes("Item[@active='false']");
            foreach (XmlNode node in localItemList)
                node.InnerXml = "";

            XmlNode folders = nodeIn.SelectNodes("Folders")[0];
            XmlNodeList localFolderList = folders.SelectNodes("Folder[@active='false']");
            foreach (XmlNode folder in localFolderList)
                folder.InnerXml = "";

            localFolderList = nodeIn.SelectNodes("Folders/Folder[@active='true']");
            foreach (XmlNode folder in localFolderList)
            {
                DeleteInactiveNodesContent(folder);
            }
        }

        private void DeleteInactiveNodes(XmlNode nodeIn)
        {
            XmlNode items = nodeIn.SelectNodes("Items")[0];
            XmlNodeList localItemList = items.SelectNodes("Item[@active='false']");
            foreach(XmlNode node in localItemList)
                items.RemoveChild(node);

            XmlNode folders = nodeIn.SelectNodes("Folders")[0];
            XmlNodeList localFolderList = folders.SelectNodes("Folder[@active='false']");
            foreach (XmlNode folder in localFolderList)
                folders.RemoveChild(folder);

            localFolderList = nodeIn.SelectNodes("Folders/Folder[@active='true']");
            foreach (XmlNode folder in localFolderList)
            {
                DeleteInactiveNodes(folder);
            }
        }

        private void UpdateItems(CryptoXML source/*local*/, CryptoXML target/*web*/)
        {
            XmlNodeList sourceItems = source.SelectNodes("//Items/Item");

            foreach (XmlNode sourceNode in sourceItems)
            {
                string sourceId = sourceNode.Attributes.GetNamedItem("item_id").Value;
                DateTime sourceDateTime = DateTime.Parse(sourceNode.Attributes.GetNamedItem("lastupdate").Value);

                string targetPath = string.Format("//Items/Item[@item_id='{0}']", sourceId);
                XmlNodeList targetItems = target.SelectNodes(targetPath);

                if(targetItems != null && targetItems.Count > 0)
                {
                    // We have a match in the target document ...
                    XmlNode targetNode = targetItems[0];
                    DateTime targetDateTime = DateTime.Parse(targetNode.Attributes.GetNamedItem("lastupdate").Value);

                    // If the server version is older ... update the server version
                    if(targetDateTime < sourceDateTime)
                    {
                        // This code is useless since the server version will be replaced by the client version
                        targetNode.InnerXml = sourceNode.InnerXml;
                        targetNode.Attributes.GetNamedItem("lastupdate").InnerText = sourceNode.Attributes.GetNamedItem("lastupdate").InnerText;
                        targetNode.Attributes.GetNamedItem("active").InnerText = sourceNode.Attributes.GetNamedItem("active").InnerText;
                    }
                        // If the server version is more recent ... update the local version
                    else if (targetDateTime > sourceDateTime)
                    {
                        sourceNode.InnerXml = targetNode.InnerXml;
                        sourceNode.Attributes.GetNamedItem("lastupdate").InnerText = targetNode.Attributes.GetNamedItem("lastupdate").InnerText;
                        sourceNode.Attributes.GetNamedItem("active").InnerText = targetNode.Attributes.GetNamedItem("active").InnerText;
                    }
                    else
                    {
                        // Already in sync ...
                    }
                }
            }
        }

        private void UpdateFolders( CryptoXML source/*local*/, CryptoXML target/*web*/)
        {
            XmlNodeList sourceItems = source.SelectNodes("//Folders/Folder");

            foreach (XmlNode sourceNode in sourceItems)
            {
                string sourceId = sourceNode.Attributes.GetNamedItem("folder_id").Value;
                DateTime sourceDateTime = DateTime.Parse(sourceNode.Attributes.GetNamedItem("lastupdate").Value);

                string targetPath = string.Format("//Folders/Folder[@folder_id='{0}']", sourceId);
                XmlNodeList targetItems = target.SelectNodes(targetPath);

                if (targetItems != null && targetItems.Count > 0)
                {
                    // We have a match in the target document ...
                    XmlNode targetNode = targetItems[0];
                    DateTime targetDateTime = DateTime.Parse(targetNode.Attributes.GetNamedItem("lastupdate").Value);

                    // If the server version is older
                    if (targetDateTime < sourceDateTime)
                    {
                        targetNode.Attributes.GetNamedItem("name").InnerText = sourceNode.Attributes.GetNamedItem("name").InnerText;
                        targetNode.Attributes.GetNamedItem("lastupdate").InnerText = sourceNode.Attributes.GetNamedItem("lastupdate").InnerText;
                        targetNode.Attributes.GetNamedItem("active").InnerText = sourceNode.Attributes.GetNamedItem("active").InnerText;
                    }
                    // If the server version is more recent
                    else if (targetDateTime > sourceDateTime)
                    {
                        sourceNode.Attributes.GetNamedItem("name").InnerText = targetNode.Attributes.GetNamedItem("name").InnerText;
                        sourceNode.Attributes.GetNamedItem("lastupdate").InnerText = targetNode.Attributes.GetNamedItem("lastupdate").InnerText;
                        sourceNode.Attributes.GetNamedItem("active").InnerText = targetNode.Attributes.GetNamedItem("active").InnerText;
                    }
                    else
                    {
                        // Already in sync ...
                    }
                }
            }
        }
        
        private void UpdateMissingNodes(XmlNode source/*local*/, XmlNode target/*web*/)
        {
            // Add the missing Items in both documents ...
            XmlNodeList sourceItemList = source.SelectNodes("Items");
            XmlNodeList targetItemList = target.SelectNodes("Items");
            if (sourceItemList.Count > 0 && targetItemList.Count > 0)
            {
                UpdateMissingItemsInTarget(sourceItemList[0], targetItemList[0], true);
                UpdateMissingItemsInTarget(targetItemList[0], sourceItemList[0], false);
            }

            // Add the missing folders
            XmlNodeList sourceFolderList = source.SelectNodes("Folders");
            XmlNodeList targetFolderList = target.SelectNodes("Folders");
            if (sourceFolderList.Count > 0 && targetFolderList.Count > 0)
            {
                UpdateMissingFoldersInTarget(sourceFolderList[0], targetFolderList[0], true);
                UpdateMissingFoldersInTarget(targetFolderList[0], sourceFolderList[0], false);
            }

            XmlNodeList sourceFolders = source.SelectNodes("Folders/Folder");
            foreach (XmlNode sourceFolder in sourceFolders)
            {
                string folderId = sourceFolder.Attributes.GetNamedItem("folder_id").Value;
                string targetPath = string.Format("Folders/Folder[@folder_id='{0}']", folderId);
                XmlNodeList targetFolders = target.SelectNodes(targetPath);
                if(targetFolders != null && targetFolders.Count > 0)
                {
                    UpdateMissingNodes(sourceFolder, targetFolders[0]);
                }
            }
        }

        private void UpdateMissingItemsInTarget(XmlNode source, XmlNode target, bool toServer)
        {
            // Every time we get into this function we are at the root of a new document
            XmlNodeList sourceItems = source.SelectNodes("Item");
            foreach (XmlNode sourceNode in sourceItems)
            {
                string sourceId = sourceNode.Attributes.GetNamedItem("item_id").Value;
                string targetPath = string.Format("Item[@item_id='{0}']", sourceId);
                XmlNodeList targetItems = target.SelectNodes(targetPath);

                if(targetItems != null && targetItems.Count > 0)
                    continue;

                DateTime lastUpdate = DateTime.Parse(sourceNode.Attributes.GetNamedItem("lastupdate").InnerText);
                TimeSpan interval = DateTime.Now - lastUpdate;
                //if(!toServer && interval.Days > 31)
                //    continue;

                XmlAttribute newElementLastUpdateAttr = target.OwnerDocument.CreateAttribute("lastupdate");
                newElementLastUpdateAttr.InnerText = sourceNode.Attributes.GetNamedItem("lastupdate").InnerText;

                // The item does not exist in the target document ...
                XmlAttribute newElementIdAttr = target.OwnerDocument.CreateAttribute("item_id");
                newElementIdAttr.InnerText = sourceNode.Attributes.GetNamedItem("item_id").InnerText;

                XmlAttribute newElementActiveAttr = target.OwnerDocument.CreateAttribute("active");
                newElementActiveAttr.InnerText = sourceNode.Attributes.GetNamedItem("active").InnerText;

                XmlElement newElement = target.OwnerDocument.CreateElement("Item");
                newElement.Attributes.Append(newElementIdAttr);
                newElement.Attributes.Append(newElementLastUpdateAttr);
                newElement.Attributes.Append(newElementActiveAttr);
                newElement.InnerXml = sourceNode.InnerXml;

                target.AppendChild(newElement);
            }
        }

        private void UpdateMissingFoldersInTarget(XmlNode source, XmlNode target, bool toServer)
        {
            // Every time we get into this function we are at the root of a new document
            XmlNodeList sourceFolders = source.SelectNodes("Folder");
            foreach (XmlNode sourceNode in sourceFolders)
            {
                string sourceId = sourceNode.Attributes.GetNamedItem("folder_id").Value;
                string targetPath = string.Format("Folder[@folder_id='{0}']", sourceId);
                XmlNodeList targetFolders = target.SelectNodes(targetPath);

                if (targetFolders != null && targetFolders.Count > 0)
                    continue;

                DateTime lastUpdate = DateTime.Parse(sourceNode.Attributes.GetNamedItem("lastupdate").InnerText);
                TimeSpan interval = DateTime.Now - lastUpdate;
                //if (!toServer && interval.Days > 31)
                //    continue;

                // The item does not exist in the target document ...
                XmlAttribute newElementIdAttr = target.OwnerDocument.CreateAttribute("folder_id");
                newElementIdAttr.InnerText = sourceNode.Attributes.GetNamedItem("folder_id").InnerText;

                XmlAttribute newElementLastUpdateAttr = target.OwnerDocument.CreateAttribute("lastupdate");
                newElementLastUpdateAttr.InnerText = sourceNode.Attributes.GetNamedItem("lastupdate").InnerText;

                XmlAttribute newElementActiveAttr = target.OwnerDocument.CreateAttribute("active");
                newElementActiveAttr.InnerText = sourceNode.Attributes.GetNamedItem("active").InnerText;

                XmlAttribute newElementNameAttr = target.OwnerDocument.CreateAttribute("name");
                newElementNameAttr.InnerText = sourceNode.Attributes.GetNamedItem("name").InnerText;

                XmlElement newElement = target.OwnerDocument.CreateElement("Folder");
                newElement.Attributes.Append(newElementIdAttr);
                newElement.Attributes.Append(newElementLastUpdateAttr);
                newElement.Attributes.Append(newElementActiveAttr);
                newElement.Attributes.Append(newElementNameAttr);
                newElement.InnerXml = sourceNode.InnerXml;

                target.AppendChild(newElement);
            }
        }
    }
}
