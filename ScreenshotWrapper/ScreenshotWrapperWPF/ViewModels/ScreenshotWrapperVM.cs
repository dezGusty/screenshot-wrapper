using ScreenshotWrapperWPF.Commands;
using ScreenshotWrapperWPF.Configuration;
using ScreenshotWrapperWPF.ServiceLayer;
using System.Windows.Input;

namespace ScreenshotWrapperWPF.ViewModels
{
    public class ScreenshotWrapperVM : BasePropertyChanged
    {
        public ScreenshotWrapperVM()
        {
            
        }

        private ICommand showWindowCommand;

        public ICommand ShowWindowCommand
        {
            get
            {
                if (showWindowCommand == null)
                {
                    ScreenshotWrapperOperations operation = new ScreenshotWrapperOperations(this);
                    showWindowCommand = new RelayCommand(operation.ShowWindow);
                }

                return showWindowCommand;
            }
        }

        private ICommand hideWindowCommand;

        public ICommand HideWindowCommand
        {
            get
            {
                if (hideWindowCommand == null)
                {
                    ScreenshotWrapperOperations operation = new ScreenshotWrapperOperations(this);
                    hideWindowCommand = new RelayCommand(operation.HideWindow);
                }

                return hideWindowCommand;
            }
        }

        private ICommand exitApplicationCommand;

        public ICommand ExitApplicationCommand
        {
            get
            {
                if (exitApplicationCommand == null)
                {
                    ScreenshotWrapperOperations operation = new ScreenshotWrapperOperations(this);
                    exitApplicationCommand = new RelayCommand(operation.ExitApplication);
                }

                return exitApplicationCommand;
            }
        }

        private ICommand takeScreenshotCommand;

        public ICommand TakeScreenshotCommand
        {
            get
            {
                if (takeScreenshotCommand == null)
                {
                    ScreenshotWrapperOperations operation = new ScreenshotWrapperOperations(this);
                    takeScreenshotCommand = new RelayCommand(operation.TakeScreenshot);
                }

                return takeScreenshotCommand;
            }
        }
    }
}
