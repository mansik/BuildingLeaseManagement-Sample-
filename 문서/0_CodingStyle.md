# Coding Style

# 폼디자인
DB의 컬럼을 기준으로 컨트롤 명칭을 "_"없이 동일하게 만든다. (DB : incs_cd, IncsCD , 컨트롤 명칭 : txtIncsCD)  
만약, 한폼에 종류가 다른데 컬럼명이 동일하면 종류명+컬럼명으로 컨트롤 명칭을 만든다. (DB : incs_cd, IncsCD, 컨트롤 명칭 : txtInsnIncsCD (보험:Insn), txtTraiIncsCD (자보:Trai))

# DB 설계
기초코드를 먼저 설계하고 기초코드를 참조하는 다른 테이블은 기초코드의 컬럼명과 동일한 컬럼명을 사용한다.
테이블명, 컬럼명은 대소문자를 구분하는 DB의 경우 Pascal 형식으로 명명한다. "_" 제거

# C# Coding Style
https://github.com/dotnet/runtime/blob/main/docs/coding-guidelines/coding-style.md

## Example File:

* ObservableLinkedList`1.cs:

    ```C#
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Diagnostics;
    using Microsoft.Win32;

    namespace System.Collections.Generic
    {
        public partial class ObservableLinkedList<T> : INotifyCollectionChanged, INotifyPropertyChanged
        {
            private ObservableLinkedListNode<T> _head;
            private int _count;

            public ObservableLinkedList(IEnumerable<T> items)
            {
                if (items == null)
                    throw new ArgumentNullException(nameof(items));

                foreach (T item in items)
                {
                    AddLast(item);
                }
            }

            public event NotifyCollectionChangedEventHandler CollectionChanged;

            public int Count
            {
                get { return _count; }
            }

            public ObservableLinkedListNode AddLast(T value)
            {
                var newNode = new LinkedListNode<T>(this, value);

                InsertNodeBefore(_head, node);
            }

            protected virtual void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
            {
                NotifyCollectionChangedEventHandler handler = CollectionChanged;
                if (handler != null)
                {
                    handler(this, e);
                }
            }

            private void InsertNodeBefore(LinkedListNode<T> node, LinkedListNode<T> newNode)
            {
                ...
            }

            ...
        }
    }
    ```

* ObservableLinkedList`1.ObservableLinkedListNode.cs:

    ```C#
    using System;

    namespace System.Collections.Generics
    {
        partial class ObservableLinkedList<T>
        {
            public class ObservableLinkedListNode
            {
                private readonly ObservableLinkedList<T> _parent;
                private readonly T _value;

                internal ObservableLinkedListNode(ObservableLinkedList<T> parent, T value)
                {
                    Debug.Assert(parent != null);

                    _parent = parent;
                    _value = value;
                }

                public T Value
                {
                    get { return _value; }
                }
            }

            ...
        }
    }
    ```


# 일반적인 C# 코드 규칙
https://learn.microsoft.com/ko-kr/dotnet/csharp/fundamentals/coding-style/coding-conventions

# C# 식별자 명명 규칙 및 규칙
https://learn.microsoft.com/ko-kr/dotnet/csharp/fundamentals/coding-style/identifier-names

* 명명 규칙

