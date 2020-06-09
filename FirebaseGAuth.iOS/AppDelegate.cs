using System;
using FirebaseGAuth.iOS.Services;
using Foundation;
using UIKit;

namespace FirebaseGAuth.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {

        public override  UIWindow Window { get; set; }
        
        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            //Configure firebase 
            Firebase.Core.App.Configure();
            return true;
        }

        public override bool OpenUrl(UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
        {
            Uri uri = new Uri(url.AbsoluteString);
            OAuthenticationService.AuthenticationState.OnPageLoading(uri);
            return true;
        }
    }
}

