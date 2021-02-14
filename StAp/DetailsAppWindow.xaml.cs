using StAp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            //this.DataContext = new MainWindowViewModel();
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DetailsInformation detailsInformation = DetailsInformation.GetInstace();

            BitmapImage imageSource = new BitmapImage(new Uri("https://steamcdn-a.akamaihd.net/steam/apps/" 
                + detailsInformation.appid.ToString() + "/header.jpg"));

            imgHeder.Source = imageSource;

            tbTitle.Text = detailsInformation.name;

            Information information = Information.GetInstace();

            var consumerkey = information.stkey;
            var userid = information.stid;
            var api = new SteamApi(consumerkey, userid);
            var review = api.GetReviewInfo(detailsInformation.appid);
            tbTotalReview.Text = review.query_summary.review_score_desc;
            tbPositive.Text = review.query_summary.total_positive.ToString();
            tbNegative.Text = review.query_summary.total_negative.ToString();
            tbTotal.Text = review.query_summary.num_reviews.ToString();
            string voted ;
            for (int i = 0; i < review.query_summary.num_reviews; i++)
            {
                if (review.reviews[i].voted_up==true)
                {
                    voted = "おすすめ";
                }
                else
                {
                    voted = "おすすめしない";
                }
                listView.Items.Add(new ReviewList
                {
                    Id = review.reviews[i].author.steamid,
                    PlayTime = review.reviews[i].author.playtime_forever/60+"時間",                    
                    ReviewTime = voted,
                });
            }
            
        }      

    public class ReviewList
        {
            public string Id { get; set; }
            public string PlayTime { get; set; }
            public string ReviewTime { get; set; }
        }
    }
}
