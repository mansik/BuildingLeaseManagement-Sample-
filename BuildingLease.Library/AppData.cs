namespace BuildingLease.Library
{
    /// <summary>
    /// DATA를 저장하는 전역변수
    /// </summary>
    public class AppData
    {
        public static class LogOn
        {
            public static int UserID { get; set; }
            public static string UserName { get; set; }
            public static int GradeTypeID { get; set; }
        }

        public static string[] InOutgoings = { "수입", "지출" };

    }
}
