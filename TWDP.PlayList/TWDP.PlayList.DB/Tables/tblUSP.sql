﻿CREATE TABLE [dbo].[tblUSP]
(
	[USPId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [UserId] UNIQUEIDENTIFIER NOT NULL, 
    [SuggestedPlaylistId] UNIQUEIDENTIFIER NOT NULL
)