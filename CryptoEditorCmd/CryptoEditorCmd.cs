using System;
using System.Collections;
using CryptoEditor.Common;

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
            Clear();

            while(!exit)
            {
                processCommand(getCommand());
            }
        }

        private void Clear()
        {
            Console.Clear();
            Console.WriteLine("CryptoEditor console application. Copyright 2Sortes Inc. (2008)");
        }

        public string getCommand()
        {
            Console.Write(">>>");
            return Console.ReadLine();
        }

        private void processCommand(string command)
        {
            string cmd = command.ToLower();

            if (cmd.StartsWith("exit") || cmd.StartsWith("quit"))
            {
                exit = true;
                Console.WriteLine("Bye!");
                System.Threading.Thread.Sleep(1000);

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

            if (cmd.StartsWith("open"))
            {
                open(cmd.Substring(6));
            }

            if (cmd.StartsWith("cd"))
            {
                cd(command);
            }

            if (cmd.StartsWith("pwd"))
            {
                pwd();
            }

            if (cmd.StartsWith("cls"))
            {
                Clear();
            }
        }

        private void displayHelp(string cmd)
        {
            Console.WriteLine("CryptoEditor Commands:");
            Console.WriteLine("login ...");
            Console.WriteLine("ls");
            Console.WriteLine("cd <folder>");
            Console.WriteLine("pwd");
            Console.WriteLine("exit");
            Console.WriteLine("quit");
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

                var persistor = new CryptoEditorPersist(plugins, currentProfile);
                persistor.LoadData();

                Console.WriteLine("Login succeeded.");
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
            string[] files = System.IO.Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\CryptoEditor\", "*.profile");

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

        private void open(string itemName)
        {
            if (!CheckLogin())
                return;

            fs.open(itemName);
        }

        private bool CheckLogin()
        {
            if(currentProfile == null || !currentProfile.PasswordValidated)
            {
                Console.WriteLine("You must login first.");
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
