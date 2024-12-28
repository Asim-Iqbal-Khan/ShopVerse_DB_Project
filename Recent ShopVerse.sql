CREATE DATABASE ShopVerse;
GO


USE ShopVerse;
GO
--Select * from Customer;
--drop table Customer;
-- Create Admin table
CREATE TABLE Admin (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    FName NVARCHAR(50),
    LName NVARCHAR(50),
    Email NVARCHAR(100),
	Password NVARCHAR(255)
);

select * from Admin
-- Create Customer table
CREATE TABLE Customer (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    FName NVARCHAR(50),
	Password NVARCHAR(255),
    LName NVARCHAR(50),
    Email NVARCHAR(100),
    Address NVARCHAR(255),
    PaymentPreference NVARCHAR(50),
	RegistrationDate DATETIME,
    LastLoginDate DATETIME,
	Age INT,
    Gender NVARCHAR(10)
);



-- Create Seller table
CREATE TABLE Seller (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    FName NVARCHAR(50),
    LName NVARCHAR(50),
    Email NVARCHAR(100),
	Password NVARCHAR(255),
    StoreAddress NVARCHAR(255),
    StoreName NVARCHAR(50),
	ApprovalStatus BIT DEFAULT 0
);

-- Create LogisticsProvider table
CREATE TABLE LogisticsProvider (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    FName NVARCHAR(50),
    LName NVARCHAR(50),
    Email NVARCHAR(100),
	Password NVARCHAR(255),
    CompanyName NVARCHAR(255),
    OfficeAddress NVARCHAR(50)
);


-- Create AdminManagesCustomer table
CREATE TABLE AdminManagesCustomer (
    AdminID INT,
    CustomerID INT,
    FOREIGN KEY (AdminID) REFERENCES Admin(UserID),
    FOREIGN KEY (CustomerID) REFERENCES Customer(UserID),
    PRIMARY KEY (AdminID, CustomerID)
);

-- Create AdminManagesSeller table
CREATE TABLE AdminManagesSeller (
    AdminID INT,
    SellerID INT,
    FOREIGN KEY (AdminID) REFERENCES Admin(UserID),
    FOREIGN KEY (SellerID) REFERENCES Seller(UserID),
    PRIMARY KEY (AdminID, SellerID)
);

-- Create AdminManagesLogisticsProvider table
CREATE TABLE AdminManagesLogisticsProvider (
    AdminID INT,
    LogID INT,
    FOREIGN KEY (AdminID) REFERENCES Admin(UserID),
    FOREIGN KEY (LogID) REFERENCES LogisticsProvider(UserID),
    PRIMARY KEY (AdminID, LogID)
);

-- Create OrderTable
CREATE TABLE OrderTable (
    OrderID INT IDENTITY(1,1) PRIMARY KEY,
    Date DATE,
    Status NVARCHAR(50),
	CustomerID INT,
	PickupDate Datetime,
	estimateDeliveryDate Datetime,
	deliveredDate Date,
	TotalAmount DECIMAL(10, 2),
	FOREIGN KEY (CustomerID) REFERENCES Customer(UserID),
	

);





-- Create OrderItem table
--DROP TABLE OrderItem
--Dropped for now
CREATE TABLE OrderItem (
    OrderItemID INT IDENTITY(1,1) PRIMARY KEY,  
    Price DECIMAL(10, 2),                       
    Quantity INT,                               
    ProductID INT,                             
    OrderID INT,                              
	SellerID INT,
	ApprovedBySeller BIT DEFAULT 0,
    FOREIGN KEY (ProductID) REFERENCES Product(ProductID), 
    FOREIGN KEY (OrderID) REFERENCES OrderTable(OrderID),
    FOREIGN KEY (SellerID) REFERENCES Seller(UserID)
);


-- Create AdminOverseesOrder table
CREATE TABLE AdminOverseesOrder (
    AdminID INT,
    OrderID INT,
    FOREIGN KEY (AdminID) REFERENCES Admin(UserID),
    FOREIGN KEY (OrderID) REFERENCES OrderTable(OrderID),
    PRIMARY KEY (AdminID, OrderID)
);



-- Create Payment table
CREATE TABLE Payment (
    PaymentID INT IDENTITY(1,1) PRIMARY KEY,
    OrderID INT,
    DateProcessed DATE,
    Amount INT,
    FOREIGN KEY (OrderID) REFERENCES OrderTable(OrderID)
);






-- Create AdminManagesCart table
CREATE TABLE AdminManagesCart (
    CartID INT,
    AdminID INT,
    FOREIGN KEY (CartID) REFERENCES Cart(CartID),
    FOREIGN KEY (AdminID) REFERENCES Admin(UserID),
    PRIMARY KEY (CartID, AdminID)
);

-- Create History table


