CREATE PROCEDURE [dbo].[spInvoice_GetsDisplayByDate]
	@InvoiceDate datetime,
	@BuildingCodeId int
AS
BEGIN
	SET NOCOUNT ON

	select invoice.*
	from dbo.[Invoice]  invoice 
	left join dbo.[BuildingRoomCode] room
		on invoice.BuildingRoomCodeId = room.Id
	where InvoiceDate = @InvoiceDate and room.BuildingCodeId = @BuildingCodeId
	order by room.DisplaySeq;
END