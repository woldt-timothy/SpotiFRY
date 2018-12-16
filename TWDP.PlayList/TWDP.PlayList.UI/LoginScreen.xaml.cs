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

namespace TWDP.PlayList.UI
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void btnSignup_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.spotify.com/us/signup");
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();


        }

        private void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
    }
}
