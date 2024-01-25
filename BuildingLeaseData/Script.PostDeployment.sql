/*
배포 후 스크립트 템플릿							
--------------------------------------------------------------------------------------
 이 파일에는 빌드 스크립트에 추가될 SQL 문이 있습니다.		
 SQLCMD 구문을 사용하여 파일을 배포 후 스크립트에 포함합니다.			
 예:      :r .\myfile.sql								
 SQLCMD 구문을 사용하여 배포 후 스크립트의 변수를 참조합니다.		
 예:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
if not exists (select 1 from dbo.[GradeType])
	begin
		SET IDENTITY_INSERT [dbo].[GradeType] ON

		insert into dbo.[GradeType] (Id, GradeTypeName, DisplaySeq, UseFlag, InsertUserId, UpdateUserId)
		values (1, N'관리자', 1, 1, 1, 1),
		(2, N'사용자', 2, 1, 1, 1);

		SET IDENTITY_INSERT [dbo].[GradeType] OFF
	end
if not exists (select 1 from dbo.[User])
	begin
		SET IDENTITY_INSERT [dbo].[User] ON

		insert into dbo.[User] (Id, UserName, [Password], GradeTypeId, UseFlag, InsertUserId, UpdateUserId)
		values (1, N'관리자', N'ytxn8TIUOSm+r2Ax4JqJmfX8L0UN7ohG7i1tFQcBXVI=', 1, 1, 1, 1), /*rhksflwk*/
		(2, N'사용자', N'A6xnQhbz4Vx2HuGl4lXwZ5U2I8iziLRFnhP5eNfIRvQ=', 2, 1, 1, 1); /*1234*/

		SET IDENTITY_INSERT [dbo].[User] OFF
	end
if not exists (select 1 from dbo.[Lessee])
	begin
		SET IDENTITY_INSERT [dbo].[Lessee] ON

		insert into dbo.[Lessee] (Id, Lessee, [Owner], RRN, BRN, Contact, UnderContractFlag, BillIssueDay, Notes, InsertUserId, UpdateUserId)
		values (1, '', '', '', '', '', 1, '1일', '기본코드로 수정, 삭제가 불가능', 1, 1);

		SET IDENTITY_INSERT [dbo].[Lessee] OFF
	end
if not exists (select 1 from dbo.[AccountHangCode])
	begin
		SET IDENTITY_INSERT [dbo].[AccountHangCode] ON

		insert into dbo.[AccountHangCode] (Id, InOutgoings, AccountHangName, DisplaySeq, UseFlag, InsertUserId, UpdateUserId)
		values (1, 0, N'종중수익사업', 1, 1, 1, 1),
		(2, 0, N'종중관리사업(비영리)', 2, 1, 1, 1),
		(3, 1, N'종중운영비(박물관)', 1, 1, 1, 1),
		(4, 1, N'사업장운영비(월곡빌딩)', 2, 1, 1, 1),
		(5, 1, N'예비비', 3, 1, 1, 1);

		SET IDENTITY_INSERT [dbo].[AccountHangCode] OFF
	end
if not exists (select 1 from dbo.[AccountCode])
	begin
		SET IDENTITY_INSERT [dbo].[AccountCode] ON

		insert into dbo.[AccountCode] (Id, AccountHangCodeId, AccountName, DisplaySeq, UseFlag, InsertUserId, UpdateUserId)
		values (1, 1, N'임대료 및 관리비 수입', 1, 1, 1, 1),
		(2, 1, N'주차료 수입', 2, 1, 1, 1),
		(3, 1, N'이자 수입', 3, 1, 1, 1),
		(4, 1, N'기타 수입(보증금 수입 포함)', 4, 1, 1, 1),
		(5, 1, N'전년도 이월금(총괄 이월금 참조)', 5, 1, 1, 1),
		(6, 2, N'승조당 수입', 1, 1, 1, 1),
		(7, 2, N'이자 수입', 2, 1, 1, 1),
		(8, 2, N'기타 수입', 3, 1, 1, 1),
		(9, 2, N'전년도 이월금(총괄 이월금 참조)', 4, 1, 1, 1),
		(10, 3, N'숭모 사업비', 1, 1, 1, 1),
		(11, 3, N'선양 사업비', 2, 1, 1, 1),		
		(12, 4, N'인건비', 1, 1, 1, 1),
		(13, 4, N'용역비', 2, 1, 1, 1),
		(14, 5, N'예비비', 1, 1, 1, 1);

		SET IDENTITY_INSERT [dbo].[AccountCode] OFF
	end
