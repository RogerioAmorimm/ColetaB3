using ColetaB3.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ColetaB3Test.Mocks
{
    class MockDocument : IDocument
    {
        private string _from;
        private string _to;
        private string _host;
        private int _port;
        private bool _isValid;

        public MockDocument()
        {
            this._isValid = false;
        }
        public MockDocument(string from, string to, string host, int port)
        {
            _from = from;
            _to = to;
            _host = host;
            _port = port;
            this._isValid = true;
            if (string.IsNullOrEmpty(from) || string.IsNullOrEmpty(to) || string.IsNullOrEmpty(host) || port <= uint.MinValue) this._isValid = false;
        }

        public string GetFrom() => string.IsNullOrEmpty(this._from) ? string.Empty : this._from;
        
        public string GetHost() => string.IsNullOrEmpty(this._host) ? string.Empty : this._host;
       
        public int GetPort() => this._port <= uint.MinValue ? 0 : this._port;
       
        public string GetTo() => string.IsNullOrEmpty(this._to) ? string.Empty : this._to;

        public bool IsValid() => this._isValid;
        
    }
}
