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

        }

        private async void Button_ClickAsync(object sender, RoutedEventArgs e)
        {

            const string username = "woldt.timothy";
            const string playlistId = "64CntkO6kptPuFglj6h5Os";
            string result;
            var http = new HttpClient();
            var accounts = new AccountsService(http, ConfigurationHelper.GetLocalConfig());

            var api = new PlaylistsApi(http, accounts);




            List<string> stringList = new List<string>();

            // Act
            var response = await api.GetTracks(username, playlistId);

            for (int i = 0; i < response.Items.Length; i++)
            {
                string songTitle = response.Items[i].Track.Name.ToString();
                string songArtist = response.Items[i].Track.Artists[0].Name.ToString();
                string songAlbumTitle = response.Items[i].Track.Album.Name.ToString();
                //string songPreviewPath = response.Items[i].Track.PreviewUrl.ToString();

                //response.Items[i].Track.PreviewUrl != null


                if (response.Items[i].Track.Name != null)
                {

                    stringList.Add(songTitle);
                }



            }





            lstRecentPlayList.ItemsSource = stringList;


            Random random = new Random();
            int randomNumber1 = random.Next(0, 40);



            string query = stringList[randomNumber1];
            if (query != null)
            {
                var httpNewPlayList = new HttpClient();


                api = new PlaylistsApi(http, accounts);

                List<string> stringList2 = new List<string>();

                var response2 = await api.SearchPlaylists(query);

                string playlistTitle;
                for (int i = 0; i < response2.Items.Length; i++)
                {




                    if (response2.Items[i].Name != null)
                    {


                        playlistTitle = response2.Items[i].Name.ToString();

                        stringList2.Add(playlistTitle);
                    }

                }

                lstSuggestedPlayList.ItemsSource = stringList2;





            }














        }
    }
}
