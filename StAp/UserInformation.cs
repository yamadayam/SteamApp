using StAp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sotusei
{
    public class Information
    {
        private static Information instance;
        //インスタンスの取得
        public static Information GetInstace()
        {
            if (instance == null)
            {
                instance = new Information();
            }
            return instance;
        }
        public string stkey { get; set; }
        public string stid { get; set; }
        private Information()
        {

        }
        public bool UpdateStatus(string stKey, string stId)
        {
            stkey = stKey;
            stid = stId;
            return true;
        }
    }

    public class DetailsInformation
    {
        private static DetailsInformation instance;
        //インスタンスの取得
        public static DetailsInformation GetInstace()
        {
            if (instance == null)
            {
                instance = new DetailsInformation();
            }
            return instance;
        }
        public int appid { get; set; }
        public string name { get; set; }
        public string img_icon_url { get; set; }
        public string img_logo_url { get; set; }
        public string playtime { get; set; }
        public string playtime2week { get; set; }

        private DetailsInformation()
        {

        }        
        public bool UpdateStatus(int Appid,string Name,string imgIconUrl,string imgLogoUrl,string Playtime,string Playtime2Week)
        {
            appid = Appid;
            name = Name;
            img_icon_url = imgIconUrl;
            img_logo_url = imgLogoUrl;
            playtime = Playtime;
            playtime2week = Playtime2Week;
            return true;
        }
    }
}
