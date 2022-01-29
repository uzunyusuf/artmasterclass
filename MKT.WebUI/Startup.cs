using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MKT.Business.Abstract;
using MKT.Business.Abstract.AppointmentsDB;
using MKT.Business.Concrete;
using MKT.Business.Concrete.AppointmentsDB;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using MKT.DataAccess.Model.AppointmentApiModel;

namespace MKT.WebUI
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

            services.AddControllersWithViews();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(co =>
            {
                co.Events = new CookieAuthenticationEvents()
                {
                    OnRedirectToLogin = (context) =>
                    {
                        context.HttpContext.Response.Redirect("/Security/Login");
                        return Task.CompletedTask;
                    },
                    OnRedirectToAccessDenied = (context) =>
                    {
                        context.HttpContext.Response.Redirect("/Security/AccessDenied");
                        return Task.CompletedTask;
                    },
                    OnSigningOut = (context) =>
                    {
                        context.HttpContext.Response.Redirect("/Security/Logout");
                        return Task.CompletedTask;
                    }
                };
            });


            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IAnnouncementService, AnnouncementService>();
            services.AddScoped<ITicketService, TicketService>();

            services.AddSingleton<IAppointmentShopifyService, AppointmentShopifyService>();
            services.AddSingleton<IOrderSingletonService, OrderSingletonService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddHttpClient();

            services.AddSession();
            services.AddDistributedMemoryCache();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();


            app.UseSession();
            app.UseAuthentication();

            app.UseAuthorization();


            var cultureInfo = new CultureInfo("en-AU");
            var dateformat = new DateTimeFormatInfo
            {
                ShortDatePattern = "dd/MM/yyyy",
                LongDatePattern = "dd/MM/yyyy hh:mm:ss tt"
            };
            cultureInfo.DateTimeFormat = dateformat;

            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
