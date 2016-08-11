--INSERT INTO [Customers](
--Firstname, Lastname, BillingAddress, BillingZip, BillingCity, DeliveryAddress, DeliveryZip, DeliveryCity, EmailAddress, PhoneNo)
--VALUES(
--'Jonas', 'Gray', '23 Green Corner Street', '56743', 'Birmingham','23 Green Corner Street', '56743', 'Birmingham', 'jonas.grey@hotmail.com', '0708123456')  

--INSERT INTO [Customers](
--Firstname, Lastname, BillingAddress, BillingZip, BillingCity, DeliveryAddress, DeliveryZip, DeliveryCity, EmailAddress, PhoneNo)
--VALUES(
--'Jane', 'Harolds', '10 West Street', '43213', 'London','10 West Street', '43213', 'London', 'jane_h77@gmail.com', '0701245512')  

--INSERT INTO [Customers](
--Firstname, Lastname, BillingAddress, BillingZip, BillingCity, DeliveryAddress, DeliveryZip, DeliveryCity, EmailAddress, PhoneNo)
--VALUES(
--'Peter', 'Birro', '12 Fox Street', '45681', 'New York','89 Moose Plaza', '45321', 'Seattle', 'peter_the_great@hotmail.com', '0739484322')  

--INSERT INTO Movies(
--Title, Director, ReleaseYear, Price)
--VALUES(
--'Interstellar', 'Christoper Nolan', '2014', '179'
--)

--INSERT INTO Movies(
--Title, Director, ReleaseYear, Price)
--VALUES(
--'Hobbit: Battle of the five armies', 'Peter Jackson', '2014', '179'
--)

--INSERT INTO Movies(
--Title, Director, ReleaseYear, Price)
--VALUES(
--'The Wolf of Wall Street', 'Martin Scorcese', '2013', '119'
--)

--INSERT INTO Movies(
--Title, Director, ReleaseYear, Price)
--VALUES(
--'Pulp Fiction', 'Quentin Tarantino', '1994', '4'
--)

--Excercise 3------------------------------------------------ 

--INSERT INTO Orders (OrderDate, CustomerId)
--SELECT '2015-01-01', Customers.Id
--FROM Customers
--WHERE Customers.Firstname = 'Jonas' AND Customers.Lastname = 'Gray';

--INSERT INTO OrderRows(OrderId, MovieId, Price)
--SELECT o.Id, m.Id, m.Price
--FROM Orders o, Movies m
--WHERE o.CustomerId = 1 AND m.Title ='Interstellar'; 

--INSERT INTO OrderRows(OrderId, MovieId, Price)
--SELECT o.Id, m.Id, m.Price
--FROM Orders o, Movies m
--WHERE o.CustomerId = 1 AND m.Title ='Pulp Fiction';
----------------------------------------------------------------------------
--INSERT INTO Orders (OrderDate, CustomerId)
--SELECT '2015-01-15', Customers.Id
--FROM Customers
--WHERE Customers.Firstname = 'Peter' AND Customers.Lastname = 'Birro';

--INSERT INTO OrderRows(OrderId, MovieId, Price)
--SELECT o.Id, m.Id, m.Price
--FROM Orders o, Movies m
--WHERE o.CustomerId = 3 AND m.Title ='The Wolf of Wall Street'; 

--INSERT INTO OrderRows(OrderId, MovieId, Price)
--SELECT o.Id, m.Id, m.Price
--FROM Orders o, Movies m
--WHERE o.CustomerId = 3 AND m.Title ='The Wolf of Wall Street';

--------------------------------------------------------------------------------------------

--INSERT INTO Orders (OrderDate, CustomerId)
--SELECT '2014-12-20', Customers.Id
--FROM Customers
--WHERE Customers.Firstname = 'Jonas' AND Customers.Lastname = 'Gray';

--INSERT INTO OrderRows(OrderId, MovieId, Price)
--SELECT o.Id, m.Id, m.Price
--FROM Orders o, Movies m
--WHERE o.CustomerId = 1 AND m.Title ='The Wolf of Wall Street'; 

----------------  Excercise 4 --------------------------------------------------

--UPDATE Movies 
--SET Price = 169
--WHERE ReleaseYear = 2014;

---------- Excercise 5 --------------------------------------------------

--SELECT Firstname, Lastname, PhoneNo, EmailAddress
--FROM Customers;

--SELECT * FROM Movies ORDER BY ReleaseYear DESC;

--SELECT Title
--FROM Movies ORDER BY CAST(Price AS INT)ASC;



	
