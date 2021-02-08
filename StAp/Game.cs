using Newtonsoft.Json;
using Sotusei;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace StAp
{

        public class Response
        {
            public List<Player> players { get; set; }
            public int game_count { get; set; }
            public List<Game> games { get; set; }
        }

        public class Root
        {
            public _310950 _310950 { get; set; }
            public Response response { get; set; }
            public Applist applist { get; set; }
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

        


        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class PcRequirements
        {
            public string minimum { get; set; }
            public string recommended { get; set; }
        }

        public class PriceOverview
        {
            public string currency { get; set; }
            public int initial { get; set; }
            public int final { get; set; }
            public int discount_percent { get; set; }
            public string initial_formatted { get; set; }
            public string final_formatted { get; set; }
        }

        public class Sub
        {
            public int packageid { get; set; }
            public string percent_savings_text { get; set; }
            public int percent_savings { get; set; }
            public string option_text { get; set; }
            public string option_description { get; set; }
            public string can_get_free_license { get; set; }
            public bool is_free_license { get; set; }
            public int price_in_cents_with_discount { get; set; }
        }

        public class PackageGroup
        {
            public string name { get; set; }
            public string title { get; set; }
            public string description { get; set; }
            public string selection_text { get; set; }
            public string save_text { get; set; }
            public int display_type { get; set; }
            public string is_recurring_subscription { get; set; }
            public List<Sub> subs { get; set; }
        }

        public class Platforms
        {
            public bool windows { get; set; }
            public bool mac { get; set; }
            public bool linux { get; set; }
        }

        public class Metacritic
        {
            public int score { get; set; }
            public string url { get; set; }
        }

        public class Category
        {
            public int id { get; set; }
            public string description { get; set; }
        }

        public class Genre
        {
            public string id { get; set; }
            public string description { get; set; }
        }

        public class Screenshot
        {
            public int id { get; set; }
            public string path_thumbnail { get; set; }
            public string path_full { get; set; }
        }

        public class Webm
        {
            public string _480 { get; set; }
            public string max { get; set; }
        }

        public class Mp4
        {
            public string _480 { get; set; }
            public string max { get; set; }
        }

        public class Movy
        {
            public int id { get; set; }
            public string name { get; set; }
            public string thumbnail { get; set; }
            public Webm webm { get; set; }
            public Mp4 mp4 { get; set; }
            public bool highlight { get; set; }
        }

        public class Recommendations
        {
            public int total { get; set; }
        }

        public class Highlighted
        {
            public string name { get; set; }
            public string path { get; set; }
        }

        public class Achievements
        {
            public int total { get; set; }
            public List<Highlighted> highlighted { get; set; }
        }

        public class ReleaseDate
        {
            public bool coming_soon { get; set; }
            public string date { get; set; }
        }

        public class SupportInfo
        {
            public string url { get; set; }
            public string email { get; set; }
        }

        public class ContentDescriptors
        {
            public List<object> ids { get; set; }
            public object notes { get; set; }
        }

        public class Data
        {
            public string type { get; set; }
            public string name { get; set; }
            public int steam_appid { get; set; }
            public int required_age { get; set; }
            public bool is_free { get; set; }
            public string controller_support { get; set; }
            public List<int> dlc { get; set; }
            public string detailed_description { get; set; }
            public string about_the_game { get; set; }
            public string short_description { get; set; }
            public string supported_languages { get; set; }
            public string reviews { get; set; }
            public string header_image { get; set; }
            public string website { get; set; }
            public PcRequirements pc_requirements { get; set; }
            public List<object> mac_requirements { get; set; }
            public List<object> linux_requirements { get; set; }
            public string legal_notice { get; set; }
            public string drm_notice { get; set; }
            public List<string> developers { get; set; }
            public List<string> publishers { get; set; }
            public PriceOverview price_overview { get; set; }
            public List<int> packages { get; set; }
            public List<PackageGroup> package_groups { get; set; }
            public Platforms platforms { get; set; }
            public Metacritic metacritic { get; set; }
            public List<Category> categories { get; set; }
            public List<Genre> genres { get; set; }
            public List<Screenshot> screenshots { get; set; }
            public List<Movy> movies { get; set; }
            public Recommendations recommendations { get; set; }
            public Achievements achievements { get; set; }
            public ReleaseDate release_date { get; set; }
            public SupportInfo support_info { get; set; }
            public string background { get; set; }
            public ContentDescriptors content_descriptors { get; set; }
        }

        public class _310950
        {
            public bool success { get; set; }
            public Data data { get; set; }
        }
}

