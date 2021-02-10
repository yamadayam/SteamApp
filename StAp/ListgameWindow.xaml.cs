using Sotusei;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace StAp
{
    /// <summary>
    /// ListgameWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class ListgameWindow : Window
    {
        public ListgameWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Information information = Information.GetInstace();
            var consumerkey = information.stkey;
            var userid = information.stid ;
            var api = new SteamApi(consumerkey, userid);

            var steamapi = api.GetGameUserInformation();
            for (int i = 0; i < steamapi.response.game_count; i++)
            {
                var hashUrl = api.HashUrl(steamapi.response.games[i].img_icon_url
                , steamapi.response.games[i].appid.ToString());
                BitmapImage imageSource = new BitmapImage(new Uri(hashUrl));

                listView.Items.Add(new ManagedItem { Picture = imageSource, Name = steamapi.response.games[i].name.ToString() });
            }
        }
        public class ManagedItem
        {
            public BitmapImage Picture { get; set; }
            public string Name { get; set; }
            public string Other { get; set; }

        }

        private void listView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Information information = Information.GetInstace();
            var consumerkey = information.stkey;
            var userid = information.stid;
            var api = new SteamApi(consumerkey, userid);
            var steamapi = api.GetGameUserInformation();
            
            DetailsInformation detailsinformation = DetailsInformation.GetInstace();
            var count = listView.SelectedItems.Count;

            var ste = steamapi.response.games[count];
            detailsinformation.UpdateStatus(ste.appid,ste.name
                , ste.img_icon_url, ste.img_logo_url, ste.playtime_forever.ToString(), ste.playtime_2weeks.ToString());

            var win = new DetailsAppWindow();
            win.Show();
        }
    }
}
