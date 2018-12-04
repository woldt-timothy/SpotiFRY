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

            User user = new User();

            user.Email = "smally@yahoo.com";
            user.FirstName = "Biggie";
            user.LastName = "Smalls";
            user.LoginId = "smallDude";
            user.Password = "apple";
            user.Insert();


            playlistEntities dc = new playlistEntities();

            var users = dc.tblUsers;
            int expected = 6;
            int actual = users.Count();

            Assert.AreEqual(expected, actual);

        }


        [TestMethod]
        public void LoadByIdTest()
        {



            Song song = new Song();

            song.LoadById("aaaa");

            string expected = "aaaa";
            string actual = song.ActivationCode;

            Assert.AreEqual(expected, actual);
        }


    }



}
