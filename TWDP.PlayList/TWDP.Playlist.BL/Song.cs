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
        //public List<Songs> { get; set; } **note to tim and dalton will make on tuesday


        public bool Insert()
        {
            int result = 0;
            try
            {
                using (playlistEntities dc = new playlistEntities())
                {
                    tblSuggestedSong suggestedSong = new tblSuggestedSong();
                    suggestedSong.SuggestedSongId = Guid.NewGuid();
                    suggestedSong.SuggestedSongTitle = this.SongTitle;
                    suggestedSong.SuggestedSongArtist = this.Artist;
                    suggestedSong.SuggestedSongAlbumTitle = this.AlbumTitle;
                    suggestedSong.SuggestedSongImagePath = this.ImagePath;

                    dc.tblSuggestedSongs.Add(suggestedSong);
                    result = dc.SaveChanges();
                }

                return result == 0 ? false : true;

            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

        //   HEY TIM, YOURE THE MAN. I ADDED THE DELETE BELOW JUST FOR SHITS AND GIGGLES. YOURE THE MAN :)
        public int Delete()
        {
            int results = 0;
            try
            {
                using (playlistEntities dc = new playlistEntities())
                {
                    var song = dc.tblSuggestedSongs.Where(a => a.SuggestedSongTitle == this.SuggestedSongTitle).FirstOrDefault();


                    tblSuggestedSong songtable = dc.tblSuggestedSongs.Where(m => m.SuggestedSongId == song.SuggestedSongTitle).FirstOrDefault();

                    if (song != null)
                    {
                        dc.tblSuggestedSongs.Remove(song);

                        results = dc.SaveChanges();
                    }
                    return results;
                }
            }
            catch (Exception ex)
            {
                return results;
                throw ex;
            }


        }


        public void LoadById()
        {
            try
            {
                using (playlistEntities dc = new playlistEntities())
                {
                    tblSuggestedSong song = dc.tblSuggestedSongs.FirstOrDefault(m => m.QId == this.SongId);
                    if (song != null)
                    {
                        this.SongId = song.SuggestedSongId;
                        this.SongTitle = song.SuggestedSongTitle;
                    }
                    else
                    {
                        throw new Exception("Couldn't find the row.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public class SongList : List<Song>
        {
            public void Load()
            {
                try
                {
                    using (playlistEntities dc = new playlistEntities())
                    {
                        dc.tblSuggestedSongs.ToList().ForEach(a => Add(new Song(a.SongId, a.SuggestedSongTitle)));
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }


        }
    }
}
