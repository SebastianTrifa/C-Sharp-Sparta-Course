use Northwind

/* 1.1	Write a query that lists all Customers in either Paris or London. Include Customer ID,
   Company Name and all address fields. */
select CustomerID, CompanyName,
		Address + ', ' + PostalCode + ' ' + City as FullAddress,
		Region, Country
	from Customers where City in ('Paris', 'London')

/* 1.2	List all products stored in bottles. */
select ProductName from Products where QuantityPerUnit like '%bottle%'

/* 1.3	Repeat question above, but add in the Supplier Name and Country. */
/* left join will include products for which no supplier is set */
select ProductName, CompanyName as Supplier, Country as SupplierCountry
	from Products
	left join Suppliers
		on Products.SupplierID = Suppliers.SupplierID
	where QuantityPerUnit like '%bottle%'
	
/* 1.4	Write an SQL Statement that shows how many products there are in each category. Include
   Category Name in result set and list the highest number first. */
   
/* right join will include categories without products */
select CategoryName, count(1) as NumberOfProducts from Products
	right join Categories
		on Products.CategoryID = Categories.CategoryID
	group by CategoryName
	order by NumberOfProducts desc
	
/* 1.5	List all UK employees using concatenation to join their title of courtesy, first name
   and last name together. Also include their city of residence. */
select TitleOfCourtesy + ' ' + FirstName + ' ' + LastName as Employee, City
	from Employees
	where Country = 'UK'
	
/* 1.6	List Sales Totals for all Sales Regions (via the Territories table using 4 joins) with
   a Sales Total greater than 1,000,000. Use rounding or FORMAT to present the numbers. */
select * from (
	select Region.RegionDescription,
			round(sum(UnitPrice * Quantity * (1 - Discount)) / 1000000,2) as 'Total Sales (million $)'
		from Orders
		join EmployeeTerritories
			on Orders.EmployeeID = EmployeeTerritories.EmployeeID
		join Territories
			on EmployeeTerritories.TerritoryID = Territories.TerritoryID
		join Region
			on Territories.RegionID = Region.RegionID
		join "Order Details"
			on Orders.OrderID = "Order Details".OrderID
		group by RegionDescription ) as SalesTotals
	where "Total Sales (million $)" > 1
	order by "Total Sales (million $)" desc
	
/* 1.7	Count how many Orders have a Freight amount greater than 100.00
   and either USA or UK as Ship Country. */
select count(1) as 'Number of orders with a freight > $100 with either USA or UK as a destination'
	from Orders where Freight > 100 and ShipCountry in ('USA', 'UK')
	
/* 1.8	Write an SQL Statement to identify the Order Number of the
   Order with the highest amount of discount applied to that order. */
   
/* Complicated way: */
/* Create a CTE that shows the total applied discount per order */
;with Discounts as (
	select Orders.OrderID, round(sum(UnitPrice * Quantity * Discount), 2) as TotalDiscount
		from Orders
		join "Order Details"
			on Orders.OrderID = "Order Details".OrderID
		group by Orders.OrderID
)

/* Find and display the order that has the largest total applied discount */
select OrderID as 'OrderID with the highest amount of discount applied to order',
		TotalDiscount as 'Total discount ($)'
	from Discounts
	where TotalDiscount = (select max(TotalDiscount) from Discounts)
	
/* Or, less advanced (but better): */
select top 1 OrderID as 'OrderID with the highest amount of discount applied to order',
		round(sum(UnitPrice * Quantity * Discount), 2) as 'Total discount ($)'
	from "Order Details"
	group by OrderID
	order by 'Total discount ($)' desc
	
	
/* 2.1 Write the correct SQL statement to create the following table:

   Spartans Table – include details about all the Spartans on this course. Separate
   Title, First Name and Last Name into separate columns, and include University
   attended, course taken and mark achieved. Add any other columns you feel would be
   appropriate. 

   IMPORTANT NOTE: For data protection reasons do NOT include date of birth in this
   exercise. */
   
/* Drop old table to prevent error messages */
if exists (select * from sysobjects where id = object_id('dbo.Spartans') and sysstat & 0xf = 3)
	drop table "dbo"."Spartans"
go

/* Create the table */
create table "Spartans" (
	"SpartanID" int NOT NULL,
	"Title" nvarchar (20),
	"FirstName"	nvarchar (20) NOT NULL,
	"LastName" nvarchar (20) NOT NULL,
	"University" nvarchar (20),
	"Program" nvarchar (20),
	CONSTRAINT "PK_Spartans" PRIMARY KEY CLUSTERED
	(
		"SpartanID"
	)
)

