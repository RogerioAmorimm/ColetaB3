using ColetaB3;
using ColetaB3.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ColetaB3Test.Mocks
{
    public class MockDataCollect : ICollect<Share>
    {
        private Share _fakeShare; 
        public MockDataCollect(Share fakeShare)
        {
            this._fakeShare = fakeShare;
        }
        public async Task<Share> GetCollect()
        {
            return this._fakeShare;
        }

        public bool IsValid()
        {
            return _fakeShare != null;
        }
    }
}
