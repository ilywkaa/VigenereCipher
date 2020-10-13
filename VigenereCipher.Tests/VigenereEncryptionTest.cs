using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace VigenereCipher.Tests
{
    public class Tests
    {
        private char[] Alphabet = new char[26]
        {
            'A', 'B', 'C', 'D', 'E', 'F', 'G',
            'H', 'I', 'J', 'K', 'L', 'M', 'N',
            'O', 'P', 'Q', 'R', 'S', 'T', 'U',
            'V', 'W', 'X', 'Y', 'Z'
        };

        private VigenereEncryption _encryptor;
        [SetUp]
        public void Setup()
        {
            _encryptor = new VigenereEncryption(Alphabet);
        }

        [Test]
        public void EncryptDefaultTest()
        {
            string res = _encryptor.EncryptSingle("ATTACKATDAWN", "LEMON");
            Assert.AreEqual("LXFOPVEFRNHR", res);
        }

        [Test]
        public void EncryptLongStringSourceTest()
        {
            string res = _encryptor.EncryptSingle("ATTACK AT DAWN ATTACK AT DAWN", "LEMON");
            Assert.AreEqual("LXFOPVEFRNHRMHGLGWOGOEIB", res);
        }

        [Test]
        public void EncryptWithDifferentRegistersTest()
        {
            string res = _encryptor.EncryptSingle("ATTACkATDaWN", "lemon");
            Assert.AreEqual("LXFOPVEFRNHR", res);
        }

        [Test]
        public void EncryptTestSourceLessLengthThanKey()
        {
            string res = _encryptor.EncryptSingle("sun", "lemon");
            Assert.AreEqual("DYZ", res);
        }

        [Test]
        public void EncryptSourceSameLengthKeyTest()
        {
            string res = _encryptor.EncryptSingle("ATTAC", "lemon");
            Assert.AreEqual("LXFOP", res);
        }

        [Test]
        public void DencryptDefaultTest()
        {
            string res = _encryptor.DencryptSingle("LXFOPVEFRNHR", "LEMON");
            Assert.AreEqual("ATTACKATDAWN", res);
        }

        [Test]
        public void DencryptSourceSameLengthKeyTest()
        {
            string res = _encryptor.DencryptSingle("LXFO", "LEMON");
            Assert.AreEqual("ATTA", res);
        }

        [Test]
        public void EncryptMultipleStringsTest()
        {
            List<string> textToEncrypt = new List<string>()
            {
                "ATTACKATDAWN",
                "ATTACKATDAWN",
                "ATTACKATDAWN"
            };
            string key = "LEMON";
            List<string> expected = new List<string>()
            {
                "LXFOPVEFRNHR",
                "LXFOPVEFRNHR",
                "LXFOPVEFRNHR"
            };
            IEnumerable<string> result = _encryptor.Encrypt(textToEncrypt.AsEnumerable(), key);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void DencryptMultipleStringsTest()
        {
            List<string> textToEncrypt = new List<string>()
            {
                "LXFOPVEFRNHR",
                "LXFOPVEFRNHR",
                "LXFOPVEFRNHR"
            };
            string key = "LEMON";
            List<string> expected = new List<string>()
            {
                "ATTACKATDAWN",
                "ATTACKATDAWN",
                "ATTACKATDAWN"
            };
            IEnumerable<string> result = _encryptor.Dencrypt(textToEncrypt.AsEnumerable(), key);
            Assert.AreEqual(expected, result);
        }
    }
}