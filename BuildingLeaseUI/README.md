# UI

## 설명
* BuildingLeaseUI 프로젝트

* DevExpress의 속성편집은 디자인 모드를 최대한 이용하였음.
* DevExpress의 Form 및 User Control의 layout은 Layout Manager를 사용하였음
	* instant Layout Assistant에서 Add Control -> Layout & Containers-> Layout Manager선택
* Setup 후 환경설정 파일 위치:  % AppData %\Roaming 위치임. 
	* C:\Users\사용자명\AppData\Roaming\프로젝트명\프로젝트명.config

## 솔루션 구조
* Repoort: Devexpress Report
* Resources: 
* UI
	* Forms: DevExpress Form
	* Modules: DevExpress User Control

## Environment
* IDE: Visual Studio 2022
* Language: C#
* Applied Project Template: .NET Framework 4.8.1
	* DevExpress v23.2 Winforms App Template Gallery - Fluent Design Application(.Net Framework)  
* NuGet
* Third Party Libraries
	* DevExpress 23.2
* DataBase: MS SQL 2022

----
* 메인폼 : DevExpress v23.2 Winforms App Template Gallery - Fluent Design Application(.Net Framework) 로 생성
* 로그인 화면의 [이미지](https://www.shutterstock.com/search/building?page=3)는 
  * [shutterstock.com](https://www.shutterstock.com)에서 찾았으며 
  * 편집은 [피그마](https://www.figma.com/)를 이용하여 작성하였음
* 참조추가 : DevExpress.Tutorial library - Fluent Design Form 에서 AccordionControl로 fluentDesignFormContainer에 폼을 호출할 때 사용
  * C:\Program Files\DevExpress 23.1\Components\Bin\Framework\DevExpress.Tutorials.v23.1.dll
* Devexpress Project Setting 
  * font 맑은 고딕, 10 -> 9.75로 변경됨.
  * DirectX = 체크: 차트 및 그리드 속도 향상
  * DPI Awareness = system
* 각 세부 폼은 `사용자 컨트롤`로 추가 후 상속을 `: DevExpress.DXperience.Demos.TutorialControlBase //DevExpress.XtraEditors.XtraUserControl`로 변경
* 속성
  * 어셈블리 이름: BuildingLeaseManagement
  * 기본 네임스페이스: BuildingLeaseUI	
  * 어셈블리 정보
	* 제목, 제품: BuildingLeaseManagement
	* 회사: BuildingLeaseManagement
	* 저작권: Copyright 2023. Mansik Kim
	* Assembly Version(변경안함)
	* Assembly File Version: 빌드시 증가 또는 변경안함.
----

# 파일 버전 관리
* 만약 버전변경을 한다면 Assembly version은 고정하고, Assembly File Version만 변경할 것.
* => Assembly version 변경 시 충돌 가능성 있음