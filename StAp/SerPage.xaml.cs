﻿using Sotusei;
using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace StAp
{
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

            var count = 0;
            listView.Items.Clear();
            try
            {
                for (int i = 0; i < list.applist.apps.Count(); i++)
                {
                    if (list.applist.apps[i].name.IndexOf(tbTitle.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        var review = api.GetReviewInfo(list.applist.apps[i].appid);
                        //var str = list.applist.apps[i].name;
                        BitmapImage imageSource = new BitmapImage(new Uri("https://steamcdn-a.akamaihd.net/steam/apps/"+ list.applist.apps[i].appid.ToString() + "/header.jpg"));
                        imageSource.DecodePixelWidth = 100;
                        listView.Items.Add(new ImageItem { Picture=imageSource, Name = list.applist.apps[i].name ,
                            Other=review.query_summary.review_score_desc });
                        count += 1;
                        if (count >= 20)
                        {
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("不正な操作",ex.Message);
            }
        }

        public class ImageItem
        {
            public BitmapImage Picture { get; set; }
            public string Name { get; set; }
            public string Other { get; set; }

        }

        private void tbTitle_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.Enter))
            {
                btSer_Click(this, new RoutedEventArgs());
            }
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
            detailsinformation.UpdateStatus(ste.appid, ste.name
                , ste.img_icon_url, ste.img_logo_url, ste.playtime_forever.ToString(), ste.playtime_2weeks.ToString());

            var win = new DetailsAppWindow();
            win.Show();
        }
    }
}
