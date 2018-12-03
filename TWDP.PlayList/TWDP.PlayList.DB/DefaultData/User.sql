BEGIN
	INSERT INTO tblUser(UserId, Email, Password, FirstName, LastName, LoginId)
	VALUES
		(NEWID(), 'jon@gmail.com', 'abc123', 'Jon', 'Bon Jovi', 'jonBoy'),
		(NEWID(), 'bob@gmail.com', 'def123' , 'Robert', 'Brown', 'bobbyBoy'),
		(NEWID(), 'dalton@gmail.com', 'ghi123' , 'Dalton', 'Palomis', 'PalomiSandwich'),
		(NEWID(), 'tom@gmail.com', 'jkl123' , 'Tom', 'Petty', 'PettyThief')
	END