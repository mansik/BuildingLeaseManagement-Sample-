# 프로젝트 명칭
* 건물임대 관리 프로그램(Sample)

## About
* C#, WinForm, MSSQL 2022, DevExpress(Report), Dapper, Repository 패턴, 배포파일 만들기가 적용된 샘플파일

## Environment
* IDE: Visual Studio 2022
* Language: C#
* Applied Project Template: .NET Framework 4.8.1
    * DevExpress v24.2 Winforms App Template Gallery - Fluent Design Application(.Net Framework)  
* NuGet  
    * Dapper
* Third Party Libraries
    * DevExpress 24.2
* 메뉴 -> 확장 -> Microsoft Visual Studio Installer Project 2022 설치
* DataBase: MS SQL 2022

## 사전 지식
* MarkDown
* Git
* Dapper
* DevExpress
* SQL Query

## 다음을 학습할 수 있다.
* C# winform의 솔루션 구성방법
* C# 함수, 변수, 클래스등의 명명법
* MSSQL 데이터베이스를 이용한 Table 및 StoredProcedure 작성방법
* Dapper 이용방법
* Repository 패턴 적용방법
* DevExpress를 이용한 화면 디자인 및 Report
* 배포파일 만들기
* 데이터베이스 프로젝트 관리 방법

## 설치파일 및 사용법
1. `설치파일` 폴더에서 DB 백업파일(압축파일) 또는 DB 스크립트 파일을 사용하여 DB를 만든다.
2. setup 파일은 SetupBuildingLease\bin\Release 폴더에 BuildingLeaseManagement.msi 임.
    * 메뉴가 모두 있는 설치파일은 `설치파일` 폴더에 BuildingLeaseManagement(Full Version).msi 임
3. DB Connectionstring 및 sa 비번 변경
    * BuildingLeaseUI 프로젝트에서 App.config 파일에서 add key="DatabasePassword" 항목의 value=""으로 설정 후 재실행 후
    * C:\Users\사용자명\AppData\Roaming\프로젝트명\프로젝트명.config파일도 DatabasePassword의 value 복사해서 붙여넣기
4. 사용자/비밀번호: 관리자/관리자, 사용자/사용자
5. 데이터는 2023.09~12월 사이에 있음
> BuildingLeaseUI 프로젝트를 시작프로젝트로 하여 디버그 및 빌드하여 볼 수 있음

## 설명
> 프로젝트시 DB 및 화면 설계전에 용어정리 먼저 하여야 한다.(한국어, 영어)

* Solution Items의 README.md, 0_CodingStyle.md, 업무분석.md(용어정리)을 먼저 읽고, 각 프로젝트의 README파일을 읽을 것.
* 설명 및 문서 파일은 markdown 문법으로 작성(*.md) 하였음.
* 각각의 프로젝트 생성 방법은 각 프로젝트의 README.md 파일 참고
* Setup 후 환경설정 파일 위치: % AppData %\Roaming 위치. 
    * C:\Users\사용자명\AppData\Roaming\프로젝트명\프로젝트명.config
* 처음 실행시 `데이터베이스 비밀번호 입력창`이 나오며, `비밀번호`앞에 `sa@`를 입력하여야 한다. 
* DB는 MS SQL Server 2022를 사용.
    * sa 비번 변경시 BuildingLeaseUI 프로젝트에서 App.config 파일에서 add key="DatabasePassword" 항목의 value=""으로 설정후 
      프로그램 재실행하면 데이터베이스 비밀번호 입력창이 나오며, 비밀번호 앞에 'sa@'를 입력하여야 한다.
    * 현업에서 데이터베이스 생성 및 초기 데이터 삽입 : BuildingLeaseData폴더내 Script.BuildingLease_Database.sql, Script.PostDeployment.sql 실행
* 쿼리는 StoredProcedure 사용. 
* DB 연동은 Dapper를 사용(ADO.NET보다 사용편리)하여 Repository 패턴을 적용함.
    * 사용방법
        * https://github.com/DapperLib/Dapper Readme
        * https://www.learndapper.com/
        * https://dappertutorial.net/dapper
