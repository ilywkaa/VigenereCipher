using System;

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
            string source = Console.ReadLine();

            Console.WriteLine("Enter key of encryption.");
            string key = Console.ReadLine();

            var encryptor = new VigenereEncryption(Alphabet);
            Console.WriteLine($"Encrypted string is : {encryptor.Encrypt(source, key)}");
        }
    }
}