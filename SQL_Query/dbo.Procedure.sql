CREATE PROCEDURE [dbo].User_CreateUser
	@UserName nvarchar(50),
	@Password nvarchar(50),
	@Role int,
	@Email nvarchar(50)
AS
	INSERT INTO dbo.[User]
	VALUES(@UserName, @Password, @Role, @Email)
