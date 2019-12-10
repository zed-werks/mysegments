namespace AspNetCore.OAuth.Provider.Strava
{
    /// <summary>
    /// Default values used by the Strava authentication middleware.
    /// </summary>
    public static class StravaAuthDefaults
    {
        public const string AuthenticationScheme = "Strava";
        public const string DisplayName = "Strava";
        public const string Issuer = "Strava";
        public const string CallbackPath = "/strava-callback";
        public const string AuthorizationEndpoint = "https://www.strava.com/api/v3/oauth/authorize";
        public const string TokenEndpoint = "https://www.strava.com/api/v3/oauth/token";
        public const string UserInformationEndpoint = "https://www.strava.com/api/v3/athlete";
    }
}
