// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace FirebaseGAuth.iOS
{
    [Register ("WelcomeView")]
    partial class WelcomeView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView vwGoogleLogin { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView vwPhoneLogin { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (vwGoogleLogin != null) {
                vwGoogleLogin.Dispose ();
                vwGoogleLogin = null;
            }

            if (vwPhoneLogin != null) {
                vwPhoneLogin.Dispose ();
                vwPhoneLogin = null;
            }
        }
    }
}