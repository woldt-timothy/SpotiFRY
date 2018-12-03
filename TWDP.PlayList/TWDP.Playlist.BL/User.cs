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



        //May or May not use in our appp //tim -- you need to hash password
        public void Insert()
        {
            try
            {
                using (playlistEntities dc = new playlistEntities())
                {
                    tblUser user = new tblUser();
                    user.UserId = Guid.NewGuid();
                    user.Email = Email;
                    user.FirstName = FirstName;
                    user.LastName = LastName;
                    user.LoginId = LoginId;
                    user.Password = Password;

                    dc.tblUsers.Add(user);
                    dc.SaveChanges();

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
                using (playlistEntities dc = new playlistEntities())
                {
                    tblUser user = dc.tblUsers.Where(u => u.UserId == UserId).FirstOrDefault();

                    if (user != null)
                    {
                        dc.tblUsers.Remove(user);
                        dc.SaveChanges();
                    }


                }

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
                using (playlistEntities dc = new playlistEntities())
                {
                    tblUser user = dc.tblUsers.FirstOrDefault(u => u.UserId == UserId);
                    if (user != null)
                    {
                        user.Email = Email;
                        user.FirstName = FirstName;
                        user.LastName = LastName;
                        user.LoginId = LoginId;
                        user.Password = Password;
                        dc.SaveChanges();
                    }

                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public void LoadById(Guid guid)
        {
            try
            {
                using (playlistEntities dc = new playlistEntities())
                {

                    var user = dc.tblUsers.FirstOrDefault(u => u.UserId == guid);
                    if (user != null)
                    {
                        UserId = user.UserId;
                        FirstName = user.FirstName;
                        LastName = user.LastName;
                        Email = user.Email;
                        Password = user.Password;
                        LoginId = user.LoginId;
                    }




                    
                }
                    
            }
            catch (Exception e)
            {

                throw e;
            }
        }







    }

}
