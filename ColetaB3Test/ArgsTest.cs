using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using ColetaB3;
namespace ColetaB3Test
{
    [TestClass]
    public class ArgsTest
    {
        private ArgsData _validArgs;
        private ArgsData _invalidArgs;
       
        public ArgsTest()
        {
            this._invalidArgs = new ArgsData(new string[] { "EKTR4", "EKTR4" });
            this._validArgs = new ArgsData(new string[] { "EKTR4", "22,1", "22,1" });
        }
        [TestMethod]
        public void Valid_Arguments()
        {   
            Assert.AreEqual(this._validArgs.IsValid(), true);
        }
        [TestMethod]
        public void Invalid_Arguments()
        {
            Assert.AreEqual(this._invalidArgs.IsValid(), false);
        }
    }
}
