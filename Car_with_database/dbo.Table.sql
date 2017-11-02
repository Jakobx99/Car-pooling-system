CREATE TABLE [dbo].[User]
(
	[UserID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [userName] VARCHAR(50) NOT NULL, 
    [password] VARCHAR(50) NOT NULL, 
    [email] VARCHAR(50) NOT NULL, 
    [firstname] VARCHAR(50) NOT NULL, 
    [lastName] VARCHAR(50) NOT NULL, 
    [address] VARCHAR(50) NOT NULL, 
    [isDriver] BIT NOT NULL, 
    [phoneNumber] INT NOT NULL, 
    [Rating] FLOAT NOT NULL DEFAULT 3
)
