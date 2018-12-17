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


            Guid testGuid = Guid.Parse("1f607a7f-a94c-4f45-9a11-03e6cf254849");

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




            //Tim and Dalton - Make sure NO SPACES when pasting GUIDs from database

            playlist.LoadById(Guid.Parse("ff03dd42-b266-4e64-888e-b1dbcc54ca2c"));

            string expected = "Best of Eric Clapton Playlist";
            string actual = playlist.SuggestedPlaylistTitle;

            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void LoadPlaylistTest()
        {

            TWDP.Playlist.BL.Playlist playlist = new TWDP.Playlist.BL.Playlist();



            playlist.LoadPlaylist(Guid.Parse("9fce6871-1700-4ded-b839-28b3cde74244"));

            int expected = 2;
            int actual = playlist.playlistList.Count();

            Assert.AreEqual(expected, actual);
        }






    }







}







