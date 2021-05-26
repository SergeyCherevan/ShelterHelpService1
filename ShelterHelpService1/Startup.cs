using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

using React.AspNet;
using JavaScriptEngineSwitcher.Extensions.MsDependencyInjection;
using JavaScriptEngineSwitcher.ChakraCore;

using ShelterHelpService1.Settings;
using ShelterHelpService1.Models;
using Microsoft.AspNetCore.Identity;

namespace ShelterHelpService1
{
    public class Startup
    {
        private IConfiguration Configuration { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            Configuration.Bind("CompanyInfo", new CompanyInfo());

            services.AddDbContext<ShelterHelpServiceContext>(
                options => options.UseSqlite(Configuration.GetConnectionString("DefaultConnection"))
            );

            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 5;   // ����������� �����
                options.Password.RequireNonAlphanumeric = false;   // ��������� �� �� ���������-�������� �������
                options.Password.RequireLowercase = false; // ��������� �� ������� � ������ ��������
                options.Password.RequireUppercase = false; // ��������� �� ������� � ������� ��������
                options.Password.RequireDigit = false; // ��������� �� �����
            }).AddEntityFrameworkStores<ShelterHelpServiceContext>();

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "ShelterHelpServiceAuth";
                options.Cookie.HttpOnly = true;
                options.LoginPath = "/";
                options.SlidingExpiration = true;
            });

            services.AddMvc().
                AddSessionStateTempDataProvider();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddReact();

            services.AddJsEngineSwitcher(options => options.DefaultEngineName = ChakraCoreJsEngine.EngineName)
                .AddChakraCore();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseReact(config => { });

            app.UseRouting();

            app.UseStaticFiles();

            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");
            });
        }
    }
}
