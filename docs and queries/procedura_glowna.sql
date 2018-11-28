CREATE PROCEDURE complete_order(@orderId INT)
AS
BEGIN

DECLARE @taxPercent DECIMAL
DECLARE @priceWithoutTax DECIMAL
DECLARE @tax DECIMAL
DECLARE @totalPrice DECIMAL
DECLARE @productsTotalNumber INT


    SET @productsTotalNumber = (SELECT COUNT(*) FROM Orders INNER JOIN OrderProducts ON Orders.OrderId = OrderProducts.OrderId WHERE Orders.OrderId = @orderId)

    SET @taxPercent = (SELECT co.TaxRate FROM Countries co WHERE co.CountryId = (SELECT Addresses.CountryId
																				 FROM Addresses 
																				 INNER JOIN Orders ON Addresses.AddressId = Orders.AddressId
																				 WHERE Orders.OrderId = @orderId))


	

    SET @priceWithoutTax = (SELECT SUM(p.Price * op.Quantity)
                            FROM Products p
                            INNER JOIN OrderProducts op ON p.ProductId = op.ProductId
                            WHERE op.OrderId = @orderId
                            GROUP BY op.OrderId)

    SET @tax = @priceWithoutTax * (@taxPercent / 100)

    SET @totalPrice = @priceWithoutTax + @tax

    EXEC [dbo].[UpdateOrder] @totalPrice, @tax, @priceWithoutTax, @taxPercent,  @productsTotalNumber, @orderId;

	RETURN @orderId
END;