using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Id.Overview.Mvc.Data;
using Id.Overview.Mvc.Models;
using Id.Overview.Mvc.Services;
using System.Security.Claims;

namespace Id.Overview.Mvc
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

            services
                .AddIdentity<ApplicationUser, IdentityRole>(options =>
                {
                    //Lockout
                    options.Lockout.AllowedForNewUsers = true;
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                    options.Lockout.MaxFailedAccessAttempts = 5;   // Número total de tentativas de acesso

                    //Password
                    options.Password.RequireDigit = true;          //Requesr ao menos 1 número na senha
                    options.Password.RequiredLength = 6;           //Tamanho mínimo de caracteres(aceitável 6 é o default)
                    options.Password.RequiredUniqueChars = 1;      //Requer o mínimo decaracteres diferentes da senha(1 é o defualt)
                    options.Password.RequireLowercase = true;      //Requer que a senha tenha ao menos 1 letra minuscula
                    options.Password.RequireUppercase = true;      //Requer que a senha tenha ao menos 1 letra maiuscula
                    options.Password.RequireNonAlphanumeric = true;//Requer que a senha tenha ao menos 1 caractere especial

                    //Sign
                    options.SignIn.RequireConfirmedEmail = false;  //Deve confirma um email (por default false)
                    options.SignIn.RequireConfirmedEmail = false;  //Para confirmar o login por número de telefone

                    //Token
                    // options.Tokens.AuthenticatorTokenProvider     //Define o change email token
                    // options.Tokens.ChangePhoneNumberTokenProvider //Token para alteração de número de tel do user
                    // options.Tokens.ChangeEmailTokenProvider       //Token para confirmação de email configurado pelo user
                    // options.Tokens.PasswordResetTokenProvider     //Token para alterar senha do user

                    //User
                    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ-._@=#$&";
                    options.User.RequireUniqueEmail = false;
                })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Cookie
            services.ConfigureApplicationCookie(options =>
            {

                options.AccessDeniedPath = "/Account/AccessDenied";
                //options.ClaimsIssuer = "";
                //options.Cookie.Domain = "";
                //options.Cookie.Expiration = "";
                options.Cookie.HttpOnly = true;
                options.Cookie.Name = ".AspNetCore.Cookies";
                //options.Cookie.Path = "";
                options.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Lax;
                options.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.SameAsRequest;
                //options.CookieManager = 
                //options.DataProtectionProvider
                //options.Events = 
                //options.EventsType = 
                options.ExpireTimeSpan = TimeSpan.FromDays(14);
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
                options.ReturnUrlParameter = "ReturnUrl";
                //options.SessionStore = 
                options.SlidingExpiration = true;
                //options.TicketDataFormat = 
            });

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
