

namespace AspNetCore.Authentication.Strava
{
    using System;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;
    
    public static class StravaExtensions
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
            => builder.AddStrava(StravaDefaults.AuthenticationScheme, _ => { });

        public static AuthenticationBuilder AddStrava(this AuthenticationBuilder builder, Action<StravaOptions> configureOptions)
            => builder.AddStrava(StravaDefaults.AuthenticationScheme, configureOptions);

        public static AuthenticationBuilder AddStrava(this AuthenticationBuilder builder, string authenticationScheme, Action<StravaOptions> configureOptions)
            => builder.AddStrava(authenticationScheme, StravaDefaults.DisplayName, configureOptions);

        public static AuthenticationBuilder AddStrava(this AuthenticationBuilder builder, string authenticationScheme, string displayName, Action<StravaOptions> configureOptions)
            => builder.AddOAuth<StravaOptions, StravaHandler>(authenticationScheme, displayName, configureOptions);
    }
}
