use ShopVerse;

ALTER TABLE Seller
ADD ApprovalStatus BIT DEFAULT 0;


INSERT INTO Seller (FName, LName, Email, StoreAddress, StoreName, ApprovalStatus)
VALUES 
('John', 'Smith', 'john.smith@example.com', '123 Elm St', 'John’s Supplies', 0),
('Jane', 'Doe', 'jane.doe@example.com', '456 Oak St', 'Jane’s Boutique', 1),
('Alice', 'Johnson', 'alice.johnson@example.com', '789 Pine St', 'Alice’s Crafts', 0),
('Bob', 'Brown', 'bob.brown@example.com', '321 Maple St', 'Bob’s Electronics', 1)


INSERT INTO Inventory (Location, ItemCount, SellerID)
VALUES
('New York Warehouse', 50, 3),
('Los Angeles Warehouse', 100, 2)

select * from Inventory

INSERT INTO Product (Name, Description, Price, InventoryID)
VALUES 
('Laptop', 'A high-performance laptop with 16GB RAM and 512GB SSD.', 1200.00, 3),
('Smartphone', 'Latest model with 128GB storage and 5G support.', 800.00, 2)


ALTER TABLE OrderTable
ADD     TotalAmount DECIMAL(10, 2), -- To track the total value of the order
    ShippingStatus NVARCHAR(50), -- To track the shipping status
    CreatedDate DATETIME DEFAULT GETDATE();

Alter table Product add image image; 
Alter table Product add Stock int check (Stock>=0); 

Alter Table Product drop column InventoryID

ALTER TABLE Product
DROP CONSTRAINT FK__Product__Invento__6C190EBB;

ALTER TABLE Product
add SellerID INT,                                
    FOREIGN KEY (SellerID) REFERENCES Seller(UserID)
	
ALTER TABLE Admin
add Password NVARCHAR(255)

ALTER TABLE Seller
add Password NVARCHAR(255)

select * from Product

Update Product 
set OpeningStock =100
where ProductID=20


INSERT INTO Admin (FName, LName, Email, Password)
VALUES 
('Alice', 'Smith', 'admin@example.com', 'admin');

-- Insert a dummy customer
INSERT INTO Customer (FName, LName, Email, Password, Address, PaymentPreference)
VALUES 
('Bob', 'Brown', 'customer@example.com', 'customer', '456 Elm St, Springfield', 'Credit Card');

-- Insert a dummy seller
INSERT INTO Seller (FName, LName, Email, Password, StoreAddress, StoreName, ApprovalStatus)
VALUES 
('Charlie', 'Davis', 'seller@example.com', 'seller', '789 Oak St, Springfield', 'Charlies Emporium', 1);

INSERT INTO Product (Name, Description, Price, image, Stock, SellerID)
VALUES
('Product 1', 'High-quality product 1', 10.99, NULL, 100, 6),
('Product 2', 'Affordable product 2', 20.49, NULL, 50, 6),
('Product 3', 'Luxury product 3', 99.99, NULL, 10, 6),
('Product 4', 'Everyday product 4', 5.75, NULL, 200, 6),
('Product 5', 'Special edition product 5', 55.99, NULL, 25, 6);

Alter table Product add CategoryID INT,                
    FOREIGN KEY (CategoryID) REFERENCES Category(CategoryID)


INSERT INTO Category (Name, Description) VALUES
('Electronics', 'This is a random description for Electronics'),
('Books', 'This is a random description for Books'),
('Clothing', 'This is a random description for Clothing'),
('Toys', 'This is a random description for Toys'),
('Home Appliances', 'This is a random description for Home Appliances');


select * from product

ALTER Table OrderItem add ApprovedBySeller BIT DEFAULT 0;

select * from OrderTable

SELECT 
    TOP 1 s.FName AS SellerName,
    s.StoreName AS StoreName,
    SUM(oi.Price * oi.Quantity) AS TotalSales,
    COUNT(DISTINCT o.OrderID) AS TotalOrders,
    AVG(oi.Price * oi.Quantity) AS AverageOrderValue,
    p.Name AS BestSellingProduct,
    COUNT(oi.ProductID) AS TotalUnitsSold
