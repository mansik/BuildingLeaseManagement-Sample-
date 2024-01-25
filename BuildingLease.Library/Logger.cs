using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BuildingLease.Library
{
    public enum LogType
    {
        Debug,
        Info,
        Data,
        Error1,
        Error2
    }

    /// <summary>

    /// ''' WriteLogBuffer()에 사용, 버퍼를 이용할 경우 사용

    /// ''' </summary>
    public class LogMessage
    {
        public LogType type;
        public string msg;

        public LogMessage(LogType logtype, string logmsg)
        {
            type = logtype;
            msg = logmsg;
        }
    }

    public class Logger
    {
        private static readonly string LogFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log");
        /// <summary>
        /// 로그를 한번에 모아서 저장하기 위해서 Queue 사용
        /// </summary>
        private static readonly Queue<LogMessage> logQueue = new Queue<LogMessage>();
        /// <summary>
        /// 쓰레드가 여러개일 경우 Thread Safe를 위해서 사용
        /// </summary>
        private static readonly object writeLock = new object();

        /// <summary>
        /// 한개의 파일안에 여러 LogType을 기록+실행파일 폴더에 저장
        /// 버퍼로 Queue를 만들어서 한번에 저장하는 기능
        /// writeNow = True Or ogQueue.Count > 50 면 파일에 저장
        /// 반드시, 프로그램 종료전에 writeNow = True 해줘야 파일에 저장된다.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="logType"></param>
        /// <param name="writeNow">writeNow = True Or logQueue.Count > 50 면 파일에 저장</param>
        public static void WriteLogBuffer(string str, LogType logType = LogType.Info, bool writeNow = false)
        {
            if (AppConfig.WriteLogFlag != "1")
                return;

            if (Directory.Exists(LogFilePath) == false)
                Directory.CreateDirectory(LogFilePath);

            string fileName = Path.Combine(LogFilePath, DateTime.Today.ToString("yyyyMMdd") + "_" + logType + ".log");

            // 버퍼로 Queue를 만들어서 한번에 저장, writeNow = True 이면 파일에 저장
            logQueue.Enqueue(new LogMessage(logType, str));

            // 파일에 저장
            if (writeNow == true || logQueue.Count > 50)
            {
                lock (writeLock) // 쓰레드가 여러개일 경우 Thread Safe를 위해서 사용
                {
                    using (StreamWriter sw = new StreamWriter(fileName, true, Encoding.UTF8)) // log 파일저장 UTF8 with Dom 로 저장됨
                    {
                        while (logQueue.Count > 0)
                        {
                            LogMessage log = logQueue.Dequeue();

                            sw.WriteLine(DateTime.Now.ToString("yyyyMMddHHmmss") + "\t" + log.msg);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// yyyyMMdd+LogType.log에 기록
        /// </summary>
        /// <param name="str"></param>
        /// <param name="logType"></param>
        public static void WriteLog(string str, LogType logType = LogType.Info)
        {
            if (AppConfig.WriteLogFlag != "1")
                return;

            if (Directory.Exists(LogFilePath) == false)
                Directory.CreateDirectory(LogFilePath);

            string fileName = Path.Combine(LogFilePath, DateTime.Today.ToString("yyyyMMdd") + "_" + logType + ".log");

            using (StreamWriter sw = new StreamWriter(fileName, true, Encoding.UTF8)) // log 파일저장 UTF8 with Dom 로 저장됨
            {
                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "\t" + str);
            }
        }

        /// <summary>
        /// deleteDays일 이전 Log 파일 삭제
        /// orverDays = 0 이면 30일전 파일만 삭제
        /// </summary>
        /// <param name="deleteDaysAgo">보존기간</param>
        public void DeleteLog(int deleteDaysAgo = 10)
        {
            if (Directory.Exists(LogFilePath) == false)
                return;

            if (deleteDaysAgo == 0)
                deleteDaysAgo = -30;
            else if (deleteDaysAgo > 0)
                deleteDaysAgo = -1 * deleteDaysAgo;

            DirectoryInfo di = new DirectoryInfo(LogFilePath);
            foreach (FileInfo fi in from f in di.EnumerateFiles("*.log")
                                    where f.LastWriteTime < DateTime.Today.AddDays(deleteDaysAgo)
                                    select f)
                // Debug.WriteLine(fi.Name)
                fi.Delete();
        }
    }
}
