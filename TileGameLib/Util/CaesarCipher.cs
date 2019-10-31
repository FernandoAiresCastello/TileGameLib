using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.Exceptions;

namespace TileGameLib.Util
{
    public static class CaesarCipher
    {
        private const int Keys = 26;

        public static string Encipher(string input, int key)
        {
            if (key < 0 || key > Keys)
                throw new TileGameLibException("Cipher key must be between 0 and " + Keys);

            StringBuilder output = new StringBuilder();

            foreach (char ch in input)
                output.Append(Cipher(ch, key));

            return output.ToString();
        }

        public static string Decipher(string input, int key)
        {
            if (key < 0 || key > Keys)
                throw new TileGameLibException("Cipher key must be between 0 and " + Keys);

            return Encipher(input, Keys - key);
        }

        private static char Cipher(char ch, int key)
        {
            if (key < 0 || key > Keys)
                throw new TileGameLibException("Cipher key must be between 0 and " + Keys);

            if (!char.IsLetter(ch))
                return ch;

            char offset = char.IsUpper(ch) ? 'A' : 'a';
            return (char)(((ch + key - offset) % Keys) + offset);
        }
    }
}
