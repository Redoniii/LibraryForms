-- Pamje që shfaq klientët me status aktiv
CREATE VIEW ViewActiveClients AS
SELECT Client_ID, First_Name, Last_Name, Email, Phone, Address
FROM Clients
WHERE Membership_Active = 1;
GO

-- Pamje që shfaq klientët me status aktiv
CREATE VIEW Klientet_Aktive AS
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



-- Pamje që grupon materialet sipas llojit
CREATE VIEW ViewMaterialsGroupedByType AS
SELECT Material_Type, COUNT(*) AS TotalMaterials
FROM Bibliographic_Materials
GROUP BY Material_Type;
GO



-- Pamje për pagesat totale të klientëve
CREATE VIEW ViewTotalPaymentsPerClient AS
SELECT C.Client_ID, C.First_Name, C.Last_Name, SUM(P.Amount) AS TotalPayments
FROM Clients C
INNER JOIN Payments P ON C.Client_ID = P.Client_ID
GROUP BY C.Client_ID, C.First_Name, C.Last_Name;
GO


-- Pamje për pagesat totale të klientëve me Koh te caktuar
CREATE VIEW ViewTotalPaymentsPerClientWithTime AS
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


-- Përshkrimi: Kjo pamje tregon huazimet e klientëve të vonuar, përfshirë informacionet e tyre dhe materialet e huazuara.
CREATE VIEW Pamje_Huazimet_e_Klienteve_te_Vonuar AS
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


CREATE VIEW Pamje_Huazimet_e_Klienteve_te_Vonuar2 AS
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



-- Pamje për huazimet aktuale
CREATE VIEW ViewCurrentLoans AS
SELECT L.Loan_ID, C.First_Name, C.Last_Name, L.Material_ID, L.Loan_Date, L.Return_Date
FROM Loans L
INNER JOIN Clients C ON L.Client_ID = C.Client_ID
WHERE L.Actual_Return_Date IS NULL;
GO

-- Pamje për materialet më të huazuara
--CREATE VIEW ViewMostBorrowedMaterials AS
--SELECT BM.Material_ID, BM.Title, COUNT(L.Loan_ID) AS TotalLoans
--FROM Bibliographic_Materials BM
--INNER JOIN Loans L ON BM.Material_ID = L.Material_ID
--GROUP BY BM.Material_ID, BM.Title
--GO

