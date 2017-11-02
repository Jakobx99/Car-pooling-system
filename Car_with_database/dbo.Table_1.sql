CREATE TABLE [dbo].[Trip]
(
	[TripID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [startingAddress] VARCHAR(50) NOT NULL, 
    [startingZip] VARCHAR(50) NOT NULL, 
    [startingCity] VARCHAR(50) NOT NULL, 
    [destinationAddress] VARCHAR(50) NULL, 
    [destinationZip] VARCHAR(50) NOT NULL, 
    [destinationCity] VARCHAR(50) NOT NULL, 
    [time] DATETIME NOT NULL, 
    [driverID] INT NOT NULL, 
    [numberOfSeats] INT NOT NULL, 
    [passengerID] INT NOT NULL
)
