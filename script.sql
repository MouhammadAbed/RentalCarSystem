USE [master]
GO
/****** Object:  Database [carRent]    Script Date: 10/19/2024 5:41:01 PM ******/
CREATE DATABASE [carRent]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'carRent', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\carRent.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'carRent_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\carRent_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [carRent] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [carRent].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [carRent] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [carRent] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [carRent] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [carRent] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [carRent] SET ARITHABORT OFF 
GO
ALTER DATABASE [carRent] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [carRent] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [carRent] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [carRent] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [carRent] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [carRent] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [carRent] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [carRent] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [carRent] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [carRent] SET  ENABLE_BROKER 
GO
ALTER DATABASE [carRent] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [carRent] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [carRent] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [carRent] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [carRent] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [carRent] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [carRent] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [carRent] SET RECOVERY FULL 
GO
ALTER DATABASE [carRent] SET  MULTI_USER 
GO
ALTER DATABASE [carRent] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [carRent] SET DB_CHAINING OFF 
GO
ALTER DATABASE [carRent] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [carRent] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [carRent] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [carRent] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'carRent', N'ON'
GO
ALTER DATABASE [carRent] SET QUERY_STORE = ON
GO
ALTER DATABASE [carRent] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [carRent]
GO
/****** Object:  UserDefinedFunction [dbo].[CalculateActualRentDays]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Function [dbo].[CalculateActualRentDays] (@ActualReturnDate datetime, @TransactionID int)  
returns int  
as  
begin  
declare @StartDate dateTime;  
 SET @StartDate =(select RentalBookings.BookingStartDate from RentalBookings  
 inner join RentalTransaction on RentalTransaction.booking_ID = RentalBookings.BookingID  
 inner join VehicleReturns on VehicleReturns.TransactionID = RentalTransaction.TransactionID  
 Where RentalTransaction.TransactionID = @TransactionID);  
  
 return DateDiff(Day,@startDate,@ActualReturnDate);  
 End;
GO
/****** Object:  UserDefinedFunction [dbo].[GetMileageBeforeRent]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Function [dbo].[GetMileageBeforeRent](@TransactionID int)
returns decimal(10,2)
as
begin
declare @MileageBeforeRent decimal (10,2)= (
	SElECT Vehicles.Milleage from RentalBookings 
	inner join Vehicles on Vehicles.VehicleID = RentalBookings.Vehicle_ID
	inner join RentalTransaction on RentalTransaction.booking_ID = RentalBookings.BookingID
	inner join VehicleReturns on VehicleReturns.TransactionID = RentalTransaction.TransactionID
	Where RentalTransaction.TransactionID = @TransactionID);
	return @MileageBeforeRent;
end;
GO
/****** Object:  UserDefinedFunction [dbo].[GetRenatlPricePerDay]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Function [dbo].[GetRenatlPricePerDay](@VehicleID int)
returns Decimal(10,2)
as
begin
declare @RentalPrice decimal(10,2);
SET @RentalPrice= (SELECT RentalRatePerDay from Vehicles Where VehicleID=@VehicleID)
return @RentalPrice
end;
GO
/****** Object:  UserDefinedFunction [dbo].[IsCarAvailabel]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Function [dbo].[IsCarAvailabel] (@VehicleID int)
returns bit
as
begin
Declare @IsAvailabel bit;
SET @IsAvailabel= (SElect IsAvailable from Vehicles Where VehicleID = @VehicleID);
return @IsAvailabel
end;
GO
/****** Object:  UserDefinedFunction [dbo].[isPersonExist]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[isPersonExist](@ID int)  
returns bit  
as  
begin  
declare @isFound bit;  
 set @IsFound =(SELECT Found = 1 From People  
 Where PersonID = @ID)  
 return @Isfound  
end;
GO
/****** Object:  UserDefinedFunction [dbo].[isPersonSetToACustomer]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[isPersonSetToACustomer]    
(@PersonID int)    
Returns bit    
As    
begin    
declare @isSetFor bit;
Select @isSetFor = 
Case 
When Count(*) > 0 then 1
Else 0
End 
From Customers
Where PersonID = @PersonID
 return @isSetFor;  
End;
GO
/****** Object:  UserDefinedFunction [dbo].[IsPersonSetToAuser]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[IsPersonSetToAuser](@PersonID int)
returns bit
as
begin
declare @isExist bit;
select @IsExist = 
case 
When Count(*) >0 Then 1
Else 0
End
From users
Where  personID = @PersonID;
return @isExist
end;
GO
/****** Object:  UserDefinedFunction [dbo].[isVehicleReturned]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[isVehicleReturned](@TransactionID INT)
RETURNS INT
AS
BEGIN
DECLARE @Found INT
SET @Found = (SELECT found = 1 FROM VehicleReturns
INNER JOIN RentalTransaction ON RentalTransaction.TransactionID=VehicleReturns.TransactionID
WHERE RentalTransaction.TransactionID=@TransactionID)
RETURN @Found
END;
GO
/****** Object:  Table [dbo].[Make]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Make](
	[MakeID] [int] IDENTITY(1,1) NOT NULL,
	[MakeName] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MakeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vehicles]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehicles](
	[VehicleID] [int] IDENTITY(1,1) NOT NULL,
	[MakeID] [int] NOT NULL,
	[Model] [varchar](100) NOT NULL,
	[Year] [int] NOT NULL,
	[Milleage] [decimal](18, 0) NOT NULL,
	[RentalRatePerDay] [smallmoney] NOT NULL,
	[PlateNumber] [varchar](10) NOT NULL,
	[VehicleCategory] [int] NOT NULL,
	[FueltypeID] [int] NOT NULL,
	[IsAvailable] [bit] NOT NULL,
	[ImagePath] [varchar](100) NULL,
 CONSTRAINT [PK__Vehicles__476B54B23F172C90] PRIMARY KEY CLUSTERED 
(
	[VehicleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ__Vehicles__03692624FB31F343] UNIQUE NONCLUSTERED 
(
	[PlateNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[VehiclesDescription_View]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE View [dbo].[VehiclesDescription_View] as
select v.vehicleID,vehicleInfo=M.MakeName+' '+v.Model+' '+ Cast (v.Year as varchar),v.IsAvailable  from Vehicles v
inner join Make M on M.MakeID = v.MakeID
GO
/****** Object:  Table [dbo].[FuelTypes]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FuelTypes](
	[FuelTypeID] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[FuelTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VehicleCategories]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VehicleCategories](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[vehileFullInfo_View]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[vehileFullInfo_View] as
SELECT        v.VehicleID, M.MakeName, v.Model, v.Year, v.Milleage, v.RentalRatePerDay, C.CategoryName, f.TypeName, v.PlateNumber, v.IsAvailable
FROM            dbo.Vehicles AS v INNER JOIN
                         dbo.FuelTypes AS f ON f.FuelTypeID = v.FueltypeID INNER JOIN
                         dbo.Make AS M ON M.MakeID = v.MakeID INNER JOIN
                         dbo.VehicleCategories AS C ON C.CategoryID = v.VehicleCategory
GO
/****** Object:  Table [dbo].[RentalTransaction]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RentalTransaction](
	[TransactionID] [int] IDENTITY(1,1) NOT NULL,
	[paidIntialTotalDueAmount] [decimal](10, 2) NULL,
	[paymentDetails] [varchar](50) NOT NULL,
	[ActualTotalDueAmount] [smallmoney] NULL,
	[TotalRemaining]  AS ([ActualTotalDueAmount]-[paidIntialTotalDueAmount]),
	[TransactionDate] [datetime] NOT NULL,
	[booking_ID] [int] NULL,
 CONSTRAINT [PK__RentalTr__55433A4BDFD00923] PRIMARY KEY CLUSTERED 
(
	[TransactionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RentalBookings]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RentalBookings](
	[BookingID] [int] IDENTITY(1,1) NOT NULL,
	[BookingStartDate] [datetime] NOT NULL,
	[BookingEndDate] [datetime] NOT NULL,
	[RentalPricePerDay] [smallmoney] NOT NULL,
	[intialRentalDays]  AS (datediff(day,[BookingStartDate],[BookingEndDate])),
	[intialDueAmount]  AS (datediff(day,[BookingStartDate],[BookingEndDate])*[RentalPricePerDay]),
	[PickUpLocaltion] [varchar](50) NULL,
	[DropOfLocation] [varchar](50) NULL,
	[InitialChekNotes] [varchar](300) NULL,
	[Vehicle_ID] [int] NULL,
	[CustomerID] [int] NULL,
	[UserID] [int] NULL,
 CONSTRAINT [PK__RentalBo__73951ACDA1E229BB] PRIMARY KEY CLUSTERED 
(
	[BookingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[GetRentDetails]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Function  [dbo].[GetRentDetails](@TransactionID int)  
returns Table  
as  
return(  
select v.VehicleID,v.Milleage,v.RentalRatePerDay,R.BookingStartDate from Vehicles v  
inner join RentalBookings R on R.Vehicle_ID=v.VehicleID  
inner join RentalTransaction rt on rt.booking_ID = R.BookingID  
Where rt.TransactionID=@TransactionID  
)
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[DriverLicenseID] [varchar](10) NULL,
	[PersonID] [int] NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[People]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[People](
	[PersonID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[SecondName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[PhoneNumber] [varchar](50) NOT NULL,
 CONSTRAINT [PK__Customer__A4AE64B8C9249DFE] PRIMARY KEY CLUSTERED 
(
	[PersonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[CustomerFullInfo]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[CustomerFullInfo] as 
SELECT c.CustomerID,c.PersonID,FullName = p.FirstName+' '+p.SecondName+' '+p.LastName,c.DriverLicenseID,p.PhoneNumber from Customers c
Inner join People p on p.PersonID = c.PersonID
GO
/****** Object:  Table [dbo].[Users]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[userID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](10) NOT NULL,
	[Password] [varchar](100) NOT NULL,
	[PersonID] [int] NOT NULL,
 CONSTRAINT [PK__Users__CB9A1CDF247DC4EC] PRIMARY KEY CLUSTERED 
(
	[userID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[UserFullInfo]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[UserFullInfo] as
 Select U.userID,U.userName,U.PersonID,p.FirstName,p.SecondName,p.LastName,p.PhoneNumber from Users U
 inner join People P on P.PersonID=U.PersonID;
GO
/****** Object:  View [dbo].[RentalBookingFullInfo]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create View [dbo].[RentalBookingFullInfo] As
select M.MakeName,FullName = P.FirstName+ ' '+P.SecondName+' '+P.LastName,U.userID,B.BookingID,B.BookingStartDate,B.BookingEndDate,B.RentalPricePerDay,B.intialRentalDays,B.intialDueAmount,B.PickUpLocaltion,
B.DropOfLocation,B.InitialChekNotes
from RentalBookings B Inner join Vehicles V on V.VehicleID=B.Vehicle_ID
inner join Make M on M.MakeID=V.MakeID
inner join Customers C on C.CustomerID = B.CustomerID
inner join People P on P.PersonID=C.PersonID
inner join Users U on U.userID=B.UserID
GO
/****** Object:  Table [dbo].[CarImages]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarImages](
	[ImageID] [int] IDENTITY(1,1) NOT NULL,
	[ImagePath] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ImageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Maintenances]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Maintenances](
	[MaintenanceID] [int] IDENTITY(1,1) NOT NULL,
	[Vehicle_ID] [int] NOT NULL,
	[MaintenanceDate] [date] NOT NULL,
	[Cost] [decimal](10, 2) NOT NULL,
	[MaintenanceDescription] [varchar](max) NOT NULL,
 CONSTRAINT [PK__Maintena__E60542B50862B7EA] PRIMARY KEY CLUSTERED 
(
	[MaintenanceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VehicleReturns]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VehicleReturns](
	[ReturnID] [int] IDENTITY(1,1) NOT NULL,
	[ActualReturnDate] [datetime] NOT NULL,
	[ActualRentDays] [int] NOT NULL,
	[CurrentMilleage] [int] NOT NULL,
	[ConsumedMilleage] [int] NOT NULL,
	[finallChekNotes] [varchar](300) NULL,
	[AdditionalCharges] [decimal](10, 2) NULL,
	[TransactionID] [int] NULL,
	[ActualDueAmount] [decimal](10, 2) NULL,
 CONSTRAINT [PK__VehicleR__F445E988EC57A411] PRIMARY KEY CLUSTERED 
(
	[ReturnID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Customers]  WITH CHECK ADD FOREIGN KEY([PersonID])
REFERENCES [dbo].[People] ([PersonID])
GO
ALTER TABLE [dbo].[Maintenances]  WITH CHECK ADD  CONSTRAINT [FK__Maintenan__Vehic__5CD6CB2B] FOREIGN KEY([Vehicle_ID])
REFERENCES [dbo].[Vehicles] ([VehicleID])
GO
ALTER TABLE [dbo].[Maintenances] CHECK CONSTRAINT [FK__Maintenan__Vehic__5CD6CB2B]
GO
ALTER TABLE [dbo].[RentalBookings]  WITH CHECK ADD FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customers] ([CustomerID])
GO
ALTER TABLE [dbo].[RentalBookings]  WITH CHECK ADD  CONSTRAINT [FK__RentalBoo__UserI__45BE5BA9] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([userID])
GO
ALTER TABLE [dbo].[RentalBookings] CHECK CONSTRAINT [FK__RentalBoo__UserI__45BE5BA9]
GO
ALTER TABLE [dbo].[RentalBookings]  WITH CHECK ADD  CONSTRAINT [FK__RentalBoo__Vehic__5EBF139D] FOREIGN KEY([Vehicle_ID])
REFERENCES [dbo].[Vehicles] ([VehicleID])
GO
ALTER TABLE [dbo].[RentalBookings] CHECK CONSTRAINT [FK__RentalBoo__Vehic__5EBF139D]
GO
ALTER TABLE [dbo].[RentalTransaction]  WITH CHECK ADD  CONSTRAINT [FK__RentalTra__booki__4D94879B] FOREIGN KEY([booking_ID])
REFERENCES [dbo].[RentalBookings] ([BookingID])
GO
ALTER TABLE [dbo].[RentalTransaction] CHECK CONSTRAINT [FK__RentalTra__booki__4D94879B]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK__Users__PersonID__44CA3770] FOREIGN KEY([PersonID])
REFERENCES [dbo].[People] ([PersonID])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK__Users__PersonID__44CA3770]
GO
ALTER TABLE [dbo].[VehicleReturns]  WITH CHECK ADD  CONSTRAINT [FK__VehicleRe__Trans__2B0A656D] FOREIGN KEY([TransactionID])
REFERENCES [dbo].[RentalTransaction] ([TransactionID])
GO
ALTER TABLE [dbo].[VehicleReturns] CHECK CONSTRAINT [FK__VehicleRe__Trans__2B0A656D]
GO
ALTER TABLE [dbo].[Vehicles]  WITH CHECK ADD  CONSTRAINT [FK__Vehicles__Fuelty__4222D4EF] FOREIGN KEY([FueltypeID])
REFERENCES [dbo].[FuelTypes] ([FuelTypeID])
GO
ALTER TABLE [dbo].[Vehicles] CHECK CONSTRAINT [FK__Vehicles__Fuelty__4222D4EF]
GO
ALTER TABLE [dbo].[Vehicles]  WITH CHECK ADD  CONSTRAINT [FK__Vehicles__MakeID__03F0984C] FOREIGN KEY([MakeID])
REFERENCES [dbo].[Make] ([MakeID])
GO
ALTER TABLE [dbo].[Vehicles] CHECK CONSTRAINT [FK__Vehicles__MakeID__03F0984C]
GO
ALTER TABLE [dbo].[Vehicles]  WITH CHECK ADD  CONSTRAINT [FK__Vehicles__Vehicl__412EB0B6] FOREIGN KEY([VehicleCategory])
REFERENCES [dbo].[VehicleCategories] ([CategoryID])
GO
ALTER TABLE [dbo].[Vehicles] CHECK CONSTRAINT [FK__Vehicles__Vehicl__412EB0B6]
GO
/****** Object:  StoredProcedure [dbo].[GetVehicleIDByMakeInfo]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[GetVehicleIDByMakeInfo]
@VehicleDescription varchar(100)
As
Begin
Declare @VehicleID int
SELECT @VehicleID = vehicleID from VehiclesDescription_View
Where vehicleinfo = @VehicleDescription
print @vehicleID
return @vehicleID
End;
GO
/****** Object:  StoredProcedure [dbo].[isVehicleExistByID]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[isVehicleExistByID]
@ID int 
as
begin
	declare @IsExist bit = 1;
	set @IsExist= (SELECT Found = 1 from Vehicles
	Where VehicleID = @ID);
	if @IsExist is null
		Set @IsExist = 0;
	return @IsExist;
end;
GO
/****** Object:  StoredProcedure [dbo].[pr_BookingFindInfo]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[pr_BookingFindInfo]
@BookingId int
AS
BEGIN
SELECT * FROM RentalBookings
Where BookingID=@BookingId;
END;
GO
/****** Object:  StoredProcedure [dbo].[pr_BookingGetAllvehicles]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[pr_BookingGetAllvehicles]
as
begin
select RentalBookings.BookingID,RentalBookings.BookingStartDate,BookingEndDate,RentalBookings.RentalPricePerDay,
RentalBookings.intialRentalDays,RentalBookings.intialDueAmount,RentalBookings.PickUpLocaltion,RentalBookings.DropOfLocation,
RentalBookings.InitialChekNotes,RentalBookings.Vehicle_ID,RentalBookings.CustomerID,RentalBookings.UserID
from RentalBookings
inner join Vehicles on vehicles.VehicleID = RentalBookings.Vehicle_ID
Where vehicles.IsAvailable=0;
End;
GO
/****** Object:  StoredProcedure [dbo].[pr_BookingNewVehicle]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[pr_BookingNewVehicle]  
@NewBookingID int output,      
@BookingStartDate datetime,      
@BookingEndDate datetime,      
@VehicleID int,      
@PickUpLocation varchar(50),      
@DropOfLocation varchar(50),      
@InitialCheckNote varchar(Max),      
@Customer_ID int,  
@User_ID int  
as      
begin      
declare @IsAvailableForRent bit = (select dbo.IsCarAvailabel(@VehicleID));      
if @IsAvailableForRent = 0      
begin      
 print 'Car is not available for rent';      
 return -1;      
end      
else      
begin      
 begin Transaction      
 begin Try      
       
  declare @RentalPricePerDay decimal(10,2);      
  set @RentalPricePerDay = dbo.GetRenatlPricePerDay(@VehicleID)      
      
  Insert Into RentalBookings (BookingStartDate,BookingEndDate,RentalPricePerDay,PickUpLocaltion,DropOfLocation,InitialChekNotes,CustomerID,Vehicle_ID,UserID)
  VALUES      
  (@BookingStartDate,@BookingEndDate,@RentalPricePerDay,@PickUpLocation,@DropOfLocation,@InitialCheckNote,@Customer_ID,@VehicleID,@User_ID);      
  SET @NewBookingID = SCOPE_IDENTITY();      
      
  --set car not available when car is booking
  update Vehicles      
  SET IsAvailable=0 Where VehicleID = @VehicleID;      
      
  --First way to get the intial due amount without using select statement    
  Declare @initialPaidTotalDueAmount decimal(10,2) = DateDiff(day,@BookingStartDate ,@BookingEndDate) * @RentalPricePerDay;    
  --second way to get the intial due amount using select statement    
  --Declare @@initialPaidTotalDueAmount decimal(10,2) = (Select *from RentalBookings where BookingID = @NewBookingID);    
  insert into RentalTransaction (paidIntialTotalDueAmount,paymentDetails,TransactionDate,booking_ID)    
  VALUES    
  (@initialPaidTotalDueAmount,'Cash',GETDATE(),@NewBookingID);    
    
  commit Transaction;      
      
  End Try      
  begin Catch      
  RollBack Transaction      
  set @NewBookingID=-1      
  end catch;      
  return @NewBookingID;      
  print Error_Message();      
end;    
end;
GO
/****** Object:  StoredProcedure [dbo].[pr_NewMaintenance]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[pr_NewMaintenance]
@NewMaintenanceID int output,
@VehicleID int,
@Description varchar(500),
@Cost Decimal
as
begin
	insert into Maintenances (Vehicle_ID,MaintenanceDate,Cost,MaintenanceDescription)
	VALUES
	(@VehicleID,GETDATE(),@Cost,@Description);
	SET @NewMaintenanceID =  scope_identity();
End
GO
/****** Object:  StoredProcedure [dbo].[pr_VehicleReturnFind]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[pr_VehicleReturnFind]
@ReturnID int
As
Begin
	SELECT * FROM VehicleReturns
	Where ReturnID = @ReturnID;
END;
GO
/****** Object:  StoredProcedure [dbo].[pr_VehicleReturnFindByTransactionId]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[pr_VehicleReturnFindByTransactionId]
@TransactionId int
As
Begin
 SELECT * FROM VehicleReturns
 Where TransactionID = @TransactionId;
END;
GO
/****** Object:  StoredProcedure [dbo].[prBooking_GetAllCurrentBookingVehicles]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[prBooking_GetAllCurrentBookingVehicles]  
As  
Begin  
 SELECT R.BookingID, c.FullName,v.MakeName,v.Model,v.Year,v.Milleage,v.RentalRatePerDay,
 R.BookingStartDate,R.BookingEndDate from vehileFullInfo_View v  
 inner join RentalBookings R ON R.vehicle_ID = v.VehicleID  
 inner join CustomerFullInfo C on C.CustomerID=R.CustomerID  
end;
GO
/****** Object:  StoredProcedure [dbo].[prCustomer_Delete]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[prCustomer_Delete]
@CustomerID int
As 
Begin
	Declare @PersonID int =(SELECT PersonID from Customers Where CustomerID=@CustomerID)
	delete from Customers Where CustomerID = @CustomerID;
	delete from People
	Where PersonID = @PersonID;
End;
GO
/****** Object:  StoredProcedure [dbo].[prCustomer_Find]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[prCustomer_Find]  
@CustomerID int  
as  
begin   
 Select * FROM Customers
 Where CustomerID = @CustomerID;  
end;
GO
/****** Object:  StoredProcedure [dbo].[prCustomer_FindByDrivingLicense]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[prCustomer_FindByDrivingLicense]
@DLId varchar(50)
as
begin
select * from Customers
Where DriverLicenseID=@DLId;
end;
GO
/****** Object:  StoredProcedure [dbo].[prCustomer_FindCustomerIdByFullName]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[prCustomer_FindCustomerIdByFullName]
@FullName varchar(100)  
AS
Begin
Declare @CustomerID int;
 select @CustomerID = CustomerID from CustomerFullInfo  
 Where FullName = @FullName  
 return @CustomerID;
End;
GO
/****** Object:  StoredProcedure [dbo].[prCustomer_GetAll]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[prCustomer_GetAll]
AS
BEGIN
	SELECT * FROM CustomerFullInfo;
END;
GO
/****** Object:  StoredProcedure [dbo].[prCustomer_GetAllCustomerName]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[prCustomer_GetAllCustomerName]
As
Begin
	select FullName from CustomerFullInfo;
end;
GO
/****** Object:  StoredProcedure [dbo].[prCustomer_isExist]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[prCustomer_isExist]
@CustomerID int
AS
BEGIN 
	declare @IsCustomerExist int;
	SET @IsCustomerExist = (SELECT Found = 0 From Customers Where CustomerID=@CustomerID);
	if @IsCustomerExist = 1
	set @IsCustomerExist = 1
	Else 
	set @IsCustomerExist = 0;
	return @IsCustomerExist;
END;
GO
/****** Object:  StoredProcedure [dbo].[prCustomer_Update]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[prCustomer_Update]     
@CustomerID int,
@DriverLicenseID varchar(10),
@PersonID int
as    
begin    
	update Customers
	SET DriverLicenseID=@DriverLicenseID,
		PersonID=@PersonID
		Where CustomerID=@CustomerID;
	return scope_identity();
end;
GO
/****** Object:  StoredProcedure [dbo].[prCustomers_Add]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[prCustomers_Add]        
@CustomerID int = -1 output,        
@DriverLicenseID varchar(10),        
@PersonID int        
As        
Begin        
	Declare @isPersonSetFor bit= (Select dbo.isPersonSetToACustomer(@PersonID));        
if @isPersonSetFor <> 1   
begin        
	insert into Customers (DriverLicenseID,PersonID)        
	VALUES        
	(@DriverLicenseID,@PersonID);      
	set @CustomerID=SCOPE_IDENTITY();      
end;
end;
GO
/****** Object:  StoredProcedure [dbo].[prPeope_AddNew]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[prPeope_AddNew]  
@NewPersonID int output,
@FirstName varchar(100),  
@LastName varchar(100), 
@SecondName varchar(100),
@PhoneNumber varchar(10)
as  
begin  
 insert into People(FirstName,SecondName,LastName,PhoneNumber)
 VALUES  
 (@FirstName,@SecondName,@LastName,@PhoneNumber)  
 set @NewPersonID=SCOPE_IDENTITY();  
 return @NewPersonID;  
end;
GO
/****** Object:  StoredProcedure [dbo].[prPeople_Add]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[prPeople_Add]  
@NewPersonID int output,  
@FirstName varchar(50),  
@SecondName varchar(50),  
@LastName varchar(50),  
@Phone varchar(10)  
as  
begin  
 Insert into People (FirstName,SecondName,LastName,PhoneNumber)  
 Values  
 (@FirstName,@SecondName,@LastName,@Phone)  
 SET @NewPersonID =  SCOPE_IDENTITY();  
end;
GO
/****** Object:  StoredProcedure [dbo].[prPeople_Delete]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[prPeople_Delete]   
@PersonID int   
as  
begin  
 delete from People  
 Where PersonID=@PersonID;  
 return @@Rowcount;  
end;
GO
/****** Object:  StoredProcedure [dbo].[prPeople_Find]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[prPeople_Find]
@PersonID int
as  
begin  
 select * from People  
 Where PersonID= @PersonID;
end;
GO
/****** Object:  StoredProcedure [dbo].[prPeople_GetAll]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[prPeople_GetAll]  
as    
begin   
 select * from People;  
end;
GO
/****** Object:  StoredProcedure [dbo].[prPeople_IsExist]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[prPeople_IsExist]
@PersonID int
as
begin 
declare @isExist int =(
Select Found=1 from People
Where PersonID=@PersonID)
return @IsExist
end;
GO
/****** Object:  StoredProcedure [dbo].[prPeople_IsPersonExist]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[prPeople_IsPersonExist]
@PersonID int
AS  
Begin  
 declare @FindCustomer bit;  
 Set @FindCustomer = (SELECT dbo.isPersonExist(@PersonID))  
 if @FindCustomer = null  
 begin   
 SET @FindCustomer=0  
 end;  
 return @FindCustomer;  
end;
GO
/****** Object:  StoredProcedure [dbo].[prPeople_UpdateInfo]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[prPeople_UpdateInfo]
@ID int ,
@FirstName varchar(50),
@secondName varchar(50),
@LastName varchar(50),
@Phone varchar(10)
as
begin
declare @IsPersonExist bit ;
declare @RowAffected int=0;
 set @IsPersonExist =(select dbo.isPersonExist(@ID));
 if @IsPersonExist = 1
 begin
 update People
 SET FirstName= @FirstName,
 SecondName=@secondName,
 LastName=@LastName,
 PhoneNumber= @Phone
 Where PersonID = @ID
 SET @RowAffected=@@ROWCOUNT;
 end;
 return @RowAffected;      
end;
GO
/****** Object:  StoredProcedure [dbo].[prTransaction_Find]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[prTransaction_Find]
@Transaction int
AS
BEGIN
	SELECT * FROM RentalTransaction
	Where TransactionID=@Transaction
END;
GO
/****** Object:  StoredProcedure [dbo].[prTransaction_GetAll]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



create Procedure [dbo].[prTransaction_GetAll]
As
Begin
select * from RentalTransaction
End;
GO
/****** Object:  StoredProcedure [dbo].[prTransaction_isVehicleReturned]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[prTransaction_isVehicleReturned]
@TransactionId int
AS
BEGIN
Declare @isReturned int
if dbo.isVehicleReturned (@TransactionId)=1
return 1
Else 
return 0
End;
GO
/****** Object:  StoredProcedure [dbo].[prUser_Add]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[prUser_Add]  
@user int output,
@UserName varchar(50),
@Password varchar(100),  
@PersonID int  
as  
begin  
Declare @IsPersonSetFroUser bit = dbo.IsPersonSetToAuser(@PersonID);  
Declare @IsPersonSetForCustomer bit = dbo.isPersonSetToACustomer(@PersonID);  
if @IsPersonSetForCustomer<>1 and @IsPersonSetFroUser<>1  
Begin  
 Insert into Users(UserName, Password,PersonID)  
 VALUES  
 (@UserName,@Password,@PersonID)  
 SET @User=SCOPE_IDENTITY();  
end
end;
GO
/****** Object:  StoredProcedure [dbo].[prUser_Delete]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[prUser_Delete]
@UserID int
As 
Begin
	Declare @PersonID int =(SELECT PersonID from Users Where userID=@UserID)
	delete from Users Where UserID = @UserID;
	delete from People
	Where PersonID = @PersonID;
End;
GO
/****** Object:  StoredProcedure [dbo].[prUser_Find]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CreaTe Procedure [dbo].[prUser_Find]
@UserID int
AS
bEGIN
	SELECT * FROM Users
	Where userID=@UserID;
END
GO
/****** Object:  StoredProcedure [dbo].[prUser_FindByPersonID]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create Procedure [dbo].[prUser_FindByPersonID]
@PersonID int
As
Begin 
	select * from Users
	Where PersonID=@PersonID;
end;
GO
/****** Object:  StoredProcedure [dbo].[prUser_FindByUserName]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[prUser_FindByUserName]
@UserName varchar(10)
As
Begin
	Select * from Users
	Where UserName=@UserName;
end;
GO
/****** Object:  StoredProcedure [dbo].[prUser_GetAll]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[prUser_GetAll]
AS
BEGIN
	SELECT * FROM UserFullInfo;
END;
GO
/****** Object:  StoredProcedure [dbo].[prUser_isExist]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[prUser_isExist]
@UserName varchar(10),    
@Password varchar(100)      
AS      
BEGIN      
 Declare @IsExist Bit;      
 SELECT @IsExist = (CASE      
 WHEN Count(*) >0 Then 1       
 ELSE 0      
 END )      
 From Users      
 Where UserName = @UserName and Password=@Password;      
 return @IsExist;    
END;
GO
/****** Object:  StoredProcedure [dbo].[PrUser_isUserNameExist]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[PrUser_isUserNameExist]
@userName varchar(10)
As
Begin
Declare @IsExist bit;
SELECT @IsExist = ( CASE 
When Count(*) > 0 Then 1
ELSE 0 
END) From Users Where UserName = @userName
return @IsExist
end;
GO
/****** Object:  StoredProcedure [dbo].[prUser_update]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  procedure [dbo].[prUser_update]
@userID int,
@UserName varchar(10),
@Password varchar(100)
AS
BEGIN
 UPDATE Users
 SET Password=@Password,
 UserName = @UserName
 WHERE userID=@userID
 return @@RowCount;  
END;
GO
/****** Object:  StoredProcedure [dbo].[prVehicle_AddNew]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[prVehicle_AddNew]     
@NewVehicleID int output,      
@MakeID int,      
@Model varchar(50),      
@Year int ,      
@Milleage decimal(10,2),      
@RentalPricePerDay decimal (10,2),      
@PlateNumber varchar(10),      
@VehicleCategoryID int,      
@FuelTypeID int,    
@ImagePath varchar(100)  
as      
begin      
 insert into Vehicles(MakeID,Model,Year,Milleage,RentalRatePerDay,PlateNumber,VehicleCategory,FueltypeID,IsAvailable,ImagePath)      
 VALUES      
 (@MakeID,@Model,@Year,@Milleage,@RentalPricePerDay,@PlateNumber,@VehicleCategoryID,@FuelTypeID,1,@ImagePath)      
 SET @NewVehicleID=SCOPE_IDENTITY();      
end;
GO
/****** Object:  StoredProcedure [dbo].[prVehicle_Find]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[prVehicle_Find]
@VehicleID int
as
begin 
	select * from Vehicles
	Where vehicleID =@VehicleID;
end;
GO
/****** Object:  StoredProcedure [dbo].[prVehicle_FindByPlateNumber]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[prVehicle_FindByPlateNumber]  
@PlateNumber varchar(50)  
as  
begin   
 select * from Vehicles  
 Where PlateNumber=@PlateNumber
end;
GO
/****** Object:  StoredProcedure [dbo].[prVehicle_FindVehicleByMakeName]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[prVehicle_FindVehicleByMakeName]
@MakeName varchar(100)
as 
begin
select * from Vehicles
inner join Make on Make.MakeID=vehicles.MakeID
Where Make.MakeName = @MakeName
end;
GO
/****** Object:  StoredProcedure [dbo].[prVehicle_Updated]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[prVehicle_Updated]       
@VehicleID int,      
@MakeID int,      
@Model varchar(50),      
@Year int,      
@Milleage decimal(10,2),      
@RentalRatePerDay decimal(10,2),      
@PlateNumber varchar(10),      
@VehicleCategoryID int,      
@FuelTypeID int,      
@IsAvailable bit,      
@ImagePath varchar(100)     
as      
begin      
 update Vehicles      
 SET       
 MakeID=@MakeID,Model=@Model,Year=@Year,Milleage=@Milleage,RentalRatePerDay=@RentalRatePerDay,PlateNumber=@PlateNumber      
 ,VehicleCategory=@VehicleCategoryID,FuelTypeID=@FuelTypeID,IsAvailable=@IsAvailable,ImagePath=@ImagePath     
 Where VehicleID = @VehicleID
 return @@RowCount;      
end;
GO
/****** Object:  StoredProcedure [dbo].[prVehilce_Delete]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[prVehilce_Delete]
@vehicleID int 
as
begin 
	declare @IsExist bit;
	execute @IsExist=isVehicleExistByID 
	@ID = @vehicleID;
	if @IsExist = 1
		begin
		delete from vehicles
		Where VehicleID=@vehicleID;
		return @IsExist
	end;
end;
GO
/****** Object:  StoredProcedure [dbo].[prVehilce_GetAll]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[prVehilce_GetAll]
as  
begin  
 Select * FROM vehileFullInfo_View  
end;
GO
/****** Object:  StoredProcedure [dbo].[prVehilce_GetAllAvailableCars]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[prVehilce_GetAllAvailableCars]
as  
begin  
 Select * FROM vehileFullInfo_View
 where IsAvailable=1;
end;
GO
/****** Object:  StoredProcedure [dbo].[stp_GetAllCarMaintenances]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_GetAllCarMaintenances]
as 
begin 
	select * from Maintenances
End;
GO
/****** Object:  StoredProcedure [dbo].[stp_GetAllFuelTypes]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[stp_GetAllFuelTypes]
as
begin
	select * from FuelTypes
end;
GO
/****** Object:  StoredProcedure [dbo].[stp_GetAllMakes]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[stp_GetAllMakes]
As 
Begin
select MakeName from Make
end;
GO
/****** Object:  StoredProcedure [dbo].[stp_GetAllVehicleCategories]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[stp_GetAllVehicleCategories]
As
Begin
Select * from VehicleCategories;
End;
GO
/****** Object:  StoredProcedure [dbo].[Stp_GetAllVehicleDescription]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Stp_GetAllVehicleDescription]
as
begin
	select vehicleInfo from VehiclesDescription_View
	Where IsAvailable=1;
end;
GO
/****** Object:  StoredProcedure [dbo].[stp_GetCarMaintenanceVehicleHistory]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_GetCarMaintenanceVehicleHistory]
@VehicleID int
as 
begin 
	select * from Maintenances
	Where Vehicle_ID=@VehicleID;
End;
GO
/****** Object:  StoredProcedure [dbo].[stp_GetFuleTypeByID]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[stp_GetFuleTypeByID] 
@ID int 
as
begin
	select * from FuelTypes
	Where FuelTypeID = @ID;
end;
GO
/****** Object:  StoredProcedure [dbo].[stp_GetFuleTypeByName]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[stp_GetFuleTypeByName]     
@TypeName Varchar(50)  
as    
begin    
 select * from FuelTypes    
 Where TypeName = @TypeName;    
end;
GO
/****** Object:  StoredProcedure [dbo].[Stp_GetMakesByID]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Stp_GetMakesByID]
@ID int 
as
begin
	SELECT * FROM Make
	Where MakeID = @ID;
end;
GO
/****** Object:  StoredProcedure [dbo].[Stp_GetMakesByName]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Stp_GetMakesByName]
@Make varchar(50)
as
begin
 SELECT * FROM Make
 Where MakeName = @Make;
end;
GO
/****** Object:  StoredProcedure [dbo].[stp_GetVehicleCategoryByID]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[stp_GetVehicleCategoryByID]
@ID int 
As
Begin
Select * from VehicleCategories
Where CategoryID =@ID
End;
GO
/****** Object:  StoredProcedure [dbo].[stp_GetVehicleCategoryByName]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[stp_GetVehicleCategoryByName]
@CategoryName varchar(50)
As  
Begin  
Select * from VehicleCategories  
Where CategoryName =@CategoryName
End;
GO
/****** Object:  StoredProcedure [dbo].[stp_updateRentalBooking]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[stp_updateRentalBooking]  
@RentalTransactionID int,  
@FinalTotalDueAmount decimal(10,2)  
as  
begin  
 update RentalTransaction   
 SET ActualTotalDueAmount = @FinalTotalDueAmount 
 Where TransactionID = @RentalTransactionID
 return @@Rowcount;
end;
GO
/****** Object:  StoredProcedure [dbo].[stp_UpdateVehicleMileage]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[stp_UpdateVehicleMileage]
@VID int ,
@ConsumedMileage decimal(10,2)
as
begin
update vehicles
SET Milleage=Milleage+@ConsumedMileage;
end;
GO
/****** Object:  StoredProcedure [dbo].[stp_WhenCarReturns]    Script Date: 10/19/2024 5:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[stp_WhenCarReturns]    
@VehicleReturnID int output,    
@TransactionID int ,          
@ActualReturnDate datetime,          
@CurrentMilleage decimal(10,2),          
@FinalCheckNotes varchar(Max),          
@AdditionalCharges decimal(10,2)=0
as
begin          
Declare @ActRentDays int;          
Declare @ConsumeMileage decimal(10,2);          
Declare @ActDueAmount decimal(10,2);          
declare @VehicleID int;        
declare @MilleageBeforeRent decimal(10,2);        
declare @StartDate datetime;        
declare @RentalRatePerDay decimal(10,2);        
begin Transaction     
begin try    
 select @VehicleID=VehicleID,@MilleageBeforeRent=Milleage,@StartDate = BookingStartDate,@RentalRatePerDay=RentalRatePerDay          
 from dbo.GetRentDetails(@TransactionID); --Get The attribute nedded from a table value function         
 set @ConsumeMileage = @CurrentMilleage-@MilleageBeforeRent;  
 set @ActRentDays= datediff(day,@StartDate,@ActualReturnDate);
 SET @ActDueAmount = (@ActRentDays * @RentalRatePerDay)+@AdditionalCharges;      
 insert into VehicleReturns (ActualReturnDate,ActualRentDays,CurrentMilleage,ConsumedMilleage,finallChekNotes,AdditionalCharges,TransactionID,ActualDueAmount)          
 VALUES     
 (@ActualReturnDate,@ActRentDays,@CurrentMilleage,@ConsumeMileage,@FinalCheckNotes,@AdditionalCharges,@TransactionID,@ActDueAmount);    
 set @VehicleReturnID = SCOPE_IDENTITY();    
 -- Procedure to update rentalTransaction to add the final total due amount    
 declare @ActualDueAmount decimal (10,2)=(Select ActualDueAmount from VehicleReturns where TransactionID= @TransactionID);    
 execute stp_updateRentalBooking    
 @RentalTransactionID=@TransactionID,    
 @FinalTotalDueAmount = @ActualDueAmount;    
     
        
--procedure to update care mileage after vehilce return;    
 execute stp_UpdateVehicleMileage    
 @VID=@VehicleID,    
 @ConsumedMileage=@ConsumeMileage  
    
 update vehicles    
 SET IsAvailable = 1    
 Where VehicleID=@VehicleID;    
 commit transaction    
 End Try    
 begin catch    
 RollBack Transaction    
 SET @VehicleReturnID = -1;    
 end catch;    
 end;
GO
USE [master]
GO
ALTER DATABASE [carRent] SET  READ_WRITE 
GO
