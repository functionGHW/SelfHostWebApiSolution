/* 
 * FileName:    ConfigItem.cs
 * Author:      functionghw<functionghw@hotmail.com>
 * CreateTime:  2/5/2017 1:30:50 PM
 * Description:
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperLibrary.Web.WebApi.Configurations
{
    public class ConfigItem
    {
        public string Name { get; set; }

        public string RouteTemplate { get; set; }

        public string[] Namespaces { get; set; }

        public Dictionary<string, object> Defaults { get; set; }
    }
}
