select * from customers where customerid = 'ALFKI'
update customers set City='Dresden' where CustomerID='ALFKI'
insert into customers (customerid,companyname,contactname,city) values ('PHLAF','philsco','phil','here')
delete from customers where customerid = 'PHLAE'