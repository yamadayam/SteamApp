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
    /// RegWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class RegWindow : Window
    {
        public RegWindow()
        {
            InitializeComponent();
        }

        private void tbReg_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tbID.Text == "" || tbKey.Text == "")
                {
                    MessageBox.Show("値が間違っています");
                }
                else
                {
                    var api = new SteamApi(tbKey.Text, tbID.Text);

                    var steamapi = api.GetUserInformation();

                    if (steamapi.response.players[0].personaname == null)
                    {
                        MessageBox.Show("値が間違っています");
                    }
                    else
                    {
                        Information information = new Information();
                        information.stid = tbID.Text;
                        information.stkey = tbKey.Text;

                        var win = new MainWindow();
                        win.Show();

                        Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            

        }
    }
}
