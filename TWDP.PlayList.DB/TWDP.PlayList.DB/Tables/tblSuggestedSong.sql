CREATE TABLE [dbo].[tblSuggestedSong]
(
	[SuggestedSongId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [SuggestedSongTitle] VARCHAR(200) NOT NULL, 
    [SuggestedSongArtist] VARCHAR(200) NOT NULL, 
    [SuggestedSongAlbumTitle] VARCHAR(200) NOT NULL, 
    [SuggestedSongImagePath] VARCHAR(1000) NOT NULL
)
