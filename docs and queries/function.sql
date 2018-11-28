CREATE OR REPLACE FUNCTION complete_order(@orderId INT)
RETURNS VOID AS

-- Declaration pleace
DECLARE @originOrderJoined RECORD
DECLARE @taxPercent DECIMAL
DECLARE @priceWithoutTax DECIMAL
DECLARE @tax DECIMAL
DECLARE @totalPrice DECIMAL
DECLARE @productsTotalNumber INT

-- Begin function
BEGIN;

    SET @originOrderJoined = (SELECT *
                              FROM Orders 
                              INNER JOIN Users ON Orders.UserId = Users.UserId
                              INNER JOIN Addresses ON Orders.AddressId = Addresses.AddressId
                              INNER JOIN Currencies ON Orders.CurrencyId = Currencies.CurrencyId
                              WHERE OrderId = @orderId)


    SET @productsTotalNumber = (SELECT COUNT(*) FROM Oders INNER JOIN OrderProducts ON Orders.OrderId = OrderProducts.OrderId WHERE OrderId = @orderId)

    SET @taxPercent = (SELECT co.TaxRate FROM Countries co WHERE co.CountryId = originOrderJoined.CountryId)

    SET @priceWithoutTax = (SELECT op.OrderId, SUM(p.Price * op.Quantity) as total
                            FROM Products p
                            INNER JOIN OrderProducts op ON p.ProductId = op.ProductId
                            WHERE op.OrderId = @orderId
                            GROUP BY op.OrderId)

    SET @tax = @priceWithoutTax * (@taxPercent / 100)

    SET @totalPrice = @priceWithoutTax + @tax

    UPDATE Orders
    SET TotalPrice = @totalPrice, Tax = @tax, PriceWithoutTax = @priceWithoutTax, TaxPercent = @taxPercent, ProductsTotalNumber = @productsTotalNumber
    WHERE OrderId = @orderId

END;
-- End function