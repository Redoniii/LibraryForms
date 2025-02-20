SELECT * FROM Clients WHERE Client_ID = 13;
SELECT * FROM Bibliographic_Materials WHERE Material_ID = 16;

SELECT * FROM Loans WHERE Client_ID = 16 AND Material_ID = 16;


INSERT INTO Loans (Client_ID, Material_ID, Loan_Date, Return_Date, Actual_Return_Date, Penalty_Fee) 
VALUES (4, 12, '2024-02-15', '2024-03-01', '2024-03-07', 0.00);

delete from Loans

select * from loans

DBCC CHECKIDENT ('Loans', RESEED, 0);

delete from Loans where Actual_Return_Date = '2024-12-13'

