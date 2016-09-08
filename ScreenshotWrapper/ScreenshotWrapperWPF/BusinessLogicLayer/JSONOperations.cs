using Newtonsoft.Json;
using ScreenshotWrapperWPF.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenshotWrapperWPF.BusinessLogicLayer
{
    public class JSONOperations
    {
        private static string path = "ScreenshotWrapperWPF/Configuration/config.json";

        public static void Serialize(SSWConfig config)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                string json = JsonConvert.SerializeObject(config);
                sw.WriteLine(json);
            }
        }

        public static SSWConfig Deserialize()
        {
            string[] lines = File.ReadAllLines(path);
            SSWConfig config = JsonConvert.DeserializeObject<SSWConfig>(lines[0]);
            return config;
        }

        public static string SlashToBackslash(string input)
        {
            input = input.Replace('\\', '/');

            if (input[input.Length - 1] != '/')
            {
                input += "/";
            }

            return input;
        }
    }
}
