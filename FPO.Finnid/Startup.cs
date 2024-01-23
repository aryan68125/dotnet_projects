using finnit.Helper;
using finnit.Repository.Common;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace finnit
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IHttpContextAccessor httpContextAccessor { get; } = new HttpContextAccessor();
       public IWebHostEnvironment _env;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            MyConnection.DefaultConnection = Configuration.GetConnectionString("Local_DefaultConnection");
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddHttpContextAccessor();
            services.AddMediatR(typeof(Startup).Assembly);
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option =>
            {
                option.AccessDeniedPath = "/Home/Error";
                option.LoginPath = "/Account/Login";
                option.LogoutPath = "/Account/Logout";
            });

            EmailMaster.HostServer = Configuration.GetSection("Email").GetSection("HostServer").Value.ToString();
            EmailMaster.Email = Configuration.GetSection("Email").GetSection("Email").Value.ToString();
            EmailMaster.Password = Configuration.GetSection("Email").GetSection("Password").Value.ToString();
            EmailMaster.EnableSsl = Convert.ToBoolean(Configuration.GetSection("Email").GetSection("SSLEnable").Value);
            EmailMaster.Port = Convert.ToInt32(Configuration.GetSection("Email").GetSection("Port").Value);

            services.AddRazorPages();
            services.AddScoped<IDataLayer, DataLayer>();
            services.AddScoped<IRequestInfo, RequestInfo>();
            //services.AddHsts(options =>
            //{
            //    options.Preload = true;
            //    options.IncludeSubDomains = true;
            //    options.MaxAge = TimeSpan.FromDays(60);
            //    options.ExcludedHosts.Add("http://www.finnidpro.com");
            //    options.ExcludedHosts.Add("www.finnidpro.com");
            //    options.ExcludedHosts.Add("finnidpro.com");
            //});

            //services.AddHttpsRedirection(options =>
            //{
            //    options.RedirectStatusCode = (int)HttpStatusCode.TemporaryRedirect;
            //    options.HttpsPort = 5001;
            //});

            //if (!_env.IsDevelopment())
            //{
            //    services.AddHttpsRedirection(options =>
            //    {
            //        options.RedirectStatusCode = (int)HttpStatusCode.PermanentRedirect;
            //        options.HttpsPort = 443;
            //    });
            //}
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
