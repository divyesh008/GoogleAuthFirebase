# GoogleAuthFirebase
Xamarin.iOS + Firebase Auth sample

We can do google login in by performing 2 steps:

1. Firebase App Setup

-Create new firebase project

-Download GoogleService-Info.plist and set it’s build action to BundleResource
 
-Go to authentication tab and Enable Google Login

-Now for google login we have to create project in google developer console too.

Note: We do not have to create project in google developer console manually it will be created automatically, I will show you that in setup.
Though we can create it manually but it’s not accurate, so it’s better to use the direct approach.

 
2. Coding 

For this I’m going to use below Plugins:

-Newtonsoft.Json
-Xam.Plugin.Settings
-Xamarin.Auth
-Xamarin.Firebase.iOS.Auth

Using Xamarin.Auth
As Google authentication is OAuth2, we will use the OAuth2Authenticator class provided by Xamarin.Auth. This class comes with several constructors but only one interests us.

new OAuth2Authenticator(
    string clientId,
    string clientSecret,
    string scope,
    Uri authorizeUrl,
    Uri redirectUrl,
    Uri accessTokenUrl,
    GetUsernameAsyncFunc getUsernameAsyncFunc = null,
    bool isUsingNativeUI = false);

    •    ClientId: the id that we’ve generated on Google Developer Console (Android/iOS)
    •    ClientSecret: not needed by Google
    •    Scope: magic string telling which permission to grant on authentication
    •    AuthorizeUrl/AccessTokenUrl: Google’s URLs required when authenticating
    •    RedirectUrl: custom url (doesn’t need to exist)
    •    GetUsernameAsyncFunc: we won’t be using it
    •    IsUsingNativeUI: the famous flag to enable in order to comply to Google’s new policy


Xamarin.Auth will query the AuthorizeUrl with our ClientId and Scope. Then, when the user will be authenticated in his web browser, Google will call our RedirectUrl with a bunch of parameters. Xamarin.Auth will catch this RedirectUrl (with our help, we’ll see that later) and parse it. Then it will call the AccessTokenUrl to get the actual token that will allow us to call APIs as the authenticated user.
AuthorizeUrl and AccessTokenUrl can be retrieved in the Google documentation. The Scope can be also retrieved in the Google documentation. Though we will use the “email” scope for our sample.

The OAuth2Authenticator class comes with two events: Completed and Error They’re quite simple to understand. The first one will call our handler when the authentication has completed (with the user authenticated or not) and the latter will allow us to react to an error (bad network, etc.)

Auth.Completed += OnAuthenticationCompleted;
Auth.Error += OnAuthenticationFailed;

When the authentication ends, OnAuthenticationCompleted is called and we can check if the user is authenticated and retrieve the precious OAuth token that we need to call other APIs.

While Xamarin.Auth usually doesn’t need anything else to work, Google authentication is a bit more tricky because it uses NativeUI. Xamarin.Auth will not be able to react to the redirection to RedirectUrl made by Google. For that, we will need to intercept the redirection ourselves (inside the Android and iOS projects) and provide the URL to Xamarin.Auth in order for it to ends the authentication flow. That requires us to keep the OAuth2Authenticator instance somewhere. I usually stores it as a static field, and clean it when I’m done.

Intercepting the redirection
For that, we need to declare a URL type in the Info.plist file. We only have to declare our package name as a potential URL scheme that will launch our app.

Then every time Safari tries to navigate to a URL like “com.dev.googleauth:/”, it will run our app and call the OpenUrl method of the AppDelegate class.

Finally Running our project

The last step is to run the actual authenticator. This will launch the native web browser and initiates the authentication.
var view = authenticator.GetUI();
PresentViewController(view, true, null);

Also when you’re handling both Completed and Error events from the authenticator, you will need to manually call DismissViewController because the SFSafariViewController doesn’t dismiss itself.

If you forgot to DismissViewController control will not come back to your application after login process done


# Fix 403 error while push code 
https://www.a2hosting.in/kb/developer-corner/version-control-systems1/403-forbidden-error-message-when-you-try-to-push-to-a-github-repository
