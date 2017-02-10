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
using System.Web.Http;

namespace HelperLibrary.Web.WebApi.Configurations
{
    public class ConfigItem
    {
        public string Name { get; set; }

        public string RouteTemplate { get; set; }

        public string[] Namespaces { get; set; }

        private Dictionary<string, object> defaults;
        public Dictionary<string, object> Defaults
        {
            get { return defaults; }
            set
            {
                if (value != null)
                {
                    var keys = value.Keys.ToArray();
                    foreach (var key in keys)
                    {
                        if (value[key] == null)
                            value[key] = RouteParameter.Optional;
                    }
                }
                defaults = value;
            }
        }
    }
}