/* Insert the (dummy) data */
insert "Spartans" values (1, 'Ms', 'Lacy', 'Patton', NULL, NULL) /* Did not attend university */
insert "Spartans" values (2, 'BSc', 'George', 'Stevens', 'Oxford', 'Applied Physics')
insert "Spartans" values (3, 'Dr', 'Orlando', 'Cook', 'Cambridge', 'Medicine')
insert "Spartans" values (4, 'MSc', 'Cassandra', 'Suarez', 'Edinburgh', 'Chemical Engineering')
insert "Spartans" values (5, 'BSc', 'Norman', 'Black', 'Manchester', 'Linguistics')

/* 3.1 List all Employees from the Employees table and who they
   report to. No Excel required. (5 Marks) */
/* left join ensure employees that do not report to anyone are included */
select Employees.FirstName + ' ' + Employees.LastName as Employee,
		Managers.FirstName + ' ' + Managers.LastName as ReportsTo
	from Employees
	left join Employees as Managers
		on Employees.ReportsTo = Managers.EmployeeID
	
/* 3.2 List all Suppliers with total sales over $10,000 in the Order
   Details table. Include the Company Name from the Suppliers Table and
   present as a line chart as below: (5 Marks) */
   
/* CTE that summarises all order details and shows the total value of the order detail as well as the company
   that supplied the product. */
;with OrderSummary as (
	select CompanyName,
			"Order Details".UnitPrice * "Order Details".Quantity * (1 - "Order Details".Discount) as OrderTotal
		from "Order Details"
		join Products
			on "Order Details".ProductID = Products.ProductID
		join Suppliers
			on Products.SupplierID = Suppliers.SupplierID
)

/* Sum the totals and group by company */
select CompanyName, round(sum(OrderTotal), 0) as 'Total sales from supplier ($)'
	from OrderSummary
	group by CompanyName
	having sum(OrderTotal) > 10000
	order by 'Total sales from supplier ($)'
	
/* 3.3 List the Top 10 Customers YTD for the latest year in the
   Orders file. Based on total amount of orders shipped. No Excel
   required. (10 Marks) */

/* Make sure there are no warnings when the script is run twice */
if exists (select * from sys.views where name='OperatingYears') drop view "OperatingYears"
if exists (select * from sys.views where name='MostRecentOrdersYTD') drop view "MostRecentOrdersYTD"
go

/* Create a view of the operating years */
create view OperatingYears as (
	select year(ShippedDate) as Year
		from Orders
		group by year(ShippedDate)
		having not year(ShippedDate) is NULL
)
go

/* Create a view of the orders year to date
   Will simulate being in the most recent year, i.e. if the current
   date is March 1, it will only show orders till March 1 in the max year. */
create view MostRecentOrdersYTD as (
	select OrderID, CustomerID, cast(ShippedDate as date) as OrderDate
		from Orders
		where year(ShippedDate) = (select max(Year) from OperatingYears)
			and datepart(dy, ShippedDate) <= datepart(dy, getdate())
)
go

/* From MostRecentOrdersYTD, compile a list of orders by company and display
   the top 10 largest customers by number of orders. */
select top 10 Customers.CompanyName, count(1) as NumberOfOrders
	from MostRecentOrdersYTD
	join Customers
		on MostRecentOrdersYTD.CustomerID = Customers.CustomerID
	group by Customers.CompanyName
	order by NumberOfOrders desc
	
/* Plot the Average Ship Time by month for all data in the Orders Table. (10 Marks) */

/* Ship Time = ShippedDate - OrderDate
   First create a CTE that shows the Ship Time and month for each OrderID.
   Note: semicolon goes right in front of 'with' in case somebody decides to copy part of
   your code and does not close his queries with semicolons */
;with OrderShipTime as (
	select OrderID,
		convert(varchar(2), datepart(m, OrderDate)) + '-' +
			convert(varchar(4), datepart(year, OrderDate)) as Month,
		datediff(day, OrderDate, ShippedDate) as ShipTime
	from Orders
)

/* Calculate the average Ship Time for each month */
select Month, round(avg(cast(ShipTime as float)), 2) as 'Average Ship Time'
	from OrderShipTime
	group by Month