* 규칙 외에도 .NET API 전체에서 사용되는 많은 식별자 명명 규칙이 있습니다.  
* 규칙에 따라 C# 프로그램은 형식 이름, 네임스페이스 및 모든 공용 멤버에 PascalCase를 사용합니다. 
* 또한 dotnet/docs 팀은 .NET 런타임 팀 코딩 스타일에서 채택된 다음 규칙을 사용합니다.

  - 인터페이스 이름은 대문자 I로 시작합니다.
  - 특성 유형은 Attribute 단어로 끝납니다.
  - 열거형 형식은 플래그가 아닌 경우에는 단수 명사, 플래그에는 복수 명사 등을 사용합니다.
  - 식별자에는 두 개의 연속된 밑줄() 문자가_ 포함되어서는 안 됩니다. 이러한 이름은 컴파일러에서 생성된 식별자를 위해 예약됩니다.
  - 변수, 메서드 및 클래스에 의미 있고 설명이 포함된 이름을 사용합니다.
  - 단순 루프 카운터를 제외하고 단일 문자 이름을 사용하지 마세요. 다음 섹션에서 설명한 구문 예제에 대한 예외를 참조하세요.
  - 간결성보다 선명도를 선호합니다.
  - 클래스 이름 및 메서드 이름에 PascalCase를 사용합니다.
  - 메서드 인수, 지역 변수 및 프라이빗 필드에 camelCase를 사용합니다.
  - 필드와 로컬 상수 모두의 상수 이름에 PascalCase를 사용합니다.
  - 프라이빗 인스턴스 필드는 밑줄(_)로 시작합니다.
  - 정적 필드는 .로 시작합니다 s_. 
  - 기본 Visual Studio 동작이나 프레임워크 디자인 지침의 일부는 아니지만 editorconfig에서 구성할 수 있습니다.
  - 널리 알려지고 허용되는 약어를 제외하고 이름에 약어 또는 약어를 사용하지 마십시오.
  - 역방향 도메인 이름 표기법을 따르는 의미 있고 설명이 포함된 네임스페이스를 사용합니다.
  - 어셈블리의 기본 용도를 나타내는 어셈블리 이름을 선택합니다.

* C# 구문의 구문을 설명하는 예제에서는 C# 언어 사양에 사용되는 규칙과 일치하는 단일 문자 이름을 사용하는 경우가 많습니다.

  - 구조체, C 클래스에 사용합니다S.
  - 메서드에 사용합니다 M .
  - 변수p, 매개 변수에 사용합니다v.
  - 매개 변수에 ref 사용합니다r.

* 앞의 단일 문자 이름은 언어 참조 섹션에서만 허용됩니다.

## 카멜식 대/소문자
1. 이름 또는 internal 필드의 이름을 지정할 private 때 낙타 대/소문자("camelCasing")를 사용하고 접두사 _ 를 사용합니다. 
2. 대리자 형식의 인스턴스를 포함하여 지역 변수의 이름을 지정할 때 카멜 대/소문자를 사용합니다.
    ```C#
    public class DataService
    {
        private IWorkerQueue _workerQueue;
    }
    ```
3. private 또는 internal인 static 필드를 사용할 때는 s_ 접두사를 사용하고 스레드 정적인 경우 t_을 사용합니다.
    ```C#
    public class DataService
    {
        private static IWorkerQueue s_workerQueue;

        [ThreadStatic]
        private static TimeSpan t_timeSpan;
    }
    ```

4. 메서드 매개 변수를 작성할 때 카멜식 대/소문자를 사용합니다.
    ```C# 
    public T SomeMethod<T>(int someNumber, bool isValid)
    {
    }
    ```

# .NET 코딩 가이드 라인
https://learn.microsoft.com/ko-kr/dotnet/standard/design-guidelines/naming-guidelines

1. 탭과 확장  
    ​Tab 문자 사용하지 않으며, 확장은 공백 문자 4개 사용

2. 중괄호  
    중괄호는 Block을 이끄는 구문의 아랫줄 처음에서 시작  
    중괄호에 안의 내용은 공백 문자 4개 이후에 기록  
    ```C#
    if(someExpression)
    {
        DoSomething();
    }
    else
    {
        DoSomethingElse();
    }
    ```

    "case" 구문은  "switch" 구문 아래 다음처럼 작성​
    ```C#
    switch(someExpression)
    {
        case 0:
            DoSomething();
            break;


        case 1:
            DosomethingElse();
            break;


        case 2:
            {
                int n = 1;
                DoAnotherThing(n);
            }
    }​
    ```

    블락에 단 한 줄의 구문이 사용되더라도 중괄호를 사용. 코드의 가독성 및 유지 보수 효율을 높임

3. 단줄 구문
    한 줄로 구성된 구문은 중괄호를 같은 줄에 함께 사용할 수 있다. 

    ```C#
    public class Foo
    {
        int bar;

        public int Bar
        {
            get { return bar; }
            set { bar = value; }
        }
    }
    ```
    이는 중괄호를 사용하는 모든 구문(if, while, for, etc.)에 적용될 수 있음

