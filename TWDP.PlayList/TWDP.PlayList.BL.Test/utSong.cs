using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using TWDP.Playlist.BL;
using TWDP.PlayList.PL;


namespace TWDP.PlayList.BL.Test
{
    [TestClass]
    public class utSong
    {
        [TestMethod]
        public void InsertTest()
        {

            //PlayList play = new Song();


            //song.AlbumTitle = "Purple Rain";
            //song.Artist = "Prince";
            //song.ImagePath = "https://static1.squarespace.com/static/568c8b6dc647ad1e5186eb94/583a70f9ff7c502cbada4d2a/583a71d8c534a5462ee9ca90/1480225248256/IMG_4469.JPG?format=1000w";
            //song.SongTitle = "Purple Rain";
            //song.Insert();


            //playlistEntities dc = new playlistEntities();

            //var songs = dc.tblSuggestedSongs;
            //int expected = 7;
            //int actual = songs.Count();

            //Assert.AreEqual(expected, actual);

        }



        [TestMethod]
        public void DeleteTest()
        {

            //Song song = new Song();


            //Guid testGuid = Guid.Parse("332bb7b0-2c32-4485-a908-f642b489c990");

            //song.SongId = testGuid;

            //song.Delete();


            //playlistEntities dc = new playlistEntities();

            //var songs = dc.tblSuggestedSongs;
            //int expected = 5;
            //int actual = songs.Count();

            //Assert.AreEqual(expected, actual);


        }






        [TestMethod]
        public void LoadByIdTest()
        {

            //Song song = new Song();

 


            ////Tim and Dalton - Make sure NO SPACES when pasting GUIDs from database

            //song.LoadById(Guid.Parse("4733a79d-32b2-4823-8f42-c1718310b6a2"));

            //string expected = "Cocaine";
            //string actual = song.SongTitle;

            //Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void LoadPlaylistTest()
        {

            //Song song = new Song();



            //song.LoadPlaylist(Guid.Parse("f92a3d3b-be2c-4936-ba72-7c55a735a7c5"));

            //int expected = 2;
            //int actual = song.songlist.Count();

            //Assert.AreEqual(expected, actual);
        }


    }







}







