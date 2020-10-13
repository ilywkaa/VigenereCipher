using System;
using System.Collections.Generic;

namespace VigenereCipher
{
    class Program
    {
        private static char[] Alphabet = new char[26]
        {
            'A', 'B', 'C', 'D', 'E', 'F', 'G',
            'H', 'I', 'J', 'K', 'L', 'M', 'N',
            'O', 'P', 'Q', 'R', 'S', 'T', 'U',
            'V', 'W', 'X', 'Y', 'Z'
        };
        static void Main(string[] args)
        {
            Console.WriteLine("Enter string to encrypt.");
            string input = Console.ReadLine();

            while (input == string.Empty)
            {
                Console.WriteLine("Repeat input, please.");
                input = Console.ReadLine();
            }

            var source = input.Split();

            Console.WriteLine("Enter key of encryption.");
            string key = Console.ReadLine();

            while (key == string.Empty)
            {
                Console.WriteLine("Repeat input, please.");
                key = Console.ReadLine();
            }

            var encryptor = new VigenereEncryption(Alphabet);
            IEnumerable<string> encrypted = encryptor.Encrypt(source, key);
            Console.WriteLine("Encrypted strings : ");
            foreach (var s in encrypted)
            {
                Console.WriteLine(s);
            }
        }
    }
}