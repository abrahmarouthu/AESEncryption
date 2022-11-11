using AESEncryption;
using NUnit.Framework.Internal;
using System.Security.Cryptography;

namespace UnitTests
{
    public class AESTest
    {
        AES sut;

        [SetUp]
        public void Setup()
        {
            sut = new AES();
        }

        [Test]
        public void EncryptStringToBytes_Aes_Test()
        {
            //Arrange
            var plainText = "Here is some data to encrypt!";
            Aes myAes = Aes.Create();
            var key = myAes.Key;
            var iv = myAes.IV;

            //Act
            var encrypted = sut.EncryptStringToBytes_Aes(plainText, key, iv);

            //Assert
            Assert.AreNotEqual(plainText, System.Text.Encoding.UTF8.GetString(encrypted, 0, encrypted.Length));
        }

        [Test]
        public void EncryptStringToBytes_Aes_Should_Throw_Exception_For_plainText()
        {
            //Arrange
            string plainText = null;
            Aes myAes = Aes.Create();
            var key = myAes.Key;
            var iv = myAes.IV;

            //Act
            //Assert
            try
            {
                var encrypted = sut.EncryptStringToBytes_Aes(plainText, key, iv);
            }
            catch(ArgumentNullException ex)
            {
                Assert.IsTrue(ex.Message.Contains("plainText"));
            }
        }

        [Test]
        public void EncryptStringToBytes_Aes_Should_Throw_Exception_For_Key()
        {
            //Arrange
            string plainText = "Here is some data to encrypt!";
            Aes myAes = Aes.Create();
            byte[] key = null;
            var iv = myAes.IV;

            //Act
            //Assert
            try
            {
                var encrypted = sut.EncryptStringToBytes_Aes(plainText, key, iv);
            }
            catch (ArgumentNullException ex)
            {
                Assert.IsTrue(ex.Message.Contains("Key"));
            }
        }
    }
}