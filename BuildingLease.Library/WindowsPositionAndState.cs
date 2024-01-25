using System;
using System.Drawing;
using System.Windows.Forms;

namespace BuildingLease.Library
{
    public class WindowsPositionAndState
    {
        /// <summary>
        /// 레지스트리에 WindowsPosition(= form.DesktopBounds), WindowState 값 저장
        /// 사용 : SetRegWindowsPositionAndWindowState(Application.ProductName,Me.DesktopBounds, Me.WindowState)
        /// </summary>
        /// <param name="appname"></param>
        /// <param name="desktopBounds"></param>
        /// <param name="windowState"></param>
        /// <returns></returns>
        public void SetRegWindowsPositionAndWindowState(string appname, Rectangle desktopBounds, FormWindowState windowState)
        {
            if (Register.GetRegKey(appname) != null)
            {
                // 레지스트리에 환경 저장 : SetValue(이름, 저장할 데이터)
                Register.SetRegKey(appname, "WindowState", Convert.ToInt32(windowState));
                Register.SetRegKey(appname, "X", desktopBounds.X);
                Register.SetRegKey(appname, "Y", desktopBounds.X);
                Register.SetRegKey(appname, "Width", desktopBounds.Width);
                Register.SetRegKey(appname, "Height", desktopBounds.Height);
            }
        }

        /// <summary>
        /// 레지스트리에서 WindowsPosition 값 가져오기
        /// 모니터가 2개 있다가 1개로 될 경우 크기를 초기화
        /// </summary>
        /// <param name="appname"></param>
        /// <returns></returns>
        public Rectangle GetRegWindowsPosition(string appname)
        {
            var rectangle = new Rectangle(0, 0, Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            if (Register.GetRegKey(appname) != null)
            {
                // 레지스트리에 환경 저장 : SetValue(이름, 저장할 데이터)                
                int x = Convert.ToInt32(Register.GetRegKey(appname, "X"));
                int y = Convert.ToInt32(Register.GetRegKey(appname, "X"));
                int width = Convert.ToInt32(Register.GetRegKey(appname, "Width"));
                int height = Convert.ToInt32(Register.GetRegKey(appname, "Height"));

                // 모니터가 2개 있다가 1개로 될 경우 크기를 초기화
                if (x > Screen.PrimaryScreen.WorkingArea.Width || y > Screen.PrimaryScreen.WorkingArea.Height)
                {
                    x = 0;
                    y = 0;
                }
                if (width > Screen.PrimaryScreen.WorkingArea.Width)
                    width = Screen.PrimaryScreen.WorkingArea.Width - x;
                if (height > Screen.PrimaryScreen.WorkingArea.Height)
                    height = Screen.PrimaryScreen.WorkingArea.Height - y;

                rectangle = new Rectangle(x, y, width, height);
            }
            return rectangle;
        }

        public FormWindowState GetRegWindowState(string appname)
        {
            FormWindowState windowState = FormWindowState.Normal;

            if (Register.GetRegKey(appname) != null)
                windowState = (FormWindowState)Register.GetRegKey(appname, "WindowState");

            return windowState;
        }

        public void SetAppDesktopBoundsAndWindowState(Form frm, string appname)
        {
            Rectangle rectangle = GetRegWindowsPosition(appname);
            if (rectangle.IsEmpty)
            {
                FormWindowState windowState = GetRegWindowState(appname);
                frm.WindowState = windowState;
            }
            else
            {
                frm.DesktopBounds = rectangle;
            }
        }
    }
}
