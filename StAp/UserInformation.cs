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
        public string appid { get; set; }
        public string name { get; set; }

        private DetailsInformation()
        {

        }
        public bool UpdateStatus(string Appid,string Name)
        {
            appid = Appid;
            name = Name;
            return true;
        }
    }
    
}
