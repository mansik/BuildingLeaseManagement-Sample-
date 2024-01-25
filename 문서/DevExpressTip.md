# DevExpress Tips

# LoadModuleAsync()를 통해서 사용자 폼(UserControl)를 추가 및 layoutcontrol 사용한 경우 
* 사용자 폼에서 컨트롤 숨길 경우 컨트롤를 감싸고 있는 layoutControlItem의 Visibility 속성을 사용한다.
  * ex) layoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

# Form BackgroundImageLayout = Stretch로 해야 DefaultAppFont의 폰트크기가 변경하면 이미지도 변경된다.(LoginForm에 적용)

# GridView에 체크박스 추가하기: GridView -> Run Designer -> View -> OptionsSelection
* MultiSelectMode = CheckBoxRowSelect, MultiSelect = True
* ShowCheckBoxSelectorInPrintExport = True, ShowCheckBoxSelectorInColumnHeader = True, ShowCheckBoxSelectorInGroupRow = True

# 출력시 컬럼의 width가 너무 줄어들때: 디자인 모드- 컬럼 - minwidth 조정

# 폼에서 키보드 이벤트를 받기 위해서 MainForm.KeyPreview = True;

# Fluent Design Form 에서 AccordionControl 을 사용한 사용자 폼(UserControl)을 한번만 로드 하기, DevExpress.Tutorial library 이용(이것 사용)
> DevExpress.DXperience.Demos.TutorialControlBase 에서 상속받은 사용자 control을 만들어서 작업
> add a reference to the DevExpress.Tutorial library
> C:\Program Files\DevExpress 23.1\Components\Bin\Framework\DevExpress.Tutorials.v23.1.dll

```C#
// UsersModules
namespace BuildingLease.UI.Modules
{
    public partial class LesseeModule : DevExpress.DXperience.Demos.TutorialControlBase //DevExpress.XtraEditors.XtraUserControl
    { 
        public LesseeModule()
        {
            InitializeComponent();
        }
    }
}
```

```C#
// FormMain
    public partial class MainForm : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public MainForm()
        {
            InitializeComponent();

            baritemUserName.Caption = Data.User.UserName;
         }

        async Task LoadModuleAsync(ModuleInfo module)
        {
            await Task.Factory.StartNew(() =>
            {
                if (!fluentDesignFormContainer.Controls.ContainsKey(module.Name))
                {
                    TutorialControlBase control = module.TModule as TutorialControlBase;
                    if (control != null)
                    {
                        control.Dock = DockStyle.Fill;
                        control.CreateWaitDialog();                        
                        fluentDesignFormContainer.Invoke(new MethodInvoker(delegate ()
                        {
                            fluentDesignFormContainer.Controls.Add(control);
                            control.BringToFront();
                        }));
                    }
                }
                else
                {
                    var control = fluentDesignFormContainer.Controls.Find(module.Name, true);
                    if (control.Length == 1)
                        fluentDesignFormContainer.Invoke(new MethodInvoker(delegate () { control[0].BringToFront(); }));                    
                }
            });
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.fluentDesignFormContainer.Controls.Add(new CashBookModule() { Dock = DockStyle.Fill });
            this.baritemNav.Caption = $"{mnuCashBook.Text}";
            accordionControl1.SelectedElement = mnuCashBook;
        }

        private async void mnuLessee_Click(object sender, EventArgs e)
        {
            this.baritemNav.Caption = $"{elementLeaseContractGroup.Text} > {mnuLessee.Text}";            
            if (ModulesInfo.GetItem("LesseeModule") == null)
                ModulesInfo.Add(new ModuleInfo("LesseeModule", "BuildingLease.UI.Modules.LesseeModule"));
            await LoadModuleAsync(ModulesInfo.GetItem("LesseeModule"));
        }
    }
```

