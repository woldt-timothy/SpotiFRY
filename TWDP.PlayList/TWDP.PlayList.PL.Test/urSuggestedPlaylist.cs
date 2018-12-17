using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TWDP.PlayList.PL;
using System.Collections.Generic;
using System.Linq;

namespace TWDP.PlayList.PL.Test
{
    [TestClass]
    public class urSuggestedPlaylist
    {
        [TestMethod]
        public void SuggestedPlayListInsert()
        {


            using (playlistEntities dc = new playlistEntities())
            {
                var beforerows = from t in dc.tblSuggestedPlaylists
                                 select t;

                int beforecount = beforerows.Count();

                tblSuggestedPlaylist newrow;

                newrow = new tblSuggestedPlaylist();

                newrow.SuggestedPlaylistId = Guid.NewGuid();
                newrow.SuggestedPlaylistTitle = "The Ultimate Pop PlayList";
                newrow.ImagePath = "https://images-na.ssl-images-amazon.com/images/I/81klCVJB0AL._SY355_.jpg";




                dc.tblSuggestedPlaylists.Add(newrow);

                dc.SaveChanges();

                var afterrows = from t in dc.tblSuggestedPlaylists
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
                var rows = from t in dc.tblSuggestedPlaylists
                           select t;
                Assert.AreEqual(rows.Count(), 5);
            }


        }



        [TestMethod]
        public void SuggestedPlayListDeleteTest()
        {
            using (playlistEntities dc = new playlistEntities())
            {

                var beforerows = from t in dc.tblSuggestedPlaylists
                                 select t;

                int beforecount = beforerows.Count();


                tblSuggestedPlaylist row = (from t in dc.tblSuggestedPlaylists
                                            where t.SuggestedPlaylistTitle == "The Ultimate Pop PlayList"
                                            select t).FirstOrDefault();

                dc.tblSuggestedPlaylists.Remove(row);
                dc.SaveChanges();



                var afterrows = from t in dc.tblSuggestedPlaylists
                                select t;
                int aftercount = afterrows.Count();

                Assert.AreEqual(beforecount, aftercount +1);
                

            }
        }




    }
}

