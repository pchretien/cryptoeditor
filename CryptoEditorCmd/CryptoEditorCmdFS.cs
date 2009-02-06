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

        public CryptoEditorCmdFS()
        {
            throw new NotImplementedException();
        }

        public CryptoEditorCmdFS(ArrayList plugins)
        {
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

            char[] slashSeparators = {'/'};
            string[] folders = currentPath.Split(slashSeparators);

            foreach(string folder in folders)
                Console.Write("[" + folder + "]->");
            Console.WriteLine("");
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
