-- Procedurë për regjistrimin e një klienti të ri
CREATE PROCEDURE RegisterClient
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

-- Procedurë për llogaritjen e pagesës për vonesën
CREATE PROCEDURE CalculatePenaltyFee
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

-- Procedurë për të marrë materialin sipas ISBN
CREATE PROCEDURE GetMaterialByISBN
    @ISBN NVARCHAR(13)
AS
BEGIN
    SELECT *
    FROM Bibliographic_Materials
    WHERE ISBN = @ISBN;
END;
GO

use LibraryManagement

-- Procedurë për regjistrimin e një huazimi
CREATE PROCEDURE RegisterTheLoans
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

-- Procedurë për regjistrimin e një pagese
CREATE PROCEDURE RegisterPayment
    @ClientID INT,
    @Amount DECIMAL(10, 2),
    @PaymentType NVARCHAR(50)
AS
BEGIN
    INSERT INTO Payments (Client_ID, Amount, Payment_Type)
    VALUES (@ClientID, @Amount, @PaymentType);
END;
GO


CREATE PROCEDURE RegisterPayments
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

use LibraryManagement
SELECT * 
FROM sys.procedures 
WHERE name = 'spRegisterPayments';


-- Procedurë për të verifikuar nëse një përdorues ekziston
CREATE PROCEDURE VerifyUser
    @Username NVARCHAR(100),
    @Password NVARCHAR(255)
AS
BEGIN
    SELECT User_ID, Role
    FROM Users
    WHERE Username = @Username AND Password = @Password;
END;
GO


-- Procedurë për të verifikuar hyrjen e nje Useri
CREATE PROCEDURE VerifyUserWithRole
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

use LibraryManagement


CREATE PROCEDURE AddUser
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



CREATE PROCEDURE RegisterBibliographicMaterial
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



CREATE PROCEDURE UpdateClients
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

use LibraryManagement

CREATE PROCEDURE UpdateMaterial
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

use LibraryManagement

INSERT INTO Loans (Client_ID, Material_ID, Loan_Date, Return_Date, Penalty_Fee)
VALUES (1, 10, '2025-01-20', '2025-02-20', 5.00);

EXEC sp_help 'Loans';




CREATE PROCEDURE pppRegisterLoans
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


SELECT * FROM Loans WHERE Loan_ID = 9;


