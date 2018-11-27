BEGIN
	INSERT INTO tblUser(UserId, Email, Password)
	VALUES
		(NEWID(), 'jon@gmail.com', 'abc123'),
		(NEWID(), 'bob@gmail.com', 'def123'),
		(NEWID(), 'dalton@gmail.com', 'ghi123'),
		(NEWID(), 'tom@gmail.com', 'jkl123')
	END