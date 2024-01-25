using System;
using System.Configuration;
using System.IO;
using System.Linq;

namespace BuildingLease.Library
{
    public static class AppConfig
    {
        public static string AppPath => AppDomain.CurrentDomain.BaseDirectory;
        public static string WriteLogFlag => GetAppConfig("WriteLogFlag");
        public static string DbPassword { get; set; }

        /// <summary>
        /// C:\Users\사용자명\AppData\Local\프로젝트명\프로젝트명.config
        /// 
        /// ConfigurationUserLevel이 None이면 프로그램이 실행되는 위치에 '프로젝트명.exe.config' 파일로 저장되는데 
        /// 열심히 만들어서 인스톨 형식으로 배포하여 Program Files 영역에 설치하게 되면 
        /// 관리자 권한을 요구하기 때문에 Program Files 영역에 설정파일을 마음대로 썼다 지웠다 하기가 어렵다. 
        /// 그래서 보통 대부분의 프로그램들은 C:\Users\유저명\AppData\Local 폴더에 설정파일들을 넣고 사용하도록 되어 있다.
        /// </summary>
        /// <returns></returns>
        public static Configuration OpenConfiguration()
        {
            Configuration config;

            // Setup Project 에서 % AppData %\Local 위치를 찾지 못해서 % AppData %\Roaming 위치를 사용함.
            // Setup Project에서 User's Application Data Folder가 % AppData %\Roaming 위치임
            // % AppData %\Local 위치: Environment.SpecialFolder.LocalApplicationData
            // % AppData %\Roaming 위치: Environment.SpecialFolder.ApplicationData            
            var projectName = System.Reflection.Assembly.GetEntryAssembly().GetName().Name;
            //var companyName = Application.CompanyName;
            //저장위치 - C:\Users\사용자명\AppData\Roaming\프로젝트명\프로젝트명.config
            var configPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), projectName);
            var configFile = System.IO.Path.Combine(configPath, projectName + ".config");

            if (string.IsNullOrWhiteSpace(configFile) || !File.Exists(configFile))
            {
                config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            }
            else
            {
                ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap
                {
                    ExeConfigFilename = configFile
                };
                config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            }
            return config;
        }

        public static string GetAppConfig(string key)
        {
            //return ConfigurationManager.AppSettings[key];
            Configuration config = OpenConfiguration();
            string val = String.Empty;
            if (config.AppSettings.Settings.AllKeys.Contains(key))
                val = config.AppSettings.Settings[key].Value;

            return val;
        }

        public static string GetConnectionString(string connectionName = "Default")
        {
            string connnectionString = string.Empty;
            Configuration config = OpenConfiguration();

            if (config.ConnectionStrings != null && config.AppSettings != null)
            {
                var password = GetAppConfig("DatabasePassword");
                var connectionString = config.ConnectionStrings.ConnectionStrings[connectionName].ConnectionString;
                if (!string.IsNullOrEmpty(password))
                {
                    connnectionString = string.Format(connectionString, Encrypt.DecryptAES(password));
                }
                else
                {
                    // DatabasePassword 없을 경우 app.conf 에 DatabasePassword 저장하기
                    _ = new InputBox().ShowDialog();
                    if (!string.IsNullOrEmpty(DbPassword))
                    {
                        if (DbPassword.Length > 0)
                        {
                            SetAppConfig("DatabasePassword", Encrypt.EncryptAES(DbPassword));
                            ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);
                            connnectionString = string.Format(connectionString, DbPassword);
                        }
                    }
                }
            }

            return connnectionString;
        }

        public static string GetProvideName(string connectionName = "Default")
        {
            Configuration config = OpenConfiguration();
            return config.ConnectionStrings.ConnectionStrings[connectionName].ProviderName;
        }

        /// <summary>
        /// 환경설정(app.config) 파일 쓰기        
        /// Program Files 영역은 관리자 권한을 요구하기 때문에 
        /// C:\Users\유저명\AppData\Local 폴더에 설정파일들을 넣고 사용한다.
        /// </summary>
        /// <param name="keyName"></param>
        /// <param name="value"></param>
        public static void SetAppConfig(string keyName, string value)
        {
            //Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            Configuration config = OpenConfiguration();

            if (config.AppSettings.Settings.AllKeys.Contains(keyName))
                config.AppSettings.Settings[keyName].Value = value;
            else
                config.AppSettings.Settings.Add(keyName, value);

            config.Save(ConfigurationSaveMode.Modified);
            // Force a reload of the changed section. This makes the New values available for reading.            
            ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);
        }


        public static void AddAppConfig(string keyName, string value)
        {
            Configuration config = OpenConfiguration();
            KeyValueConfigurationCollection cfgCollection = config.AppSettings.Settings;

            cfgCollection.Add(keyName, value);

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);
        }

        public static void RemoveAppConfig(string key)
        {
            Configuration config = OpenConfiguration();
            KeyValueConfigurationCollection cfgCollection = config.AppSettings.Settings;

            cfgCollection.Remove(key);

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);

        }
    }
}