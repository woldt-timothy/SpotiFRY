using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWDP.PlayList.PL;

namespace TWDP.Playlist.BL
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LoginId { get; set; }



        //May or May not use in our appp
        public void Insert()
        {
            try
            {
                using (playlistEntities dc = new playlistEntities())
                {

                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }


        //Take a look at this again //May or May not use in our appp
        public void Delete()
        {
            try
            {

            }
            catch (Exception e)
            {

                throw e;
            }



        }


        //Take a look at this again //May or May not use in our appp
        public void Update()
        {
            try
            {

            }
            catch (Exception e)
            {

                throw e;
            }
        }







    }

}
