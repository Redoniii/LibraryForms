USE [master]
GO
/****** Object:  Database [LibraryManagement]    Script Date: 21/02/2025 14:17:33 ******/
CREATE DATABASE [LibraryManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LibraryManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\LibraryManagement.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LibraryManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\LibraryManagement_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [LibraryManagement] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LibraryManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LibraryManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LibraryManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LibraryManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LibraryManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LibraryManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [LibraryManagement] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [LibraryManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LibraryManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LibraryManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LibraryManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LibraryManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LibraryManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LibraryManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LibraryManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LibraryManagement] SET  ENABLE_BROKER 
GO
ALTER DATABASE [LibraryManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LibraryManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LibraryManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LibraryManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LibraryManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LibraryManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LibraryManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LibraryManagement] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [LibraryManagement] SET  MULTI_USER 
GO
ALTER DATABASE [LibraryManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LibraryManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LibraryManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LibraryManagement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [LibraryManagement] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [LibraryManagement] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [LibraryManagement] SET QUERY_STORE = ON
GO
ALTER DATABASE [LibraryManagement] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [LibraryManagement]
GO
/****** Object:  UserDefinedFunction [dbo].[CalculateTotalPenalties]    Script Date: 21/02/2025 14:17:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[CalculateTotalPenalties] (
    @ClientID INT,
    @DailyPenalty DECIMAL(10, 2)
)
RETURNS DECIMAL(10, 2)
AS
BEGIN
    RETURN (
        SELECT SUM(
            CASE 
                WHEN Actual_Return_Date > Return_Date THEN DATEDIFF(DAY, Return_Date, Actual_Return_Date) * @DailyPenalty
                ELSE 0 
            END
        )
        FROM Loans
        WHERE Client_ID = @ClientID
    );
END;
GO
/****** Object:  UserDefinedFunction [dbo].[GetAverageLoansPerClient]    Script Date: 21/02/2025 14:17:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[GetAverageLoansPerClient] ()
RETURNS DECIMAL(10, 2)
AS
BEGIN
    RETURN (
        SELECT CAST(COUNT(*) AS DECIMAL(10, 2)) / NULLIF(COUNT(DISTINCT Client_ID), 0)
        FROM Loans
    );
END;
GO
/****** Object:  UserDefinedFunction [dbo].[GetClientBalance]    Script Date: 21/02/2025 14:17:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[GetClientBalance] (
    @ClientID INT
)
RETURNS DECIMAL(10, 2)
AS
BEGIN
    DECLARE @TotalPenalties DECIMAL(10, 2);
    DECLARE @TotalPayments DECIMAL(10, 2);

    SELECT @TotalPenalties = ISNULL(SUM(Penalty_Fee), 0)
    FROM Loans
    WHERE Client_ID = @ClientID;

    SELECT @TotalPayments = ISNULL(SUM(Amount), 0)
    FROM Payments
    WHERE Client_ID = @ClientID;

    RETURN @TotalPenalties - @TotalPayments;
END;
GO
/****** Object:  UserDefinedFunction [dbo].[KalkuloDenimet]    Script Date: 21/02/2025 14:17:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[KalkuloDenimet] (
    @LoanID INT,
    @DailyPenalty DECIMAL(10, 2)
)
RETURNS DECIMAL(10, 2)
AS
BEGIN
    DECLARE @PenaltyFee DECIMAL(10, 2);
    DECLARE @DaysLate INT;

    SELECT @DaysLate = DATEDIFF(DAY, Return_Date, Actual_Return_Date)
    FROM Loans
    WHERE Loan_ID = @LoanID AND Actual_Return_Date > Return_Date;

    IF (@DaysLate > 0)
        SET @PenaltyFee = @DaysLate * @DailyPenalty;
    ELSE
        SET @PenaltyFee = 0.00;

    RETURN @PenaltyFee;
END;
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 21/02/2025 14:17:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[Client_ID] [int] IDENTITY(1,1) NOT NULL,
	[First_Name] [nvarchar](100) NOT NULL,
	[Last_Name] [nvarchar](100) NOT NULL,
	[Date_of_Birth] [date] NULL,
	[Email] [nvarchar](255) NULL,
	[Phone] [nvarchar](15) NULL,
	[Address] [nvarchar](255) NULL,
	[Membership_Active] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Client_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[ViewActiveClients]    Script Date: 21/02/2025 14:17:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Pamje që shfaq klientët me status aktiv
CREATE VIEW [dbo].[ViewActiveClients] AS
SELECT Client_ID, First_Name, Last_Name, Email, Phone, Address
FROM Clients
WHERE Membership_Active = 1;

GO
/****** Object:  Table [dbo].[Bibliographic_Materials]    Script Date: 21/02/2025 14:17:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bibliographic_Materials](
	[Material_ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](255) NOT NULL,
	[Author] [nvarchar](255) NOT NULL,
	[Co_Authors] [nvarchar](255) NULL,
	[Publisher] [nvarchar](255) NULL,
	[Publication_Date] [date] NULL,
	[ISBN] [nvarchar](13) NULL,
	[DOI] [nvarchar](50) NULL,
	[Material_Type] [nvarchar](50) NOT NULL,
	[Abstract] [nvarchar](max) NULL,
	[Available_Copies] [int] NOT NULL,
	[Date_Added] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Material_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[ViewMaterialsGroupedByType]    Script Date: 21/02/2025 14:17:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Pamje që grupon materialet sipas llojit
CREATE VIEW [dbo].[ViewMaterialsGroupedByType] AS
SELECT Material_Type, COUNT(*) AS TotalMaterials
FROM Bibliographic_Materials
GROUP BY Material_Type;

GO
/****** Object:  Table [dbo].[Payments]    Script Date: 21/02/2025 14:17:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[Payment_ID] [int] IDENTITY(1,1) NOT NULL,
	[Client_ID] [int] NOT NULL,
	[Amount] [decimal](10, 2) NOT NULL,
	[Payment_Date] [date] NOT NULL,
	[Payment_Type] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Payment_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[ViewTotalPaymentsPerClient]    Script Date: 21/02/2025 14:17:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Pamje për pagesat totale të klientëve
CREATE VIEW [dbo].[ViewTotalPaymentsPerClient] AS
SELECT C.Client_ID, C.First_Name, C.Last_Name, SUM(P.Amount) AS TotalPayments
FROM Clients C
INNER JOIN Payments P ON C.Client_ID = P.Client_ID
GROUP BY C.Client_ID, C.First_Name, C.Last_Name;

GO
/****** Object:  Table [dbo].[Loans]    Script Date: 21/02/2025 14:17:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Loans](
	[Loan_ID] [int] IDENTITY(1,1) NOT NULL,
	[Client_ID] [int] NOT NULL,
	[Material_ID] [int] NOT NULL,
	[Loan_Date] [date] NOT NULL,
	[Return_Date] [date] NOT NULL,
	[Actual_Return_Date] [date] NULL,
	[Penalty_Fee] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[Loan_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[ViewCurrentLoans]    Script Date: 21/02/2025 14:17:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Pamje për huazimet aktuale
CREATE VIEW [dbo].[ViewCurrentLoans] AS
SELECT L.Loan_ID, C.First_Name, C.Last_Name, L.Material_ID, L.Loan_Date, L.Return_Date
FROM Loans L
INNER JOIN Clients C ON L.Client_ID = C.Client_ID
WHERE L.Actual_Return_Date IS NULL;

GO
/****** Object:  UserDefinedFunction [dbo].[GetMostBorrowedMaterials]    Script Date: 21/02/2025 14:17:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[GetMostBorrowedMaterials] ()
RETURNS TABLE
AS
RETURN (
    SELECT TOP 10 Material_ID, COUNT(*) AS BorrowCount
    FROM Loans
    GROUP BY Material_ID
    ORDER BY BorrowCount DESC
);
GO
/****** Object:  UserDefinedFunction [dbo].[GetTopActiveClients]    Script Date: 21/02/2025 14:17:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[GetTopActiveClients] ()
RETURNS TABLE
AS
RETURN (
    SELECT TOP 10 Client_ID, COUNT(*) AS LoanCount
    FROM Loans
    GROUP BY Client_ID
    ORDER BY LoanCount DESC
);
GO
/****** Object:  View [dbo].[ViewTotalPaymentsPerClientWithTime]    Script Date: 21/02/2025 14:17:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Pamje për pagesat totale të klientëve me Koh te caktuar
CREATE VIEW [dbo].[ViewTotalPaymentsPerClientWithTime] AS
SELECT 
    C.Client_ID, 
    C.First_Name, 
    C.Last_Name, 
    SUM(P.Amount) AS TotalPayments,
    YEAR(P.Payment_Date) AS PaymentYear,   -- Viti i pagesës
    MONTH(P.Payment_Date) AS PaymentMonth -- Muaji i pagesës
FROM Clients C
INNER JOIN Payments P 
    ON C.Client_ID = P.Client_ID
GROUP BY 
    C.Client_ID, 
    C.First_Name, 
    C.Last_Name, 
    YEAR(P.Payment_Date), 
    MONTH(P.Payment_Date);
GO
/****** Object:  View [dbo].[Pamje_Huazimet_e_Klienteve_te_Vonuar]    Script Date: 21/02/2025 14:17:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Pamje_Huazimet_e_Klienteve_te_Vonuar] AS
SELECT 
    l.Loan_ID,
    c.First_Name AS Emri,
    c.Last_Name AS Mbiemri,
    bm.Title AS Materiali,
    l.Loan_Date AS Data_Huazimit,
    l.Return_Date AS Data_Kthimit,
    l.Actual_Return_Date AS Data_Real_Kthimit,
    DATEDIFF(DAY, l.Return_Date, ISNULL(l.Actual_Return_Date, GETDATE())) AS Dite_Vonese,
    l.Penalty_Fee AS Gjobe
FROM 
    Loans l
JOIN 
    Clients c ON l.Client_ID = c.Client_ID
JOIN 
    Bibliographic_Materials bm ON l.Material_ID = bm.Material_ID
WHERE 
    (l.Actual_Return_Date IS NULL AND l.Return_Date < GETDATE()) -- Jo të kthyer dhe të vonuar
    OR (l.Actual_Return_Date > l.Return_Date); -- Të kthyer me vonesë
GO
/****** Object:  View [dbo].[Pamje_Huazimet_e_Klienteve_te_Vonuar2]    Script Date: 21/02/2025 14:17:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Pamje_Huazimet_e_Klienteve_te_Vonuar2] AS
SELECT 
    l.Loan_ID,
    c.First_Name AS Emri,
    c.Last_Name AS Mbiemri,
    bm.Title AS Materiali,
    l.Loan_Date AS Data_Huazimit,
    l.Return_Date AS Data_Kthimit,
    l.Actual_Return_Date AS Data_Real_Kthimit,
    CASE
        WHEN l.Actual_Return_Date IS NULL THEN DATEDIFF(DAY, l.Return_Date, GETDATE())
        WHEN l.Actual_Return_Date > l.Return_Date THEN DATEDIFF(DAY, l.Return_Date, l.Actual_Return_Date)
        ELSE 0
    END AS Dite_Vonese,
    CASE
        WHEN l.Actual_Return_Date IS NULL THEN DATEDIFF(DAY, l.Return_Date, GETDATE()) * 1.00
        WHEN l.Actual_Return_Date > l.Return_Date THEN DATEDIFF(DAY, l.Return_Date, l.Actual_Return_Date) * 1.00
        ELSE 0.00
    END AS Gjobe_Automatike,
    l.Penalty_Fee AS Gjobe_Manuale,
    CASE 
        WHEN l.Actual_Return_Date IS NULL THEN 'Në Vonesë'
        WHEN l.Actual_Return_Date > l.Return_Date THEN 'I Kthyer me Vonesë'
        ELSE 'I Kthyer në Kohë'
    END AS Statusi
FROM 
    Loans l
JOIN 
    Clients c ON l.Client_ID = c.Client_ID
JOIN 
    Bibliographic_Materials bm ON l.Material_ID = bm.Material_ID
WHERE 
    (l.Actual_Return_Date IS NULL AND l.Return_Date < GETDATE())
    OR (l.Actual_Return_Date > l.Return_Date);
GO
/****** Object:  View [dbo].[Klientet_Aktive_MeKoh]    Script Date: 21/02/2025 14:17:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Klientet_Aktive_MeKoh] AS
SELECT
    c.Client_ID AS [ID_Klienti],
    c.First_Name AS [Emri],
    c.Last_Name AS [Mbiemri],
    MIN(COALESCE(l.Loan_Date, p.Payment_Date)) AS [Data_e_Regjistrimit],
    CASE 
        WHEN EXISTS (
            SELECT 1 
            FROM Loans l1 
            WHERE l1.Client_ID = c.Client_ID AND l1.Actual_Return_Date IS NULL
        ) THEN 'Aktiv'
        ELSE 'Jo Aktiv'
    END AS [Statusi]
FROM Clients c
LEFT JOIN Loans l ON c.Client_ID = l.Client_ID
LEFT JOIN Payments p ON c.Client_ID = p.Client_ID
WHERE COALESCE(l.Loan_Date, p.Payment_Date) IS NOT NULL
GROUP BY c.Client_ID, c.First_Name, c.Last_Name;
GO
/****** Object:  View [dbo].[Klientet_Aktive]    Script Date: 21/02/2025 14:17:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Klientet_Aktive] AS
SELECT
    c.Client_ID AS [ID_Klienti],
    c.First_Name AS [Emri],
    c.Last_Name AS [Mbiemri],
    MIN(COALESCE(l.Loan_Date, p.Payment_Date)) AS [Data_e_Regjistrimit],
    CASE 
        WHEN EXISTS (
            SELECT 1 
            FROM Loans l1 
            WHERE l1.Client_ID = c.Client_ID AND l1.Actual_Return_Date IS NULL
        ) 
        OR EXISTS (
            SELECT 1 
            FROM Payments p1
            WHERE p1.Client_ID = c.Client_ID
        ) THEN 'Aktiv'
        ELSE 'Jo Aktiv'
    END AS [Statusi]
FROM Clients c
LEFT JOIN Loans l ON c.Client_ID = l.Client_ID
LEFT JOIN Payments p ON c.Client_ID = p.Client_ID
GROUP BY c.Client_ID, c.First_Name, c.Last_Name;
GO
/****** Object:  View [dbo].[vViewTotalPaymentsPerClient]    Script Date: 21/02/2025 14:17:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vViewTotalPaymentsPerClient] AS
SELECT C.Client_ID, C.First_Name, C.Last_Name,P.Payment_Date, SUM(P.Amount) AS TotalPayments
FROM Clients C
INNER JOIN Payments P ON C.Client_ID = P.Client_ID
GROUP BY C.Client_ID, C.First_Name, C.Last_Name, P.Payment_Date;
GO
/****** Object:  Table [dbo].[Users]    Script Date: 21/02/2025 14:17:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[User_ID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](255) NOT NULL,
	[Role] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[User_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Bibliographic_Materials] ADD  DEFAULT (getdate()) FOR [Date_Added]
GO
ALTER TABLE [dbo].[Clients] ADD  DEFAULT ((1)) FOR [Membership_Active]
GO
ALTER TABLE [dbo].[Loans] ADD  DEFAULT (getdate()) FOR [Loan_Date]
GO
ALTER TABLE [dbo].[Loans] ADD  DEFAULT ((0.00)) FOR [Penalty_Fee]
GO
ALTER TABLE [dbo].[Payments] ADD  DEFAULT (getdate()) FOR [Payment_Date]
GO
ALTER TABLE [dbo].[Loans]  WITH CHECK ADD FOREIGN KEY([Client_ID])
REFERENCES [dbo].[Clients] ([Client_ID])
GO
ALTER TABLE [dbo].[Loans]  WITH CHECK ADD FOREIGN KEY([Material_ID])
REFERENCES [dbo].[Bibliographic_Materials] ([Material_ID])
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD FOREIGN KEY([Client_ID])
REFERENCES [dbo].[Clients] ([Client_ID])
GO
ALTER TABLE [dbo].[Bibliographic_Materials]  WITH CHECK ADD CHECK  (([Available_Copies]>=(0)))
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD CHECK  (([Amount]>=(0)))
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [chk_Role] CHECK  (([Role]='Biblotekar' OR [Role]='Admin'))
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [chk_Role]
GO
/****** Object:  StoredProcedure [dbo].[AddUser]    Script Date: 21/02/2025 14:17:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddUser]
    @Username NVARCHAR(100),
    @Password NVARCHAR(255),
    @Role NVARCHAR(50)
AS
BEGIN
    BEGIN TRY
        -- Kontrollo nëse Username ekziston
        IF EXISTS (SELECT 1 FROM Users WHERE Username = @Username)
        BEGIN
            RAISERROR('Ky Username ekziston tashmë.', 16, 1);
            RETURN;
        END

        -- Shto përdoruesin e ri
        INSERT INTO Users (Username, Password, Role)
        VALUES (@Username, @Password, @Role);

        -- Kthe ID-n e përdoruesit të sapo shtuar
        SELECT SCOPE_IDENTITY() AS User_ID;
    END TRY
    BEGIN CATCH
        -- Kap gabimet dhe kthe mesazhin e gabimit
        DECLARE @ErrorMessage NVARCHAR(4000);
        SET @ErrorMessage = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[CalculatePenaltyFee]    Script Date: 21/02/2025 14:17:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CalculatePenaltyFee]
    @LoanID INT,
    @PenaltyPerDay DECIMAL(10, 2)
AS
BEGIN
    DECLARE @DaysLate INT;

    SELECT @DaysLate = DATEDIFF(DAY, Return_Date, Actual_Return_Date)
    FROM Loans
    WHERE Loan_ID = @LoanID;

    IF @DaysLate > 0
    BEGIN
        UPDATE Loans
        SET Penalty_Fee = @DaysLate * @PenaltyPerDay
        WHERE Loan_ID = @LoanID;
    END
    ELSE
    BEGIN
        UPDATE Loans
        SET Penalty_Fee = 0
        WHERE Loan_ID = @LoanID;
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[GetAllBibliographicMaterials]    Script Date: 21/02/2025 14:17:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllBibliographicMaterials]
AS
BEGIN
    SELECT *
    FROM Bibliographic_Materials;
END;

GO
/****** Object:  StoredProcedure [dbo].[GetAllClients]    Script Date: 21/02/2025 14:17:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllClients]
AS
BEGIN
    SELECT *
    FROM Clients;
END;

GO
/****** Object:  StoredProcedure [dbo].[GetMaterialByISBN]    Script Date: 21/02/2025 14:17:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetMaterialByISBN]
    @ISBN NVARCHAR(13)
AS
BEGIN
    SELECT *
    FROM Bibliographic_Materials
    WHERE ISBN = @ISBN;
END;
GO
/****** Object:  StoredProcedure [dbo].[pppRegisterLoans]    Script Date: 21/02/2025 14:17:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pppRegisterLoans]
    @ClientID INT,
    @MaterialID INT,
    @LoanDate DATE,
    @ReturnDate DATE,
	@ActualReturnDate Date,
    @PenaltyFee DECIMAL(10, 2)
AS
BEGIN
    INSERT INTO Loans (Client_ID, Material_ID, Loan_Date, Return_Date, Actual_Return_Date,Penalty_Fee)
    VALUES (@ClientID, @MaterialID, @LoanDate, @ReturnDate, @ActualReturnDate,@PenaltyFee);

    SELECT SCOPE_IDENTITY() AS Loan_ID; -- Return the newly inserted Loan_ID
END
GO
/****** Object:  StoredProcedure [dbo].[ppRegisterLoans]    Script Date: 21/02/2025 14:17:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ppRegisterLoans]
    @ClientID INT,
    @MaterialID INT,
    @LoanDate DATE,
    @ReturnDate DATE,
    @PenaltyFee DECIMAL(10, 2)
AS
BEGIN
    INSERT INTO Loans (Client_ID, Material_ID, Loan_Date, Return_Date, Penalty_Fee)
    VALUES (@ClientID, @MaterialID, @LoanDate, @ReturnDate, @PenaltyFee);

    SELECT SCOPE_IDENTITY() AS Loan_ID; -- Return the newly inserted Loan_ID
END
GO
/****** Object:  StoredProcedure [dbo].[pRegisterLoans]    Script Date: 21/02/2025 14:17:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pRegisterLoans]
    @ClientID INT,
    @MaterialID INT,
	@Loan_Date Date,
	@ReturnDate DATE,
	@PenaltyFee decimal(10,2)
    
AS
BEGIN  
        INSERT INTO Loans (Client_ID, Material_ID, Loan_Date, Return_Date, Penalty_Fee)
        VALUES (@ClientID, @MaterialID, @Loan_Date, @ReturnDate, @PenaltyFee);
END;
GO
/****** Object:  StoredProcedure [dbo].[RegisterBibliographicMaterial]    Script Date: 21/02/2025 14:17:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RegisterBibliographicMaterial]
    @Title NVARCHAR(255),
    @Author NVARCHAR(255),
    @CoAuthors NVARCHAR(255) = NULL,
    @Publisher NVARCHAR(255) = NULL,
    @PublicationDate DATE = NULL,
    @ISBN NVARCHAR(13) = NULL,
    @DOI NVARCHAR(50) = NULL,
    @MaterialType NVARCHAR(50),
    @Abstract NVARCHAR(MAX) = NULL,
    @AvailableCopies INT
AS
BEGIN
    INSERT INTO Bibliographic_Materials (Title, Author, Co_Authors, Publisher, Publication_Date, ISBN, DOI, Material_Type, Abstract, Available_Copies)
    VALUES (@Title, @Author, @CoAuthors, @Publisher, @PublicationDate, @ISBN, @DOI, @MaterialType, @Abstract, @AvailableCopies);
END;

GO
/****** Object:  StoredProcedure [dbo].[RegisterClient]    Script Date: 21/02/2025 14:17:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RegisterClient]
    @FirstName NVARCHAR(100),
    @LastName NVARCHAR(100),
    @DateOfBirth DATE = NULL,
    @Email NVARCHAR(255) = NULL,
    @Phone NVARCHAR(15) = NULL,
    @Address NVARCHAR(255) = NULL
AS
BEGIN
    INSERT INTO Clients (First_Name, Last_Name, Date_of_Birth, Email, Phone, Address)
    VALUES (@FirstName, @LastName, @DateOfBirth, @Email, @Phone, @Address);
END;
GO
/****** Object:  StoredProcedure [dbo].[RegisterLoan]    Script Date: 21/02/2025 14:17:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RegisterLoan]
    @ClientID INT,
    @MaterialID INT,
    @ReturnDate DATE
AS
BEGIN
    DECLARE @AvailableCopies INT;

    SELECT @AvailableCopies = Available_Copies
    FROM Bibliographic_Materials
    WHERE Material_ID = @MaterialID;

    IF @AvailableCopies > 0
    BEGIN
        INSERT INTO Loans (Client_ID, Material_ID, Return_Date)
        VALUES (@ClientID, @MaterialID, @ReturnDate);

        UPDATE Bibliographic_Materials
        SET Available_Copies = Available_Copies - 1
        WHERE Material_ID = @MaterialID;
    END
    ELSE
    BEGIN
        RAISERROR ('Material not available', 16, 1);
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[RegisterLoans]    Script Date: 21/02/2025 14:17:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RegisterLoans]
    @ClientID INT,
    @MaterialID INT,
	@Loan_Date Date,
    @ReturnDate DATE
AS
BEGIN
    DECLARE @AvailableCopies INT;

    SELECT @AvailableCopies = Available_Copies
    FROM Bibliographic_Materials
    WHERE Material_ID = @MaterialID;

    IF @AvailableCopies > 0
    BEGIN
        INSERT INTO Loans (Client_ID, Material_ID, Loan_Date, Return_Date)
        VALUES (@ClientID, @MaterialID, @Loan_Date, @ReturnDate);

        UPDATE Bibliographic_Materials
        SET Available_Copies = Available_Copies - 1
        WHERE Material_ID = @MaterialID;
    END
    ELSE
    BEGIN
        RAISERROR ('Material not available', 16, 1);
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[RegisterPayment]    Script Date: 21/02/2025 14:17:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RegisterPayment]
    @ClientID INT,
    @Amount DECIMAL(10, 2),
    @PaymentType NVARCHAR(50)
AS
BEGIN
    INSERT INTO Payments (Client_ID, Amount, Payment_Type)
    VALUES (@ClientID, @Amount, @PaymentType);
END;
GO
/****** Object:  StoredProcedure [dbo].[RegisterPayments]    Script Date: 21/02/2025 14:17:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RegisterPayments]
    @ClientID INT,
    @Amount DECIMAL(10, 2),
    @PaymentType NVARCHAR(50),
	@PaymentDate DATE
AS
BEGIN
    INSERT INTO Payments (Client_ID, Amount, Payment_Type, Payment_Date)
    VALUES (@ClientID, @Amount, @PaymentType, @PaymentDate);
END;
GO
/****** Object:  StoredProcedure [dbo].[RegisterrLoan]    Script Date: 21/02/2025 14:17:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RegisterrLoan]
    @Client_ID INT,
    @Material_ID INT,
    @Loan_Date DATE,
    @Return_Date DATE,
    @Actual_Return_Date DATE = NULL, -- NULL if not returned yet
    @Penalty_Fee DECIMAL(10, 2) = 0 -- Default to 0 if no penalty
AS
BEGIN
    -- Declare the Loan_ID variable
    DECLARE @Loan_ID INT;

    -- Generate a new Loan_ID (assuming it's an auto-incremented ID or calculated)
    -- You could adjust this part if Loan_ID is auto-incremented in your table.
    -- If auto-increment is used, you don't need to manually insert Loan_ID
    SET @Loan_ID = (SELECT ISNULL(MAX(Loan_ID), 0) + 1 FROM Loans);

    -- Insert the new loan record into the Loans table
    INSERT INTO Loans (
        Loan_ID,
        Client_ID,
        Material_ID,
        Loan_Date,
        Return_Date,
        Actual_Return_Date,
        Penalty_Fee
    )
    VALUES (
        @Loan_ID,
        @Client_ID,
        @Material_ID,
        @Loan_Date,
        @Return_Date,
        @Actual_Return_Date,
        @Penalty_Fee
    );

    -- Optionally, you can return the Loan_ID for reference after the insert
    SELECT @Loan_ID AS NewLoanID;
END;
GO
/****** Object:  StoredProcedure [dbo].[RegisterTheLoans]    Script Date: 21/02/2025 14:17:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RegisterTheLoans]
    @ClientID INT,
    @MaterialID INT,
	@Loan_Date Date,
	@PenaltyFee decimal(10,2),
    @ReturnDate DATE
AS
BEGIN
    DECLARE @AvailableCopies INT;

    SELECT @AvailableCopies = Available_Copies
    FROM Bibliographic_Materials
    WHERE Material_ID = @MaterialID;

    IF @AvailableCopies > 0
    BEGIN
        INSERT INTO Loans (Client_ID, Material_ID, Loan_Date, Return_Date, Penalty_Fee)
        VALUES (@ClientID, @MaterialID, @Loan_Date, @ReturnDate, @PenaltyFee);

        UPDATE Bibliographic_Materials
        SET Available_Copies = Available_Copies - 1
        WHERE Material_ID = @MaterialID;
    END
    ELSE
    BEGIN
        RAISERROR ('Material not available', 16, 1);
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[UpdateClients]    Script Date: 21/02/2025 14:17:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateClients]
    @Client_ID INT,
    @First_Name NVARCHAR(50),
    @Last_Name NVARCHAR(50),
    @Date_of_Birth DATE,
    @Email NVARCHAR(100),
    @Phone NVARCHAR(20),
    @Address NVARCHAR(200),
    @Membership_Active NVARCHAR(10)
AS
BEGIN
    UPDATE Clients
       SET 
            First_Name = @First_Name,
            Last_Name = @Last_Name,
            Date_of_Birth = @Date_of_Birth,
            Email = @Email,
            Phone = @Phone,
            Address = @Address,
            Membership_Active = @Membership_Active
       WHERE 
          Client_ID = @Client_ID;
END;

GO
/****** Object:  StoredProcedure [dbo].[UpdateMaterial]    Script Date: 21/02/2025 14:17:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateMaterial]
    @Material_ID INT,
    @Title NVARCHAR(255) = NULL,
    @Author NVARCHAR(255) = NULL,
    @Co_Authors NVARCHAR(255) = NULL,
    @Publisher NVARCHAR(255) = NULL,
    @Publication_Date DATE = NULL,
    @ISBN NVARCHAR(13) = NULL,
    @DOI NVARCHAR(50) = NULL,
    @Material_Type NVARCHAR(50) = NULL,
    @Abstract NVARCHAR(MAX) = NULL,
    @Available_Copies INT = NULL
AS
BEGIN  
  -- Update the material
    UPDATE Bibliographic_Materials
    SET 
        Title = @Title,
        Author = @Author,
        Co_Authors = @Co_Authors,
        Publisher = @Publisher,
        Publication_Date = @Publication_Date,
        ISBN = @ISBN,
        DOI = @DOI,
        Material_Type = @Material_Type,
        Abstract = @Abstract,
        Available_Copies = @Available_Copies
    WHERE Material_ID = @Material_ID;
END;
GO
/****** Object:  StoredProcedure [dbo].[UpdateUsers]    Script Date: 21/02/2025 14:17:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateUsers]
    @UserID INT,
    @UserName NVARCHAR(50),
    @Password NVARCHAR(50),
    @Role NVARCHAR(50)
AS
BEGIN
    UPDATE Users
       SET 
            Username = @UserName,
            Password = @Password,
            Role = @Role
       WHERE 
          User_ID = @UserID;
END;
GO
/****** Object:  StoredProcedure [dbo].[VerifyUser]    Script Date: 21/02/2025 14:17:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[VerifyUser]
    @Username NVARCHAR(100),
    @Password NVARCHAR(255)
AS
BEGIN
    SELECT User_ID, Role
    FROM Users
    WHERE Username = @Username AND Password = @Password;
END;
GO
/****** Object:  StoredProcedure [dbo].[VerifyUserWithRole]    Script Date: 21/02/2025 14:17:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[VerifyUserWithRole]
    @Username NVARCHAR(100),
    @Password NVARCHAR(255),
    @Role NVARCHAR(50)
AS
BEGIN
    -- Set NOCOUNT ON to avoid extra result sets
    SET NOCOUNT ON;

    -- Check if the user exists with the given username, password, and role
    SELECT COUNT(*) AS UserCount
    FROM Users
    WHERE Username = @Username
      AND Password = @Password
      AND Role = @Role;
END;
GO
USE [master]
GO
ALTER DATABASE [LibraryManagement] SET  READ_WRITE 
GO
