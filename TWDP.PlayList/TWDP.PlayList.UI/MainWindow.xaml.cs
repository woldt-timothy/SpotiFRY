﻿using System;
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

using SpotifyApi.NetCore.Http;
using SpotifyApi.NetCore.Extensions;
using System.Net.Http;
using SpotifyApi.NetCore;
using System.IO;
using System.Net;
using TWDP.Playlist.BL;
using System.Net;
using System.Net.Mail;

namespace TWDP.PlayList.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
         public MainWindow()
        {
                    InitializeComponent();
                    if (btnEmail.IsMouseOver == true)
                    {
                        btnEmail.Background = Brushes.Green;
                    }
        }

        private async void Button_ClickAsync(object sender, RoutedEventArgs e)
        {

            const string username = "woldt.timothy";
            const string playlistId = "64CntkO6kptPuFglj6h5Os";
            
            var http = new HttpClient();
            var accounts = new AccountsService(http, ConfigurationHelper.GetLocalConfig());
            var api = new PlaylistsApi(http, accounts);


            List<string> artistList = new List<string>();

            var response = await api.GetTracks(username, playlistId);

            for (int i = 0; i < response.Items.Length; i++)
            {
                    string songArtist = response.Items[i].Track.Artists[0].Name.ToString();

                    if (response.Items[i].Track.Artists[0].Name != null)
                    {
                        artistList.Add(songArtist);
                    }

            }

            lstRecentPlayList.ItemsSource = artistList;


            Random random = new Random();
            int randomNumber = random.Next(0, response.Items.Length);


            string query = artistList[randomNumber];

            if (query != null)
            {

                var httpNewPlayList = new HttpClient();
                api = new PlaylistsApi(http, accounts);

                List<string> playlistList = new List<string>();

                var response1 = await api.SearchPlaylists(query);

                string playlistTitle;

                for (int i = 0; i < response1.Items.Length; i++)
                {
                    if (response1.Items[i].Name != null)
                    {
                        playlistTitle = response1.Items[i].Name.ToString();
                        playlistList.Add(playlistTitle);
                    }
                }


                var duplicateKeys = playlistList.GroupBy(x => x)
                .Where(group => group.Count() > 1)
                  .Select(group => group.Key);

                var resultsYU = duplicateKeys.ToList();

                for (int i = 0; i < resultsYU.Count; i++)
                {
                    string duplicatePlayList = resultsYU[i];
                    playlistList.RemoveAll(p => p.StartsWith(duplicatePlayList));
                }

                lstSuggestedPlayList.ItemsSource = playlistList;
            }

        }

        private void btnEmail_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MailMessage mail = new MailMessage();
                //put your SMTP address and port here.
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                //Put the email address
                mail.From = new MailAddress("playlsitmakerbeta@gmail.com");
                //Put the email where you want to send.
                mail.To.Add("Dalton5699@hotmail.com");

                mail.Subject = "Your Playlsit Is Finally Here!";

                StringBuilder sbBody = new StringBuilder();

                sbBody.AppendLine("Hello Customer,");

                sbBody.AppendLine("Here is the Playlist that you have requested via Playlist Finder, Enjoy!");

                sbBody.AppendLine(lstSuggestedPlayList.ToString());

                mail.Body = sbBody.ToString();

                //Your log file path
                System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(@"C:\Logs\CheckoutPOS.log");

                mail.Attachments.Add(attachment);

                //Your username and password!
                SmtpServer.Credentials = new System.Net.NetworkCredential("playlsitmakerbeta@gmail.com", "PlaylistMaker21");
                //Set Smtp Server port
                SmtpServer.Port = 465;
                // SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                MessageBox.Show("The email has been sent!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("An Error Occured");

            }


            //GMAIL ACCOUNT INFO
            //Username: playlsitmakerbeta@gmail.com
            //Password: PlaylistMaker21

        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            LoginScreen frm2 = new LoginScreen();
            frm2.Show();
            this.Close();
        }
    }
}
