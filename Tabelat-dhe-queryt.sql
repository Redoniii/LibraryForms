CREATE DATABASE LibraryManagement;
GO

USE LibraryManagement;
GO

DBCC CHECKIDENT ('Loans', RESEED, 0);



-- Insert 15 new rows into Bibliographic_Materials
INSERT INTO Bibliographic_Materials  
(Title, Author, Co_Authors, Publisher, Publication_Date, ISBN, DOI, Material_Type, Abstract, Available_Copies) 
VALUES
('E Drejta Nd�rkomb�tare', 'Shk�lzen Gashi', NULL, 'Jurisprudenca Moderne', '2021-03-15', '9781111111111', '10.0001/law.001', 'Book', 'Lib�r mbi t� drejt�n nd�rkomb�tare.', 10),
('Filozofia e Jet�s', 'Blerina Krasniqi', 'Erion Deda', 'Botime Shkencore', '2020-07-21', '9782222222222', '10.0002/philo.002', 'Book', 'Ese mbi filozofin� e jet�s dhe etik�n.', 5),
('Astronomia p�r Fillestar�', 'Dardan Xhemajli', NULL, 'Universi', '2023-01-10', '9783333333333', '10.0003/astro.003', 'Book', 'Udh�zues mbi astronomin� p�r fillestar�.', 12),
('Gjuha Shqipe dhe Let�rsia', 'Xhevdet Bajraktari', 'Lindita Sejdiu', 'Sht�pia e Librit', '2022-09-15', '9784444444444', '10.0004/lit.004', 'Book', 'Tekst m�simor p�r shkollat e mesme.', 7),
('Programimi n� Python', 'Gentian Krasniqi', NULL, 'Softueri Modern', '2021-11-30', '9785555555555', '10.0005/prog.005', 'Book', 'Lib�r p�r m�simin e Python.', 15),
('Biologjia p�r Nx�n�sit', 'Flutura Gashi', NULL, 'Dituria', '2023-05-20', '9786666666666', '10.0006/bio.006', 'Book', 'Material p�r nx�n�s mbi biologjin�.', 10),
('Fizika Moderne', 'Blerim Isufi', 'Edona Zogaj', 'Akademia', '2020-02-14', '9787777777777', '10.0007/phys.007', 'Book', 'Lib�r p�r fizik�n moderne.', 6),
('Historia Bot�rore', 'Edon Ahmeti', NULL, 'Botime Nd�rkomb�tare', '2021-08-12', '9788888888888', '10.0008/hist.008', 'Book', 'Nj� pasqyr� mbi historin� bot�rore.', 8),
('Matematika Diskrete', 'Alban Kelmendi', NULL, 'Numrat', '2022-10-01', '9789999999999', '10.0009/math.009', 'Book', 'Lib�r mbi matematik�n diskrete.', 9),
('Ekonomia Moderne', 'Arta Sadiku', NULL, 'Tregu Global', '2019-04-25', '9781212121212', '10.0010/econ.010', 'Book', 'Studim mbi ekonomin� moderne.', 5),
('Robotika p�r F�mij�', 'Dren Thaqi', NULL, 'Teknologjia e Re', '2023-06-10', '9782323232323', '10.0011/robot.011', 'Book', 'Udh�zues p�r robotik�n p�r f�mij�.', 10),
('Kriptografia dhe Siguria', 'Lea Hoxha', NULL, 'Teknologji Siguri', '2022-12-12', '9783434343434', '10.0012/crypto.012', 'Book', 'Lib�r mbi kriptografin� dhe sigurin�.', 7),
('Algoritmet e Avancuara', 'Artan Selimi', NULL, 'Inxhinieria e T� Dh�nave', '2021-03-18', '9784545454545', '10.0013/alg.013', 'Book', 'Lib�r mbi algoritmet e avancuara.', 12),
('Gjeopolitika e Rajonit', 'Bekim Hoxha', 'Valmir Gashi', 'Strategjia Globale', '2020-11-15', '9785656565656', '10.0014/geo.014', 'Book', 'Studim mbi gjeopolitik�n e rajonit.', 10),
('Psikologjia Pozitive', 'Leonard Shala', 'Flaka Miftari', 'Shkenca e Shpirtit', '2023-02-20', '9786767676767', '10.0015/psy.015', 'Book', 'Lib�r mbi psikologjin� pozitive.', 10);

