using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using CryptoEditor.Common.Interfaces;

namespace CryptoEditorCmd
{
    public class CryptoEditorCmdFS
    {
        private string currentPath = "/";
        private Hashtable fs = new Hashtable();
        private ArrayList plugins;

        public CryptoEditorCmdFS()
        {
            throw new NotImplementedException();
        }

        public CryptoEditorCmdFS(ArrayList plugins)
        {
            this.plugins = plugins;

            for (int i = 0; i < plugins.Count; i++)
            {
                ICryptoEditor plugin = (ICryptoEditor)plugins[i];
                fs.Add(plugin.Text, plugin);
            }
        }

        public string CurrentPath
        {
            get { return currentPath; }
        }

        public void ls()
        {
            if (currentPath.Equals("/"))
            {
                foreach (string key in fs.Keys)
                {
                    Console.WriteLine(key);
                }

                return;
            }

            ICryptoEditor plugin = (ICryptoEditor)plugins[0];
            ICryptoEditorDoc doc = plugin.GetDoc();
            if (doc == null)
                return;

            plugin.View.DisplayView(doc);
        }

        public void open(string itemName)
        {
            ICryptoEditor plugin = (ICryptoEditor)plugins[0];
            ICryptoEditorDoc doc = plugin.GetDoc();
            if (doc == null)
                return;

            ICryptoEditorPluginItem item = doc.GetItem("");
            if (item == null)
                return;

            plugin.Detail.DisplayItem(item);
        }

        public void cd(string path)
        {
            string pathIn = path;

            if (pathIn.StartsWith("/"))
            {
                // Absolute path ...
                // Nothing to do ...
            }
            else
            {
                // Relative path
                if (pathIn.StartsWith("./"))
                    pathIn = pathIn.Substring(2);

                pathIn = currentPath + pathIn;
            }

            if (!pathIn.EndsWith("/"))
                pathIn += "/";

            currentPath = pathIn;
        }

        public void pwd()
        {
            Console.WriteLine(currentPath);
        }
    }
}
