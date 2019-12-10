

namespace AspNetCore.OAuth.Provider.Strava
{
    using System.ComponentModel;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authentication.OAuth;
    using Microsoft.AspNetCore.Http;
    using System.Security.Claims;
    public class StravaAuthOptions : OAuthOptions
    {
        /// <summary>
        /// Configuration options for <see cref="StravaAuthHandler"/>.
        /// </summary>
        public StravaAuthOptions()
        {
            ClaimsIssuer = StravaAuthDefaults.Issuer;

            CallbackPath = new PathString(StravaAuthDefaults.CallbackPath); // used by OWIN, not MVC

            AuthorizationEndpoint = StravaAuthDefaults.AuthorizationEndpoint;
            TokenEndpoint = StravaAuthDefaults.TokenEndpoint;
            UserInformationEndpoint = StravaAuthDefaults.UserInformationEndpoint;

            Scope.Add("read");
            Scope.Add("activity:read_all");
            Scope.Add("profile:read_all");
            
            this.UsePkce = true;

            this.ClaimsIssuer = StravaAuthDefaults.Issuer;

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
        }
    }
}
