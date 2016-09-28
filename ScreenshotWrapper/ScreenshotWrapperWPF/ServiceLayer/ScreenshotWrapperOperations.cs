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
            TaskbarIcon tb = (TaskbarIcon)Application.Current.FindResource("NotifyIcon");
            string path = string.Empty;
            if (this.config.IsCaptureEnabled == false)
            {
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

                    try
                    {
                        getAllDesktopsScreenshot(path);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButton.OKCancel, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                    }
                }
                else
                {
                    path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    path = path + "\\temp.png";
                    try
                    {
                        getAllDesktopsScreenshot(path);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButton.OKCancel, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                    }

                    SaveFileDialog sfd = this.helper.CreateSaveFileDialog("PNG File (*.png)|*.png", Path.GetFullPath(this.config.OutputPath), ".png");
                    ToolWindow tw = new ToolWindow();
                    tw.Show();
                    sfd.ShowDialog(tw);
                    tw.Close();
                    try
                    {
                        File.Move(path, sfd.FileName);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Write the output!", "Error", MessageBoxButton.OKCancel, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                        return;
                    }

                    path = sfd.FileName;
                }
            }
            else
            {
                CaptureWindow cw = new CaptureWindow();
                cw.Show();
            }

            tb.ShowBalloonTip("Screenshot saved!", string.Format("Location: {0}", path), BalloonIcon.Info);
        }
    }
}
