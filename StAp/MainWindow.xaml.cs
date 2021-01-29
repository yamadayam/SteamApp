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
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();

            _navi = this.myFrame.NavigationService;
        }

        private NavigationService _navi;

        private List<Uri> _uriList = new List<Uri>() {
            new Uri("HomePage.xaml",UriKind.Relative),
            new Uri("SerPage.xaml",UriKind.Relative),
            new Uri("AcPage.xaml",UriKind.Relative),
            new Uri("CfPage.xaml",UriKind.Relative),
        };

        private void myFrame_Loaded(object sender, RoutedEventArgs e) {
            _navi.Navigate(_uriList[0]);
        }

        private void Home_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            _navi.Navigate(_uriList[0]);
        }

        private void Search_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            _navi.Navigate(_uriList[1]);
        }

        private void Account_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e) {            
            _navi.Navigate(_uriList[2]);
        }

        private void Config_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            _navi.Navigate(_uriList[3]);
        }

    }
}