# Fluent Design Form 에서 AccordionControl 을 사용한 사용자 폼(UserControl)을 한번만 로드하기 => 이것 사용하지 말고 위의 것으로 대체)
```C#
// UsersModules
namespace BuildingLease.UI.Modules
{
    public partial class CashBookModule : DevExpress.XtraEditors.XtraUserControl
    {
        // 화면에 한번만 로딩하기
        private static CashBookModule _instance;
        public static CashBookModule Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CashBookModule();
                return _instance;
            }
        }

        public CashBookModule()
        {
            InitializeComponent();
        }
    }
}
```

```C#
// FormMain
private void accordionControlElementLessee_Click(object sender, EventArgs e)
{
    if (!fluentDesignFormContainer.Controls.Contains(UsersModule.Instance))
    {
        fluentDesignFormContainer.Controls.Add(UsersModule.Instance);
        UsersModule.Instance.Dock = DockStyle.Fill;
        UsersModule.Instance.BringToFront();
    }
    UsersModule.Instance.BringToFront();
}
```


# IMEMode 는 한글 반각인 Hangul 선택
* Fluent Design Form 에서 사용자 컨트롤의 IME 설정은 
*  부모폼(MainForm)에서 IMEMode를 한글 반각인 Hangul을 선택하면 
*  추가된 컨트롤은 자동 적용된다.(여기서는 Module들도 컨트롤로 추가되었으므로 자동적용됨.)
```C#
ImeMode = ImeMode.Hangul; // 추가된 컨트롤에서 한글이 선택되도록 한다.(Hangul = 한글 반각)
```

* 아래 작업은 안해줘도 됨.
```C#
public FormLogin()
{
    InitializeComponent();
    textEditUserName.GotFocus += new EventHandler(textEditUserName_GotFocus);    
}

private void textEditUserName_GotFocus(object sender, EventArgs e)
{
    // 시작시 포커스가 되는 컨트롤은 속성창에 imemode가 안먹혀서 여기서 설정 => 컨트롤이 아닌 폼에서 IMEMode를 설정하면 됨
    textEditUserName.ImeMode = ImeMode.Hangul;
}
```

# TextEdit Control 에서 Enter 키 입력시 다음 컨트롤로 포커스 이동하기 : EnterMoveNextContrl 속성 

# 문자열 변수 값 지정시 다음과 같은 경우에 @기호를 사용
1. 파일경로 표현시(백슬래시 '\' 사용)
2. 쿼리문 작성시(string 여러줄의 문자열 지정)

* 일반문자열로 표현시  
```C#
string file = "C:\\Users\\Downloads\\ReadMe.txt";
string sql = 
    "SELECT Seq"            
    + "     , Name " 
    + "     , Flavor " 
    + "     , Rank " 
    + "FROM Fruit ";

Debug.WriteLine(sql); // 한줄로 보여짐
```

* @기호 사용시  
```C#
string file = @"C:\Users\Downloads\ReadMe.txt";
string sql = 
    @"SELECT Seq
        , Name 
        , Flavor 
        , Rank 
    FROM Fruit ";

Debug.WriteLine(sql); // 한줄로 보여짐
```

# query 작성 및 디버깅시 가독성 향상 : @ 또는 \n\r 또는 Environment.NewLine 사용
```C#
// 이것 추천
string sql = 
    @"SELECT Seq
        , Name 
        , Flavor 
        , Rank 
    FROM Fruit ";

```
```C#
string sql = 
    "SELECT Seq "+"\r\n"+    
    "     , Name "+"\r\n"+
    "     , Flavor "+"\r\n"+
    "     , Rank "+"\r\n"+
    "FROM Fruit ";

```
```C#
string sql = 
    "SELECT Seq " + Environment.NewLine +
    "     , Name " + Environment.NewLine +
    "     , Flavor " + Environment.NewLine +
    "     , Rank " + Environment.NewLine +
    "FROM Fruit ";

Debug.WriteLine(sql); // 위의 문장 그대로 보여짐
```