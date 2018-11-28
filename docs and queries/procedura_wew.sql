CREATE PROCEDURE [dbo].[UpdateOrder] @totalPrice DECIMAL, @tax DECIMAL, @priceWithoutTax DECIMAL, @taxPercent DECIMAL, @productsTotalNumber DECIMAL, @orderId INT
AS
UPDATE Orders
    SET TotalPrice = @totalPrice, Tax = @tax, PriceWithoutTax = @priceWithoutTax, TaxPercent = @taxPercent, ProductsTotalNumber = @productsTotalNumber
    WHERE OrderId = @orderId