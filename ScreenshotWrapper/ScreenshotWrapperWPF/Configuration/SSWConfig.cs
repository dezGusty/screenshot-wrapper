using ScreenshotWrapperWPF.BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ScreenshotWrapperWPF.Configuration
{
    public class SSWConfig
    {
        private SSWConfig()
        {
            
        }

        private static SSWConfig instance;

        public static SSWConfig Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SSWConfig();
                    instance = JSONOperations.Deserialize();
                }

                return instance;
            }
        }

        private string outputPath;

        public string OutputPath
        {
            get
            {
                return this.outputPath;
            }
            set
            {
                this.outputPath = value;
            }
        }

        private int numberOfScreenshots;

        public int NumberOfScreenshots
        {
            get
            {
                return this.numberOfScreenshots;
            }
            set
            {
                this.numberOfScreenshots = value;
            }
        }

        private bool isSavedDirectly;

        public bool IsSavedDirectly
        {
            get
            {
                return this.isSavedDirectly;
            }
            set
            {
                this.isSavedDirectly = value;
            }
        }

        private bool isUsingDateFormat;

        public bool IsUsingDateFormat
        {
            get
            {
                return this.isUsingDateFormat;
            }
            set
            {
                this.isUsingDateFormat = value;
            }
        }
    }
}
