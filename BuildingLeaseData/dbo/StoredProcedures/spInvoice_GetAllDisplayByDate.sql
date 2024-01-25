CREATE PROCEDURE [dbo].[spInvoice_GetAllDisplayByDate]
	@InvoiceDate datetime
AS
BEGIN
	/*SET NOCOUNT ON*/
	/* 영향받는 row 수를 사용하기 위해서 SET NOCOUNT ON 주석 처리*/

	select room.BuildingCodeId, Invoice.*
	from dbo.[Invoice]
	left join dbo.[BuildingRoomCode] room
		on room.Id = Invoice.BuildingRoomCodeId
	left join dbo.[BuildingCode] building
		on building.Id = room.BuildingCodeId
	where InvoiceDate = @InvoiceDate
	order by building.DisplaySeq, room.DisplaySeq;
END