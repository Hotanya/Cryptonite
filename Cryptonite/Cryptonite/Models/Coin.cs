using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cryptonite.Models
{
    public partial class Coin
    {
        [JsonProperty("NZD")]
        public double Usd { get; set; }

        [JsonProperty("BTC")]
        public double Btc { get; set; }

    }

    public partial class Coin
    {
        public static Coin FromJson(string json) => JsonConvert.DeserializeObject<Coin>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Coin self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    public class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
        };
    }
}
