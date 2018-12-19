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

using SpotifyApi.NetCore.Http;
using SpotifyApi.NetCore.Extensions;
using System.Net.Http;
using SpotifyApi.NetCore;
using System.IO;
using System.Net;
using TWDP.Playlist.BL;
using System.Net;
using System.Net.Mail;
using Newtonsoft.Json;

namespace TWDP.PlayList.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<TWDP.Playlist.BL.Playlist> playlists1 = new List<Playlist.BL.Playlist>();

        List<string> playlistList2 = new List<string>();
        List<string> playlistListImagePaths = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
            if (btnEmail.IsMouseOver == true)
            {
                btnEmail.Background = Brushes.Green;
            }
        }

        public async void Button_ClickAsync(object sender, RoutedEventArgs e)
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
                List<string> playlistListImagePath = new List<string>();


                var response1 = await api.SearchPlaylists(query);

                string playlistTitle;
                string playlistImagePath;

                for (int i = 0; i < response1.Items.Length; i++)
                {
                    if (response1.Items[i].Name != null)
                    {
                         playlistImagePath = response1.Items[i].Images[0].Url.ToString();
                        playlistTitle = response1.Items[i].Name.ToString();
                        playlistList.Add(playlistTitle);
                        playlistList2.Add(playlistTitle);
                        playlistListImagePath.Add(playlistImagePath);
                        playlistListImagePaths.Add(playlistImagePath);
                    }
                }


                //var duplicateKeys = playlistList.GroupBy(x => x)
                //.Where(group => group.Count() > 1)
                //  .Select(group => group.Key);

                //var resultsYU = duplicateKeys.ToList();

                //for (int i = 0; i < resultsYU.Count; i++)
                //{
                //    string duplicatePlayList = resultsYU[i];
                //    playlistList.RemoveAll(p => p.StartsWith(duplicatePlayList));
                //}

                //for (int i = 1; i < playlistList.Count; i++)
                //{
                //    TWDP.Playlist.BL.Playlist playlist = new Playlist.BL.Playlist();
                //    playlist.SuggestedPlaylistTitle = playlistList[0];
                //    playlists1.Add(playlist);
                //}


                //var duplicateKeys2 = playlistList2.GroupBy(x => x)
                //.Where(group => group.Count() > 1)
                // .Select(group => group.Key);

                //var resultsYUM = duplicateKeys2.ToList();

                //for (int i = 0; i < resultsYUM.Count; i++)
                //{
                //    string duplicatePlayList = resultsYUM[i];
                //    playlistList2.RemoveAll(p => p.StartsWith(duplicatePlayList));
                //}



                lstSuggestedPlayList.ItemsSource = playlistList;
            }

        }

        private void SendEmail()
        {
            if (lstRecentPlayList.Items.Count <= 0)
            {
                MessageBox.Show("No Playlists to send, please click 'Get Playlists'", "Error");
            }
            else
            {
                string cols = string.Join("    -   ", lstSuggestedPlayList.Items.Cast<String>());
                string mailBodyhtml = cols;
                var msg = new MailMessage("playlistmakerbeta@gmail.com", "dalton5699@hotmail.com", "Your new playlists are finally here!", mailBodyhtml); //change my email to users email that they use to login
                                                                                                                                                          //msg.To.Add("to2@gmail.com");
                msg.IsBodyHtml = true;
                var smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Credentials = new NetworkCredential("playlistmakerbeta@gmail.com", "PlaylistMaker21");
                smtpClient.EnableSsl = true;
                smtpClient.Send(msg);
                MessageBox.Show("Email Sent Successfully");
            }
        }






        async void btnEmail_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SendEmail();



                for (int i = 0; i < playlistList2.Count - 1; i++)
                {
                   
                    TWDP.Playlist.BL.Playlist playlist = new TWDP.Playlist.BL.Playlist();
                    playlist.ImagePath = playlistListImagePaths[i];
                    playlist.SuggestedPlaylistTitle = playlistList2[i];


                    HttpClient client = new HttpClient();
                    Uri baseAddress = new Uri("http://playlistapitwdp.azurewebsites.net/api/");
                    client.BaseAddress = baseAddress;


                    string serializedPlaylist = JsonConvert.SerializeObject(playlist);
                    var content = new StringContent(serializedPlaylist);
                    content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    HttpResponseMessage  response =  client.PostAsync("PlayList", content).Result;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("An Error Occured");

            }
        }




        //GMAIL ACCOUNT INFO
        //Username: playlsitmakerbeta@gmail.com
        //Password: PlaylistMaker21




        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            LoginScreen frm2 = new LoginScreen();
            frm2.Show();
            this.Close();
        }

        private void btnPreview_ClickAsync(object sender, RoutedEventArgs e)
        {
            if (lstRecentPlayList.Items.Count <= 0)
            {
                MessageBox.Show("Please click 'Get Playlists' to load the playlists first.", "Error - No playlist to preview");
            }
            else if (lstSuggestedPlayList.SelectedItems.Count <= 0)
            {
                MessageBox.Show("Please select the playlist in the 'Suggested' section to preview it.", "Error - No plsylist Selected");
            }
            else
            {
                //ADD ALL OF THE PREVIEW CODE INTO THIS SECTION
            }
        }

        private void lstSuggestedPlayList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstSuggestedPlayList.SelectedItems.Count <= 0)
            {
                //default
                imgAlbumArtwork.Source = new BitmapImage(new Uri("/Images/logo.png", UriKind.RelativeOrAbsolute));
            }
            else
            {
                //selected item background
                imgAlbumArtwork.Source = new BitmapImage(new Uri(playlistListImagePaths[lstSuggestedPlayList.SelectedIndex], UriKind.RelativeOrAbsolute));
            }
        }
    }

}

