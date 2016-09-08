using ScreenshotWrapperWPF.Configuration;
using ScreenshotWrapperWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ScreenshotWrapperWPF.ServiceLayer
{
    public class ScreenshotWrapperOperations
    {
        #region dll imports

        [DllImport("Debug//ScreenshotWrapperDLL.dll", EntryPoint = "getAllDesktopsScreenshot", CharSet = CharSet.Unicode
            ,CallingConvention = CallingConvention.Cdecl, ThrowOnUnmappableChar = true)]
        public static extern void getAllDesktopsScreenshot(string filename);

        #endregion

        private ScreenshotWrapperVM model;
        private SSWConfig config;

        public ScreenshotWrapperOperations(ScreenshotWrapperVM model)
        {
            this.model = model;
            this.config = SSWConfig.Instance;
        }

        public void ShowWindow(object param)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
        }

        public void HideWindow(object param)
        {
            foreach (Window item in Application.Current.Windows)
            {
                if (string.Compare(item.Name, "mainWindow") == 0)
                {
                    item.Hide();
                }
            }
        }

        public void ExitApplication(object param)
        {
            Application.Current.Shutdown();
        }

        public void TakeScreenshot(object param)
        {
            try
            {
                string shortDate = DateTime.Now.ToShortDateString().Replace('.', '-');
                string longTime = DateTime.Now.ToLongTimeString().Replace(':', '_');
                string filename = string.Format("{0}-{1}.bmp", shortDate, longTime);
                string path = this.config.OutputPath + filename;
                getAllDesktopsScreenshot(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
