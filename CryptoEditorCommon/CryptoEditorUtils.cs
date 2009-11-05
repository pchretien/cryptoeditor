using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using CryptoEditor.Common.Interfaces;

namespace CryptoEditor.Common
{
    public class CryptoEditorUtils
    {
        private static string pluginFolder = ".";
        private static string pluginExtension = "*.dll";

        public static void LoadPlugins(ArrayList plugins)
        {
            string[] files = Directory.GetFiles(pluginFolder, pluginExtension);
            foreach (string fileName in files)
            {
                FileInfo info = new FileInfo(fileName);
                Assembly assembly = Assembly.LoadFrom(info.FullName);

                Type[] types = assembly.GetTypes();
                foreach (Type type in types)
                {
                    object[] attributes = type.GetCustomAttributes(true);
                    foreach (Attribute attribute in attributes)
                    {
                        if (attribute is CryptoEditorPluginAttribute)
                        {
                            ICryptoEditor node = (ICryptoEditor)Activator.CreateInstance(type, null);
                            if( ((CryptoEditorPluginAttribute) attribute).Text != null )
                                node.Text = ((CryptoEditorPluginAttribute) attribute).Text;
                            plugins.Add(node);
                        }
                    }
                }
            }
        }

        private static string lowChars = "abcdefghijklmnopqrstuvwxyz";
        private static string upChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static string numChars = "1234567890";
        private static string weakChars = " .,";

        public static void CheckApplicationDataFolder()
        {
            if(System.IO.Directory.Exists(System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\CryptoEditor"))
                return;

            DirectoryInfo ret = System.IO.Directory.CreateDirectory(
                System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\CryptoEditor");

            ret = ret;
        }

        public static int ValidatePassword(string password)
        {
            bool uppercase = false;
            bool special = false;
            bool number = false;
            bool weak = false;

            int validity = password.Length * 5;

            foreach (char c in password)
            {
                string character = new string(c, 1);

                if (lowChars.Contains(character))
                {
                    continue;
                }

                if (upChars.Contains(character))
                {
                    if (!uppercase)
                    {
                        validity += 15;
                        uppercase = true;
                    }

                    continue;
                }

                if (numChars.Contains(character))
                {
                    if (!number)
                    {
                        validity += 15;
                        number = true;
                    }

                    continue;
                }

                if (weakChars.Contains(character))
                {
                    if (!weak)
                    {
                        validity += 15;
                        weak = true;
                    }

                    continue;
                }

                if (!special)
                {
                    validity += 20;
                    special = true;
                }
            }

            return (validity > 100) ? 100 : validity;
        }
    }
}
