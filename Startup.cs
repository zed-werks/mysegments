//-------------------------------------------------------------------------
// Copyright © 2019 Zed Werks Inc.
//
// Licensed under the GNU General Public License, Version 3.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// https://www.gnu.org/licenses/gpl-3.0.en.html
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//-------------------------------------------------------------------------
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Http.Logging;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Logging;


using VueCliMiddleware;

namespace mysegments
{
    public class Startup
    {
        private readonly IConfiguration configuration;
        private readonly ILogger<Startup> logger;
        private void CheckSameSite(HttpContext httpContext, CookieOptions options)
        {
            if (options.SameSite == SameSiteMode.None)
            {
                var userAgent = httpContext.Request.Headers["User-Agent"].ToString();
                // TODO: Use your User Agent library of choice here. 
                if (options.SameSite == SameSiteMode.Lax/* UserAgent doesn’t support new behavior */)
                {
                    options.SameSite = SameSiteMode.Unspecified;
                }
            }
        }
        /// <summary>
        /// This sets up the OIDC authentication for Hangfire.
        /// </summary>
        /// <param name="services">The passed in IServiceCollection.</param>
        private void ConfigureAuthentication(IServiceCollection services)
        {
            services.AddAuthentication(auth =>
            {
                auth.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
                auth.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                auth.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddCookie(options =>
            {
                options.Cookie.Name = "com.mysegments";
                //options.LoginPath = AuthorizationConstants.LoginPath;
                //options.LogoutPath = AuthorizationConstants.LogoutPath;
            })
            .AddOpenIdConnect(options =>
            {
                options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.ResponseType = OpenIdConnectResponseType.Code;
                options.SaveTokens = false;
                options.GetClaimsFromUserInfoEndpoint = true;
                options.Scope.Add("openid");
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                };
                this.configuration.GetSection("OpenIdConnect").Bind(options);
                options.Events = new OpenIdConnectEvents()
                {
                    OnRedirectToIdentityProvider = ctx =>
                    {
                        this.logger.LogDebug("Redirecting to identity provider");
                        return Task.FromResult(0);
                    },
                };
            });
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="env">The injected Environment provider.</param>
        /// <param name="configuration">The injected configuration provider.</param>
        /// <param name="logger">The injected logger provider.</param>
        public Startup(IConfiguration configuration, ILogger<Startup> logger)
        {
            this.configuration = configuration;
            this.logger = logger;

        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.MinimumSameSitePolicy = SameSiteMode.Unspecified;
                options.OnAppendCookie = cookieContext =>
                    CheckSameSite(cookieContext.Context, cookieContext.CookieOptions);
                options.OnDeleteCookie = cookieContext =>
                    CheckSameSite(cookieContext.Context, cookieContext.CookieOptions);
            });
                        // Add framework services.
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddControllersWithViews();

            // Add AddRazorPages if the app uses Razor Pages.
            services.AddRazorPages();

            // In production, the Vue files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
                app.UseHttpsRedirection();
            }

            app.UseCookiePolicy(); // Before UseAuthentication or anything else that writes cookies. 
            app.UseAuthentication();


/*
            app.Use(async (context, next) =>
            {
                if (!context.User.Identity.IsAuthenticated)
                {
                    await context.ChallengeAsync();
                }
                else
                {
                    await next();
                }
            }); */

            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");

                if (env.IsDevelopment())
                {
                    endpoints.MapToVueCliProxy(
                        "{*path}",
                        new SpaOptions { SourcePath = "ClientApp" },
                        npmScript: "serve",
                        regex: "Compiled successfully");
                }

                // Add MapRazorPages if the app uses Razor Pages. Since Endpoint Routing includes support for many frameworks, adding Razor Pages is now opt -in.
                endpoints.MapRazorPages();
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";
            });
        }
    }
}