-- Insert 15 new rows into Clients
INSERT INTO Clients 
(First_Name, Last_Name, Date_of_Birth, Email, Phone, Address, Membership_Active) 
VALUES
('Arjeta', 'Sadiku', '1994-03-25', 'arjeta.sadiku@example.com', '045987654', 'Prishtin�, Kosov�', 1),
('Behar', 'Morina', '1989-06-12', 'behar.morina@example.com', '046123456', 'Mitrovic�, Kosov�', 0),
('Gresa', 'Luma', '1997-01-18', 'gresa.luma@example.com', '048654987', 'Tiran�, Shqip�ri', 1),
('Alban', 'Berisha', '1995-05-05', 'alban.berisha@example.com', '049789654', 'Ferizaj, Kosov�', 1),
('Erisa', 'Nikolli', '1992-11-09', 'erisa.nikolli@example.com', '046546879', 'Durr�s, Shqip�ri', 1),
('Hysen', 'Rama', '1986-02-21', 'hysen.rama@example.com', '045231456', 'Pej�, Kosov�', 1),
('Jonida', 'Gjinaj', '1998-08-08', 'jonida.gjinaj@example.com', '048987321', 'Shkod�r, Shqip�ri', 0),
('Ardit', 'Zeqiri', '1993-04-12', 'ardit.zeqiri@example.com', '049987654', 'Prizren, Kosov�', 1),
('Blerim', 'Avdulli', '1990-12-30', 'blerim.avdulli@example.com', '046123789', 'Fier, Shqip�ri', 1),
('Sara', 'Gjini', '1999-07-07', 'sara.gjini@example.com', '049432109', 'Lezh�, Shqip�ri', 1),
('Valon', 'Hoti', '1988-10-10', 'valon.hoti@example.com', '045678123', 'Gjilan, Kosov�', 1),
('Ledina', 'Miftari', '1991-09-09', 'ledina.miftari@example.com', '048345987', 'Vlor�, Shqip�ri', 1),
('Kreshnik', 'Shala', '1987-03-03', 'kreshnik.shala@example.com', '045987321', 'Podujev�, Kosov�', 0),
('Florian', 'Gjoka', '1992-01-01', 'florian.gjoka@example.com', '049765432', 'Berat, Shqip�ri', 1),
('Elira', 'Selimi', '1996-12-12', 'elira.selimi@example.com', '046543987', 'Gjakov�, Kosov�', 1);

-- Insert 15 new rows into Loans
INSERT INTO Loans 
(Client_ID, Material_ID, Loan_Date, Return_Date, Actual_Return_Date, Penalty_Fee) 
VALUES
(11, 1, '2025-01-01', '2025-01-14', NULL, 0.00),
(12, 2, '2025-01-05', '2025-01-20', NULL, 0.00),
(13, 3, '2025-01-10', '2025-01-25', NULL, 0.00),
(14, 4, '2025-01-12', '2025-01-26', NULL, 0.00),
(15, 5, '2025-01-15', '2025-01-29', NULL, 0.00),
(11, 6, '2025-01-20', '2025-02-03', '2025-02-04', 2.00),
(12, 7, '2025-01-22', '2025-02-05', NULL, 0.00),
(13, 8, '2025-01-25', '2025-02-08', NULL, 0.00),
(14, 9, '2025-01-28', '2025-02-11', '2025-02-12', 3.50),
(15, 10, '2025-01-30', '2025-02-13', NULL, 0.00),
(11, 11, '2025-01-30', '2025-02-13', NULL, 0.00),
(12, 12, '2025-02-01', '2025-02-15', NULL, 0.00),
(13, 13, '2025-02-05', '2025-02-19', NULL, 0.00),
(14, 14, '2025-02-08', '2025-02-22', '2025-02-23', 4.00),
(15, 15, '2025-02-10', '2025-02-24', NULL, 0.00);

-- Insert 15 new rows into Payments
INSERT INTO Payments 
(Client_ID, Amount, Payment_Date, Payment_Type) 
VALUES
(11, 15.00, '2025-01-15', 'Pages� mujore'),
(12, 12.50, '2025-01-20', 'D�nim p�r vones�'),
(13, 20.00, '2025-01-25', 'Pages� mujore'),
(14, 5.00, '2025-01-30', 'D�nim p�r vones�'),
(15, 25.00, '2025-02-03', 'Pages� mujore'),
(11, 7.50, '2025-02-05', 'D�nim p�r vones�'),
(12, 30.00, '2025-02-10', 'Pages� mujore'),
(13, 15.00, '2025-02-15', 'Pages� mujore'),
(14, 10.00, '2025-02-20', 'Pages� mujore'),
(15, 5.00, '2025-02-25', 'D�nim p�r vones�'),
(11, 20.00, '2025-02-28', 'Pages� mujore'),
(12, 15.50, '2025-03-05', 'D�nim p�r vones�'),
(13, 18.00, '2025-03-10', 'Pages� mujore'),
(14, 12.00, '2025-03-15', 'Pages� mujore'),
(15, 9.00, '2025-03-20', 'Pages� mujore');

select * from Bibliographic_Materials

select * from Clients

select * from Payments

select * from Loans

select * from Users


