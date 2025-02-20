CREATE FUNCTION KalkuloDenimet (
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


CREATE FUNCTION CalculateTotalPenalties (
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


CREATE FUNCTION GetClientBalance (
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

CREATE FUNCTION GetAverageLoansPerClient ()
RETURNS DECIMAL(10, 2)
AS
BEGIN
    RETURN (
        SELECT CAST(COUNT(*) AS DECIMAL(10, 2)) / NULLIF(COUNT(DISTINCT Client_ID), 0)
        FROM Loans
    );
END;


CREATE FUNCTION GetMostBorrowedMaterials ()
RETURNS TABLE
AS
RETURN (
    SELECT TOP 10 Material_ID, COUNT(*) AS BorrowCount
    FROM Loans
    GROUP BY Material_ID
    ORDER BY BorrowCount DESC
);

CREATE FUNCTION GetTopActiveClients ()
RETURNS TABLE
AS
RETURN (
    SELECT TOP 10 Client_ID, COUNT(*) AS LoanCount
    FROM Loans
    GROUP BY Client_ID
    ORDER BY LoanCount DESC
);


