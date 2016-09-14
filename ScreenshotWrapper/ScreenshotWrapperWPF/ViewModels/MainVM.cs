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
                this.IsSaveDirectlyEnabled = true;
            }
            else
            {
                this.IsSaveAsEnabled = true;
            }

            if (this.config.IsUsingDateFormat == true)
            {
                this.IsDateEnabled = true;
            }
            else
            {
                this.IsCountEnabled = true;
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

        private bool isSaveAsEnabled;

        public bool IsSaveAsEnabled
        {
            get
            {
                return this.isSaveAsEnabled;
            }
            set
            {
                this.isSaveAsEnabled = value;
                NotifyPropertyChanged("IsSaveAsEnabled");
            }
        }

        private bool isSaveDirectlyEnabled;

        public bool IsSaveDirectlyEnabled
        {
            get
            {
                return this.isSaveDirectlyEnabled;
            }
            set
            {
                this.isSaveDirectlyEnabled = value;
                NotifyPropertyChanged("IsSaveDirectlyEnabled");
            }
        }

        private bool isDateEnabled;

        public bool IsDateEnabled
        {
            get
            {
                return this.isDateEnabled;
            }
            set
            {
                this.isDateEnabled = value;
                NotifyPropertyChanged("IsDateEnabled");
            }
        }

        private bool isCountEnabled;

        public bool IsCountEnabled
        {
            get
            {
                return this.isCountEnabled;
            }
            set
            {
                this.isCountEnabled = value;
                NotifyPropertyChanged("IsCountEnabled");
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

        private ICommand saveOutputOptionCommand;

        public ICommand SaveOutputOptionCommand
        {
            get
            {
                if (this.saveOutputOptionCommand == null)
                {
                    MainOperations operation = new MainOperations(this);
                    this.saveOutputOptionCommand = new RelayCommand(operation.SaveOutputOption);
                }

                return this.saveOutputOptionCommand;
            }
        }

        private ICommand saveFilenameCommand;

        public ICommand SaveFilenameCommand
        {
            get
            {
                if (this.saveFilenameCommand == null)
                {
                    MainOperations operation = new MainOperations(this);
                    this.saveFilenameCommand = new RelayCommand(operation.SaveFilenameOption);
                }

                return this.saveFilenameCommand;
            }
        }
    }
}
