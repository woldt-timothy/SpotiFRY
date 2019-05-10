using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using TWDP.Playlist.BL;
using TWDP.PlayList.PL;

namespace TWDP.PlayList.BL.Test
{
    [TestClass]
    public class utPlayList
    {
        [TestMethod]
        public void InsertTest()
        {
            TWDP.Playlist.BL.Playlist playlist = new TWDP.Playlist.BL.Playlist();
   
            playlist.ImagePath = "https://static1.squarespace.com/static/568c8b6dc647ad1e5186eb94/583a70f9ff7c502cbada4d2a/583a71d8c534a5462ee9ca90/1480225248256/IMG_4469.JPG?format=1000w";
            playlist.SuggestedPlaylistTitle = "Red's Super Groovy PlayList";
            playlist.Insert();

            playlistEntities dc = new playlistEntities();

            var playlists = dc.tblSuggestedPlaylists;
            int expected = 6;
            int actual = playlists.Count();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeleteTest()
        {
            TWDP.Playlist.BL.Playlist playlist = new TWDP.Playlist.BL.Playlist();

            Guid testGuid = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa");

            playlist.SuggestedPlaylistId= testGuid;
            playlist.Delete();

            playlistEntities dc = new playlistEntities();

            var playlists = dc.tblSuggestedPlaylists;
            int expected = 5;
            int actual = playlists.Count();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LoadByIdTest()
        {
            TWDP.Playlist.BL.Playlist playlist = new TWDP.Playlist.BL.Playlist();

            playlist.LoadById(Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"));

            string expected = "Queens of the Stone Age: Greatest Hits";
            string actual = playlist.SuggestedPlaylistTitle;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LoadPlaylistTest()
        {
            TWDP.Playlist.BL.Playlist playlist = new TWDP.Playlist.BL.Playlist();

            playlist.LoadPlaylist(Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"));

            int expected = 2;
            int actual = playlist.playlistList.Count();

            Assert.AreEqual(expected, actual);
        }
    }
}







