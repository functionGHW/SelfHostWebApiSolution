/* 
 * FileName:    ConfigLoader.cs
 * Author:      functionghw<functionghw@hotmail.com>
 * CreateTime:  2/5/2017 1:36:06 PM
 * Description:
 * */

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperLibrary.Web.WebApi.Configurations
{
    public static class ConfigLoader
    {
        public static IEnumerable<ConfigItem> Load(string configFile)
        {
            if (string.IsNullOrEmpty(configFile))
                throw new ArgumentNullException(nameof(configFile));

            var jsonContent = new StringBuilder();
            foreach (var line in File.ReadAllLines(configFile))
            {
                string tmp = line.Trim();
                if (string.IsNullOrEmpty(tmp))
                    continue;
                if (tmp.StartsWith("#"))
                    continue;

                jsonContent.Append(tmp);
            }

            return JsonConvert.DeserializeObject<IEnumerable<ConfigItem>>(jsonContent.ToString());
        }
    }
}
