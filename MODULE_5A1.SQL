USE master
GO
IF EXISTS(SELECT * FROM sys.sysdatabases WHERE name='module5a')
DROP DATABASE module5a
GO
CREATE DATABASE module5a
GO
USE module5a
GO
CREATE TABLE Roles
(
	ID NVARCHAR(25) PRIMARY KEY,
	Title NVARCHAR(25)
)
GO
CREATE TABLE CabinTypes
(
	ID NVARCHAR(25) PRIMARY KEY,
	Name NVARCHAR(25)
)
CREATE TABLE Countries
(
	ID NVARCHAR(25) PRIMARY KEY,
	Name NVARCHAR(25)
)
CREATE TABLE Aircrafts(
	ID NVARCHAR(25) PRIMARY KEY,
	Name NVARCHAR(25),
	MakeModel NVARCHAR(25),
	TotalSeats INT,
	EconomySeats INT,
	BusinessSeats INT
)
CREATE TABLE Offices(
	ID NVARCHAR(25) PRIMARY KEY,
	CountryID NVARCHAR(25) CONSTRAINT fk_Offices_Countries FOREIGN KEY(CountryID) REFERENCES dbo.Countries(ID),
	Title NVARCHAR(25),
	Phone NVARCHAR(25),
	Contact NVARCHAR(25)
)
GO
CREATE TABLE Users(
	ID NVARCHAR(25) PRIMARY KEY,
	RoleID NVARCHAR(25) CONSTRAINT fk_Users_Roles FOREIGN KEY(RoleID) REFERENCES dbo.Roles(ID),
	OfficeID NVARCHAR(25) CONSTRAINT fk_Users_Offices FOREIGN KEY(OfficeID) REFERENCES dbo.Offices(ID),
	Email NVARCHAR(25),
	Password NVARCHAR(50),
	FirstName NVARCHAR(25),
	LastName NVARCHAR(25),
	BirthDate DATETIME,
	Active BIT
)
GO
CREATE TABLE Airport(
	ID NVARCHAR(25) PRIMARY KEY,
	CountryID NVARCHAR(25) CONSTRAINT fk_Country_Airport FOREIGN KEY(CountryID) REFERENCES dbo.Countries(ID),
	IATACode NVARCHAR(25),
	Name NVARCHAR(25)
)
GO
CREATE TABLE Routes(
	ID NVARCHAR(25) PRIMARY KEY,
	DepartureAirportID NVARCHAR(25) CONSTRAINT fk_Dep_Air FOREIGN KEY(DepartureAirportID) REFERENCES dbo.Airport(ID),
	ArrivalAirportID NVARCHAR(25) CONSTRAINT fk_Arr_Air FOREIGN KEY(ArrivalAirportID) REFERENCES dbo.Airport(ID),
	Distance FLOAT,
	FlightTime TIME
)
GO
CREATE TABLE Schedules(
	ID NVARCHAR(25) PRIMARY KEY,
	Date DATE,
	Time TIME,
	AircraftID NVARCHAR(25) CONSTRAINT fk_Schedules_Aircrafts FOREIGN KEY(AircraftID) REFERENCES dbo.Aircrafts(ID),
	RouteID NVARCHAR(25) CONSTRAINT fk_Schedules_Routes FOREIGN KEY(RouteID) REFERENCES dbo.Routes(ID),
	FlightNumber NVARCHAR(25),
	EconomyPrice MONEY,
	Confirmed BIT
)
GO
CREATE TABLE Tickets
(
	ID NVARCHAR(25) PRIMARY KEY,
	UserID NVARCHAR(25) CONSTRAINT fk_Tickets_Users FOREIGN KEY (UserID) REFERENCES dbo.Users(ID),
	ScheduleID NVARCHAR(25) CONSTRAINT fk_Tickets_Schedules FOREIGN KEY (ScheduleID) REFERENCES dbo.Schedules(ID),
	CabinType NVARCHAR(25) CONSTRAINT fk_Tickets_CabinTypes FOREIGN KEY (CabinType) REFERENCES dbo.CabinTypes(ID),
	FirstName NVARCHAR(25),
	LastName NVARCHAR(25),
	Phone NVARCHAR(25),
	PassportNumber NVARCHAR(25),
	PassportCountry NVARCHAR(25) CONSTRAINT fk_Tickets_Countries FOREIGN KEY (PassportCountry) REFERENCES dbo.Countries(ID),
	BookingReference NVARCHAR(25),
	Confirm BIT
)
CREATE TABLE Amenities
(
	ID NVARCHAR(25) PRIMARY KEY,
	AmenService NVARCHAR(25),
	Price FLOAT 
)
CREATE TABLE AmenitiesCabinType
(
	AmenitiesID NVARCHAR(25),
	CabinTypeID NVARCHAR(25),
	PRIMARY KEY (AmenitiesID,CabinTypeID),
	FOREIGN KEY (AmenitiesID) REFERENCES dbo.Amenities(ID),
	FOREIGN KEY (CabinTypeID) REFERENCES dbo.CabinTypes(ID)
)
CREATE TABLE AmenitiesTickets
(
	AmenitiesID NVARCHAR(25),
	TicketID NVARCHAR(25),
	Price FLOAT,
	PRIMARY KEY (AmenitiesID,TicketID),
	FOREIGN KEY (AmenitiesID) REFERENCES dbo.Amenities(ID),
	FOREIGN KEY (TicketID) REFERENCES dbo.Tickets(ID)
)
//----------//



