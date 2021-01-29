using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1 {
    class steam {
        public string ConsumerKey { get; private set; }
        public string UserId { get; private set; }
        public string EndPointUrl { get; private set; }
        public string Json { get; private set; }

        public steam(string consumerKey, string userId) {
            ConsumerKey = consumerKey;
            EndPointUrl = "https://api.steampowered.com";
            UserId = userId;
        }
        public IEnumerable<Player> GetUserInformation() {
            var parm = new Dictionary<string, string>();
            parm["Key"] = ConsumerKey;
            parm["steamids"] = UserId;

            var url = string.Format("{0}/{1}?{2}", EndPointUrl,
               "ISteamUser/GetPlayerSummaries/v2/",
               string.Join("&", parm.Select(p => string.Format("{0}={1}", p.Key, p.Value))));

            var client = new WebClient() {
                Encoding = Encoding.UTF8
            };
            Json = client.DownloadString(url);
            
            var result = JsonConvert.DeserializeObject <Player>(Json);
            return new List<Player>() { result };
        }
    }
}
