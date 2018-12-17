CREATE TABLE [dbo].[tblSpotifyClientInformation]
(
	[SpotifyInformationId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [UserId] UNIQUEIDENTIFIER NOT NULL, 
    [SpotifyClientId] VARCHAR(400) NOT NULL, 
    [SpotifyClientSecret] VARCHAR(400) NOT NULL
)
