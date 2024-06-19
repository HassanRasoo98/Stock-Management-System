CREATE DATABASE Stock_Management_System;
USE Stock_Management_System;

CREATE TABLE CustomerInformation (
    CustomerID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    FathersName NVARCHAR(100) NOT NULL,
    Address NVARCHAR(255) NOT NULL,
    CNIC NVARCHAR(15) NOT NULL,
    PhoneNumber NVARCHAR(15) NOT NULL,
    [Date] DATE NOT NULL
);

CREATE TABLE ProductDetails (
    ProductID INT PRIMARY KEY IDENTITY(1,1),
    ProductQuantity INT NOT NULL,
    Price DECIMAL(10, 2) NOT NULL,
    BatchID NVARCHAR(50) NOT NULL
);

CREATE TABLE PaymentInformation (
    PaymentID INT PRIMARY KEY IDENTITY(1,1),
    CustomerID INT NOT NULL,
    ProductID INT NOT NULL,
    CashCollected DECIMAL(10, 2) NOT NULL,
    RemainingInCredit DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (CustomerID) REFERENCES CustomerInformation(CustomerID),
    FOREIGN KEY (ProductID) REFERENCES ProductDetails(ProductID)
);


-- Inserting records into the CustomerInformation table

INSERT INTO CustomerInformation (Name, FathersName, Address, CNIC, PhoneNumber, [Date])
VALUES ('John Doe', 'Richard Doe', '123 Elm Street, Springfield', '12345-6789012-3', '555-1234', '2024-06-16');

INSERT INTO CustomerInformation (Name, FathersName, Address, CNIC, PhoneNumber, [Date])
VALUES ('Jane Smith', 'Robert Smith', '456 Oak Avenue, Metropolis', '67890-1234567-8', '555-5678', '2024-06-17');

INSERT INTO CustomerInformation (Name, FathersName, Address, CNIC, PhoneNumber, [Date])
VALUES ('Alice Johnson', 'Michael Johnson', '789 Pine Road, Gotham', '98765-4321098-7', '555-9012', '2024-06-18');

INSERT INTO CustomerInformation (Name, FathersName, Address, CNIC, PhoneNumber, [Date])
VALUES ('Bob Brown', 'James Brown', '101 Maple Lane, Star City', '54321-0987654-6', '555-3456', '2024-06-19');

INSERT INTO CustomerInformation (Name, FathersName, Address, CNIC, PhoneNumber, [Date])
VALUES ('Carol White', 'Thomas White', '202 Cedar Drive, Central City', '23456-7890123-4', '555-7890', '2024-06-20');

-- Inserting records into the ProductDetails table

INSERT INTO ProductDetails (ProductQuantity, Price, BatchID)
VALUES (100, 29.99, 'BATCH001');

INSERT INTO ProductDetails (ProductQuantity, Price, BatchID)
VALUES (200, 19.99, 'BATCH002');

INSERT INTO ProductDetails (ProductQuantity, Price, BatchID)
VALUES (150, 39.99, 'BATCH003');

INSERT INTO ProductDetails (ProductQuantity, Price, BatchID)
VALUES (80, 49.99, 'BATCH004');

INSERT INTO ProductDetails (ProductQuantity, Price, BatchID)
VALUES (50, 59.99, 'BATCH005');

-- Inserting records into the PaymentInformation table

INSERT INTO PaymentInformation (CustomerID, ProductID, CashCollected, RemainingInCredit)
VALUES (1, 1, 50.00, 10.00);

INSERT INTO PaymentInformation (CustomerID, ProductID, CashCollected, RemainingInCredit)
VALUES (2, 2, 100.00, 0.00);

INSERT INTO PaymentInformation (CustomerID, ProductID, CashCollected, RemainingInCredit)
VALUES (3, 3, 80.00, 20.00);

INSERT INTO PaymentInformation (CustomerID, ProductID, CashCollected, RemainingInCredit)
VALUES (4, 4, 70.00, 30.00);

INSERT INTO PaymentInformation (CustomerID, ProductID, CashCollected, RemainingInCredit)
VALUES (5, 5, 60.00, 40.00);


SELECT * FROM CustomerInformation;
SELECT * FROM ProductDetails;
SELECT * FROM PaymentInformation;


DELETE FROM CustomerInformation WHERE CustomerID = 7;

DROP TABLE CustomerInformation;
DROP TABLE ProductDetails;
