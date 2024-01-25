using Microsoft.Win32;
using System.Windows.Forms;

namespace BuildingLease.Library
{
    public class Register
    {
        // 프로그램에 따라  RegAppRootPath을 지정해줘야한다. Application.ProductName으로 하면 update가 안일어난다.(autoupdate에서 Application.ProductName = autoupdate로 되어 경로를 못찾는다.)
        private static readonly string s_regAppRootPath = @"SOFTWARE\" + Application.ProductName + @"\";

        /// <summary>
        /// HEKY_CURRENT_USER\SOFTWARE\appname\subKey\
        /// </summary>
        /// <param name="appname">등록될 프로그램 명칭</param>
        /// <param name="subKey">appname아래에 등록될 섹션(디렉터리)</param>
        /// <returns></returns>
        private static RegistryKey OpenWriteModeRegKey(string appname = null, string subKey = null)
        {
            RegistryKey key = null;
            string path = RegPath(appname, subKey);

            key = Registry.CurrentUser.OpenSubKey(path, true);
            if (key == null)
                key = Registry.CurrentUser.CreateSubKey(path);

            return key;
        }

        /// <summary>
        /// 레지스트리 키 경로 설정
        /// HEKY_CURRENT_USER\SOFTWARE\appname\subKey\
        /// </summary>
        /// <param name="appname">레지스트리에 등록될 프로그램 명칭</param>
        /// <param name="subKey">레지스트리의 appname아래에 등록될 섹션(디렉터리)</param>
        /// <returns></returns>
        private static string RegPath(string appname = null, string subKey = null)
        {
            string path = string.Empty;

            if (appname == null)
            {
                path = s_regAppRootPath;
                if (subKey != null)
                    path = s_regAppRootPath + subKey + @"\";
            }
            else
            {
                path = s_regAppRootPath + appname + @"\";
                if (subKey != null)
                    path = path + @"\" + subKey + @"\";
            }
            return path;
        }

        /// <summary>
        /// HEKY_CURRENT_USER\SOFTWARE\appname\에 저장
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public static void SetRegKey(string name, object value)
        {
            var key = OpenWriteModeRegKey();
            if (key != null)
            {
                key.SetValue(name, value);
                key.Close();
            }
        }

        public static void SetRegKey(string appname, string name, object value)
        {
            var key = OpenWriteModeRegKey(appname);
            if (key != null)
            {
                key.SetValue(name, value);
                key.Close();
            }
        }
        public static void SetRegKey(string appname, string subKey, string name, object value)
        {
            var key = OpenWriteModeRegKey(appname, subKey);
            if (key != null)
            {
                key.SetValue(name, value);
                key.Close();
            }
        }

        public static object GetRegKey(string name)
        {
            object key = null;
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey(RegPath());
            if (regKey != null)
            {
                key = regKey.GetValue(name);
                regKey.Close();
            }
            return key;
        }

        public static object GetRegKey(string appname, string name)
        {
            object key = null;
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey(RegPath(appname));
            if (regKey != null)
            {
                key = regKey.GetValue(name);
                regKey.Close();
            }
            return key;
        }

        public static object GetRegKey(string appname, string subKey, string name)
        {
            object key = null;
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey(RegPath(appname, subKey));
            if (regKey != null)
            {
                key = regKey.GetValue(name);
                regKey.Close();
            }
            return key;
        }
    }
}
