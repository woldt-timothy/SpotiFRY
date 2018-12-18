using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TWDP.Playlist.BL;

namespace TWDP.PlayList.SL.Controllers
{
    public class UserController : ApiController
    {
        [Authorize(Users = "DESKTOP-H8546LJ//CREATOR OWNER")]
        // GET: api/User
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/User/5
        public User Get(string loginid)
        {
            User user = new User();
            user.LoadById(loginid);
            return user;
        }

        // POST: api/User
        public void Post([FromBody]TWDP.Playlist.BL.User user)
        {
            user.Insert();
        }

        // PUT: api/User/5
        public void Put([FromBody]User user)
        {
            user.Update();
        }

        // DELETE: api/User/5
        public void Delete(string loginid)
        {

            User user = new User();
            user.LoadById(loginid);
            user.Delete();
        }

        //// Login: api/User
        //public bool Login()
        //{
        //    User user = new User();
        //    return  user.Login();
        //}


    }
}
