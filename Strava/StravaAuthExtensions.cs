

namespace AspNetCore.OAuth.Provider.Strava
{
    using System;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;
    
    public static class StravaAuthExtensions
    {
        /// <summary>
        /// Authenticate users using Facebook
        /// </summary>
        /// <param name="app">The <see cref="IAppBuilder"/> passed to the configuration method</param>
        /// <param name="options">Middleware configuration options</param>
        /// <returns>The updated <see cref="IAppBuilder"/></returns>
        /// 
        ///         public static IApplicationBuilder UseRequestCulture(
        public static IApplicationBuilder UseStravaAuthentication(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthenticationMiddleware>();
        }

        public static AuthenticationBuilder AddStrava(this AuthenticationBuilder builder)
            => builder.AddStrava(StravaAuthDefaults.AuthenticationScheme, _ => { });

        public static AuthenticationBuilder AddStrava(this AuthenticationBuilder builder, Action<StravaAuthOptions> configureOptions)
            => builder.AddStrava(StravaAuthDefaults.AuthenticationScheme, configureOptions);

        public static AuthenticationBuilder AddStrava(this AuthenticationBuilder builder, string authenticationScheme, Action<StravaAuthOptions> configureOptions)
            => builder.AddStrava(authenticationScheme, StravaAuthDefaults.DisplayName, configureOptions);

        public static AuthenticationBuilder AddStrava(this AuthenticationBuilder builder, string authenticationScheme, string displayName, Action<StravaAuthOptions> configureOptions)
            => builder.AddOAuth<StravaAuthOptions, StravaAuthHandler>(authenticationScheme, displayName, configureOptions);
    }
}
