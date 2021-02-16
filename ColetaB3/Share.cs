using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ColetaB3
{

    public class Share 
    {

        public string by { get; set; }

        [JsonProperty(PropertyName = "valid_key")]
        public bool valid { get; set; }

        [JsonProperty(PropertyName = "results")]
        public Dictionary<string, Result> results { get; set; }

    }

    public class Result 
    {
        [JsonProperty(PropertyName = "name")]
        public string name { get; set; }

        [JsonProperty(PropertyName = "price")]
        public double price { get; set; }

        [JsonProperty(PropertyName = "updated_at")]
        public DateTime updated_at { get; set; }

    }
  
}
