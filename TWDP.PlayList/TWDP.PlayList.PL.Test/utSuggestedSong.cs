using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TWDP.PlayList.PL;
using System.Collections.Generic;
using System.Linq;

namespace TWDP.PlayList.PL.Test
{
    [TestClass]
    public class utSuggestedSong
    {
        [TestMethod]
        public void SuggestedSongInsert()
        {


            using (playlistEntities dc = new playlistEntities())
            {
                var beforerows = from t in dc.tblSuggestedSongs
                                 select t;

                int beforecount = beforerows.Count();

                tblSuggestedSong newrow;

                newrow = new tblSuggestedSong();

                newrow.SuggestedSongId = Guid.NewGuid();
                newrow.SuggestedSongTitle = "Come Together";
                newrow.SuggestedSongAlbumTitle = "Abbey Road";
                newrow.SuggestedSongArtist = "The Beatles";
                newrow.SuggestedSongImagePath = "https://images-na.ssl-images-amazon.com/images/I/81klCVJB0AL._SY355_.jpg";
                

                dc.tblSuggestedSongs.Add(newrow);

                dc.SaveChanges();

                var afterrows = from t in dc.tblSuggestedSongs
                                select t;
                int aftercount = afterrows.Count();

                Assert.AreEqual(beforecount, aftercount - 1);
            }



        }

        [TestMethod]
        public void SuggestedSongLoadTest()
        {
            using (playlistEntities dc = new playlistEntities())
            {
                var rows = from t in dc.tblSuggestedSongs
                           select t;
                Assert.AreEqual(rows.Count(), 5);
            }


        }



        [TestMethod]
        public void SuggestedSongDeleteTest()
        {
            using (playlistEntities dc = new playlistEntities())
            {
                tblSuggestedSong row = (from t in dc.tblSuggestedSongs
                                 where t.SuggestedSongTitle == "Come Together"
                                        select t).FirstOrDefault();

                dc.tblSuggestedSongs.Remove(row);
                dc.SaveChanges();
            }
        }




    }
}
