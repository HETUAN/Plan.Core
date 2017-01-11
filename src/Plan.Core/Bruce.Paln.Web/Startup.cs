using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Bruce.Paln.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseStaticFiles();
            loggerFactory.AddConsole()
                .AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("Error");
            }

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationScheme = "UserAuth",　   // Cookie 验证方案名称，后面多处都需要用到，部分地方必须要求常量，所以直接配置为字符串。
                AutomaticAuthenticate = true,     // 是否自动启用验证，如果不启用，则即便客服端传输了Cookie信息，服务端也不会主动解析。
                                                  // 除了明确配置了 [Authorize(ActiveAuthenticationSchemes = "上面的方案名")] 属性的地方，才会解析，此功能一般用在需要在同一应用中启用多种验证方案的时候。比如分Area.
                LoginPath = "/User/Index"　　　　　// 登录页
                AccessDeniedPath = "/Error"
            });

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationScheme = "AdminAuth",　   // Cookie 验证方案名称，后面多处都需要用到，部分地方必须要求常量，所以直接配置为字符串。
                AutomaticAuthenticate = true,     // 是否自动启用验证，如果不启用，则即便客服端传输了Cookie信息，服务端也不会主动解析。
                                                  // 除了明确配置了 [Authorize(ActiveAuthenticationSchemes = "上面的方案名")] 属性的地方，才会解析，此功能一般用在需要在同一应用中启用多种验证方案的时候。比如分Area.
                LoginPath = "/Admin/Index",　　　　　// 登录页
                AccessDeniedPath = "/Error"

            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
