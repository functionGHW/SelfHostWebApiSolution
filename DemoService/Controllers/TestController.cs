/* 
 * FileName:    TestController.cs
 * Author:      functionghw<functionghw@hotmail.com>
 * CreateTime:  2/5/2017 12:29:32 PM
 * Description:
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace DemoService.Controllers
{
    public class TestController : ApiController
    {
        [HttpGet]
        public string Index()
        {
            return "Hello";
        }
    }
}
