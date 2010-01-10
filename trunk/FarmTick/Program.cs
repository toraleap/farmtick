using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace FarmTick
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1)
            {
                MessageBox.Show("您已经启动了一个FarmTick的实例！\n如果您没有找到它，请检查系统通知区的FarmTick图标。", "FarmTick", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new fMain());
        }
    }
}
