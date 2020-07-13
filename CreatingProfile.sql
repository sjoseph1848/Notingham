use [1848notinghamdb]

CREATE TABLE dbo.StockProfile
(
	stockProfileId INT IDENTITY(1,1),
	symbol NVARCHAR(50) NOT NULL,
	price DECIMAL NOT NULL,
	BETA DECIMAL NOT NULL,
	volumeAvg INT NOT NULL,
	marketCap INT NOT NULL,
	lastDividend DECIMAL NOT NULL,
	pricerange NVARCHAR(50) NOT NULL,
	priceChanges DECIMAL NOT NULL,
	companyName NVARCHAR(50) NOT NULL,
	exchange NVARCHAR(50) NOT NULL,
	exchangeShortName NVARCHAR(50) NOT NULL,
	industry NVARCHAR(50) NOT NULL,
	website NVARCHAR(50) NOT NULL,
	companyDescription NVARCHAR(max), 
	ceo NVARCHAR(50),
	sector NVARCHAR(50),
	country NVARCHAR(50),
	fullTimeEmployees NVARCHAR(50),
	dcdiff DECIMAL,
	dcf DECIMAL,
	companyImage NVARCHAR(50),
	stockDate DATETIME
);

ALTER TABLE dbo.StockProfile ALTER COLUMN pricerange NVARCHAR(50) NULL
ALTER TABLE dbo.StockProfile ALTER COLUMN companyName NVARCHAR(50) NULL
ALTER TABLE dbo.StockProfile ALTER COLUMN companyImage NVARCHAR(max) NULL
ALTER TABLE dbo.StockProfile ALTER COLUMN BETA DECIMAL(8,6) NOT NULL
ALTER TABLE dbo.StockProfile ALTER COLUMN companyName NVARCHAR(200) NULL

ALTER TABLE dbo.StockProfile ALTER COLUMN price decimal(8,2) NOT NULL
ALTER TABLE dbo.Popularity ALTER COLUMN Name NVARCHAR(max) NOT NULL
ALTER TABLE dbo.StockProfile 
	ADD lastDividend decimal(6,3) NULL
ALTER TABLE dbo.StockProfile
	ADD Beta decimal(8,6) NULL
ALTER TABLE dbo.StockProfile ALTER COLUMN marketCap bigint NOT NULL
ALTER TABLE dbo.StockProfile ALTER COLUMN priceChanges decimal(5,2) NULL
ALTER TABLE dbo.StockProfile ALTER COLUMN dcdiff decimal(5,2) NULL
ALTER TABLE dbo.StockProfile ALTER COLUMN dcf decimal(5,2) NULL