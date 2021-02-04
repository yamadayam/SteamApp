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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sotusei {
    /// <summary>
    /// AcPage.xaml の相互作用ロジック
    /// </summary>
    public partial class AcPage : Page {
        public AcPage() {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e) {
            var consumerkey = "84578F8035947FB06BFC5FB9E4902701";
            var userid = "76561199051966013";
            var api = new SteamApi(consumerkey, userid);

            var steamapi = api.GetUserInformation();

            tbSteamid.Text = steamapi.response.players[0].steamid;
            tbName.Text = steamapi.response.players[0].personaname;
            Image image = new Image();
            BitmapImage imageSource = new BitmapImage(new Uri(steamapi.response.players[0].avatarfull));
            tbAvatar.Source = imageSource;
        }

        private void btGame_Click(object sender, RoutedEventArgs e)
        {
            var win = new ListgameWindow();
            win.Show();
        }
    }
}