GO
INSERT dbo.Roles VALUES('admin','administrator')
INSERT dbo.Roles VALUES('user','user')

GO
SELECT * FROM dbo.Roles
GO

INSERT dbo.Countries VALUES('VIE', 'VIETNAM')
INSERT dbo.Countries VALUES('USA', 'UNITED STATE OF AMERICA')
INSERT dbo.Countries VALUES('CHI', 'CHINA ')
INSERT dbo.Countries VALUES('HON', 'HONG KONG')
INSERT dbo.Countries VALUES('SWI', 'SWITZERLAND')
INSERT dbo.Countries VALUES('IRA', 'IRAN')
INSERT dbo.Countries VALUES('KOR', 'KOREA')
INSERT dbo.Countries VALUES('MAL', 'MALAYSIA')
INSERT dbo.Countries VALUES('THA', 'THAILAND')
INSERT dbo.Countries VALUES('JAP', 'JAPAN')
INSERT dbo.Countries VALUES('ITA', 'ITALIA')
INSERT dbo.Countries VALUES('FRA', 'FRANCE')
SELECT * FROM dbo.Countries
GO
INSERT INTO dbo.Aircrafts VALUES('B733', 'Boeing-733', 'Boeing', 150, 100, 50)
INSERT INTO dbo.Aircrafts VALUES('B792', 'Boeing-792', 'Boeing', 150, 100, 50)
INSERT INTO dbo.Aircrafts VALUES('B758', 'Boeing-758', 'Boeing', 150, 100, 50)
INSERT INTO dbo.Aircrafts VALUES('AN22', 'An-22', 'Antonov', 200, 120, 80)
INSERT INTO dbo.Aircrafts VALUES('AN24', 'An-24', 'Antonov', 200, 120, 80)
INSERT INTO dbo.Aircrafts VALUES('B710', 'Boeing-710', 'Boeing', 150, 100, 50)
INSERT INTO dbo.Aircrafts VALUES('B910', 'Boeing-910', 'Boeing', 200, 140, 60)
INSERT INTO dbo.Aircrafts VALUES('M370', 'MH-370', 'Boeing', 200, 140, 60)
INSERT INTO dbo.Aircrafts VALUES('M311', 'MH-311', 'Boeing', 200, 140, 60)
INSERT INTO dbo.Aircrafts VALUES('A320', 'Airbus A320', 'Airbus', 250, 200, 50)
INSERT INTO dbo.Aircrafts VALUES('A344', 'Airbus A344', 'Airbus', 250, 200, 50)
INSERT INTO dbo.Aircrafts VALUES('AN2', 'An-2', 'Antonov', 200, 120, 80)
INSERT INTO dbo.Aircrafts VALUES('M329', 'MH-329', 'Boeing', 200, 140, 60)
INSERT INTO dbo.Aircrafts VALUES('M443', 'MH-443', 'Boeing', 200, 140, 60)
SELECT * FROM dbo.Aircrafts
GO

