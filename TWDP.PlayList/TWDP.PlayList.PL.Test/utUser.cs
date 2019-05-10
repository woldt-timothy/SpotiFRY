using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TWDP.PlayList.PL;
using System.Collections.Generic;
using System.Linq;

namespace TWDP.PlayList.PL.Test
{
    [TestClass]
    public class utUser
    {
        [TestMethod]
        public void UserInsert()
        {
            using (playlistEntities dc = new playlistEntities())
            {
                var beforerows = from t in dc.tblUsers
                                 select t;

                int beforecount = beforerows.Count();
                tblUser newrow;

                newrow = new tblUser();
                newrow.Email = "littlejimmy@gmail.com";
                newrow.Password = "987zyx";
                newrow.FirstName = "Jimmy";
                newrow.LastName = "Johnson";
                newrow.LoginId = "jimbo528";
                newrow.SpotifyId = "TonyBony";
               
                dc.tblUsers.Add(newrow);
                dc.SaveChanges();

                var afterrows = from t in dc.tblUsers
                                select t;
                int aftercount = afterrows.Count();

                Assert.AreEqual(beforecount, aftercount - 1);
            }
        }

        [TestMethod]
        public void UserLoadTest()
        {
            using (playlistEntities dc = new playlistEntities())
            {
                var rows = from t in dc.tblUsers
                           select t;
                Assert.AreEqual(rows.Count(), 5);
            }
        }

        [TestMethod]
        public void UserDeleteTest()
        {
            using (playlistEntities dc = new playlistEntities())
            {
                var beforerows = from t in dc.tblUsers
                                 select t;

                int beforecount = beforerows.Count();

                tblUser row = (from t in dc.tblUsers
                             where t.Email == "littlejimmy@gmail.com"
                               select t).FirstOrDefault();

                dc.tblUsers.Remove(row);
                dc.SaveChanges();

                var afterrows = from t in dc.tblUsers
                                select t;
                int aftercount = afterrows.Count();

                Assert.AreEqual(beforecount, aftercount + 1);
            }
        }
    }
}
