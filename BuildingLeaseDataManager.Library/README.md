# Database관리 라이브러리(Dapper 이용, Repository 패턴)

## 설명: 
* 클래스 라이브러리로 프로젝트 생성

* 쿼리는 프로시저를 사용. 
* DB 연동은 Dapper를 사용(ADO.NET보다 사용편리)하여 Repository 패턴을 적용함.
	* 사용방법
	* https://github.com/DapperLib/Dapper Readme
	* https://www.learndapper.com/
	* https://dappertutorial.net/dapper

## 솔루션 구조
> 아래 SqlDbAccess보단 DataAccess와 Internal.DataAccess의 SqlDataAccess를 사용하는 것이 편리하다.
> `현재 프로젝트는 Internal.DataAccess의 DBConnection, Models, SqlDbAccess를 사용하였음.`

* DataAccess(사용안함): Internal.DataAccess의 SqlDataAccess를 사용할 때 여기서 작성

* Internal.DataAccess의 SqlDataAccess(사용안함)
  * SqlDataAccess에서는 SqlClient를 직접 작업하며,
  * DataAccess의 SqlDataAccessSample에서는 DB가 어떤 종류인지 몰라도 된다는 장점이 있다.

* Internal.DataAccess의 DBConnection: DB connection 작업

* Models: Database Table 모델

* SqlDbAccess:  Internal.DataAccess의 SqlDataAccess를 사용하지 않고 바로 SqlClient를 사용할때 사용

## 환경
* Visual Studio: [x] 2022
* 프로젝트 생성: [x] .Net Framework, [ ] .Net WinForm(windows form)
* Package 
  * [ ] DevExpress 23.2
* NuGet
  * [x] Dapper
  * [x] System.Data.SqlClient 

## 작업