INSERT dbo.Airport VALUES('NB', 'VIE', 'HAN', N'Nội Bài') 
INSERT dbo.Airport VALUES('TSN', 'VIE', 'HOC', N'Tân Sơn Nhất')
INSERT dbo.Airport VALUES('LEO', 'ITA', 'FCO', N'Leonardo')
INSERT dbo.Airport VALUES('ROI', 'FRA', 'CDG', N'Roissy')
INSERT dbo.Airport VALUES('BK', 'CHI', 'BEK', N'Bắc Kinh')
INSERT dbo.Airport VALUES('KUL', 'MAL', 'KUL', N' Kuala Lumpur')
INSERT dbo.Airport VALUES('SUV', 'THA', 'BKK', N'Suvarnabhumi')
INSERT dbo.Airport VALUES('HAN', 'JAP', 'HND', N'Haneda')
INSERT dbo.Airport VALUES('HKG', 'HON', 'HKG', N'Hồng Kông')
INSERT dbo.Airport VALUES('ZUR', 'SWI', 'ZRH', N'Zurich')
INSERT dbo.Airport VALUES('SHI', 'IRA', 'SYZ', N'Shiraz ')
INSERT dbo.Airport VALUES('HJA', 'USA', 'ATL', N'Hartsfield Jackson Atlanta')
INSERT dbo.Airport VALUES('OHA', 'USA', 'ORD', N'O-Hare')
INSERT dbo.Airport VALUES('CHEO', 'KOR', 'CJJ', N'Cheongju')
SELECT * FROM dbo.Airport INNER JOIN dbo.Countries ON Countries.ID = Airport.CountryID
GO
INSERT INTO dbo.Routes VALUES('route_12', 'SHI', 'HJA', 7000, '8:25:00')
INSERT INTO dbo.Routes VALUES('route_11', 'ZUR', 'HKG', 8000, '10:00:00')
INSERT INTO dbo.Routes VALUES('route_10', 'BK', 'SHI', 12500, '16:00:00')
INSERT INTO dbo.Routes VALUES('route_09', 'ROI', 'BK', 14000, '17:00:00')
INSERT INTO dbo.Routes VALUES('route_08', 'SUV', 'ZUR', 12000, '14:00:00')
INSERT INTO dbo.Routes VALUES('route_07', 'KUL', 'ROI', 4000, '5:25:00')
INSERT INTO dbo.Routes VALUES('route_06', 'CHEO', 'LEO', 7000, '8:25:00')
INSERT INTO dbo.Routes VALUES('route_05', 'HJA', 'HAN', 6000, '7:25:00')
INSERT INTO dbo.Routes VALUES('route_04', 'TSN', 'BK', 4000, '5:25:00')
INSERT INTO dbo.Routes VALUES('route_03', 'NB', 'ROI', 22500, '18:00:00')
INSERT INTO dbo.Routes VALUES('route_02', 'NB', 'OHA', 18000, '15:20:00')

