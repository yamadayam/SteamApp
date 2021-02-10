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
        public Response response { get; set; }
        public Applist applist { get; set; }
        public int success { get; set; }
        public QuerySummary query_summary { get; set; }
        public List<Review> reviews { get; set; }
        public string cursor { get; set; }
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
    public class QuerySummary
    {
        public int num_reviews { get; set; }
        public int review_score { get; set; }
        public string review_score_desc { get; set; }
        public int total_positive { get; set; }
        public int total_negative { get; set; }
        public int total_reviews { get; set; }
    }

    public class Author
    {
        public string steamid { get; set; }
        public int num_games_owned { get; set; }
        public int num_reviews { get; set; }
        public int playtime_forever { get; set; }
        public int playtime_last_two_weeks { get; set; }
        public int playtime_at_review { get; set; }
        public int last_played { get; set; }
    }

    public class Review
    {
        public string recommendationid { get; set; }
        public Author author { get; set; }
        public string language { get; set; }
        public string review { get; set; }
        public int timestamp_created { get; set; }
        public int timestamp_updated { get; set; }
        public bool voted_up { get; set; }
        public int votes_up { get; set; }
        public int votes_funny { get; set; }
        public string weighted_vote_score { get; set; }
        public int comment_count { get; set; }
        public bool steam_purchase { get; set; }
        public bool received_for_free { get; set; }
        public bool written_during_early_access { get; set; }
    }
}

