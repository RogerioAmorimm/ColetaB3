using ColetaB3.Interfaces;
using ColetaB3Test.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ColetaB3Test
{
    [TestClass]
    public class DocumentTest
    {
        private const string _teste = "teste";
        IDocument _documenteWithInvalidPath = new MockDocument();
        IDocument _documenteWithValidPath = new MockDocument();
        IDocument _documenteWithInvalidConfig = new MockDocument();
        IDocument _documenteWithValidConfig = new MockDocument();
        public DocumentTest()
        {
            this._documenteWithInvalidPath = new MockDocument();

            this._documenteWithValidPath = new MockDocument(_teste, _teste, _teste, 25);
           
            this._documenteWithInvalidConfig = new MockDocument(_teste, _teste, _teste, -1);

            this._documenteWithValidConfig = new MockDocument(_teste, _teste, _teste, 25);

        }
        [TestMethod]
        public void Valid_path_document()
        {
            Assert.AreEqual(this._documenteWithValidPath.IsValid(), true);
        }

        [TestMethod]
        public void Invalid_path_document()
        {
            Assert.AreEqual(this._documenteWithInvalidPath.IsValid(), false);
        }

        [TestMethod]
        public void Correct_configuration_document()
        {
            Assert.AreEqual(this._documenteWithValidConfig.IsValid(), true);
        }

        [TestMethod]
        public void Incorrect_configuration_document()
        {
            Assert.AreEqual(this._documenteWithInvalidConfig.IsValid(), false);
        }
    }
}