GO
SELECT * FROM dbo.Routes
GO
GO
INSERT dbo.Schedules VALUES('S14', '01-01-2011', '11:20:00', 'A344', 'route_07', '109-203-011', 240, 0)
INSERT dbo.Schedules VALUES('S13', '02-10-2019', '12:10:00', 'B792', 'route_06', '201-001-872', 210, 0)
INSERT dbo.Schedules VALUES('S12', '05-20-2019', '12:40:00', 'A320', 'route_06', '576-091-201', 240, 0)
INSERT dbo.Schedules VALUES('S3', '11-10-2019', '12:00:00', 'B758', 'route_03', '111-231-210', 210, 1)
INSERT dbo.Schedules VALUES('S2', '11-10-2019', '09:00:00', 'B792', 'route_02', '320-381', 210, 1)
INSERT dbo.Schedules VALUES('S11', '03-10-2019', '05:40:00', 'AN2', 'route_02', '122-129', 225, 0)
INSERT dbo.Schedules VALUES('S10', '01-10-2019', '08:25:00', 'AN2', 'route_10', '122-129', 225, 0)
INSERT dbo.Schedules VALUES('S9', '07-12-2019', '06:00:00', 'AN22', 'route_09', '321-019', 225, 1)
INSERT dbo.Schedules VALUES('S8', '10-10-2019', '03:00:00', 'AN24', 'route_08', '321-019', 225, 1)
INSERT dbo.Schedules VALUES('S5', '12-08-2019', '08:00:00', 'M370', 'route_05', '201-211-256', 250, 1)
INSERT dbo.Schedules VALUES('S4', '10-11-2019', '07:00:00', 'B710', 'route_04', '551-092-322-118', 210, 1)
INSERT dbo.Schedules VALUES('S7', '04-08-2019', '04:00:00', 'A344', 'route_07', '322', 240, 1)
INSERT dbo.Schedules VALUES('S6', '03-10-2019', '03:00:00', 'A320', 'route_06', '102-908', 240, 1)


SELECT * FROM dbo.Schedules
GO

INSERT dbo.Offices VALUES('o7', 'JAP', N'Kirama', '29892911', 'anomic@kirama.com')
INSERT dbo.Offices VALUES('o6', 'JAP', N'Kirama', '29892911', 'anomic@kirama.com')
INSERT dbo.Offices VALUES('o5', 'THA', N'Singthon', '9892229', 'anomic@singthon.com')
INSERT dbo.Offices VALUES('o4', 'MAL', N'Rote', '8928881', 'anomic@rote.com')
INSERT dbo.Offices VALUES('o3', 'USA', N'Kamoric', '8519282', 'anomic@amoric.com')
INSERT dbo.Offices VALUES('o2', 'VIE', N'Doha', '19003210', 'anomic@doha.com')

GO
SELECT * FROM dbo.Offices
GO
INSERT dbo.Users VALUES('u9', 'admin', 'o6', N'kanuts@gmail.com', N'p11002',N'Harik', N'Shingk', '08-12-1985', 0)
INSERT dbo.Users VALUES('u8', 'user', 'o7', N'karits@gmail.com', N'p09201',N'Shit', N'Mary', '04-19-1980', 0)
INSERT dbo.Users VALUES('u7', 'user', 'o6', N'karibe@gmail.com', N'p10922',N'Mish', N'Karibe', '07-23-1992', 1)
INSERT dbo.Users VALUES('u6', 'user', 'o7', N'rotage@gmail.com', N'p09211',N'Cristia', N'Makup', '07-11-1990', 1)
INSERT dbo.Users VALUES('u5', 'admin', 'o6', N'resocdj@gmail.com', N'p41234',N'Taca', N'Shimit', '06-12-1998', 1)
INSERT dbo.Users VALUES('u4', 'user', 'o2', N'poteca@gmail.com', N'p28111',N'Hany', N'Lemmi', '06-12-1997', 1)
INSERT dbo.Users VALUES('u3', 'admin', 'o5', N'grandsing@gmail.com', N'p98211',N'Deviln', N'Rocoh', '06-13-1992', 1)
INSERT dbo.Users VALUES('u2', 'admin', 'o2', N'john_9@gmail.com', N'p29822',N'Bakam', N'John', '10-14-1997', 1)

GO
SELECT * FROM dbo.Users 

