CREATE TABLE [dbo].[tblSuggestedPlaylist]
(
	[SuggestedPlaylistId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [SuggestedPlaylistTitle] VARCHAR(500) NOT NULL, 
    [ImagePath] VARCHAR(500) NOT NULL
)
