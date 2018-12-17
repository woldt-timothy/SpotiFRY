BEGIN

INSERT INTO tblSuggestedPlaylist(SuggestedPlaylistId, SuggestedPlaylistTitle, ImagePath)
VALUES
	(NEWID(), 'Best of Eric Clapton Playlist', 'https://images-na.ssl-images-amazon.com/images/I/71DQrKpImPL._SL1400_.jpg' ),
	(NEWID(), 'Best of Tom Petty Playlist',  'https://i.ytimg.com/vi/WoQUFbArlK0/hqdefault.jpg' ),
	(NEWID(), 'Best of Jack Mack and The Heart Attack Playlist',  'https://images-na.ssl-images-amazon.com/images/I/81BY1RNu7oL._SL1500_.jpg' ),
	(NEWID(), 'Best of Rush Playlist',  'https://images-na.ssl-images-amazon.com/images/I/510hrmXZVFL._SS500.jpg' )
END