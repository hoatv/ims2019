using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IMS_2019.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Routing;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace IMS_2019
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        //public void ConfigureServices(IServiceCollection services)
        //{
        //    services.Configure<CookiePolicyOptions>(options =>
        //    {
        //        // This lambda determines whether user consent for non-essential cookies is needed for a given request.
        //        options.CheckConsentNeeded = context => true;
        //        options.MinimumSameSitePolicy = SameSiteMode.None;
        //    });

        //    services.AddDbContext<ApplicationDbContext>(options =>
        //        options.UseSqlServer(
        //            Configuration.GetConnectionString("DefaultConnection")));
        //    services.AddDefaultIdentity<IdentityUser>()
        //        .AddEntityFrameworkStores<ApplicationDbContext>();

        //    services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        //}

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            //.AddDefaultTokenProviders()
            .AddDefaultUI();

            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseMySql(
            Configuration.GetConnectionString("DefaultConnection")));

            services.AddAuthentication(IdentityConstants.ApplicationScheme)
            .AddCookie("Cookies")
            .AddGoogle(config =>
            {
                //config.SignInScheme = "Cookies";
                //config.CallbackPath = new PathString("/signin-google");
                //config.CallbackPath = new PathString("/signin-google");
                config.ClientId = "418407572097-67g09ffief26d363ugu611qqhgum14e5.apps.googleusercontent.com";
                config.ClientSecret = "HmEtIuqN2Vteh-J7ORKlFd0v";
                config.CallbackPath = new PathString("/signin-google");
                //config.Events = new OAuthEvents
                //{
                //    OnCreatingTicket = context =>
                //    {
                //        string email = context.User.Value<string>("email");
                //        if (!email.Contains("@topica.edu.vn") &&  !email.Contains("@topica.asia"))
                //            throw new Exception("You must sign in with a TOPICA email address");
                //        //return RedirectToLocal(returnUrl);

                //        //context.Response.Redirect("/Home/Error?message=" + "Error");
                //        return Task.CompletedTask;
                //    }
                //};

                //config.ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "UserId");
                //config.ClaimActions.MapJsonKey(ClaimTypes.Email, "EmailAddress", ClaimValueTypes.Email);
                //config.ClaimActions.MapJsonKey(ClaimTypes.Name, "Name");
            });



            //services.AddMvc().AddRazorPagesOptions(options => {
            //    options.Conventions.AddAreaPageRoute("Identity", "/Account/Login", "/Account/Login");
            //}).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //    //services.ConfigureApplicationCookie(options =>
            //    //{
            //    //    options.LoginPath = $"/account/login";
            //    //    options.LogoutPath = $"/account/logout";
            //    //    options.AccessDeniedPath = $"/account/access-denied";
            //    //});

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //app.UseCookiePolicy();


            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                //routes.MapRoute(
                //    name: "Google API Sign-in",
                //    url: "signin-google",
                //    defaults: new { controller = "Account", action = "ExternalLoginCallbackRedirect" }
                //);
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Document}/{action=Index}");

                //routes.MapRoute(
                    //name: "signin-google",
                    ////UriParser: "signin-google",
                    //template: "{controller=Account}/{action=ExternalLoginConfirmation}");
            });
        }
    }
}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.HttpsPolicy;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using IMS_2019.Data;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;


//using Microsoft.AspNetCore.Authentication.Google;
//using Microsoft.AspNetCore.Authentication;
//using System.Security.Claims;
//using Microsoft.AspNetCore.Identity.UI.Services;
//using Microsoft.AspNetCore.Authentication.Cookies;
//using Microsoft.AspNetCore.Authentication.OAuth;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

//namespace IMS_2019
//{
//    public class Startup
//    {
//        public Startup(IConfiguration configuration)
//        {
//            Configuration = configuration;
//        }

//        public IConfiguration Configuration { get; }

//        // This method gets called by the runtime. Use this method to add services to the container.
//        public void ConfigureServices(IServiceCollection services)
//        {
//            services.Configure<CookiePolicyOptions>(options =>
//            {
//                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
//                options.CheckConsentNeeded = context => true;
//                options.MinimumSameSitePolicy = SameSiteMode.None;
//            });

//            services.AddDbContext<ApplicationDbContext>(options =>
//                options.UseSqlServer(
//                    Configuration.GetConnectionString("DefaultConnection")));
//            services.AddDefaultIdentity<IdentityUser>()
//                .AddEntityFrameworkStores<ApplicationDbContext>();

//            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
//        }

//        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
//        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
//        {
//            if (env.IsDevelopment())
//            {
//                app.UseDeveloperExceptionPage();
//                app.UseDatabaseErrorPage();
//            }
//            else
//            {
//                app.UseExceptionHandler("/Home/Error");
//                app.UseHsts();
//            }

//            app.UseHttpsRedirection();
//            app.UseStaticFiles();
//            app.UseCookiePolicy();

//            app.UseAuthentication();

//            app.UseMvc(routes =>
//            {
//                routes.MapRoute(
//                    name: "default",
//                    template: "{controller=Document}/{action=Index}");
//            });
//        }
//    }
//}