4. 주석
    1. 주석  
        주석은 개발 목표, 알고리즘 개관, 논리 흐름을 보이기 위해 사용되어야 함  
        주석 자체를 읽는 것만으로 함수의 목적, 동작, 일반 기능에 대한 이해를 할 수 있어야 함  

    2. 판권 알림  
        각각의 파일은 판권에 대한 고지로 시작을 한다.  
        다음 예시의 문장은 제품에 따라 바뀔 수 있지만, 이와 유사한 형태여야 함  

        ```
        //-----------------------------------------------------------------------
        // <copyright file="ContainerControl.cs" company="Microsoft">
        //     Copyright (c) Microsoft Corporation.  All rights reserved.
        // </copyright>
        //-----------------------------------------------------------------------
        ```

    3. 기록 주석  
        주석 파일의 빌드 과정에서 오류를 피하기 위해, 삼중 슬래시를 사용하지 않을 수 있음  
        하지만, XML의 사용은 추후 주석의 교환 등에서 편의를 제공  
        특히 methods 관련 주석의 경우, XML doc 주석 형식을 사용  

        지역적 dev 주석은 <devdoc> 태그를 사용

        ```C#
        public class Foo
        {

            /// <summary>Public stuff about the method</summary>
            /// <param name=”bar”>What a neat parameter!</param>
            /// <devdoc>Cool internal stuff!</devdoc>
            ///
            public void MyMethod(int bar) { ... }

        }
        ``` 

        외부에 존재하는 XML 주석 파일을 삽입하려면, <include> 태그를 사용 

        ```C#
        public class Foo
        {

            /// <include file='doc\Foo.uex' path='docs/doc[@for="Foo.MyMethod"]/*' />
            ///
            public void MyMethod(int bar) { … }

        }
        ```
    4. 주석 형식  
        이중 슬래시 형식은 대다수의 상황에서 사용  
        가능하다면 주석의 위치는 코드의 옆보다는 위에 사용 

        ```C#
        // This is required for WebClient to work through the proxy
        //
        GlobalProxySelection.Select = new WebProxy( ... );

        // Create object to access Internet resources
        //
        WebClient myClient = new WebClient();
        ```

        주석은 공간이 허용한다면, 줄의 마지막에 위치할 수도 있다

        ```C#
        public class SomethingUseful
        {
            private int itemHash;                              // instance member
            private static bool hasDoneSomething;    // static member
        }
        ```

5. 공백(space) 문자의 사용  
    공백 문자는 코드 밀도를 감소시켜 가독력을 높여줌

    - 함수 구문에 존재하는 따옴표 다음에는 하나의 공백 문자를 사용한다.  
        Right:        Console.In.Read(myChar, 0, 1);  
        Wrong:      Console.In.Read(myChar,0,1);  

    - 소괄호 시작과 끝에서는 공백 문자를 사용하지 않는다.  
        Right:        CreateFoo(myChar, 0, 1);  
        Wrong:      CreateFoo( myChar, 0, 1 );   

    - 소괄호와 함수 사이에서는 공백 문자를 사용하지 않는다.  
        Right:        CreateFoo()  
        Wrong:      CreateFoo ()  

    - 대괄호 안에서는 공백 문자를 사용하지 않는다.  
        Right:        x = dataArray[index];  
        Wrong:      x = dataArray[ index ];  

    - 흐름 제어 구문에서는 공백 문자 하나를 사용한다.  
        Right:        while (x == y) { ... }  
        Wrong:      while(x == y) { ... }  
 
    ㆍ 비교 명령 앞 뒤에서는 공백 문자 하나를 사용한다.  
        Right:        if (x == y) { ... }  
        Wrong:      if (x==y) { ... }  

