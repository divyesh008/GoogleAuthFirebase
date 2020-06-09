using System;
namespace FirebaseGAuth.iOS.Configuration
{
    public static class AppConstants
    {
        /// <summary>
        /// Google api key.
        /// </summary>
        public const string GoogleApiKey = "<Your Firebase Project API Key>";

        /// <summary>
        /// Google Client Id.
        /// </summary>
        public const string GoogleClientId = "<Your Google Project ClientId>";

        /// <summary>
        /// User Profile Access Scope. Can read this details after login.
        /// </summary>
        public const string Scope = "https://www.googleapis.com/auth/userinfo.profile https://www.googleapis.com/auth/userinfo.email https://www.googleapis.com/auth/plus.login";

        /// <summary>
        /// Google Redirect Url. After login process redirect back to app.
        /// </summary>
        public const string GoogleRedirectUrl = "<Your Google Project iOS URL scheme>:/oauth2redirect";

        /// <summary>
        /// Google Authorization Url.
        /// </summary>
        public const string GoogleAuthorizeUrl = "https://accounts.google.com/o/oauth2/auth";

        /// <summary>
        /// Google Access Token Url.
        /// </summary>
        public const string GoogleAccessTokenUrl = "https://www.googleapis.com/oauth2/v4/token";

        /// <summary>
        /// Determine to Use native ui or not. If yes it will use device's default browser.
        /// </summary>
        public const bool GoogleIsUsingNativeUI = true;

    }
}
