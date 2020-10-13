using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

[assembly: InternalsVisibleTo("VigenereCipher.Tests")]
namespace VigenereCipher
{
    internal class VigenereEncryption
    {
        private readonly int Power;
        private readonly Dictionary<char, int> AlphabetCharToInt = new Dictionary<char, int>();
        private readonly Dictionary<int, char> AlphabetIntToChar = new Dictionary<int, char>();
        

        public VigenereEncryption(char[] alphabet)
        {
            Debug.Assert(alphabet.Length > 0);

            Power = alphabet.Length;
            int i = 0;
            foreach (var c in alphabet)
            {
                AlphabetCharToInt[c] = i;
                AlphabetIntToChar[i] = c;
                i++;
            }
        }


        public IEnumerable<string> Encrypt(IEnumerable<string> source, string key)
        {
            List<string> result = new List<string>();
            foreach (var s in source)
            {
                result.Add(EncryptSingle(s, key));
            }

            return result.AsEnumerable();
        }


        public string EncryptSingle(string source, string key)
        {
            Debug.Assert(source != null && key != null);

            source = Regex.Replace(source, @"\s", "").ToUpper();
            key = key.ToUpper();

            int len = key.Length;
            var result = new StringBuilder(source.Length);
            for (int i = 0; i < source.Length; i++)
            {
                result.Append
                (
                   AlphabetIntToChar
                   [
                       (AlphabetCharToInt[source[i]] + AlphabetCharToInt[ key[ i % len ]] ) % Power
                   ]
                );
            }

            return result.ToString();
        }


        public IEnumerable<string> Dencrypt(IEnumerable<string> source, string key)
        {
            List<string> result = new List<string>();
            foreach (var s in source)
            {
                result.Add(DencryptSingle(s, key));
            }

            return result.AsEnumerable();
        }


        public string DencryptSingle(string encrypted, string key)
        {
            Debug.Assert(encrypted != null && key != null);

            encrypted = encrypted.ToUpper();
            key = key.ToUpper();

            int len = key.Length;
            var result = new StringBuilder(encrypted.Length);
            for (int i = 0; i < encrypted.Length; i++)
            {
                result.Append
                (
                    AlphabetIntToChar
                    [
                        (AlphabetCharToInt[encrypted[i]] - AlphabetCharToInt[ key[i % len]] + Power) % Power
                    ]  
                );
            }

            return result.ToString();
        }
    }
}