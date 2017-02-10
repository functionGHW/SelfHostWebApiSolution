/* 
 * FileName:    ServiceInitializer.cs
 * Author:      functionghw<functionghw@hotmail.com>
 * CreateTime:  2/7/2017 10:18:52 PM
 * Description:
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace DemoService
{
    public class ServiceInitializer
    {
        public void Initialize(HttpConfiguration config)
        {
            Console.WriteLine("DemoService Loaded");
        }
    }
}
