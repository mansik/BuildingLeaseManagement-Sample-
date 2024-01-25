CREATE PROCEDURE [dbo].[spAccountCode_GetAllDisplay]
AS
BEGIN
	SET NOCOUNT ON
	
	select account.Id, hang.AccountHangName, account.AccountName, hang.InOutgoings 
	from dbo.[AccountCode] account
	inner join dbo.[AccountHangCode] hang
		on account.AccountHangCodeId = hang.Id 
	order by hang.InOutgoings, hang.DisplaySeq, account.DisplaySeq;
END