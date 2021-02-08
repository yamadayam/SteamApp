using Newtonsoft.Json;
using Sotusei;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StAp {
    /// <summary>
    /// SerPage.xaml の相互作用ロジック
    /// </summary>
    public partial class SerPage : Page {
        public ObservableCollection<string> JapaneseCalendar { get; private set; } = new ObservableCollection<string>();
        public SerPage() {
            InitializeComponent();
            
        }

        private void btSer_Click(object sender, RoutedEventArgs e)
        {
            var consumerkey = "84578F8035947FB06BFC5FB9E4902701";
            var userid = "76561199051966013";
            var api = new SteamApi(consumerkey, userid);

            var list = api.GetGameList();
            
            
            for (int i = 0; i < list.applist.apps.Count(); i++)
            {
                var str = list.applist.apps[i].name;

                if (str.IndexOf(tbTitle.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    var app = api.GetGameInfo(list.applist.apps[i].appid.ToString());
                    BitmapImage imageSource = new BitmapImage(new Uri(app._310950.data.header_image)); 
                    listView.Items.Add(new ImageItem { Picture = imageSource, Name = list.applist.apps[i].appid.ToString() });
                }
            }
            //var name = steamapi.applist.apps[0].name;
            ////BitmapImage imageSource = new BitmapImage(new Uri(hashUrl));

            //listView.Items.Add(new ImageItem { /*Picture = imageSource,*/ Name = name });

        }

        public class ImageItem
        {
            public BitmapImage Picture { get; set; }
            public string Name { get; set; }
            public string Other { get; set; }

        }



    }
}
