using Microsoft.VisualStudio.TestTools.UnitTesting;
using EnCryptDecrypt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnCryptDecrypt.Tests
{
    [TestClass()]
    public class CryptorEngineTests
    {
        [TestMethod()]
        public void EncryptTest()
        {

            string input = "hello";
            String output = CryptorEngine.Encrypt(input, true);
            Assert.AreEqual(output, "4xnRYvSKNeo=");
        }

        [TestMethod()]
        public void DecryptTest()
        {

            string input = "4xnRYvSKNeo=";
            String output = CryptorEngine.Decrypt(input, true);
            Assert.AreEqual(output, "hello");

        }
    }
}