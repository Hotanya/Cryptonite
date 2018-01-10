using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Cryptonite.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Cryptonite
{
    public class DataService
    {
        HttpClient client = new HttpClient();
        public DataService()
        {

        }
        public async Task<Coin> GetCoinsAsync()
        {
            var response = await client.GetAsync("https://min-api.cryptocompare.com/data/price?fsym=XRP&tsyms=NZD");
            
                var content = await response.Content.ReadAsStringAsync();
                var Coins = Coin.FromJson(content);//JsonConvert.DeserializeObject<List<Coin>>(content);
                return Coins; 
        }

    }
}
