using System;
using FirebaseGAuth.iOS.Configuration;
using FirebaseGAuth.iOS.Helpers;
using Xamarin.Auth;

namespace FirebaseGAuth.iOS.Services
{
    public class OAuthenticationService
    {
        private static OAuth2Authenticator oAuth2Authenticator;

        public static OAuth2Authenticator CreateOAuth2(OAuth2ProviderType socialLoginType)
        {
            switch (socialLoginType)
            {
                case OAuth2ProviderType.GOOGLE:
                    oAuth2Authenticator = new OAuth2Authenticator(
                        clientId: AppConstants.GoogleClientId,
                        clientSecret: string.Empty,
                        scope: AppConstants.Scope,
                        authorizeUrl: new Uri(AppConstants.GoogleAuthorizeUrl),
                        redirectUrl: new Uri(AppConstants.GoogleRedirectUrl),
                        getUsernameAsync: null,
                        isUsingNativeUI: AppConstants.GoogleIsUsingNativeUI,
                        accessTokenUrl: new Uri(AppConstants.GoogleAccessTokenUrl));
                    break;
            }

            AuthenticationState = oAuth2Authenticator;
            return oAuth2Authenticator;
        }


        public OAuth2Authenticator GetAuthenticator()        {            return oAuth2Authenticator;        }

        public static OAuth2Authenticator AuthenticationState { get; private set; }

    }
}
