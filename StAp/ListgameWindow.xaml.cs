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
        public string[,] array { get; set; }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {            
            Information information = Information.GetInstace();
            var consumerkey = information.stkey;
            var userid = information.stid ;
            var api = new SteamApi(consumerkey, userid);
            DetailsInformation detailsInformation = DetailsInformation.GetInstace();
            var steamapi = api.GetGameUserInformation();

            array = new string[steamapi.response.game_count,2];

            for (int i = 0; i < steamapi.response.game_count; i++)
            {
                array[i, 0] = steamapi.response.games[i].appid.ToString();
                array[i, 1] = steamapi.response.games[i].name;

                var hashUrl = api.HashUrl(steamapi.response.games[i].img_icon_url
                , steamapi.response.games[i].appid.ToString());
                BitmapImage imageSource = new BitmapImage(new Uri(hashUrl));

                listView.Items.Add(new ManagedItem { Picture = imageSource, Name = steamapi.response.games[i].name.ToString()
                    ,PlayTime=steamapi.response.games[i].playtime_forever/60+"時間"});
            }
        }
        public class ManagedItem
        {
            public BitmapImage Picture { get; set; }
            public string Name { get; set; }
            public string PlayTime { get; set; }

        }

        private void listView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            tbGameinfo_Click(sender, e);
        }

        private void tbGameinfo_Click(object sender, RoutedEventArgs e)
        {
            DetailsInformation detailsinformation = DetailsInformation.GetInstace();
            var count = listView.SelectedIndex;



            detailsinformation.UpdateStatus(array[count, 0], array[count, 1]);

            var win = new DetailsAppWindow();
            win.Show();
        }
    }
}
