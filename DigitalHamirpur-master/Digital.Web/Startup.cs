using Digital.Data.Models;
using Digital.Repo;
using Digital.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NToastNotify;

namespace Digital.Web
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
                options.ConsentCookie.SecurePolicy = CookieSecurePolicy.Always;
            });
            services.AddSession(options =>
            {
                options.Cookie.IsEssential = true;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
            });
            services.Configure<CookieTempDataProviderOptions>(options =>
            {
                options.Cookie.IsEssential = true;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;

            });
            services.AddSession();
            services.AddMvc().AddRazorRuntimeCompilation();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddHttpClient();
            services.AddControllers();
            services.AddHttpContextAccessor();
            services.AddDistributedMemoryCache();
            services.AddAutoMapper(typeof(Startup).Assembly);
            // SiteKeys.Configure(Configuration.GetSection("SiteKeys"));
            services.Configure<CookieTempDataProviderOptions>(options =>
            {
                options.Cookie.IsEssential = true;
            });

            //set connection string
            services.AddDbContext<ElectronicDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opt =>
            {
                opt.LoginPath = "/Account/Login";
            });
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddControllersWithViews().AddRazorRuntimeCompilation().AddNToastNotifyNoty(new NotyOptions
            {
                ProgressBar = true,
                Timeout = 2000
            }); ; ;
            services.AddRazorPages();
            services.Configure<FormOptions>(x => x.ValueCountLimit = 1048576);
            //services.AddMvc().AddRazorRuntimeCompilation();

            #region add dependency
            //add dependency injection
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ISubcategoryService, SubcategoryService>();
            services.AddScoped<IProductService, ProductService>();


            //end dependency injection

            #endregion


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
            app.UseAuthorization();
            app.UseNToastNotify();
            app.UseMvc(routes =>
            {


                routes.MapAreaRoute(
                    name: "Admin",
                    areaName: "Admin",
                    template: "Admin/{controller=Dashboard}/{action=Index}/{id?}"
                    );

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                    );


            });



        }
    }
}
