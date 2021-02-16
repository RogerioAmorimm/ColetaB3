using ColetaB3.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ColetaB3
{
    public class Document: IDocument
    {
        public string _path { get; private set; }
        
        private string _host;
        private int _port;
        private string _to;
        private string _from;
        private bool _isValid = false;
        public Document(string path )
        {
            this._path = path;
            this._isValid = this.BuildFile();
        }

        private bool BuildFile()
        {
            if (!File.Exists(this._path)) return false;

            try
            {
                using (StreamReader sr = new StreamReader(this._path)) 
                {
                    string row;
                    while((row = sr.ReadLine())!= null) 
                    {
                        var array = row.Split(";");
                        this._to = array[0];
                        this._host = array[1];
                        this._port = Convert.ToInt32(array[2]);
                    }
                }
                return true;
            }
            catch (Exception e )
            {
                Console.WriteLine(string.Format("Method: {0}, Message: {1}",
                    System.Reflection.MethodBase.GetCurrentMethod().Name, e.Message));
                return false;
            }
        }

        public string GetHost()
        {
            return this._host;
        }

        public int GetPort()
        {
            return this._port;
        }

        public string GetTo()
        {
            return this._to;
        }

        public string GetFrom()
        {
            return this._from;
        }

        public bool IsValid() => this._isValid;
        
    }
}
