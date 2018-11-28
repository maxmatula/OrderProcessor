CREATE TRIGGER UpdateOrderOnInsert
   ON  [dbo].[Orders]
   AFTER UPDATE
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @id INT
	SET @id = (SELECT inserted.OrderId FROM inserted)

    EXEC [dbo].[complete_order] @id
	
END
GO