//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using TWDP.PlayList.PL;
//using System.Collections.Generic;
//using System.Linq;

//namespace TWDP.PlayList.PL.Test
//{
//    [TestClass]
//    public class utUserSuggestedSong
//    {
//        [TestMethod]
//        public void UserSuggestedSongInsert()
//        {
//            using (playlistEntities dc = new playlistEntities())
//            {
              
//                var beforerows = from t in dc.tblUserSuggestedSongs
//                                 select t;

//                int beforecount = beforerows.Count();

              
//                tblUserSuggestedSong newrow;

//                newrow = new tblUserSuggestedSong();

              
//                newrow.UserSuggestedSongId = Guid.NewGuid();
//                newrow.UserId = Guid.NewGuid();
//                newrow.SuggestedSongId = Guid.NewGuid();
                

              
//                dc.tblUserSuggestedSongs.Add(newrow);

              
//                dc.SaveChanges();

              
//                var afterrows = from t in dc.tblUserSuggestedSongs
//                                select t;
//                int aftercount = afterrows.Count();

//                Assert.AreEqual(beforecount, aftercount - 1);
//            }



//        }

//        [TestMethod]
//        public void UserSuggestedSongLoadTest()
//        {
//            using (playlistEntities dc = new playlistEntities())
//            {
//                var rows = from t in dc.tblUserSuggestedSongs
//                           select t;
//                Assert.AreEqual(rows.Count(), 5);
//            }


//        }


//        [TestMethod]
//        public void UserSuggestedSongTest()
//        {

//            Guid guid = Guid.Parse("59aa5dd9-ab75-4870-9af5-db0362d61548");


//            using (playlistEntities dc = new playlistEntities())
//            {
//                tblUserSuggestedSong row = (from t in dc.tblUserSuggestedSongs
//                             where t.UserSuggestedSongId == guid
//                                            select t).FirstOrDefault();

//                dc.tblUserSuggestedSongs.Remove(row);
//                dc.SaveChanges();
//            }
//        }



//    }
//}
