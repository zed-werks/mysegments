
namespace AspNetCore.Authentication.Strava
{
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authentication.OAuth;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Security.Claims;
    using System.Text.Encodings.Web;
    using System.Text.Json;
    using System.Threading.Tasks;
    public class StravaHandler : OAuthHandler<StravaOptions>
    {
        /// <summary>
        /// Authentication handler for Strava authentication
        /// </summary>
        public StravaHandler(
            IOptionsMonitor<StravaOptions> options,
            ILoggerFactory factory,
            UrlEncoder encoder,
            ISystemClock clock) : base(options, factory, encoder, clock) { }

        protected override string FormatScope()
        {
            // Strava deviates from the OAuth spec and requires comma separated scopes instead of space separated.
            return string.Join(",", Options.Scope);
        }
    }
}
