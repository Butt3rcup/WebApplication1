using System;
using System.Reflection;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApplication1.DbContext;
using WebApplication1.Extends;
using WebApplication1.Http;

namespace WebApplication1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(options =>
            {
                 
                options.JsonSerializerOptions.Encoder = JavaScriptEncoder.Create(allowedRanges: UnicodeRanges.All);
                options.JsonSerializerOptions.Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
                options.JsonSerializerOptions.Converters.Add(new JsonDateTimeConvert());
            });

            services.AddHttpClient<HttpClienService>().SetHandlerLifetime(TimeSpan.FromMinutes(2));

            services.AddDbContext<RazorPagesMovieContext>(options =>  options.UseMySql(Configuration.GetConnectionString("RazorPagesMovieContext")));

        }

        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            //containerBuilder.RegisterType<TestServiceE>().As<ITestServiceE>().SingleInstance();
            //containerBuilder.RegisterModule<CustomAutofacModule>();

            containerBuilder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).AsImplementedInterfaces()
                .Where(t => t.Name.EndsWith("Service")).PropertiesAutowired().AsSelf().InstancePerDependency()
                .PropertiesAutowired(); //Service 注入?

            containerBuilder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).AsImplementedInterfaces()
                .Where(t => t.Name.EndsWith("Controller")).PropertiesAutowired().AsSelf()
                .InstancePerDependency(); //注册控制器为属性注入

            // containerBuilder.Register(c => new TestAop());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
