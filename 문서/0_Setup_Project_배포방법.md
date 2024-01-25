# Setup Project를 통한 배포 파일 만들기

1. 메뉴 -> 확장 -> Microsoft Visual Studio Installer Project 2022 설치
2. 새 프로젝트 추가 : 탬플릿 검색 -> Setup Project 로 검색
3. 탬플릿 Setup Project을 이용하여 프로젝트 생성 SetupBuildingLease
4. SetupBuildingLease 프로젝트 속성 
  1. Author: Kim Man Sik
  2. Manufacturer: BuildingLeaseManagement => BuildingLeaseUI의 속성-> 어셈블리 정보의 회사
  3. ProductName: BuildingLeaseManagement => BuildingLeaseUI의 속성-> 어셈블리 정보의 제품
  4. Title: 건물임대관리  
  5. RemovePreviousVersions: true -> Version이 달라야 된다.(ProductCode가 새로운 값으로 할당되어야 한다.)
  6. 재배포시 Version 변경
  6. TargetPlatform: x64
  7. 프로젝트 -> 마우스 우측 -> 속성 
  8.   -> Prerequi...버튼 -> 필수 구성요소를 ... 체크 해제(사전 설치 요구)
  9.   -> Output file name: Release\BuildingLeaseManagement.msi 변경
5. 프로젝트 추가: 우측클릭 -> Add -> 프로젝트 출력 -> BuildingLeaseUI 추가
  1. * 프로젝트 추가를 다시하는 경우 단축아이콘도 다시 만들어야 함
6. (단축아이콘 및 경로 설정)프로젝트에서 기본출력 from BuildingLeaseUI (Active)  더블클릭
  1. Application Folder 선택
  2. 아이콘 추가: 우측클릭 -> Add -> BuildingLeaseManagement.ico 추가 
  3. 단축아이콘 만들기: 기본출력 from BuildingLeaseUI (Active) 선택후 -> 우측클릭 -> Shortcuts ... 선택
  4. 만들어진 Shortcuts 의 이름을 `건물임대관리`로 변경 ->  속성 창에서 아이콘 변경
  5. 만든 단축아이콘을 User's Program Menu로 이동
  6. 단축아이콘 하나를 더 만들어서 User's Desktop으로 이동(생략)
  7. 프로그램 경로 변경: Application Folder 선택 -> 속성 창 
      -> DefaultLocation: `[ProgramFiles64Folder][Manufacturer]\[ProductName]`에서 `[ProgramFiles64Folder]\[ProductName]`로 변경
      -> Setup 시 환경설정파일의 위치도 아래에서 `% AppData %\Roaming\[ProductName]` 가 되도록 셋팅한다.
7. (환경설정파일 경로 및 파일명 설정)프로젝트에서 기본출력 from BuildingLeaseUI (Active)  더블클릭
  1. File System On Target Marchine 선택
  2. 마우스 우측클릭 -> Add Spical Folder -> 사용자 애플리케이션 데이터 폴더 선택 -> User's Application Data Folder 생성됨(% AppData %\Roaming)
  3. User's Application Data Folder 선택(% AppData %\Roaming) -> BuildingLeaseManagement 폴더 추가 및 App.Config 파일 추가
  4. 환경설정 파일 추가: 우측클릭 -> Add -> App.config 추가 후 
  5. 추가된 App.Config 파일의 Target Name을 BuildingLeaseManagement.config로 변경
8. Release 모드로 전환
9. SetupBuildingLease 프로젝트 속성에서 Version을 변경한다.(ProductCode가 새로운 값으로 할당된다.)
10. 그래야 이전 설치된 파일을 자동으로 삭제한다.
11. 빌드
12. msi 파일을 배포