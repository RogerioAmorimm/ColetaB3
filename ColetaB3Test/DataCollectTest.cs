using ColetaB3;
using ColetaB3.Interfaces;
using ColetaB3Test.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ColetaB3Test
{
    [TestClass]
    public class DataCollectTest
    {
        private const string _key = "Key";


        ICollect<Share> _dataCollectWithMinPrice;
        ICollect<Share> _dataCollectWithValidPrice;
        ICollect<Share> _dataCollectWithInvalidObject;
        ICollect<Share> _dataCollectWithValidObject;
        Share _validShareWithValidPrice;
        Share _validShareWithMinPrice;


        public DataCollectTest()
        {
            this._validShareWithValidPrice = BuildShare(22.2);
            this._validShareWithMinPrice = BuildShare(-1);

            this._dataCollectWithMinPrice = new MockDataCollect(_validShareWithMinPrice);
            this._dataCollectWithValidPrice = new MockDataCollect(_validShareWithValidPrice);
            this._dataCollectWithValidObject = new MockDataCollect(_validShareWithValidPrice);
            this._dataCollectWithInvalidObject = new MockDataCollect(null);
        }

        private Share BuildShare(double price)
        {
            var share = new Share();
            share.valid = true;
            share.by = "teste";
            share.results = new Dictionary<string, Result>();
            share.results.Add(_key, new Result() { price = price, name = "FAKE", updated_at = DateTime.Now});
            return share;
        }

        [TestMethod]
        public async Task DataCollect_with_lower_price_equal_to_zero()
        {
            var assert = await this._dataCollectWithMinPrice.GetCollect();
            Assert.AreEqual(assert.results[_key].price >= 0, false);
        }

        [TestMethod]
        public async Task DataCollect_with_higher_price_zero()
        {
            var assert = await this._dataCollectWithValidPrice.GetCollect();
            Assert.AreEqual(assert.results[_key].price >= 0, true);
        }

        [TestMethod]
        public  void DataCollect_with_invalid_object()
        {
            Assert.AreEqual(this._dataCollectWithInvalidObject.IsValid(), false);
        }

        [TestMethod]
        public void DataCollect_with_valid_object()
        {
            Assert.AreEqual(this._dataCollectWithValidObject.IsValid(), true);
        }
    }
}
