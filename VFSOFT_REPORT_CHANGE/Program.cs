/***
 * Autor:PwnInt
 * Time:2021/8/6 15:47:19
 * Name:OpenAccess
 * Ver:1.0
 * Can I Just Say Thank you for being in my Life
 ****/
using System;
using System.Windows.Forms;

namespace VFSOFT_REPORT_CHANGE
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
