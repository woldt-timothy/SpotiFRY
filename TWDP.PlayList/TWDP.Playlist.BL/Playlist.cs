using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWDP.PlayList.PL;


namespace TWDP.Playlist.BL
{
    public class Playlist
    {
        public Guid SuggestedPlaylistId { get; set; }
        public string SuggestedPlaylistTitle { get; set; }
        public string ImagePath { get; set; }
        private Guid SuggestedPlayListId;
        private string SuggestedPlayListTitle;
        private string SuggestedPlayListImagePath;
        public List<Playlist> playlistList = new List<Playlist>();
        
        public Playlist()
        {

        }

        public Playlist(Guid suggestedPlaylistId, string suggestedPlaylistTitle, string imagePath)
        {
            SuggestedPlaylistId = suggestedPlaylistId;
            SuggestedPlaylistTitle = suggestedPlaylistTitle;
            ImagePath = imagePath;
        }

        public void Insert()
        {
            try
            {
                using (playlistEntities dc = new playlistEntities())
                {
                    tblSuggestedPlaylist suggestedPlayList = new tblSuggestedPlaylist();
                    suggestedPlayList.SuggestedPlaylistId = Guid.NewGuid();
                    suggestedPlayList.SuggestedPlaylistTitle= SuggestedPlaylistTitle;
                    suggestedPlayList.ImagePath= ImagePath;

                    dc.tblSuggestedPlaylists.Add(suggestedPlayList);
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
                    tblSuggestedPlaylist playlist = dc.tblSuggestedPlaylists.Where(sp => sp.SuggestedPlaylistId == SuggestedPlaylistId).FirstOrDefault();

                    if (playlist!= null)
                    {
                        dc.tblSuggestedPlaylists.Remove(playlist);

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
                    tblSuggestedPlaylist playlist = dc.tblSuggestedPlaylists.FirstOrDefault(sp => sp.SuggestedPlaylistId == guid);
                    if (playlist != null)
                    {
                        SuggestedPlaylistId = playlist.SuggestedPlaylistId;
                        SuggestedPlaylistTitle = playlist.SuggestedPlaylistTitle;
                        ImagePath = playlist.ImagePath;       
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

                var playlists = from usp in dc.tblUSPs
                            where usp.UserId == guid
                            join s in dc.tblSuggestedPlaylists on usp.SuggestedPlaylistId equals s.SuggestedPlaylistId

                            select new
                            {
                                s.SuggestedPlaylistTitle,
                                s.ImagePath,
                                s.SuggestedPlaylistId
                            };

                foreach (var s in playlists)
                {
                    Playlist playlist = new Playlist(s.SuggestedPlaylistId, s.SuggestedPlaylistTitle, s.ImagePath);
                    playlistList.Add(playlist);

                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}