using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TWDP.PlayList.PL;
using System.Collections.Generic;
using System.Linq;

namespace TWDP.PlayList.PL.Test
{
    [TestClass]
    public class utUWP
    {
        [TestMethod]
        public void USPinsert()
        {
            using (playlistEntities dc = new playlistEntities())
            {

                var beforerows = from t in dc.tblUSPs
                                 select t;

                int beforecount = beforerows.Count();


                tblUSP newrow;

                newrow = new tblUSP();


                newrow.USPId = Guid.NewGuid();
                newrow.UserId = Guid.NewGuid();
                newrow.SuggestedPlaylistId = Guid.NewGuid();



                dc.tblUSPs.Add(newrow);


                dc.SaveChanges();


                var afterrows = from t in dc.tblUSPs
                                select t;
                int aftercount = afterrows.Count();

                Assert.AreEqual(beforecount, aftercount - 1);
            }



        }

        [TestMethod]
        public void USPloadtest()
        {
            using (playlistEntities dc = new playlistEntities())
            {
                var rows = from t in dc.tblUSPs
                           select t;
                Assert.AreEqual(rows.Count(), 5);
            }


        }


        [TestMethod]
        public void USPDeletetest()
        {

            Guid guid = Guid.Parse("cb4c239f-0307-4d57-ad1e-0285ae17ce85");





            using (playlistEntities dc = new playlistEntities())
            {

                var beforerows = from t in dc.tblUSPs
                                 select t;

                int beforecount = beforerows.Count();


                tblUSP row = (from t in dc.tblUSPs
                                            where t.USPId == guid
                                            select t).FirstOrDefault();

                dc.tblUSPs.Remove(row);
                dc.SaveChanges();


                var afterrows = from t in dc.tblUSPs
                                select t;
                int aftercount = afterrows.Count();

                Assert.AreEqual(beforecount, aftercount + 1);
            }
        }



    }
}