6. 작명  
   * 대소문자 : https://msdn.microsoft.com/ko-kr/library/ms229043(v=vs.100).aspx
    ```
    식별자         Case        예제  
    class         파스칼식    AppDomain  
    열거형        파스칼식    ErrorLevel  
    열거형 값     파스칼식    FatalError  
    event         파스칼식    ValueChanged  
    예외 클래스   파스칼식    WebException  
    읽기 전용 정적 필드 파스칼식    RedValue  
    interface     파스칼식    IDisposable  
    메서드        파스칼식    ToString  
    namespace     파스칼식    System.Drawing  
    인자          카멜식      typeName  
    Property      파스칼식    BackColor  
    ```

    다음은 .NET Framwork에서 지역 및 전역 변수에 이름을 부여하는 방법  

    - 헝가리안 표기법을 사용하지 않는다.
    - 멤버 변수를 위한 접두어(_, m_, s_, etc.)를 사용하지 않는다.
        지역 변수와 전역 변수를 구분하고 싶다면, C#에서는 "this."를 VB.NET에서는 "Me."를 사용한다.  
    - 멤버 변수는 camel 표기법을 사용한다.
    - 매개 변수는 camel 표기법을 사용한다.
    - 지역 변수는 camel 표기법을 사용한다.
    - 함수, 클래스, 이벤트 등은 파스칼 표기법을 사용한다.
    - 함수 명명은 동사(행위)+명사순(GetName)를 주로 하고, 명사+전치사+명사(StringToDate), 전치사+명사(ToString) 

    > `참고`
    >    - 파스칼식 대/소문자: 식별자의 첫 번째 문자와, 연결된 각 후속 단어의 첫 번째 문자를 대문자로 표기한다.  
    >    예) BackColor  
    >    
    >    - 카멜식 대/소문자: 식별자의 첫 번째 문자는 소문자로 표기한다.  
    >     연결된 각 후속 단어의 첫 번째 문자는 대문자로 표기한다.  >     
    >     예) backColor  
    > 
    >    - 인터페이스 이름에는 접두어 "I"를 사용한다.
    >    - enum, class 에서 접두어를 사용하지 않는다.

    이는 일관성 있고 가독성 높은 코드 생산을 위하여, 알려진 지침을 확장시킨 것이다.

7. 작명 규약

    1 Interop Classes

    DllImport 구문을 가진 클래스들은, 다음과 같은 작명 규약을 따라야 한다:
    - NativeMethods: No suppress unmanaged code attribute, these are methods that can be used anywhere because a stack walk will be performed. 
  
    ```C#
    class NativeMethods
    {
        private NativeMethods() { ... }

        [DllImport(“user32”)]
        internal static extern void FormatHardDrive(string driveName);
    }

        ㆍ UnsafeNativeMethods: Has suppress unmanaged code attribute. These methods are
            potentially dangerous and any caller of these methods must do a full security review to   
            ensure that the usage is safe and protected as no stack walk will be performed.
    ```		

    ```C#
    [SuppressUnmanagedCode]
    class UnsafeNativeMethods
    {
        private UnsafeNativeMethods() { ... }

        [DllImport(“user32”)]
        internal static extern void CreateFile(string fileName);
    }


        ㆍ SafeNativeMethods: Has suppress unmanaged code attribute. These methods are safe and
            can be used fairly safely and the caller isn’t needed to do full security reviews even though
            no stack walk will be performed. 
    ```

    ```C# 
    [SuppressUnmanagedCode]
    class SafeNativeMethods
    {
        private SafeNativeMethods() { ... }

        [DllImport(“user32”)]
        internal static extern void MessageBox(string text);
    }
    ``` 

    모든 interop 클래스는 private 이어야 하며, 모든 method는 지역적이어야 함  
    또한 모든 private 생성자는 인스턴스 생성을 예방한 후 제공되어야 함  

8. 파일 구성

    - 각각의 소스 파일에는 하나의 public 클래스만 담는다.  
    - 소스 파일의 이름에는 내부 public 클래스의 이름이 담겨있어야 한다.  
    - 디렉토리 이름은 각 클래스의 namespace를 따른다.  

        예를 들어, "System.Windows.Forms.Control"라는 public 클래스를 "system\Windows\Forms\Control.cs"라는 디렉토리에서 찾으려 할 때,  

    - 클래스 멤버는 알파벳 순서로 정렬되어 있어야 하며, 부문별로 그룹지어져 있어야 한다. (Fields, Constructors, Properties, Events, Methods, Private interface, etc.)  
    - 사용된 구문은 namespace 정의에 존재하여야 한다.  

    ```C#
    namespace MyNamespace
    {

        using System;

            public class MyClass : IFoo
            {
                // fields
                int foo;

                // constructors
                public MyClass() { ... }

                // properties
                public int Foo { get { ... } set { ... } }

                // events
                public event EventHandler FooChanged { add { ... } remove { ... } }

                // methods
                void DoSomething() { … }
                void FindSomethind() { … }

                //private interface implementations
                void IFoo.DoSomething() { DoSomething(); }

                // nested types
                class NestedType { ... }

        }

    }
    ```


