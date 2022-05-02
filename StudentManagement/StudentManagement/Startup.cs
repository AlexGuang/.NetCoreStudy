using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement
{
    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration configuration)
        {
            _config = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton<IStudentRepository,MockStudentRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            #region 判断开发者环境和处理开发者异常界面
            //if (env.IsEnvironment("UAT"))//如果开发环境是用户验收环境
            //{
            //    app.UseDeveloperExceptionPage();//可以显示开发者异常页面
            //}
            //else if (env.IsDevelopment())
            //{
            //    #region 开发者异常界面
            //    //  DeveloperExceptionPageOptions developerExceptionPageOptions = new DeveloperExceptionPageOptions();
            //    // developerExceptionPageOptions.SourceCodeLineCount = 10;//对报错附近的代码显示，能够快速定位
            //    //  app.UseDeveloperExceptionPage(developerExceptionPageOptions);
            //    #endregion
            //    app.UseDeveloperExceptionPage();
            //}
            //else if (env.IsStaging()||env.IsProduction()||env.IsEnvironment("UAT"))
            //{
            //    app.UseExceptionHandler("/Error");

            //}
            #endregion
            #region 中间件和静态文件学习
            //DefaultFilesOptions defaultFilesOptions = new DefaultFilesOptions();//注册默认网页

            //defaultFilesOptions.DefaultFileNames.Clear();
            //defaultFilesOptions.DefaultFileNames.Add("52ab.html");


            //添加默认文件中间件
            //app.UseDefaultFiles();
            //添加静态文件中间件
            //app.UseStaticFiles();

            //index.html index.htm 默认 default.html default.htm

            //FileServerOptions fileServerOptions = new FileServerOptions();
            //fileServerOptions.DefaultFilesOptions.DefaultFileNames.Clear();
            //fileServerOptions.DefaultFilesOptions.DefaultFileNames.Add("52ab.html");

            //app.UseFileServer(fileServerOptions); 终端中间件
            #endregion
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseStaticFiles();

            // app.UseMvcWithDefaultRoute();

            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            //});
            app.UseMvc();
        }
    }
}