FROM Seller s
JOIN Product p ON s.UserID = p.SellerID
JOIN OrderItem oi ON p.ProductID = oi.ProductID
JOIN OrderTable o ON oi.OrderID = o.OrderID
WHERE s.UserID = 6 -- Replace @SellerID with the desired seller's ID
GROUP BY s.FName, s.StoreName, p.Name
ORDER BY TotalSales DESC;

select * from OrderItem

select * from Product



INSERT INTO ReturnRequest (ProductID, OrderID, Quantity, Reason)
VALUES 
    (20, 1, 1, 'Damaged item'), 
    (19, 2, 1, 'Wrong product sent'),
    (18, 3, 1, 'Poor quality'),
    (18, 3, 1, 'Damaged item'),
    (18, 4, 1, 'Did not match description');

select * from OrderTable

INSERT INTO LogisticsProvider (FName, LName, Email, Password, CompanyName, OfficeAddress)
VALUES ('John', 'Doe', 'logistics@example.com', 'logistics', 'FastEx Logistics', '1234 Street Blvd, CityName');


--REPORT 1:
SELECT 
    SUM(oi.Price * oi.Quantity) AS TotalSales
FROM OrderItem oi WHERE SellerID=6;

SELECT 
    SUM(oi.Price * oi.Quantity) / COUNT(DISTINCT o.OrderID) AS AverageOrderValue
FROM OrderItem oi
JOIN OrderTable o ON oi.OrderID = o.OrderID
WHERE oi.SellerID = 6;


SELECT 
    TOP 1 p.Name AS BestSellingProduct,
    SUM(oi.Quantity) AS TotalQuantitySold
FROM OrderItem oi
JOIN Product p ON oi.ProductID = p.ProductID
WHERE oi.SellerID = 6
GROUP BY p.Name
ORDER BY SUM(oi.Quantity) DESC;


SELECT 
    TOP 1 c.Name AS TopCategory,
    SUM(oi.Price * oi.Quantity) AS TotalSalesByCategory
FROM OrderItem oi
JOIN Product p ON oi.ProductID = p.ProductID
JOIN Category c ON p.CategoryID = c.CategoryID
WHERE oi.SellerID = 6
GROUP BY c.Name
ORDER BY SUM(oi.Price * oi.Quantity) DESC;


select * from Customer

--Report 2
SELECT 
    C.UserID AS MostActiveCustomer,
    AVG(O.TotalAmount) AS AvgSpendPerCustomer,
    (SELECT COUNT(DISTINCT OrderID) FROM OrderTable WHERE CustomerID = C.UserID) AS RepeatPurchaseRate
FROM Customer C
JOIN OrderTable O ON C.UserID = O.CustomerID
GROUP BY C.UserID;


--Report 3
-- Low Stock Alert
SELECT 
    ProductID, 
    Name AS ProductName, 
    Stock
FROM Product
WHERE Stock < 10;

-- Dead Stock
SELECT 
    P.ProductID,
    P.Name AS ProductName,
    P.Stock
FROM Product P
WHERE P.ProductID NOT IN (
    SELECT DISTINCT OI.ProductID
    FROM OrderItem OI
    JOIN OrderTable OT ON OI.OrderID = OT.OrderID
    WHERE DATEDIFF(DAY, OT.Date, GETDATE()) <= 30
);


-- Stock Turnover Rate
SELECT 
    P.ProductID,
    P.Name AS ProductName,
    SUM(OI.Quantity) AS TotalUnitsSold,
    (P.OpeningStock + P.Stock) / 2 AS AverageInventory,
    SUM(OI.Quantity) / NULLIF((P.OpeningStock + P.Stock) / 2, 0) AS StockTurnoverRate
FROM Product P
JOIN OrderItem OI ON P.ProductID = OI.ProductID
GROUP BY P.ProductID, P.Name, P.OpeningStock, P.Stock;

--highest negative reviews
SELECT 
    S.UserID AS SellerID,         -- SellerID
    S.StoreName,                  -- Seller's store name (or you can use FName, LName if needed)
    P.ProductID,
    P.Name AS ProductName,
    COALESCE(SUM(RR.Quantity), 0) AS TotalReturns,
    AVG(R.Rating) AS AverageRating
FROM Product P
JOIN Seller S ON P.SellerID = S.UserID -- Join to get seller details
LEFT JOIN Review R ON P.ProductID = R.ProductID
LEFT JOIN ReturnRequest RR ON P.ProductID = RR.ProductID
WHERE S.UserID = 6 -- Filter by the logged-in seller's ID
GROUP BY S.UserID, S.StoreName, P.ProductID, P.Name
HAVING AVG(R.Rating) <= 2.0 -- Filter products with low ratings
ORDER BY TotalReturns DESC, AverageRating ASC;








