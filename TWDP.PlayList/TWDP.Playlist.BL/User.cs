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
        public string SpotifyId { get; set; }



        public User()
        {
        }


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
                    user.Password = GetHash();
                    user.SpotifyId = GetHashSpotifyId();

                    

                    dc.tblUsers.Add(user);
                    dc.SaveChanges();

                }
            }
            catch (Exception e)
            {


                throw e;
            }
        }

        private string GetHashSpotifyId()
        {
            using (var hash = new System.Security.Cryptography.SHA1Managed())
            {
                var hashbytes = System.Text.Encoding.UTF8.GetBytes(this.SpotifyId);
                return Convert.ToBase64String(hash.ComputeHash(hashbytes));
            }
        }


        private string GetHash()
        {
            using (var hash = new System.Security.Cryptography.SHA1Managed())
            {
                var hashbytes = System.Text.Encoding.UTF8.GetBytes(this.Password);
                return Convert.ToBase64String(hash.ComputeHash(hashbytes));
            }
        }

        public bool Login()
        {
            try
            {
                if (LoginId != null && LoginId != string.Empty)
                {
                    if (Password != null && Password != string.Empty)
                    {
                        playlistEntities dc = new playlistEntities();
                        tblUser user = dc.tblUsers.FirstOrDefault(u => u.LoginId == this.LoginId);
                        if (user != null)
                        {
                            if (user.Password == this.GetHash())
                            {
                                
                                FirstName = user.FirstName;
                                LastName = user.LastName;
                                UserId = user.UserId;
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }


        public void Delete()
        {
            try
            {
                using (playlistEntities dc = new playlistEntities())
                {
                    tblUser user = dc.tblUsers.Where(u => u.LoginId == LoginId).FirstOrDefault();

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


        
        public void Update()
        {
            try
            {
                using (playlistEntities dc = new playlistEntities())
                {
                    tblUser user = dc.tblUsers.FirstOrDefault(u => u.LoginId == LoginId);
                    if (user != null)
                    {
                        user.Email = Email;
                        user.LastName = LastName;
                        user.FirstName = FirstName;
                        user.LoginId = LoginId;
                        user.Password = GetHash();
                        user.SpotifyId = GetHashSpotifyId();
                        dc.SaveChanges();
                    }

                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public void LoadById(string loginid)
        {
            try
            {
                using (playlistEntities dc = new playlistEntities())
                {

                    var user = dc.tblUsers.FirstOrDefault(u => u.LoginId == loginid);
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
