using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ScreenshotWrapperWPF.Exceptions
{
    public class SSWConfigException : Exception
    {
        public SSWConfigException()
        {

        }

        public SSWConfigException(string message) 
            : base(message)
        {

        }

        public SSWConfigException(string message, Exception innerException) 
            : base(message, innerException)
        {

        }

        protected SSWConfigException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {

        }
    }
}