* DevExpress의 속성편집은 디자인 모드(run Design)를 최대한 이용하였음.
* DevExpress의 Form 및 User Control의 layout은 Layout Manager를 사용하였음
    * instant Layout Assistant에서 Add Control -> Layout & Containers-> Layout Manager선택
    * 아이콘은 DevExpress에서 제공하는 이미지를 이용하였음.
* SetupBuildingLease(배포파일) 프로젝트 생성 방법은 Solution Items-> 0_Setup_Project_배포방법.md 파일 참고
* 배포는 0_ClickOnes_배포방법.md 또는 0_Setup_Projcet_배포방법.md 파일을 참고할 것.

## 솔루션 구조 및 프로젝트 설명
> 각각의 프로젝트 생성 방법은 각 프로젝트의 README.md 파일 참고

* API: 솔루션에서 사용할 라이브러리 관리
    * BuildingLease.Library: UI 관련 라이브러리
    * BuildingLeaseDataManager.Library: Database관리 라이브러리(Dapper 이용)
* DataBase: 데이터베이스 스크립트 관리 및 DB에 게시하여 실제 DB에 데이터베이스를 생성한다.
* Solution Items: 필요한 문서를 관리한다. 
    * 솔루션 -> 추가 -> 기존 항목 -> 문서 폴더내의 파일을 선택해서 추가하면 자동으로 `Solution Items`로 폴더가 생성되며, 폴더명은 수정하지 말것.
* UI: UI 관련 프로젝트 관리
    * BuildingLeaseUI: BuildingLease UI
* SetupBuildingLease: 배포파일 만들기
    * Solution Items-> 0_Setup_Project_배포방법.md 파일 참고
	
# 파일 버전 관리
* 만약 버전변경을 한다면 Assembly version은 고정하고, Assembly File Version만 변경할 것.
    * => Assembly version 변경 시 충돌 가능성 있음

# 규칙
* BuildingLeaseDataManager.Library.csproj
    * SqlDbAccess(사용)
    * Internal.DataAccess의 DBConnection(사용)
    * DataAccess(사용안함): UserData, SqlDataAccessSample, AsyncSqlDataAccessSamples
        * 이 경우 Internal.DataAccess.SqlDataAccess에서는 SqlClient를 직접 작업하며, 
	    * DataAccess.SqlDataAccessSample에서는 DB가 어떤 종류인지 몰라도 된다는 장점이 있다.
* 금액 type: C#에서 decimal , sql에서 money, 입력은 정수로 입력됨
* control nameing: 의미 + control종류, LoginForm, okButton, userNameTextEdit
* Method nameing: AddDisplay라는 이름은 별도의 DisplayModel을 반환하는 경우에 붙인다.
* Method nameing: 기존 Model을 사용하는 경우는 Gets 사용
* 이미지를 사용할 때 Project resource 대신 local resource, form resource로 저장하였음
    * => 장점: 폼을 다른 프로젝트로 이동 시에 이미지 파일이 없어도 이미지가 사라지는 현상이 없음, form.resx 파일 안에 바이너리로 저장
    * => 단점: 동일한 이미지가 여러 곳에 사용된 경우 변경 시 폼마다 다시 저장해야 한다.

# resource별 장단점
* Project resource 사용
    * => 장점: 폼을 다른 프로젝트로 이동 시에 프로젝트에서 resouece에 image를 지정해주거나 프로젝트의 Resources.resx 파일 복사하면 동일한 이미지가 여러곳에 사용된 경우 일괄 변경이 된다.
    * => 단점: 폼을 다른 프로젝트로 이동 시에 기존 이미지 파일이 없거나 Resources.resx파일이 깨진 경우 이미지가 사라지는 현상이 있음.
* local resource, form resource 사용
    * => 장점: 폼을 다른 프로젝트로 이동 시에 이미지 파일이 없어도 이미지가 사라지는 현상이 없음, form.resx 파일 안에 바이너리로 저장
    * => 단점: 동일한 이미지가 여러 곳에 사용된 경우 변경 시 폼마다 다시 저장해야 한다.