INSERT dbo.CabinTypes VALUES('A','2-CLASS-A')
INSERT dbo.CabinTypes VALUES('B','4-CLASS-B')
INSERT dbo.CabinTypes VALUES('C','3-CLASS-C')
INSERT dbo.CabinTypes VALUES('D','5-CLASS-D')
UPDATE CabinTypes SET Name = 'First class' WHERE ID = 'A'
UPDATE CabinTypes SET Name = 'Business class' WHERE ID = 'B'
UPDATE CabinTypes SET Name = 'Premium economy class' WHERE ID = 'C'
UPDATE CabinTypes SET Name = 'Economy class' WHERE ID = 'D'
SELECT * FROM CabinTypes

INSERT INTO dbo.Amenities VALUES('amt_01','BEER',0)
update Amenities set 
INSERT INTO dbo.Amenities VALUES('amt_02','LIVE AT 35',35)
INSERT INTO dbo.Amenities VALUES('amt_03','DIRECT TV',50)
INSERT INTO dbo.Amenities VALUES('amt_04','SLPPER',45)

UPDATE Amenities SET Price = 0 WHERE Amenities.ID = 'amt_04'
INSERT INTO dbo.Amenities VALUES('amt_05','DONT DISTURB',10)
INSERT INTO dbo.Amenities VALUES('amt_06','TURKISH COFFEE',15)
INSERT INTO dbo.Amenities VALUES('amt_07','SEAT-TO-SEAT CHAR',30)
INSERT INTO dbo.Amenities VALUES('amt_08','PLAYING CARD',50)

INSERT INTO dbo.Amenities VALUES('amt_10','ICE WHITE WATER',0)
INSERT INTO dbo.Amenities VALUES('amt_11','MAGAZINE',0)

SELECT * FROM Amenities

INSERT INTO AmenitiesCabinType VALUES('amt_01','A')
INSERT INTO AmenitiesCabinType VALUES('amt_02','A')
INSERT INTO AmenitiesCabinType VALUES('amt_03','A')
INSERT INTO AmenitiesCabinType VALUES('amt_04','A')
INSERT INTO AmenitiesCabinType VALUES('amt_05','A')

INSERT INTO AmenitiesCabinType VALUES('amt_10','A')
INSERT INTO AmenitiesCabinType VALUES('amt_01','B')
INSERT INTO AmenitiesCabinType VALUES('amt_02','B')
INSERT INTO AmenitiesCabinType VALUES('amt_03','B')
INSERT INTO AmenitiesCabinType VALUES('amt_04','B')
INSERT INTO AmenitiesCabinType VALUES('amt_01','C')
INSERT INTO AmenitiesCabinType VALUES('amt_05','C')
INSERT INTO AmenitiesCabinType VALUES('amt_08','C')
INSERT INTO AmenitiesCabinType VALUES('amt_01','D')
INSERT INTO AmenitiesCabinType VALUES('amt_02','D')
INSERT INTO AmenitiesCabinType VALUES('amt_08','D')
INSERT INTO AmenitiesCabinType VALUES('amt_07','D')
INSERT INTO AmenitiesCabinType VALUES('amt_06','D')

INSERT INTO AmenitiesCabinType VALUES('amt_10','D')
INSERT INTO AmenitiesCabinType VALUES('amt_11','D')

SELECT * FROM dbo.Users
SELECT * FROM dbo.Schedules
SELECT * FROM dbo.CabinTypes
SELECT * FROM dbo.Countries

INSERT INTO Tickets VALUES('0001','u2','S2','A','John','Wick','0123456789','11111111','VIE','01',1)
INSERT INTO Tickets VALUES('0002','u2','S3','B','Deviln','Rocoh','0123456789','22222222','KOR','01',0)
INSERT INTO Tickets VALUES('0003','u4','S2','A','Deviln','Rocoh','0123456789','33333333','FRA','02',1)
INSERT INTO Tickets VALUES('0004','u4','S4','C','Hany','Lemmi','0123456789','44444444','VIE','02',1)
INSERT INTO Tickets VALUES('0005','u5','S4','D','Taca','Shimit','0123456789','55555555','VIE','03',0)
INSERT INTO Tickets VALUES('0006','u6','S5','A','Cristia','Makup','0123456789','66666666','HON','03',1)
INSERT INTO Tickets VALUES('0007','u7','S2','C','Mish','Karibe','0123456789','77777777','JAP','03',1)
INSERT INTO Tickets VALUES('0008','u8','S4','B','Shit','Mary','0123456789','88888888','IRA','04',0)
INSERT INTO Tickets VALUES('0009','u9','S2','D','Harik','Shingk','0123456789','99999999','MAL','04',1)

