using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Media.Imaging;

namespace StAp {
    class SteamApi {
        public string ConsumerKey { get; private set; }
        public string UserId { get; private set; }
        public string EndPointUrl { get; private set; }
        public string Json { get; private set; }

        public SteamApi(string consumerKey,string userId) {
            ConsumerKey = consumerKey;
            UserId = userId;
        }

        public Root GetUserInformation(){
            EndPointUrl = "https://api.steampowered.com/" +
                "ISteamUser/GetPlayerSummaries/v2/";
            var parm = new Dictionary<string, string>();
            parm["Key"] = ConsumerKey;
            parm["steamids"] = UserId;            

            var url = string.Format("{0}?{1}", EndPointUrl, 
               string.Join("&", parm.Select(p => string.
               Format("{0}={1}", p.Key, p.Value))));

            var client = new WebClient() {
                Encoding = Encoding.UTF8
            };
            Json = client.DownloadString(url);

            return JsonConvert.DeserializeObject<Root>(Json);
        }

        public Root GetGameUserInformation()
        {
            EndPointUrl = "https://api.steampowered.com/IPlayerService/GetOwnedGames/v0001/?";
            //var parm = new Dictionary<string, string>();
            //parm["Key"] = ConsumerKey;
            //parm["steamids"] = UserId;

            var url = string.Format("{0}key={1}&steamid={2}&include_appinfo=1", EndPointUrl, ConsumerKey, UserId);

            var client = new WebClient()
            {
                Encoding = Encoding.UTF8
            };
            Json = client.DownloadString(url);

            return JsonConvert.DeserializeObject<Root>(Json);
        }

        public string HashUrl(string Hash,string Id)
        {
            var Url = string.Format("{0}/{1}/{2}.jpg", 
                "http://media.steampowered.com/steamcommunity/public/images/apps"
                , Id, Hash);

            return Url;
        }

        public Root GetGameList()
        {
            var json = File.ReadAllText("Text/gamelist.json", Encoding.GetEncoding("UTF-8"));

            return JsonConvert.DeserializeObject<Root>(json);
        }


    }
    
}
