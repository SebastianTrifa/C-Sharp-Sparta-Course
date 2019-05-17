SELECT Suppliers.CompanyName, ROUND(SUM([Order Details].Quantity*[Order Details].UnitPrice*(1-[Order Details].Discount)),0) AS Total_Value_Orders FROM Suppliers
INNER JOIN Products ON Products.SupplierID = Suppliers.SupplierID
INNER JOIN [Order Details] ON [Order Details].ProductID = Products.ProductID 
GROUP BY Suppliers.CompanyName
HAVING SUM([Order Details].Quantity*[Order Details].UnitPrice*(1-[Order Details].Discount))>10000
ORDER BY Total_Value_Orders;