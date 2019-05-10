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
    public class utUserSLTest
    {
        [TestMethod]
        public void InsertTest()
        {
            TWDP.Playlist.BL.User user= new TWDP.Playlist.BL.User();

            user.Email = "OpieTaylor@gmail.com";
            user.FirstName = "Opie";
            user.LastName = "Taylor";
            user.LoginId = "OpieTheMan";
            user.Password = "maple";
            user.SpotifyId = "Youranidiot";
            
            HttpClient client = new HttpClient();
            Uri baseAddress = new Uri("azurewebsites.net/api/");
            client.BaseAddress = baseAddress;


            string serializedUser = JsonConvert.SerializeObject(user);
            var content = new StringContent(serializedUser);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = client.PostAsync("User", content).Result;

            playlistEntities dc = new playlistEntities();
            var users = dc.tblUsers;

            int expected = 10;
            int actual = users.Count();

            Assert.AreEqual(expected, actual);
        }
        private static string ProcessParametersForLoadById(String ac)
        {
            string prePender = "?loginid=" + ac;

            return prePender;
        }

        private static string ProcessParamatersForDelete(String ac)
        {
            string prePender = "?loginid=" + ac;

            return prePender;
        }

        [TestMethod]
        public void LoadByIdTest()
        {
            HttpClient client = new HttpClient();

            Uri baseAddress = new Uri("azurewebsites.net/api/");

            client.BaseAddress = baseAddress;

            string result;
            dynamic item;
            HttpResponseMessage response;

            User user = new User();
            
            string acTeststr = ProcessParametersForLoadById("SOMEONE");
            response = client.GetAsync("User" + acTeststr).Result;
            result = response.Content.ReadAsStringAsync().Result;
            user = JsonConvert.DeserializeObject<User>(result);

            string expected = "SOMEONESNAME";

            Assert.AreEqual(expected, user.FirstName);

        }

        [TestMethod]
        public void DeleteTest()
        {
            HttpClient client = new HttpClient();

            Uri baseAddress = new Uri("azurewebsites.net/api/");

            client.BaseAddress = baseAddress;

            string acTeststr = ProcessParamatersForDelete("Pal");
            HttpResponseMessage response = client.DeleteAsync("User"+ acTeststr).Result;

            playlistEntities dc = new playlistEntities();
            var users = dc.tblUsers;

            int expected = 9;
            int actual = users.Count();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void UpdateTest()
        {
            TWDP.Playlist.BL.User user = new TWDP.Playlist.BL.User();

            user.LoginId= "jon";
            user.LastName = "Wal";
            user.Password = "GOOSE";
            user.SpotifyId = "SpotifyId";
            user.Email = "dicky@hotmail.com";
            user.FirstName = "Jimmy";

            HttpClient client = new HttpClient();
            Uri baseAddress = new Uri("azurewebsites.net/api/");
            client.BaseAddress = baseAddress;

            string serializedUser = JsonConvert.SerializeObject(user);
            var content = new StringContent(serializedUser);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = client.PutAsync("User", content).Result;

            playlistEntities dc = new playlistEntities();

            User user2 = new User();
            user2.LoadById("jon");

            string expected = "dicky@hotmail.com";

            Assert.AreEqual(expected, user2.Email);
        }
    }
}
