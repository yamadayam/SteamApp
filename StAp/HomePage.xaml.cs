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

namespace StAp {
    /// <summary>
    /// HomePage.xaml の相互作用ロジック
    /// </summary>
    public partial class HomePage : Page {
        public HomePage() {
            InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://store.steampowered.com/");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void listView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        
    }
}
