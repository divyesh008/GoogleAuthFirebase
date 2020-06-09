using System;
namespace FirebaseGAuth.iOS.Configuration
{
    public static class AppConstants
    {
        /// <summary>
        /// Google api key.
        /// </summary>
        public const string GoogleApiKey = "AIzaSyCcVwhx42IykyBNqFVxJh0gA9LdsM_Koco";

        /// <summary>
        /// Google Client Id.
        /// </summary>
        public const string GoogleClientId = "31148871439-fsngvnu6k04358l9qguhs9fhk1tn501l.apps.googleusercontent.com";

        /// <summary>
        /// User Profile Access Scope. Can read this details after login.
        /// </summary>
        public const string Scope = "https://www.googleapis.com/auth/userinfo.profile https://www.googleapis.com/auth/userinfo.email https://www.googleapis.com/auth/plus.login";

        /// <summary>
        /// Google Redirect Url. After login process redirect back to app.
        /// </summary>
        public const string GoogleRedirectUrl = "com.googleusercontent.apps.31148871439-fsngvnu6k04358l9qguhs9fhk1tn501l:/oauth2redirect";

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
