using ScreenshotWrapperWPF.BusinessLogicLayer;
using ScreenshotWrapperWPF.Configuration;
using ScreenshotWrapperWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                try
                {
                    DialogResult result = fbd.ShowDialog();
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
    }
}
