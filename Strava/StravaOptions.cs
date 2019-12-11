using System.Security.AccessControl;


namespace AspNetCore.Authentication.Strava
{
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text.Json;
    using System.Security.Claims;

    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authentication.OAuth;
    using Microsoft.AspNetCore.Http;

    public class StravaOptions : OAuthOptions
    {
        /// <summary>
        /// Configuration options for <see cref="StravaHandler"/>.
        /// </summary>
        public StravaOptions()
        {
            ClaimsIssuer = StravaDefaults.Issuer;

            CallbackPath = new PathString(StravaDefaults.CallbackPath); // used by OWIN, not MVC

            AuthorizationEndpoint = StravaDefaults.AuthorizationEndpoint;
            TokenEndpoint = StravaDefaults.TokenEndpoint;
            UserInformationEndpoint = StravaDefaults.UserInformationEndpoint;

            Scope.Add("read");
            Scope.Add("activity:read_all");
            Scope.Add("profile:read_all");

            ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "id");
            ClaimActions.MapJsonKey(ClaimTypes.Name, "username");
            ClaimActions.MapJsonKey(ClaimTypes.GivenName, "firstname");
            ClaimActions.MapJsonKey(ClaimTypes.Surname, "lastname");
            ClaimActions.MapJsonKey(ClaimTypes.Email, "email");
            ClaimActions.MapJsonKey(ClaimTypes.StateOrProvince, "state");
            ClaimActions.MapJsonKey(ClaimTypes.Country, "country");
            ClaimActions.MapJsonKey(ClaimTypes.Gender, "sex");
            ClaimActions.MapJsonKey("urn:strava:city", "city");
            ClaimActions.MapJsonKey("urn:strava:profile", "profile");
            ClaimActions.MapJsonKey("urn:strava:profile-medium", "profile_medium");
            ClaimActions.MapJsonKey("urn:strava:created-at", "created_at");
            ClaimActions.MapJsonKey("urn:strava:updated-at", "updated_at");
            ClaimActions.MapJsonKey("urn:strava:premium", "premium");

            this.Events = new OAuthEvents
            {
                OnCreatingTicket = async context =>
                {
                    // Get user info from the userinfo endpoint and use it to populate user claims
                    var request = new HttpRequestMessage(HttpMethod.Get, context.Options.UserInformationEndpoint);
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", context.AccessToken);
                    var response = await context.Backchannel.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, context.HttpContext.RequestAborted);
                    response.EnsureSuccessStatusCode();
                    JsonElement user = JsonSerializer.Deserialize<JsonElement>(await response.Content.ReadAsStringAsync());
                    context.RunClaimActions(user);
                }
            };
        }
    }
}
