BEGIN

	INSERT INTO tblUserSuggestedSong(UserSuggestedSongId, UserId, SuggestedSongId)

	VALUES
		(NEWID(), NEWID(), NEWID()),
		(NEWID(), NEWID(), NEWID()),
		(NEWID(), NEWID(), NEWID()),
		(NEWID(), NEWID(), NEWID())
	END