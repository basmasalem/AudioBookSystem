using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Data;
using Core.Data.Repositories;
using Core.Model;
using Core.Service;
using Core.Web.Mapping;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace Core.Web
{
    public class Startup
    {
        private readonly IConfiguration configuration;
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }



        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLocalization(options => options.ResourcesPath = "Resources");


            //For application running on IIS 
            services.Configure<IISServerOptions>(options =>
            {
                options.MaxRequestBodySize = int.MaxValue;  //set maxsize of max request Header
            });

            // Auto Mapper Configurations
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);



            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
           .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
           options =>
           {
               options.Cookie.Name = "WebAudioKetab";
               options.ExpireTimeSpan = TimeSpan.FromMinutes(180);
               options.LoginPath = new PathString("/Account/Login/");
               options.LogoutPath = new PathString("/Account/Login/");
           });



            // allow html.action
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddMvc(options => options.EnableEndpointRouting = false)
                .AddViewLocalization(Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();
            services.Configure<RequestLocalizationOptions>(options =>
            {
                var cultures = new List<CultureInfo> {
                     new CultureInfo("en-US"),
                     new CultureInfo("ar-EG")
                };
                options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("ar-EG");
                options.SupportedCultures = cultures;
                options.SupportedUICultures = cultures;
            });
            services.AddDataProtection();
            services.AddDbContext<AudioKetabDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SqlCon")).UseLazyLoadingProxies();
            });

            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            services.AddScoped<IServiceWrapper, ServiceWrapper>();


            services.Configure<MailSettings>(configuration.GetSection("MailSettings"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.Use(async (context, next) =>
            {
                var statusCodePagesFeature = context.Features.Get<IStatusCodePagesFeature>();
                if (statusCodePagesFeature != null)
                {
                    statusCodePagesFeature.Enabled = false;
                }
                await next();
                if (context.Response.StatusCode == 404)
                {
                    context.Request.Path = "/Home/NotFound";
                    await next();
                }
            });



            app.UseRequestLocalization(app.ApplicationServices.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);
            app.UseRouting();
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMvcWithDefaultRoute();

        
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            });
        }
    }
}
