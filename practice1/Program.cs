using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace practice1 {
    class Program {
        public static void Main() {
            var url =
             "http://api.steampowered.com/ISteamUser/GetPlayerSummaries/v2/?key=84578F8035947FB06BFC5FB9E4902701&steamids=76561199051966013";

            //var client = new WebClient() {
            //    Encoding = Encoding.UTF8
            //};
            var client = new WebClient() {
                Encoding = Encoding.UTF8
            };

            string Json = client.DownloadString(url);

            var result = JsonConvert.DeserializeObject<Root>(Json);

            Console.WriteLine(result.response.players[0].steamid);
        }
    }
}
