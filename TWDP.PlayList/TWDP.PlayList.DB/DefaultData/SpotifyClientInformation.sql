BEGIN
	INSERT INTO tblSpotifyClientInformation(SpotifyInformationId, UserId, SpotifyClientId, SpotifyClientSecret)
	VALUES
		(NEWID(), NEWID(), 'Hashed', 'Hashed'),
		(NEWID(), NEWID(), 'Hashed1', 'Hashed1'),
		(NEWID(), NEWID(), 'Hashed2', 'Hashed2'),
		(NEWID(), NEWID(), 'Hashed3', 'Hashed3')
	END