using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TWDP.PlayList.PL;
using System.Collections.Generic;
using System.Linq;

namespace TWDP.PlayList.PL.Test
{
    [TestClass]
    public class utSpotifyInformation
    {
        [TestMethod]
        public void SpotifyInsert()
        {


            using (playlistEntities dc = new playlistEntities())
            {
                var beforerows = from t in dc.tblSpotifyClientInformations
                                 select t;

                int beforecount = beforerows.Count();

                tblSpotifyClientInformation newrow;

                newrow = new tblSpotifyClientInformation();

                newrow.SpotifyInformationId = Guid.NewGuid();
                newrow.UserId = Guid.NewGuid();
                newrow.SpotifyClientSecret = "Hash5";
                newrow.SpotifyClientId = "Hash6";




                dc.tblSpotifyClientInformations.Add(newrow);

                dc.SaveChanges();

                var afterrows = from t in dc.tblSpotifyClientInformations
                                select t;
                int aftercount = afterrows.Count();

                Assert.AreEqual(beforecount, aftercount - 1);
            }



        }

        [TestMethod]
        public void SuggestedPlayListLoadTest()
        {
            using (playlistEntities dc = new playlistEntities())
            {
                var rows = from t in dc.tblSpotifyClientInformations
                           select t;
                Assert.AreEqual(rows.Count(), 5);
            }


        }



        [TestMethod]
        public void SuggestedPlayListDeleteTest()
        {
            using (playlistEntities dc = new playlistEntities())
            {

                var beforerows = from t in dc.tblSpotifyClientInformations
                                 select t;

                int beforecount = beforerows.Count();


                tblSpotifyClientInformation row = (from t in dc.tblSpotifyClientInformations
                                            where t.SpotifyClientSecret == "Hash5"
                                            select t).FirstOrDefault();

                dc.tblSpotifyClientInformations.Remove(row);
                dc.SaveChanges();



                var afterrows = from t in dc.tblSpotifyClientInformations
                                select t;
                int aftercount = afterrows.Count();

                Assert.AreEqual(beforecount, aftercount + 1);
                

            }
        }




    }
}