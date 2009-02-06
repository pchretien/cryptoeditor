using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using CryptoEditor.Common;
using CryptoEditor.Common.Interfaces;

namespace CryptoEditorCmd
{
    public class CryptoEditorCmd
    {
        public bool exit = false;
        private ArrayList plugins = new ArrayList();
        private CryptoEditorProfile currentProfile = null;
        private CryptoEditorCmdFS fs = null;

        public CryptoEditorCmd()
        {
            CryptoEditor.Common.CryptoEditorUtils.LoadPlugins(plugins);
            fs = new CryptoEditorCmdFS(plugins);
        }

        public void Run()
        {
            Console.WriteLine("CryptoEditor console application. Copyright 2Sortes Inc. (2008)\n");
            login();
            
            while(!exit)
            {
                processCommand(getCommand());
            }
        }

        public string getCommand()
        {
            Console.Write(">>>");
            return Console.ReadLine();
        }

        private void processCommand(string command)
        {
            string cmd = command.ToLower();

            if(cmd.StartsWith("exit"))
            {
                exit = true;
                Console.WriteLine("Bye!");

                return;
            }

            if(cmd.StartsWith("?") || cmd.StartsWith("help"))
            {
                displayHelp(cmd);
                return;
            }

            if(cmd.StartsWith("login"))
            {
                login();
                return;
            }

            if(cmd.StartsWith("ls"))
            {
                ls();
            }

            if (cmd.StartsWith("cd"))
            {
                cd(command);
            }

            if (cmd.StartsWith("pwd"))
            {
                pwd();
            }
        }

        private void displayHelp(string cmd)
        {
            Console.WriteLine("CryptoEditor Help ...");
        }

        private void login()
        {
            CryptoEditorProfile profile = selectProfile();
            if(profile == null )
                return;

            currentProfile = profile;

            Console.Write("password:");
            string password = Console.ReadLine();

            string tmpPassword = CryptoEditorEncryption.Hash(password);
            if (tmpPassword.Equals(currentProfile.EncryptedPassword))
            {
                currentProfile.PasswordValidated = true;
                currentProfile.Password = password;

                return;
            }

            Console.WriteLine("Invalid username or password!");
            currentProfile = null;
        }

        private CryptoEditorProfile selectProfile()
        {
            CryptoEditorProfile retProfile = null;

            int index = 0;
            Hashtable profiles = new Hashtable();
            string[] files = System.IO.Directory.GetFiles(".", "*.profile");

            foreach (string file in files)
            {
                CryptoEditorProfile profile = new CryptoEditorProfile();
                profile.Load(file);
                
                Console.WriteLine(index+" - "+profile.Name);
                profiles.Add(index.ToString(), profile);
            }

            Console.Write("Select a profile number: ");

            string selectedProfile = Console.ReadLine();
            retProfile = (CryptoEditorProfile)profiles[selectedProfile];

            if (retProfile == null)
            {
                Console.WriteLine("Invalid profile number.");
            }

            return retProfile;
        }

        private void ls()
        {
            if (!CheckLogin())
                return;

            fs.ls();
        }

        private bool CheckLogin()
        {
            if(currentProfile == null || !currentProfile.PasswordValidated)
            {
                Console.WriteLine("You m ust login first.");
                return false;
            }

            return true;
        }

        private void cd(string command)
        {
            if (!CheckLogin())
                return;

            char[] whiteSpaces = {' '};
            string path = command.Substring(2).TrimStart(whiteSpaces);
            fs.cd(path);
        }

        private void pwd()
        {
            if (!CheckLogin())
                return;

            fs.pwd();
        }
    }
}
