﻿using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using eStore.DL.Data;
using Microsoft.AspNetCore.Http;
using eStore.Shared.Models.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Threading.Tasks;
//using eStore.ImportDatabase.Data;

namespace eStore
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
            //services.AddCors();
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                        //builder.WithOrigins("http://localhost",
                        //                    "http://localhost:3000").AllowAnyHeader()
                        //                          .AllowAnyMethod(); 
                    });
            });
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddDbContext<eStoreDbContext>(options =>
                            options.UseSqlServer(
                                Configuration.GetConnectionString("DefaultConnection")));

            //services.AddDbContext<eStoreDbContext>(options =>
            //                options.UseSqlite(
            //                    Configuration.GetConnectionString("DefaultConnectionMac")));

            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddControllersWithViews();


            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            //{
            //    opt.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ClockSkew = TimeSpan.FromMinutes(5),
            //        RequireSignedTokens = true,
            //        RequireExpirationTime = true,
            //        ValidateLifetime = true,
            //        ValidateAudience = false,
            //        ValidIssuer = issuer,
            //        IssuerSigningKey = new X509SecurityKey(certificate),
            //        ValidateIssuerSigningKey = true,
            //        NameClaimType = "sub"
            //    };
            //    opt.IncludeErrorDetails = true;
            //});

            //Added From Old
            services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
                 .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<eStoreDbContext>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest)
                .AddRazorPagesOptions(options =>
                {
                    //options.AllowAreas = true;
                    options.Conventions.AuthorizeAreaFolder("Identity", "/Account/Manage");
                    options.Conventions.AuthorizeAreaPage("Identity", "/Account/Logout");
                });

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = $"/Identity/Account/Login";
                options.LogoutPath = $"/Identity/Account/Logout";
                options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
                //options.Events = new CookieAuthenticationEvents()
                //{
                //    OnRedirectToLogin = (ctx) =>
                //    {
                //        if (ctx.Request.Path.StartsWithSegments("/api") && ctx.Response.StatusCode == 200)
                //        {
                //            ctx.Response.StatusCode = 401;
                //        }

                //        return Task.CompletedTask;
                //    },
                //    OnRedirectToAccessDenied = (ctx) =>
                //    {
                //        if (ctx.Request.Path.StartsWithSegments("/api") && ctx.Response.StatusCode == 200)
                //        {
                //            ctx.Response.StatusCode = 403;
                //        }

                //        return Task.CompletedTask;
                //    }
                //};
            });

            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromHours(4);//You can set Time
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
                options.Cookie.Name = ".eStore.Session";
            });

            services.AddRazorPages();

            services.AddAuthorization(options =>
            {
                options.FallbackPolicy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
            });
            services.AddSwaggerGen();
            services.AddControllers(config =>
            {
                // using Microsoft.AspNetCore.Mvc.Authorization;
                // using Microsoft.AspNetCore.Authorization;
                var policy = new AuthorizationPolicyBuilder()
                                 .RequireAuthenticatedUser()
                                 .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            Console.WriteLine($"EnvName:{env.EnvironmentName}");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseDefaultFiles();
            app.UseRouting(); app.UseCors();



            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCookiePolicy();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                 name: "areas",
                 pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });


        }
    }
}
