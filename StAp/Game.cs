using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Sotusei {
    public class Information
    {
        public string stkey { get; set; }
        public string stid { get; set; }
    }
    

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Player
    {
        public string steamid { get; set; }
        public int communityvisibilitystate { get; set; }
        public int profilestate { get; set; }
        public string personaname { get; set; }
        public string profileurl { get; set; }
        public string avatar { get; set; }
        public string avatarmedium { get; set; }
        public string avatarfull { get; set; }
        public string avatarhash { get; set; }
        public int lastlogoff { get; set; }
        public int personastate { get; set; }
        public string primaryclanid { get; set; }
        public int timecreated { get; set; }
        public int personastateflags { get; set; }
    }
    public class Game
    {
        public int appid { get; set; }
        public string name { get; set; }
        public int playtime_forever { get; set; }
        public string img_icon_url { get; set; }
        public string img_logo_url { get; set; }
        public int playtime_windows_forever { get; set; }
        public int playtime_mac_forever { get; set; }
        public int playtime_linux_forever { get; set; }
        public int? playtime_2weeks { get; set; }
        public bool? has_community_visible_stats { get; set; }
    }
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class App
    {
        public int appid { get; set; }
        public string name { get; set; }
    }

    public class Applist
    {
        public List<App> apps { get; set; }
    }

    public class Response
    {
        public List<Player> players { get; set; }
        public int game_count { get; set; }
        public List<Game> games { get; set; }
    }

    public class Root
    {
        public Response response { get; set; }
        public Applist applist { get; set; }
    }



}