if not exists (select 1 from dbo.[BuildingCode])
	begin
		SET IDENTITY_INSERT [dbo].[BuildingCode] ON

		insert into dbo.[BuildingCode] (Id, BuildingName, Notes, DisplaySeq, UseFlag, InsertUserId, UpdateUserId)
		values (1, N'월곡빌딩_지상', N'대구 달서구 월곡로 266 (1~8층)', 1, 1, 1, 1),
		(2, N'월곡빌딩_창고', N'대구 달서구 월곡로 266 (B1~B2)', 2, 1, 1, 1),
		(3, N'열락당종중빌딩', N'대구 달서구 월배로 222', 3, 1, 1, 1),
		(4, N'월촌빌딩', N'대구 달서구 송현로7길 23', 4, 1, 1, 1),
		(5, N'건물,대지', N'', 5, 1, 1, 1),
		(6, N'중계기(연임대)', N'', 6, 1, 1, 1),
		(7, N'농지,임야,기타(연임대)', N'', 7, 1, 1, 1);

		SET IDENTITY_INSERT [dbo].[BuildingCode] OFF
	end
if not exists (select 1 from dbo.[Config])
	begin
		SET IDENTITY_INSERT [dbo].[Config] ON

		insert into dbo.[Config] (Id, OfficeTel, OfficeEmail, LastExpenseNumber)
		values (1, '053-642-5912', 'wolgok5912@daum.net', '0');

		SET IDENTITY_INSERT [dbo].[Config] OFF
	end
if not exists (select 1 from dbo.[BankBookCode])
	begin
		SET IDENTITY_INSERT [dbo].[BankBookCode] ON

		insert into dbo.[BankBookCode] (Id, [BankBookName], [BankName], [AccountNumber], [Notes], [DisplaySeq], [UseFlag], [InsertUserId], [UpdateUserId])
		values (1, N'4번', N'대구은행', N'094-05-268275-004', N'보통예금', 1, 1, 1, 1),
		(2, N'1번', N'대구은행', N'094-05-268275-001', N'보통예금', 2, 1, 1, 1),
		(3, N'열락당', N'대구은행', N'504-10-132791-1', N'보통예금', 3, 1, 1, 1),
		(4, N'월촌', N'대구은행', N'094-10-002937', N'보통예금', 4, 1, 1, 1),
		(5, N'싹쓸이', N'대구은행', N'094-10-003365', N'보통예금', 5, 1, 1, 1),
		(6, N'그린힐스', N'대구은행', N'094-10-002911', N'보통예금', 6, 1, 1, 1),
		(7, N'창고보증금', N'대구은행', N'505-10-202344-2', N'보통예금', 7, 0, 1, 1),
		(8, N'청도유등리', N'대구은행', N'094-10-002929', N'보통예금', 8, 0, 1, 1),
		(9, N'박물관', N'새마을금고', N'9002-1065-4172-1', N'보통예금(박물관)', 9, 1, 1, 1),
		(10, N'장학금', N'새마을금고', N'0000-0000-0000-0', N'보통예금(장학금)', 10, 1, 1, 1),
		(11, N'예금1', N'대구은행', N'511-21-761786-8', N'정기예금_10억_240125', 11, 1, 1, 1),
		(12, N'예금2', N'농협', N'353-4917-0815-24', N'정기예금_2억_240125', 12, 1, 1, 1),
		(13, N'예금3', N'새마을금고', N'9110-4184-9520-1', N'정기예금_3억_240419', 13, 1, 1, 1);

		SET IDENTITY_INSERT [dbo].[BankBookCode] OFF
	end