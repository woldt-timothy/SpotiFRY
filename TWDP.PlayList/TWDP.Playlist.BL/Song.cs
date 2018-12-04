using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWDP.PlayList.PL;

namespace TWDP.Playlist.BL
{
    public class Song
    {



        public Guid SongId { get; set; }
        public string SongTitle { get; set; }
        public string Artist { get; set; }
        public string AlbumTitle { get; set; }
        public string ImagePath { get; set; }
        public List<Song> songlist { get; set; }



        private string suggestedSongAlbumTitle;
        private string suggestedSongArtist;
        private Guid suggestedSongId;
        private string suggestedSongImagePath;
        private string suggestedSongTitle;


        public Song()
        {

            songlist = new List<Song>();


        }





        public Song(string suggestedSongAlbumTitle, string suggestedSongArtist, Guid suggestedSongId, string suggestedSongImagePath, string suggestedSongTitle)
        {
            this.suggestedSongAlbumTitle = suggestedSongAlbumTitle;
            this.suggestedSongArtist = suggestedSongArtist;
            this.suggestedSongId = suggestedSongId;
            this.suggestedSongImagePath = suggestedSongImagePath;
            this.suggestedSongTitle = suggestedSongTitle;
        }





        public void Insert()
        {
            
            try
            {
                using (playlistEntities dc = new playlistEntities())
                {
                    tblSuggestedSong suggestedSong = new tblSuggestedSong();
                    suggestedSong.SuggestedSongId = Guid.NewGuid();
                    suggestedSong.SuggestedSongTitle = SongTitle;
                    suggestedSong.SuggestedSongArtist = Artist;
                    suggestedSong.SuggestedSongAlbumTitle = AlbumTitle;
                    suggestedSong.SuggestedSongImagePath = ImagePath;

                    dc.tblSuggestedSongs.Add(suggestedSong);
                    dc.SaveChanges();
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
                 
                  tblSuggestedSong songtable = dc.tblSuggestedSongs.Where(s => s.SuggestedSongId == SongId).FirstOrDefault();

                    if (songtable!= null)
                    {
                        dc.tblSuggestedSongs.Remove(songtable);

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

                    tblSuggestedSong song = dc.tblSuggestedSongs.FirstOrDefault(s => s.SuggestedSongId == guid);
                    if (song != null)
                    {
                        SongId = song.SuggestedSongId;
                        SongTitle = song.SuggestedSongTitle;
                        Artist = song.SuggestedSongArtist;
                        ImagePath = song.SuggestedSongImagePath;
                        AlbumTitle = song.SuggestedSongAlbumTitle;
                    }
                    else
                    {
                        throw new Exception("Couldn't find the row.");
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void LoadPlaylist(Guid guid)
        {

            try
            {
                playlistEntities dc = new playlistEntities();

                        var songs = from u in dc.tblUsers
                            join uss in dc.tblUserSuggestedSongs on guid equals uss.UserId
                            join s in dc.tblSuggestedSongs on uss.SuggestedSongId equals s.SuggestedSongId
                            
                            select new
                            {
                                s.SuggestedSongAlbumTitle,
                                s.SuggestedSongArtist,
                                s.SuggestedSongId,
                                s.SuggestedSongImagePath,
                                s.SuggestedSongTitle
                            };

                foreach (var s in songs)
                {
                     Song song = new Song(s.SuggestedSongAlbumTitle, s.SuggestedSongArtist, s.SuggestedSongId, s.SuggestedSongImagePath, s.SuggestedSongTitle);
                    songlist.Add(song);

                }




            }
            catch (Exception e)
            {

                throw e;
            }


        }
      
    }


}
