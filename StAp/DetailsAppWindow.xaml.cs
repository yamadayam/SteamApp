using StAp;
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

namespace Sotusei
{
    /// <summary>
    /// DetailsAppWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class DetailsAppWindow : Window
    {
        public DetailsAppWindow()
        {
            InitializeComponent();
           
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DetailsInformation detailsInformation = DetailsInformation.GetInstace();

            BitmapImage imageSource = new BitmapImage(new Uri("https://steamcdn-a.akamaihd.net/steam/apps/" + detailsInformation.appid.ToString() + "/header.jpg"));

            imgHeder.Source = imageSource;

            tbTitle.Text = detailsInformation.name;

            Information information = Information.GetInstace();

            var consumerkey = information.stkey;
            var userid = information.stid;
            var api = new SteamApi(consumerkey, userid);

            tbTotalReview.Text = api.GetReviewInfo(detailsInformation.appid).query_summary.review_score_desc;
            tbPositive.Text = api.GetReviewInfo(detailsInformation.appid).query_summary.total_positive.ToString();
            tbNegative.Text = api.GetReviewInfo(detailsInformation.appid).query_summary.total_negative.ToString();


        }

        private void cbLangage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