DELETE FROM Tickets
SELECT * FROM Tickets

SELECT * FROM Amenities
SELECT * FROM Tickets

INSERT INTO AmenitiesTickets VALUES('amt_01','0011',20)
INSERT INTO AmenitiesTickets VALUES('amt_02','0011',35)



INSERT dbo.Schedules VALUES('S2000', '03-10-2019', '03:00:00', 'A320', 'route_06', '102-908', 240, 1)
INSERT dbo.Schedules VALUES('S2001', '03-10-2019', '03:00:00', 'A320', 'route_07', '102-908', 240, 1)
INSERT dbo.Schedules VALUES('S2010', '03-10-2019', '03:00:00', 'A320', 'route_08', '102-908', 240, 1)
DELETE FROM Tickets WHERE BookingReference = '04'
INSERT INTO Tickets VALUES('0011','u9','S2000','D','Ninh','Khuong Duy','0123456789','99999999','MAL','04',1)
INSERT INTO Tickets VALUES('0012','u2','S2001','B','Mai','Tien Tien ','0123456789','88888888','MAL','04',1)
UPDATE Tickets SET CabinType = 'A' WHERE Tickets.ID = '0012'
INSERT INTO Tickets VALUES('0013','u3','S2010','D','Nguyen','Ngoc Hai','0123456789','77777777','MAL','04',1)
SELECT * FROM AmenitiesTickets
DELETE FROM AmenitiesTickets



--SELECT * FROM Schedules
--SELECT * FROM Tickets WHERE BookingReference = '04'
--SELECT Tickets.ID,Tickets.ID+', '+Routes.ArrivalAirportID + '-' + Routes.DepartureAirportID + ', ' + CONVERT(NVARCHAR(10),Schedules.Date,103) + ', '+ CONVERT(NVARCHAR(5),Schedules.Time,8) AS INFO
--		FROM Tickets INNER JOIN Schedules ON Tickets.ScheduleID = Schedules.ID
--					 INNER JOIN Routes ON Schedules.RouteID = Routes.ID
--		WHERE BookingReference = '04'

--SELECT Schedules.Time FROM Schedules
--SELECT DATEDIFF(SECOND , FORMAT(GETDATE(),'HH:mm:ss'),Schedules.Time) + DATEDIFF(SECOND , FORMAT(GETDATE(),'yyyy/MM/dd'), Schedules.Date) AS DateDiff, Schedules.Time,  Schedules.Date FROM Schedules INNER JOIN Tickets ON Tickets.ScheduleID = Schedules.ID WHERE Tickets.ID = '0011'

--SELECT FORMAT(GETDATE(),'HH:mm:ss')
--SELECT Tickets.FirstName +' '+Tickets.LastName AS Fullname, Tickets.PassportNumber, CabinTypes.Name
--FROM Tickets INNER JOIN CabinTypes ON Tickets.CabinType = CabinTypes.ID
--WHERE Tickets.ID = '0011'

--SELECT Amenities.ID,Amenities.AmenService,Amenities.Price,AmenitiesTickets.Price AS PRICE_TICK_AMEN
--FROM Amenities INNER JOIN AmenitiesCabinType ON Amenities.ID = AmenitiesCabinType.AmenitiesID 
--				INNER JOIN Tickets ON AmenitiesCabinType.CabinTypeID = Tickets.CabinType 
--				LEFT JOIN AmenitiesTickets ON AmenitiesTickets.TicketID = Tickets.ID AND AmenitiesTickets.AmenitiesID = Amenities.ID
--WHERE Tickets.ID = '0012'