--Report 4

--Revenue by Product Category
SELECT 
    C.CategoryID,
    C.Name AS CategoryName,
    SUM(OI.Price * OI.Quantity) AS RevenuePerCategory,
    (SUM(OI.Price * OI.Quantity) * 100.0 / (SELECT SUM(Price * Quantity) FROM OrderItem)) AS PercentageContribution
FROM Category C
JOIN Product P ON C.CategoryID = P.CategoryID
JOIN OrderItem OI ON P.ProductID = OI.ProductID
GROUP BY C.CategoryID, C.Name
ORDER BY RevenuePerCategory DESC;


--Report 5

--Average Ratings by Product
SELECT 
    P.ProductID,
    P.Name AS ProductName,
    AVG(R.Rating) AS AverageRating
FROM Product P
JOIN Review R ON P.ProductID = R.ProductID
GROUP BY P.ProductID, P.Name
ORDER BY AverageRating DESC;

--Product Sentiment Analysis
SELECT 
    P.ProductID,
    P.Name AS ProductName,
    R.Content,
    CASE 
        WHEN R.Content LIKE '%excellent%' THEN 'Positive'
        WHEN R.Content LIKE '%good%' THEN 'Positive'
        WHEN R.Content LIKE '%poor quality%' OR R.Content LIKE '%bad%' THEN 'Negative'
        ELSE 'Neutral'
    END AS Sentiment
FROM Product P
JOIN Review R ON P.ProductID = R.ProductID;

--Top rated Products
SELECT 
    P.ProductID,
    P.Name AS ProductName,
    AVG(R.Rating) AS AverageRating
FROM Product P
JOIN Review R ON P.ProductID = R.ProductID
GROUP BY P.ProductID, P.Name
HAVING AVG(R.Rating) >= 4.5
ORDER BY AverageRating DESC;


--Report 6
-- Total sales by seller
SELECT 
    S.UserID,
    S.StoreName,
    SUM(OI.Price * OI.Quantity) AS TotalSales
FROM Seller S
JOIN OrderItem OI ON S.UserID = OI.SellerID
GROUP BY S.UserID, S.StoreName;

--Average Product Rating
SELECT 
    S.UserID,
    S.StoreName,
    AVG(R.Rating) AS AverageProductRating
FROM Seller S
JOIN Product P ON S.UserID = P.SellerID
JOIN Review R ON P.ProductID = R.ProductID
GROUP BY S.UserID, S.StoreName;

--Report 9
--New User Registraion
SELECT 
    COUNT(*) AS NewUserRegistrations,
    FORMAT(RegistrationDate, 'yyyy-MM') AS Month
FROM Customer
WHERE RegistrationDate IS NOT NULL
GROUP BY FORMAT(RegistrationDate, 'yyyy-MM')
ORDER BY Month;

--User Engagement Metrics
SELECT 
    COUNT(DISTINCT UserID) AS ActiveUsers,
    FORMAT(LastLoginDate, 'yyyy-MM') AS Month
FROM Customer
WHERE LastLoginDate IS NOT NULL
GROUP BY FORMAT(LastLoginDate, 'yyyy-MM')
ORDER BY Month;

--Churn Rate
SELECT 
    (CAST((SELECT COUNT(*) FROM Customer WHERE LastLoginDate < DATEADD(year, -1, GETDATE())) AS FLOAT) / 
     CAST((SELECT COUNT(*) FROM Customer) AS FLOAT)) * 100.0 AS ChurnRate;

--Active Users
SELECT 
    (CAST((SELECT COUNT(*) FROM Customer WHERE LastLoginDate >= DATEADD(month, -1, GETDATE())) AS FLOAT) / 
     CAST((SELECT COUNT(*) FROM Customer) AS FLOAT)) * 100.0 AS ActiveUserRatio;



--Report 10
--Age Distribution
SELECT 
    Age,
    COUNT(*) AS NumberOfUsers
FROM Customer
GROUP BY Age
ORDER BY Age;

--Gender Analysis
SELECT 
    Gender,
    COUNT(*) AS NumberOfUsers
FROM Customer
GROUP BY Gender;


select * from InsertLog
















