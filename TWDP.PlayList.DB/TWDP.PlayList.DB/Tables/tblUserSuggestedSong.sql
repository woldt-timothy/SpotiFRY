﻿CREATE TABLE [dbo].[tblUserSuggestedSong]
(
	[UserSuggestedSongId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [UserId] UNIQUEIDENTIFIER NOT NULL, 
    [SuggestedSongId] UNIQUEIDENTIFIER NOT NULL
)
