SELECT CustomerId, CompanyName, Address, City, Region, PostalCode, Country FROM Customers 
WHERE City IN ('London', 'Paris');

SELECT * FROM Products 
WHERE LOWER(QuantityPerUnit) LIKE '%bottle%';

SELECT Products.*, CompanyName, Country FROM Products 
INNER JOIN Suppliers ON Products.SupplierID = Suppliers.SupplierID
WHERE LOWER(QuantityPerUnit) LIKE '%bottle%';

SELECT COUNT(DISTINCT Products.ProductID) AS Number, Products.CategoryID, Categories.CategoryName FROM Products
INNER JOIN Categories ON Products.CategoryID = Categories.CategoryID
GROUP BY Products.CategoryID, Categories.CategoryName
ORDER BY Number DESC;

SELECT TitleOfCourtesy+' '+FirstName+' '+LastName AS Employee_Name, City FROM Employees 
WHERE Country LIKE 'UK';

SELECT Region.RegionDescription, ROUND(SUM([Order Details].Quantity*[Order Details].UnitPrice*(1-[Order Details].Discount)),0) AS Total_Orders FROM Orders
INNER JOIN [Order Details] ON Orders.OrderID=[Order Details].OrderID
INNER JOIN EmployeeTerritories ON EmployeeTerritories.EmployeeID=Orders.EmployeeID
INNER JOIN Territories ON EmployeeTerritories.TerritoryID=Territories.TerritoryID
INNER JOIN Region ON Territories.RegionID = Region.RegionID
GROUP BY Region.RegionDescription
HAVING SUM([Order Details].Quantity*[Order Details].UnitPrice*(1-[Order Details].Discount))>1000000;

select COUNT(OrderID) AS Number_Freight FROM orders
WHERE Freight>100 AND ShipCountry IN ('USA','UK');

SELECT OrderID, Discount FROM [Order Details]
WHERE Discount = (SELECT MAX(Discount) AS MaxDisc FROM [Order Details]);



CREATE TABLE "Spartans"(
"ID" "int" NOT NULL IDENTITY,
"Title" nvarchar(20) NOT NULL,
"First_Name" nvarchar(20) NULL,
"Last_Name" nvarchar(20) NOT NULL,
"University" nvarchar(30) NULL,
"Course" nvarchar(30) NULL,
"Degree_Classification" nvarchar(5) NULL,
CONSTRAINT [PK_ID] PRIMARY KEY CLUSTERED(
 "ID"
)
);

INSERT INTO Spartans (Title, First_Name, Last_Name, University, Course, Degree_Classification) VALUES('Mr.','Luitzen','Hietkamp','University of Twente','BEng Mechanical Engineering', '1st');
INSERT INTO Spartans (Title, First_Name, Last_Name, University, Course, Degree_Classification) VALUES('Mr.','Sebastian','Trifa','University of Bristol','MSci Physics with Astrophysics', '1st');
INSERT INTO Spartans (Title, First_Name, Last_Name, University, Course, Degree_Classification) VALUES('Ms.','Jaspreet','Rai','University of Greenwich','BEng Electronic Engineering', '1st');
INSERT INTO Spartans (Title, First_Name, Last_Name, University, Course, Degree_Classification) VALUES('Mr.','Emmanuel','Badejo','University of Twente','BEng Software Engineering', '1st');
INSERT INTO Spartans (Title, First_Name, Last_Name, University, Course, Degree_Classification) VALUES('Mr.','Li','Dinh','University of Twente','MSci Nutrition', '1st');




select Emp.TitleOfCourtesy, Emp.FirstName, Emp.LastName, Employees.TitleOfCourtesy, Employees.FirstName, Employees.LastName from Employees AS Emp
LEFT JOIN Employees ON Employees.EmployeeID=Emp.ReportsTo;

SELECT Suppliers.CompanyName, ROUND(SUM([Order Details].Quantity*[Order Details].UnitPrice*(1-[Order Details].Discount)),0) AS Total_Value_Orders FROM Suppliers
INNER JOIN [Order Details] ON Suppliers.SupplierID = [Order Details].ProductID
GROUP BY Suppliers.CompanyName
HAVING SUM([Order Details].Quantity*[Order Details].UnitPrice*(1-[Order Details].Discount))>10000
ORDER BY Total_Value_Orders;

SELECT COUNT(Orders.OrderID) AS 'No. Orders', Orders.ShipName from Orders
INNER JOIN (SELECT TOP 10 WITH TIES COUNT(OrderID) AS 'No. Orders', CustomerID FROM Orders
GROUP BY CustomerID, Year(OrderDate)
HAVING Year(OrderDate)= (SELECT MAX(YEAR(OrderDate)) FROM Orders)
ORDER BY COUNT(OrderID) DESC) AS Merger
ON Merger.CustomerID=Orders.CustomerID
GROUP BY ShipName, YEAR(Orders.OrderDate)
HAVING Year(OrderDate)= (SELECT MAX(YEAR(OrderDate)) FROM Orders)
ORDER BY COUNT(OrderID) DESC;

SELECT Avg(Convert(float,Datediff(DD,OrderDate,ShippedDate))) As 'ShipTime', Concat(Year(OrderDate),'-',Month(OrderDate)) As 'OrderMonth' FROM ORDERS
GROUP BY Year(OrderDate),Month(OrderDate)
ORDER BY Year(OrderDate),Month(OrderDate);