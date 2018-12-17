BEGIN
	INSERT INTO tblUser(UserId, Email, Password, FirstName, LastName, LoginId, SpotifyId)
	VALUES
		(NEWID(), 'jon@gmail.com', 'abc123', 'Jon', 'Bon Jovi', 'jonBoy', 'ToyMan'),
		(NEWID(), 'bob@gmail.com', 'def123' , 'Robert', 'Brown', 'bobbyBoy', 'RudyThaKid'),
		(NEWID(), 'dalton@gmail.com', 'ghi123' , 'Dalton', 'Palomis', 'PalomiSandwich', 'JimboJonesLikesD'),
		(NEWID(), 'woldt.timothy@gmail.com', 'maple' , 'Timothy', 'Woldt', 'woldtman', 'woldt.timothy')
	END