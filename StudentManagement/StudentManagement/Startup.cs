using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                DeveloperExceptionPageOptions developerExceptionPageOptions = new DeveloperExceptionPageOptions();
                developerExceptionPageOptions.SourceCodeLineCount = 10;//对报错附近的代码显示，能够快速定位
                app.UseDeveloperExceptionPage(developerExceptionPageOptions);
            }
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



            app.Run(async (context) =>
            {
                throw new Exception("您的轻轻在管道中发生了一些错误，请检查");
                
                await context.Response.WriteAsync("Hello world");
            });
        }
    }
}
