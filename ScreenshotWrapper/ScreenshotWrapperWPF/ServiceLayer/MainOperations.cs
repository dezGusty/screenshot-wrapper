using ScreenshotWrapperWPF.BusinessLogicLayer;
using ScreenshotWrapperWPF.Configuration;
using ScreenshotWrapperWPF.ViewModels;
using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenshotWrapperWPF.ServiceLayer
{
    public class MainOperations
    {
        private MainVM model;
        private SSWConfig config;

        public MainOperations(MainVM model)
        {
            this.model = model;
            this.config = SSWConfig.Instance;
        }

        internal void SelectOutputFolder(object param)
        {
            if (param != null)
            {
                System.Windows.Forms.FolderBrowserDialog fbd = new System.Windows.Forms.FolderBrowserDialog();
                try
                {
                    System.Windows.Forms.DialogResult result = fbd.ShowDialog();
                    if (string.Compare(fbd.SelectedPath, string.Empty) != 0)
                    {
                        model.StorageLocationFilename = JSONOperations.SlashToBackslash(fbd.SelectedPath);
                        this.config.OutputPath = JSONOperations.SlashToBackslash(fbd.SelectedPath);
                        JSONOperations.Serialize(this.config);
                    }
                }
                catch (Exception)
                {
                    return;
                }
            }
        }

        internal void SaveOutputOption(object param)
        {
            if (MainVM.Instance.IsSaveAsEnabled == true)
            {
                this.config.IsSavedDirectly = false;
            }
            else
            {
                this.config.IsSavedDirectly = true;
            }

            JSONOperations.Serialize(this.config);
            MessageBox.Show("Changes saved!", "Success", MessageBoxButton.OKCancel, MessageBoxImage.Information,
                MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
        }

        internal void SaveFilenameOption(object param)
        {
            if (MainVM.Instance.IsDateEnabled == true)
            {
                this.config.IsUsingDateFormat = true;
            }
            else
            {
                this.config.IsUsingDateFormat = false;
            }

            JSONOperations.Serialize(this.config);
            MessageBox.Show("Changes saved!", "Success", MessageBoxButton.OKCancel, MessageBoxImage.Information, 
                MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
        }

        internal void SaveCaptureRegionOption(object param)
        {
            if (MainVM.Instance.IsCaptureEnabled == true)
            {
                this.config.IsCaptureEnabled = true;
            }
            else
            {
                this.config.IsCaptureEnabled = false;
            }

            JSONOperations.Serialize(this.config);
        }
    }
}
