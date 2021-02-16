using ColetaB3.Interfaces;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ColetaB3
{
    public class DataCollect : ICollect<Share>
    {
        private readonly string _query;
        private HttpClient _client;
        private bool _isValid = false;
        public DataCollect(string query) 
        {
            this._query= query;
            this._client = new HttpClient();
        }
        public bool IsValid() => this._isValid;

        public async Task<Share> GetCollect()
        {
            try
            {
                string url = string.Format("https://api.hgbrasil.com/finance/stock_price?key=b5437c30&symbol={0}", this._query);
                var response = await this._client.GetStringAsync(url);
                
                var share = JsonConvert.DeserializeObject<Share>(response);
                this._isValid = true;
                return share;
            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("Method: {0}, Message: {1}",
                   System.Reflection.MethodBase.GetCurrentMethod().Name, e.Message));

                this._isValid= false; 
                return new Share();
                
            }
        }
    }
}
