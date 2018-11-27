BEGIN

INSERT INTO tblSuggestedSong(SuggestedSongId, SuggestedSongTitle, SuggestedSongArtist, SuggestedSongAlbumTitle, SuggestedSongImagePath)
VALUES
	(NEWID(), 'Smells Like Teen Spirit', 'Nirvana', 'Nevermind', 'https://images-na.ssl-images-amazon.com/images/I/71DQrKpImPL._SL1400_.jpg' ),
	(NEWID(), 'Cocaine', 'Eric Clapton', 'Slowhand', 'https://i.ytimg.com/vi/WoQUFbArlK0/hqdefault.jpg' ),
	(NEWID(), 'All Along the Watchtower', 'Jimi Hendrix', 'Electric Ladyland', 'https://images-na.ssl-images-amazon.com/images/I/81BY1RNu7oL._SL1500_.jpg' ),
	(NEWID(), 'Round & Round', 'Jack Mack And The Heart Attack', '	The Best of Jack Mack & The Heart Attack', 'https://images-na.ssl-images-amazon.com/images/I/510hrmXZVFL._SS500.jpg' )
END