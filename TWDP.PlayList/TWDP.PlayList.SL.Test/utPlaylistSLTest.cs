using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TWDP.PlayList.PL;
using TWDP.Playlist.BL;
using System.Net.Http;
using System.Linq;

namespace TWDP.PlayList.SL.Test
{
    [TestClass]
    public class utPlaylistSLTest
    {
        [TestMethod]
        public void InsertTest()
        {
            TWDP.Playlist.BL.Playlist playlist = new TWDP.Playlist.BL.Playlist();
            playlist.ImagePath = "https://static1.squarespace.com/static/568c8b6dc647ad1e5186eb94/583a70f9ff7c502cbada4d2a/583a71d8c534a5462ee9ca90/1480225248256/IMG_4469.JPG?format=1000w";
            playlist.SuggestedPlaylistTitle = "Jimbos PayList";


            HttpClient client = new HttpClient();
            Uri baseAddress = new Uri("http://playlistapitwdp.azurewebsites.net/api/");
            client.BaseAddress = baseAddress;


            string serializedPlaylist = JsonConvert.SerializeObject(playlist);
            var content = new StringContent(serializedPlaylist);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = client.PostAsync("PlayList", content).Result;

            playlistEntities dc = new playlistEntities();
            var playlists = dc.tblSuggestedPlaylists;

            int expected = 9;
            int actual = playlists.Count();

            Assert.AreEqual(expected, actual);





        }
    }
}