-- Create Review table
CREATE TABLE Review (
    ReviewID INT IDENTITY(1,1) PRIMARY KEY,  
    Content NVARCHAR(255) NOT NULL,          
    Rating DECIMAL(2,1) CHECK (Rating BETWEEN 0 AND 5),
    ReviewDate DATE NOT NULL
	CustomerID INT,
	FOREIGN KEY (CustomerID) REFERENCES Customer(UserID),
	ProductID INT,                                                   
    FOREIGN KEY (ProductID) REFERENCES Product(ProductID)
);

CREATE TABLE ReturnRequest (
    ReturnID INT IDENTITY(1,1) PRIMARY KEY,
    ProductID INT NOT NULL,
    OrderID INT NOT NULL,
    Quantity INT NOT NULL CHECK (Quantity > 0),
    Reason NVARCHAR(255),
    ReturnDate DATE DEFAULT GETDATE(),
    FOREIGN KEY (ProductID) REFERENCES Product(ProductID),
    FOREIGN KEY (OrderID) REFERENCES OrderTable(OrderID)
);



CREATE TABLE Product (
    ProductID INT IDENTITY(1,1) PRIMARY KEY,       
    Name NVARCHAR(100) NOT NULL,                     
    Description NVARCHAR(MAX),                     
    Price DECIMAL(10, 2) NOT NULL,                  
	image image,
	Stock int check (stock>=0),
	OpeningStock INT DEFAULT 0,
	SellerID INT,                                
    FOREIGN KEY (SellerID) REFERENCES Seller(UserID),
	CategoryID INT,                
    FOREIGN KEY (CategoryID) REFERENCES Category(CategoryID)
);






-- Create SellerAddsProduct table

--DROP Table SellerAddsProduct
--Dropped
CREATE TABLE SellerAddsProduct (
    ProductID INT,                          
    UserID INT,                              
    FOREIGN KEY (ProductID) REFERENCES Product(ProductID), 
    FOREIGN KEY (UserID) REFERENCES Seller(UserID),         
    PRIMARY KEY (ProductID, UserID)          
);

-- Create Category table
CREATE TABLE Category (
    CategoryID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,               
    Description NVARCHAR(MAX)                 
);


-- Create CartItem table
--DROP table CartItem
CREATE TABLE CartItem (
    CartItemID INT IDENTITY(1,1) PRIMARY KEY,     
    ProductID INT,                      
    CartID INT,                        
    Quantity INT,                       
    FOREIGN KEY (ProductID) REFERENCES Product(ProductID),   
    FOREIGN KEY (CartID) REFERENCES Cart(CartID)             
);


-- Create Cart table
--DROP TABLE Cart
CREATE TABLE Cart (
    CartID INT IDENTITY(1,1) PRIMARY KEY,
    CustomerID INT,
    FOREIGN KEY (CustomerID) REFERENCES Customer(UserID),
    CheckoutStatus NVARCHAR(50)
);





-- Create Wishlist table
CREATE TABLE Wishlist (
    WishlistID INT IDENTITY(1,1) PRIMARY KEY,
    CustomerID INT,                             
    FOREIGN KEY (CustomerID) REFERENCES Customer(UserID)
);

-- Create WishlistItem table

CREATE TABLE WishlistItem (
    CustomerID INT,               
    WishlistID INT,               
    ProductID INT,                 
    PRIMARY KEY (CustomerID, WishlistID),  
    FOREIGN KEY (CustomerID) REFERENCES Customer(UserID),
    FOREIGN KEY (WishlistID) REFERENCES Wishlist(WishlistID),  
    FOREIGN KEY (ProductID) REFERENCES Product(ProductID)  
);


CREATE TABLE InsertLog (
    LogID INT IDENTITY(1,1) PRIMARY KEY,
    TableName NVARCHAR(100),
    RecordID INT,
    InsertedDateTime DATETIME DEFAULT GETDATE()
);

CREATE TRIGGER CategoryInsertion
ON Category
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO InsertLog (TableName, RecordID, InsertedDateTime)
    SELECT 'Category', i.CategoryID, GETDATE()
    FROM inserted i;
END;


CREATE TRIGGER ProductInsertion
ON Product
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO InsertLog (TableName, RecordID, InsertedDateTime)
    SELECT 'Product', i.ProductID, GETDATE()
    FROM inserted i;
END;


CREATE TRIGGER AddedCustomers
ON Customer
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO InsertLog (TableName, RecordID, InsertedDateTime)
    SELECT 'Customer', i.UserID, GETDATE()
    FROM inserted i;
END;


CREATE TRIGGER AddedSellers
ON Seller
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO InsertLog (TableName, RecordID, InsertedDateTime)
    SELECT 'Seller', i.UserID, GETDATE()
    FROM inserted i;
END;



select * from Customer;

select * from WishlistItem

delete from WishlistItem where CustomerID=2 and WishlistID=1