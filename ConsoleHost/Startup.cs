/* 
 * FileName:    Startup.cs
 * Author:      functionghw<functionghw@hotmail.com>
 * CreateTime:  2/5/2017 10:49:50 AM
 * Description:
 * */

using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Threading;
using System.Web.Http.Dispatcher;
using HelperLibrary.Web.WebApi.Configurations;
using System.IO;
using Umbraco.Web.WebApi;

namespace ConsoleHost
{
    public class Startup
    {
        private static readonly string ServicesFolder = Path.GetFullPath("ApiServices");

        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            // 通过配置文件动态配置路由
            var configItems = ConfigLoader.Load(Path.Combine(ServicesFolder, "GlobalConfig.jsonconfig"));
            var routes = config.Routes;
            foreach (var item in configItems)
            {
                var route = routes.MapHttpRoute(item.Name, item.RouteTemplate, item.Defaults);
                if (item.Namespaces != null && item.Namespaces.Any())
                {
                    route.DataTokens["Namespaces"] = item.Namespaces;
                }
            }
            // 强制加载全部api的程序集文件
            GetApiAssemblyList();
            // 使用区分命名空间的控制器选择器，解决控制器名称冲突
            config.Services
                .Replace(typeof(IHttpControllerSelector), 
                    new NamespaceHttpControllerSelector(config));
            
            config.MessageHandlers.Add(new MyHandler());
            // 移除xml格式，只返回json格式
            //var formatters = config.Formatters;
            //formatters.Remove(formatters.XmlFormatter);

            app.UseWebApi(config);
        }

        private Assembly[] GetApiAssemblyList()
        {
            var list = new List<Assembly>();
            foreach (var dllFile in Directory.GetFiles(ServicesFolder, "*.dll"))
            {
                list.Add(Assembly.LoadFile(dllFile));
            }
            return list.ToArray();
        }
    }

    public class MyHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Console.WriteLine("[{0}] {1}\t {2}", DateTime.Now.ToString("HH:mm:ss"), request.Method, request.RequestUri);
            return base.SendAsync(request, cancellationToken);
        }
    }
}