--SELECT * FROM AmenitiesCabinType WHERE CabinTypeID = 'D'

--SELECT * FROM AmenitiesCabinType ORDER BY CabinTypeID
--USE module5a
--GO			 
--SELECT * FROM AmenitiesTickets
DELETE FROM AmenitiesTickets


INSERT dbo.Schedules VALUES('S100', '12-12-2019', '03:00:00', 'A320', 'route_06', '111', 240, 1)
INSERT dbo.Schedules VALUES('S101', '12-12-2019', '03:00:00', 'A320', 'route_06', '222', 240, 1)

INSERT INTO Tickets VALUES('1111','u2','S100','A','John','Wick','0123456789','11111111','VIE','11',1)
INSERT INTO Tickets VALUES('2222','u2','S100','B','John','Wick','0123456789','11111111','VIE','11',1)
INSERT INTO Tickets VALUES('3333','u2','S100','C','John','Wick','0123456789','11111111','VIE','11',1)
INSERT INTO Tickets VALUES('4444','u2','S100','D','John','Wick','0123456789','11111111','VIE','11',1)

INSERT INTO Tickets VALUES('11111','u2','S101','A','John','Wick','0123456789','11111111','VIE','11',1)
INSERT INTO Tickets VALUES('22222','u2','S101','B','John','Wick','0123456789','11111111','VIE','11',1)
INSERT INTO Tickets VALUES('33333','u2','S101','C','John','Wick','0123456789','11111111','VIE','11',1)
INSERT INTO Tickets VALUES('44443','u2','S101','D','John','Wick','0123456789','11111111','VIE','11',1)

INSERT INTO Tickets VALUES('111111','u2','S100','A','John','Wick','0123456789','11111111','VIE','11',1)
INSERT INTO Tickets VALUES('222222','u2','S100','B','John','Wick','0123456789','11111111','VIE','11',1)
INSERT INTO Tickets VALUES('333333','u2','S100','C','John','Wick','0123456789','11111111','VIE','11',1)
INSERT INTO Tickets VALUES('444444','u2','S100','D','John','Wick','0123456789','11111111','VIE','11',1)


INSERT INTO AmenitiesTickets VALUES('amt_01','1111',0)
INSERT INTO AmenitiesTickets VALUES('amt_02','1111',0)
INSERT INTO AmenitiesTickets VALUES('amt_03','1111',0)
INSERT INTO AmenitiesTickets VALUES('amt_05','1111',0)

INSERT INTO AmenitiesTickets VALUES('amt_01','2222',0)
INSERT INTO AmenitiesTickets VALUES('amt_02','2222',0)
INSERT INTO AmenitiesTickets VALUES('amt_04','2222',0)

INSERT INTO AmenitiesTickets VALUES('amt_05','3333',0)
INSERT INTO AmenitiesTickets VALUES('amt_08','3333',0)

INSERT INTO AmenitiesTickets VALUES('amt_01','4444',0)
INSERT INTO AmenitiesTickets VALUES('amt_02','4444',0)
INSERT INTO AmenitiesTickets VALUES('amt_06','4444',0)
INSERT INTO AmenitiesTickets VALUES('amt_07','4444',0)
INSERT INTO AmenitiesTickets VALUES('amt_10','4444',0)
INSERT INTO AmenitiesTickets VALUES('amt_11','4444',0)

----------------------------------------------------------
INSERT INTO AmenitiesTickets VALUES('amt_01','111111',0)
INSERT INTO AmenitiesTickets VALUES('amt_02','111111',0)
INSERT INTO AmenitiesTickets VALUES('amt_03','111111',0)
INSERT INTO AmenitiesTickets VALUES('amt_04','111111',0)
INSERT INTO AmenitiesTickets VALUES('amt_05','111111',0)

