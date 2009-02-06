using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoEditor
{
    public class CryptoEditorUtils
    {
        private static string lowChars = "abcdefghijklmnopqrstuvwxyz";
        private static string upChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static string numChars = "1234567890";
        private static string weakChars = " .,";

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
