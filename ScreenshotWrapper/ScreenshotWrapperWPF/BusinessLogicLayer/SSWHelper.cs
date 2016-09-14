using ScreenshotWrapperWPF.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenshotWrapperWPF.BusinessLogicLayer
{
    public class SSWHelper
    {
        private SSWConfig config;

        public SSWHelper()
        {
            this.config = SSWConfig.Instance;
        }

        internal string MakeDateFilename()
        {
            string shortDate = DateTime.Now.ToShortDateString().Replace('.', '-');
            string longTime = DateTime.Now.ToLongTimeString().Replace(':', '_');
            string filename = string.Format("{0}-{1}.png", shortDate, longTime);
            string path = this.config.OutputPath + filename;

            return path;
        }

        internal string MakeCountFilename()
        {
            return this.config.OutputPath + string.Format("[{0}].png", this.config.NumberOfScreenshots);
        }
    }
}
