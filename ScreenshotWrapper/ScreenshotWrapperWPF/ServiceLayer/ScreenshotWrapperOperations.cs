using Hardcodet.Wpf.TaskbarNotification;
using ScreenshotWrapperWPF.Configuration;
using ScreenshotWrapperWPF.ViewModels;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ScreenshotWrapperWPF.BusinessLogicLayer;
using Microsoft.Win32;
using ScreenshotWrapperWPF.Views;
using System.IO;
using System.Threading;

namespace ScreenshotWrapperWPF.ServiceLayer
{
    public class ScreenshotWrapperOperations
    {
        #region dll imports

        [DllImport("Debug//ScreenshotWrapperDLL.dll", EntryPoint = "getAllDesktopsScreenshot", CharSet = CharSet.Unicode
            , CallingConvention = CallingConvention.Cdecl, ThrowOnUnmappableChar = true)]
        public static extern void getAllDesktopsScreenshot(string filename);

        #endregion

        private ScreenshotWrapperVM model;
        private SSWConfig config;
        private SSWHelper helper;

        public ScreenshotWrapperOperations(ScreenshotWrapperVM model)
        {
            this.model = model;
            this.config = SSWConfig.Instance;
            this.helper = new SSWHelper();
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
                TaskbarIcon tb = (TaskbarIcon)Application.Current.FindResource("NotifyIcon");
                string path = string.Empty;
                if (this.config.IsSavedDirectly == true)
                {
                    if (this.config.IsUsingDateFormat == true)
                    {
                        path = this.helper.MakeDateFilename();
                    }
                    else
                    {
                        path = this.helper.MakeCountFilename();
                        this.config.NumberOfScreenshots++;
                        JSONOperations.Serialize(this.config);
                    }
                }
                else
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "PNG File (*.png)|*.png";
                    sfd.InitialDirectory = Path.GetFullPath(this.config.OutputPath);
                    sfd.DefaultExt = ".png";
                    ToolWindow tw = new ToolWindow();
                    tw.Show();
                    sfd.ShowDialog(tw);
                    path = sfd.FileName;
                    tw.Close();
                    Thread.Sleep(200);
                }

                getAllDesktopsScreenshot(path);
                tb.ShowBalloonTip("Screenshot saved!", string.Format("Location: {0}", path), BalloonIcon.Info);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OKCancel, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }
    }
}