# 명명: [.NET 코딩 가이드 라인]을 기초로 작성함.

## 함수명명 동사부분
```
Rtrv : DB를 통한 조회 : RtrvPt
Show : DB를 통하지 않는 화면에 뿌려줄 경우 : ShowPtInfo
Clear : 값, 화면을 초기화
Save : 저장 : SavePrscPrnDel
Set  : 구조체, 변수, 콤보박스등에 값을 셋팅(return값 있는 경우) : SetCboPtDgns, SetBindingRtrvAdmsRcpn
Get  : 구조체, 변수등에서 값을 가져올 경우(return값 있는 경우) : GetIotmName
Check : 값등을 체크 : CheckJumin
Clcl(calculation),Cal,Compute : 계산
Find : 찾기
Erase : 지우기
Add : 추가, DB에서 주로 사용
Update : DB에서 주로 사용
Delete : DB에서 주로 사용
Insert : DB에서 주로 사용
Read : 파일에서 주로 사용
Write :파일에서 주로 사용
```

## 컨트롤 : 헝가리안 표기법
```
ani - Animation button
bed - Pen Bedit
cbo - Combobox
chk - Checkbox
clp - Picture Clip
com - Communications
ctr - Control(타입이 알려지지 않은 컨트롤)
dat - Data
db -  ODBC Database
dir - Directory List Box
dlg - Common Dialog
drv - Drive List Box
ds -  ODBC Dynaset
fil - File List Box
frm - Form
fra - Frame
gau - Gauge
gpb - Group Push Button
grd - Grid
hed - Pen Hedit
hsb - Horizontal Scroll Bar
img - Image
ink - Pen Ink
key - Keyboard key status
lbl - Label
lin - Line
lst - Listbox
mdi - MDI Child Form
mpm - MAPI Message
mps - MAPI Session
mci - MCI
mnu - Menu
opt - Option Button
ole - Ole Client
opt - Option Button
out - Outine Control
pic - Picture
pnl - 3d Panel
rpt - Report Control
shp - Shae
spn - Spin Control
txt - Text/Edit Box
tmr - Timer
vsb - Vertical Scroll Bar
```

## 변수 : 헝가리안 : 사용금지
```
c             char
by            BYTE(unsigned integer)
n             short
i             int
x,y           x좌표와 y좌표를 쓸때 이용하는 int
cx, cy        x또는 y길이로 사용, c는 "count"를 의미한다.
b 또는 f      BOOL(int), f는 "flag"를 의미한다.
w             WORD(unsigned long)
l             LONG(long)
dw            DWORD(unsigned long)
fn            function
s             string
sz            string terminated by 0 byte
h             handle
p             pointer
vt            VARIANT
hr            HRESULT
m             A member variable in a class.
st,s_         A static member variable in a class.
g             A global variable.
I             COM interface
```

## DB 설계 | 종료문자
```
Dt      : 일시 datetime 
Stdt(시작일시), Endt(종료일시) : 기간의 일시 datetime
Date    : 기간이 아닌 일자 varchar(8)
Stdy(시작일자),Endy(종료일자) : 기간의 일자 varchar(8)
Perd    : 기간 100일, varchar(3) 
Itvl    : 간격(interval)

Tm, Time: 시간
YM, YYMM: 년월

Dvcd    : 구분코드
Tycd    : 유형코드

Rgno    : 기관기호
Cnt     : 개수
No      : 번호

Odno    : 차수
Amt     : 금액

Cd      : 코드
Stat_Cd : 상태코드

Nm      : 명칭
Yn      : 여부
Dosg    : 용량

Nots        : 메모
Cnts        : 내용
Resn        : 사유

Rrrn        : 주민번호
Frrn        : 주민번호앞
Srrn        : 주민번호 뒤

Seq        : 순서
Sqno        : 자동증가 일련번호 
```

## Spread 활성시트
Fpspread1.ActiveSheet 사용 (Fpspread1.Sheet(0)는 특수한 경우만 사용)

## Spread rowcount<0 일 경우 작업이 일어나지 않도록 :셀클릭, 더블클릭등에는 무조건 사용
if Fpspread1.ActiveSheet.ActiveRowIndex<0 then exit sub
