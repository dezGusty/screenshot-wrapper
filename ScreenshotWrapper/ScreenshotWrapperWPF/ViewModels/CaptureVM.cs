using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenshotWrapperWPF.ViewModels
{
    public class CaptureVM : BasePropertyChanged
    {

        public CaptureVM()
        {
            this.Height = System.Windows.SystemParameters.PrimaryScreenHeight;
            foreach (Screen item in Screen.AllScreens)
            {
                this.Width += item.Bounds.Width;
            }
        }

        private double height;

        public double Height
        {
            get
            {
                return this.height;
            }
            set
            {
                this.height = value;
                NotifyPropertyChanged("Height");
            }
        }

        private double width;

        public double Width
        {
            get
            {
                return this.width;
            }
            set
            {
                this.width = value;
                NotifyPropertyChanged("Width");
            }
        }
    }
}
