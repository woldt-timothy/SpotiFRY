using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using TWDP.Playlist.BL;
using TWDP.PlayList.PL;


namespace TWDP.PlayList.BL.Test
{
    [TestClass]
    public class utUser
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
            user.SpotifyId = "Lebowski11";
            user.Insert();


            playlistEntities dc = new playlistEntities();

            var users = dc.tblUsers;
            int expected = 6;
            int actual = users.Count();

            Assert.AreEqual(expected, actual);


        }


        [TestMethod]
        public void DeleteTest()
        {

            User user = new User();

      
            user.LoginId = "smallDude";
      
            user.Delete();


            playlistEntities dc = new playlistEntities();

            var users = dc.tblUsers;
            int expected = 6;
            int actual = users.Count();

            Assert.AreEqual(expected, actual);


        }


        [TestMethod]
        public void UpdateTest()
        {

            User user = new User();


            user.Email = "smally@yahoo.com";
            user.FirstName = "Smally";
            user.LastName = "Smalls";
            user.LoginId = "smallDude";
            user.Password = "apple";
            user.SpotifyId = "Lebowski11";

            user.Update();


            User otherUser = new User();


            otherUser.LoadById("smallDude");




           
            string expected = "Smally";

            string actual = otherUser.FirstName;

            Assert.AreEqual(expected, actual);


        }






    }



}
