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

-- Procedurë për regjistrimin e një huazimi
CREATE PROCEDURE RegisterLoan
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

CREATE PROCEDURE GetAllBibliographicMaterials
AS
BEGIN
    SELECT *
    FROM Bibliographic_Materials;
END;
GO

-- Procedurë për të marrë të gjithë klientët
CREATE PROCEDURE GetAllClients
AS
BEGIN
    SELECT *
    FROM Clients;
END;
GO
