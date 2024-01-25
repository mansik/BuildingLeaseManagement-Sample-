CREATE PROCEDURE [dbo].[spLeaseContract_GetAllDisplay]
AS
BEGIN
	SET NOCOUNT ON
	/* 열이름 자동 나열하는 방법
		BuildingLease.UserDB의 저장프로시저에서 열어서 
		select c.*으로 입력하고 *에 마우스 우측클릭해서 리펙터링 
		-> 와일드 카드 확장하면 열이름이 자동 완성된다.
	*/
	select c.*,
	       r.BuildingCodeId, r.[Floor], r.Room
	from dbo.[LeaseContract] c
	left join dbo.[BuildingRoomCode] r
	  on c.BuildingRoomCodeId = r.Id
	order by ContractStartDate desc;
END