-- Tabela: Bibliographic_Materials
CREATE TABLE Bibliographic_Materials (
    Material_ID INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(255) NOT NULL,
    Author NVARCHAR(255) NOT NULL,
    Co_Authors NVARCHAR(255),
    Publisher NVARCHAR(255),
    Publication_Date DATE,
    ISBN NVARCHAR(13),
    DOI NVARCHAR(50),
    Material_Type NVARCHAR(50) NOT NULL,
    Abstract NVARCHAR(MAX),
    Available_Copies INT NOT NULL CHECK (Available_Copies >= 0),
    Date_Added DATE DEFAULT GETDATE()
);


-- Tabela: Clients
CREATE TABLE Clients (
    Client_ID INT PRIMARY KEY IDENTITY(1,1),
    First_Name NVARCHAR(100) NOT NULL,
    Last_Name NVARCHAR(100) NOT NULL,
    Date_of_Birth DATE,
    Email NVARCHAR(255) UNIQUE,
    Phone NVARCHAR(15),
    Address NVARCHAR(255),
    Membership_Active BIT DEFAULT 1
);

-- Tabela: Loans
CREATE TABLE Loans (
    Loan_ID INT PRIMARY KEY IDENTITY(1,1),
    Client_ID INT NOT NULL,
    Material_ID INT NOT NULL,
    Loan_Date DATE NOT NULL DEFAULT GETDATE(),
    Return_Date DATE NOT NULL,
    Actual_Return_Date DATE,
    Penalty_Fee DECIMAL(10, 2) DEFAULT 0.00,
    FOREIGN KEY (Client_ID) REFERENCES Clients(Client_ID),
    FOREIGN KEY (Material_ID) REFERENCES Bibliographic_Materials(Material_ID)
);

-- Tabela: Payments
CREATE TABLE Payments (
    Payment_ID INT PRIMARY KEY IDENTITY(1,1),
    Client_ID INT NOT NULL,
    Amount DECIMAL(10, 2) NOT NULL CHECK (Amount >= 0),
    Payment_Date DATE NOT NULL DEFAULT GETDATE(),
    Payment_Type NVARCHAR(50) NOT NULL,
    FOREIGN KEY (Client_ID) REFERENCES Clients(Client_ID)
);

-- Tabela: Users
CREATE TABLE Users (
    User_ID INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(100) NOT NULL UNIQUE,
    Password NVARCHAR(255) NOT NULL,
    Role NVARCHAR(50) NOT NULL 
);

ALTER TABLE Users
ADD CONSTRAINT chk_Role CHECK (Role IN ('Admin', 'Biblotekar'));

--- End of tables ---



--- Queryt
-- Query: Identifikimi i Klient�ve me Shum� Huazime t� Vonuara
SELECT 
    C.Client_ID, 
    CONCAT(C.First_Name, ' ', C.Last_Name) AS Client_Name, 
    COUNT(L.Loan_ID) AS Overdue_Loans, 
    SUM(L.Penalty_Fee) AS Total_Penalty_Fees
FROM Loans L
INNER JOIN Clients C ON L.Client_ID = C.Client_ID
WHERE L.Return_Date < L.Actual_Return_Date
  AND L.Loan_Date >= DATEADD(MONTH, -1, GETDATE())
GROUP BY C.Client_ID, C.First_Name, C.Last_Name
HAVING COUNT(L.Loan_ID) > 3;

-- Query: Analiza e Pagesave p�r Lloje t� Ndryshme Sh�rmbimesh
SELECT 
    P.Payment_Type, 
    SUM(P.Amount) AS Total_Amount, 
    COUNT(DISTINCT P.Client_ID) AS Client_Count
FROM Payments P
WHERE P.Payment_Date >= DATEADD(YEAR, -1, GETDATE())
GROUP BY P.Payment_Type;

-- Query: Analiza e Huazimeve t� Librave p�r Llojin e Materialit
SELECT 
    BM.Title, 
    BM.Material_Type, 
    COUNT(L.Loan_ID) AS Loan_Count
FROM Loans L
INNER JOIN Bibliographic_Materials BM ON L.Material_ID = BM.Material_ID
GROUP BY BM.Title, BM.Material_Type;

-- Query: Identifikimi i Klient�ve me Pagesa t� Munguar
SELECT 
    C.Client_ID, 
    CONCAT(C.First_Name, ' ', C.Last_Name) AS Client_Name, 
    SUM(L.Penalty_Fee) AS Total_Unpaid_Penalty
FROM Clients C
LEFT JOIN Payments P ON C.Client_ID = P.Client_ID
LEFT JOIN Loans L ON C.Client_ID = L.Client_ID
WHERE P.Payment_ID IS NULL
  AND L.Penalty_Fee > 0
  AND L.Loan_Date >= DATEADD(YEAR, -1, GETDATE())
GROUP BY C.Client_ID, C.First_Name, C.Last_Name;


select * from Bibliographic_Materials

use LibraryManagement
delete  from Payments where Payment_ID = 31