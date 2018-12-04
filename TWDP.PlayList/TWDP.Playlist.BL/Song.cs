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

    }
}