INSERT INTO AmenitiesTickets VALUES('amt_01','222222',0)
INSERT INTO AmenitiesTickets VALUES('amt_02','222222',0)
INSERT INTO AmenitiesTickets VALUES('amt_03','222222',0)
INSERT INTO AmenitiesTickets VALUES('amt_04','222222',0)

INSERT INTO AmenitiesTickets VALUES('amt_01','333333',0)
INSERT INTO AmenitiesTickets VALUES('amt_05','333333',0)
INSERT INTO AmenitiesTickets VALUES('amt_08','333333',0)

INSERT INTO AmenitiesTickets VALUES('amt_01','444444',0)
INSERT INTO AmenitiesTickets VALUES('amt_02','444444',0)
INSERT INTO AmenitiesTickets VALUES('amt_06','444444',0)
INSERT INTO AmenitiesTickets VALUES('amt_07','444444',0)
INSERT INTO AmenitiesTickets VALUES('amt_11','444444',0)
----------------------------------------------------------

INSERT INTO AmenitiesTickets VALUES('amt_01','11111',0)
INSERT INTO AmenitiesTickets VALUES('amt_03','11111',0)
INSERT INTO AmenitiesTickets VALUES('amt_04','11111',0)
INSERT INTO AmenitiesTickets VALUES('amt_05','11111',0)

INSERT INTO AmenitiesTickets VALUES('amt_01','22222',0)
INSERT INTO AmenitiesTickets VALUES('amt_02','22222',0)
INSERT INTO AmenitiesTickets VALUES('amt_03','22222',0)
INSERT INTO AmenitiesTickets VALUES('amt_04','22222',0)

INSERT INTO AmenitiesTickets VALUES('amt_01','33333',0)
INSERT INTO AmenitiesTickets VALUES('amt_08','33333',0)

INSERT INTO AmenitiesTickets VALUES('amt_01','44443',0)
INSERT INTO AmenitiesTickets VALUES('amt_02','44443',0)
INSERT INTO AmenitiesTickets VALUES('amt_06','44443',0)
INSERT INTO AmenitiesTickets VALUES('amt_07','44443',0)
INSERT INTO AmenitiesTickets VALUES('amt_10','44443',0)
INSERT INTO AmenitiesTickets VALUES('amt_11','44443',0)

--SELECT ISNULL(S.SOLUONG, 0 ) AS SOLUONG FROM Amenities LEFT JOIN (
--SELECT AmenitiesTickets.AmenitiesID,Tickets.CabinType,COUNT(*) AS SOLUONG FROM AmenitiesTickets INNER JOIN Tickets ON AmenitiesTickets.TicketID = Tickets.ID LEFT JOIN Schedules ON Tickets.ScheduleID = Schedules.ID WHERE Tickets.CabinType = 'D' AND Schedules.FlightNumber = '111' GROUP BY AmenitiesTickets.AmenitiesID,Tickets.CabinType) S ON Amenities.ID  = S.AmenitiesID
--UNPIVOT(ORDERS FOR Amenities.ID IN (A,B,C) ) AS AUNPUT

--SELECT * FROM AmenitiesTickets INNER JOIN Tickets ON AmenitiesTickets.TicketID = Tickets.ID WHERE Tickets.CabinType = 'A'

--SELECT CabinTypes.Name FROM CabinTypes
--SELECT Amenities.AmenService FROM Amenities

--SELECT Schedules.FlightNumber FROM Schedules WHERE Schedules.Date = '2019-11-13'

UPDATE Schedules SET Date = DATEADD(day, 1, convert(date, GETDATE())),Time = GETDATE() WHERE ID LIKE '%S200%'

UPDATE Schedules SET Date = DATEADD(day, 1, convert(date, GETDATE())),Time = GETDATE() WHERE ID LIKE 'S4'
SELECT * FROM AmenitiesCabinType INNER JOIN Amenities ON AmenitiesCabinType.AmenitiesID = Amenities.ID WHERE CabinTypeID = 'B'
