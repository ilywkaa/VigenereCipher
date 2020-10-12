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
        public void EncryptTestDefault()
        {
            string res = _encryptor.Encrypt("ATTACKATDAWN", "LEMON");
            Assert.AreEqual("LXFOPVEFRNHR", res);
        }

        [Test]
        public void EncryptTestLongStringSource()
        {
            string res = _encryptor.Encrypt("ATTACK AT DAWN ATTACK AT DAWN", "LEMON");
            Assert.AreEqual("LXFOPVEFRNHRMHGLGWOGOEIB", res);
        }

        [Test]
        public void EncryptTestWithDifferentRegisters()
        {
            string res = _encryptor.Encrypt("ATTACkATDaWN", "lemon");
            Assert.AreEqual("LXFOPVEFRNHR", res);
        }

        [Test]
        public void EncryptTestSourceLessLengthThanKey()
        {
            string res = _encryptor.Encrypt("sun", "lemon");
            Assert.AreEqual("DYZ", res);
        }

        [Test]
        public void EncryptTestSourceSameLengthKey()
        {
            string res = _encryptor.Encrypt("ATTAC", "lemon");
            Assert.AreEqual("LXFOP", res);
        }

        [Test]
        public void DencryptTestDefault()
        {
            string res = _encryptor.Dencrypt("LXFOPVEFRNHR", "LEMON");
            Assert.AreEqual("ATTACKATDAWN", res);
        }

        [Test]
        public void DencryptTestSourceSameLengthKey()
        {
            string res = _encryptor.Dencrypt("LXFO", "LEMON");
            Assert.AreEqual("ATTA", res);
        }
    }
}