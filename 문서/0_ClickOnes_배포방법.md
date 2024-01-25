# ClickOnes 배포방법
0. ClickOnes 에서 배포 및 update 가 된다.

1. SalesMngm 프로젝트 빌드 (AutoUpdate 프로젝트는 필요 없음)

2. SalesMngm 프로젝트 속성 -> 서명
    - 아래 '자체 서명된 인증서 만들기' 대로 작업  
    - 파일에서 선택 -> 위에서 만든 인증서 선택(d:\SalesMngm.pfx)  

3. SalesMngm 프로젝트 속성 -> 보안
    - 'ClickOnes 보안 설정 사용' 체크  
    - '완전 신뢰 어플리케이션' 선택  

4. SalesMngm 프로젝트 속성 -> 게시 -> 지금게시
    - 폴더 위치 게시 : 게시 파일이 만들어질 폴더 (..\Setup ClickOnes\)  
    - 설치폴더 URL : 실제 설치된 인터라넷의 경로 입력(여기서 update 가 일어남) :   \\ms\SalesMngm\  
        > SalesMngm.application 파일에서 변경 가능  
         ```C#
         <deploymentProvider codebase="file://ms/SalesMngm/SalesMngm.application" />
         ```
    - 어플리케이션 파일  
        : SalesMngm.config 포함, txtHistory.txt 제외  
    - 필수구성요소 : 맞는 .netframework 체크  
    - 업데이트 : 업데이트 체크, 어플리케이션 시작 전 체크  
    - 옵션  
        : 설명 : 게시자 이름, 제품이름 기재  
        : 배포 : publish.html , 게시할 때마다 자동으로 배포 페이지... 체크  
        : 매니페스트 : 바탕화면 바로가기 만들기 체크  

5. 게시 폴더의 것을 배포 
    - 아래 2개의 파일만 있으면 설치가 된다.  
        SalesMngm.application  
        setup.exe  

6. 이후 소스 빌드 때 마다 
    - SalesMngm 프로젝트 속성 -> 게시 -> 지금게시  


# 설치하는 컴퓨터
1. 설치 하는 컴퓨터에서 작업(신뢰할수 없는 인증서... 로 인해 설치 거부 되는 것 막음)
    - regedit
        \HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\.NETFramework\Security\TrustManager\PromptingLevel  
        LocalIntranet  Enabled  
        MyComputer     Enabled  

2. 게시 폴더의 SalesMngm.application, setup.exe 파일을 복사헤서 설치함.

3. ClickOnes로 설치된 파일 삭제
    - C:\Users\kmans\AppData\Local\Apps\2.0\ 폴더내 임의의 명칭이 있는 폴더 삭제(PB3RXA4B.H8X)


# 자체 서명된 인증서 만들기
    - MSDN에 보면 MakeCert는 사용하지 말라고 권장
    - MS Docs에 가보면 New-SelfSignedCertificate 라는 것을 사용합니다.
      이는 PowerShell을 통해 사용 가능하며, MS Docs에 설명이 나와있습니다.,   
      https://learn.microsoft.com/ko-kr/windows/msix/package/create-certificate-package-signing

1. PowerShell에서 (옵션 설명 :  -NotAfter (Get-Date).AddYears(10) << 10은 현재부터 10년동안 유효기한)

    New-SelfSignedCertificate -Type Custom -Subject "CN=KMS Software, O=KMS Corporation, C=US" -KeyUsage DigitalSignature -FriendlyName "Your friendly name goes here" -CertStoreLocation "Cert:\CurrentUser\My" -TextExtension @("2.5.29.37={text}1.3.6.1.5.5.7.3.3", "2.5.29.19={text}") -NotAfter (Get-Date).AddYears(10)
     
     > 결과  
        Thumbprint                                      CN  
     B7DA0FBE0821E6357C1BA32F0F1EB570EF5C7162       KMS Software  

2. 암호 설정, 여기의 암호가 3)에 사용됨 : <Your Password> 부분에 들어가는 것이 암호이다.  
    예시) $password = ConvertTo-SecureString -String <Your Password> -Force -AsPlainText   

    $password = ConvertTo-SecureString -String miju@miju.com -Force -AsPlainText  

3. 인증서 내보내기 : 2)의 $password 변수를 사용  
    예시) Export-PfxCertificate -cert Cert:\CurrentUser\My\<Certificate Thumbprint> -FilePath <FilePath>.pfx -ProtectTo <Username or group name>
    
    Export-PfxCertificate -cert Cert:\CurrentUser\My\B7DA0FBE0821E6357C1BA32F0F1EB570EF5C7162 -FilePath d:\SalesMngm.pfx -Password $password  
    
4. 인증서 설치 : 3)의 -FilePath d:\SalesMngm.pfx 의 파일을 마우스 우측클릭해서 설치  
    - SalesMngm.pfx 파일을 설치 1  
        : 현재사용자 - 암호 입력(miju@miju.com : 2)에서 설정한 암호) - '인증서 종류를 기준으로 인증서 저장소를 자동선택' 선택함 (윈도우의 '사용자 인증서 관리' 프로그램 실행 -> '개인용' 에 위치함 )  

    - SalesMngm.pfx 파일을 설치 2  
        : 현재사용자 - 암호 입력(miju@miju.com : 2)에서 설정한 암호) - '모든 인증서를 다음 저장소에 저장' 선택함 - '신뢰할 수 있는 루트 인증 기관' 선택 (윈도우의 '사용자 인증서 관리' 프로그램 실행 -> '신뢰할 수 있는 루트 인증 기관' 에 위치함 )  
        : 설치 2번의 작업으로 설치 파일 실행시 Publisher 가 Unknown 에서 해당 인증서로 됨.  