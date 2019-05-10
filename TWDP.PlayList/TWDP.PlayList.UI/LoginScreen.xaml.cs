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
using TWDP.Playlist.BL;
using log4net;

namespace TWDP.PlayList.UI
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {

        log4net.ILog log = log4net.LogManager.GetLogger("Utility2.Logger");

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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                /// Basic Authentication, tried to do windows authentication also but did not get it to work on my computer
                RestClient restClient = new RestClient();

                restClient.userName = txtEmail.Text;
                restClient.userPassword = txtPassword.Password.ToString();
                restClient.endPoint = "azurewebsites.net/api/User?loginid=" + restClient.userName;
                restClient.makeRequest();

                log.Warn(txtEmail.Text);

                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                if (log.IsWarnEnabled)
                    log.Warn(txtPassword.Password.ToString());

                lblPleaseLogin.Content = "Wrong Username or Password, Please try again.";
            }
        }
    }
}
