using ScreenshotWrapperWPF.BusinessLogicLayer;
using ScreenshotWrapperWPF.Commands;
using ScreenshotWrapperWPF.Configuration;
using ScreenshotWrapperWPF.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ScreenshotWrapperWPF.ViewModels
{
    public class MainVM : BasePropertyChanged
    {
        public MainVM()
        {
            this.config = SSWConfig.Instance;
            this.StorageLocationFilename = config.OutputPath;
            if (this.config.IsSavedDirectly == true)
            {
                this.IsSaveDirectlyRadioChecked = true;
                this.IsSaveAsRadioChecked = false;
            }
            else
            {
                this.IsSaveDirectlyRadioChecked = false;
                this.IsSaveAsRadioChecked = true;
            }
        }

        private static MainVM instance;
        private SSWConfig config;

        public static MainVM Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MainVM();
                }

                return instance;
            }
        }

        private bool isSaveAsRadioChecked;

        public bool IsSaveAsRadioChecked
        {
            get
            {
                return this.isSaveAsRadioChecked;
            }
            set
            {
                this.isSaveAsRadioChecked = value;
                NotifyPropertyChanged("IsSaveAsRadioChecked");
            }
        }

        private bool isSaveDirectlyRadioChecked;

        public bool IsSaveDirectlyRadioChecked
        {
            get
            {
                return this.isSaveDirectlyRadioChecked;
            }
            set
            {
                this.isSaveDirectlyRadioChecked = value;
                NotifyPropertyChanged("IsSaveDirectlyRadioChecked");
            }
        }

        private string storageLocationFilename;

        public string StorageLocationFilename
        {
            get
            {
                return this.storageLocationFilename;
            }
            set
            {
                this.storageLocationFilename = value;
                NotifyPropertyChanged("StorageLocationFilename");
            }
        }

        private ICommand selectFolderCommand;

        public ICommand SelectFolderCommand
        {
            get
            {
                if (this.selectFolderCommand == null)
                {
                    MainOperations operation = new MainOperations(this);
                    this.selectFolderCommand = new RelayCommand(operation.SelectOutputFolder);
                }

                return this.selectFolderCommand;
            }
        }
    }
}
