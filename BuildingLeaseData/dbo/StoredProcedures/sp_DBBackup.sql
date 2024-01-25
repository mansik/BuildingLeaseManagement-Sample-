CREATE PROCEDURE [dbo].[sp_DBBackup]
　@BackupPath nvarchar(100),  
  @FullFileName nvarchar(200) out
AS
BEGIN
	
	declare @DBName nvarchar(50), @FileName nvarchar(100), @Name nvarchar(50);
	set @DBName = DB_NAME()	
	set @FileName = @DBName + N'_' + format(dateadd(hour, 9, getutcdate()),N'yyyyMMdd_HHmmss') + N'.bak'
	set @FullFileName = iif(right(@BackupPath,1) = N'\', @BackupPath, @BackupPath+ N'\') + @FileName
	set @Name = @DBName + N'전체 테이터베이스 백업'

	BACKUP DATABASE @DBName 
	TO  DISK = @FullFileName 
	WITH 
		NOFORMAT, 
		NOINIT,
		NAME = @Name;	
END