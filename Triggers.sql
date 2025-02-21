use LibraryManagement

CREATE TRIGGER trg_DecreaseAvailableCopies
ON Loans
AFTER INSERT
AS
BEGIN
    UPDATE Bibliographic_Materials
    SET Available_Copies = Available_Copies - 1
    FROM Bibliographic_Materials BM
    INNER JOIN Inserted I ON BM.Material_ID = I.Material_ID
    WHERE BM.Available_Copies > 0;
END;


CREATE TRIGGER trg_CheckMembershipStatus
ON Payments
AFTER INSERT
AS
BEGIN
    UPDATE Clients
    SET Membership_Active = 1
    FROM Clients C
    INNER JOIN Inserted I ON C.Client_ID = I.Client_ID
    WHERE C.Membership_Active = 0;
END;



CREATE TRIGGER trg_UpdatePenaltyFees
ON Loans
AFTER UPDATE
AS
BEGIN
    UPDATE Loans
    SET Penalty_Fee = DATEDIFF(DAY, Return_Date, Actual_Return_Date) * 1.00 -- Ndryshoni 1.00 në tarifën tuaj ditore
    WHERE Actual_Return_Date > Return_Date AND Penalty_Fee = 0.00;
END;



CREATE TRIGGER trg_IncreaseLoanCount
ON Loans
AFTER INSERT
AS
BEGIN
    UPDATE Clients
    SET Membership_Active = Membership_Active + 1
    FROM Clients C
    INNER JOIN Inserted I ON C.Client_ID = I.Client_ID;
END;



CREATE TRIGGER trg_AutoAddCopies
ON Bibliographic_Materials
AFTER UPDATE
AS
BEGIN
    IF EXISTS (
        SELECT 1 
        FROM Bibliographic_Materials
        WHERE Available_Copies = 0
    )
    BEGIN
        UPDATE Bibliographic_Materials
        SET Available_Copies = 5 -- Shtoni 5 kopje automatikisht
        WHERE Available_Copies = 0;
    END;
END;



CREATE TRIGGER trg_ArchiveOldLoans
ON Loans
AFTER UPDATE
AS
BEGIN
    DELETE FROM Loans
    WHERE Return_Date < DATEADD(YEAR, -1, GETDATE());
END;
