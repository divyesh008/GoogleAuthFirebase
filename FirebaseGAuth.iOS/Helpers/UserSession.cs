using System;
using Firebase.Auth;
using Foundation;
using Xamarin.Auth;

namespace FirebaseGAuth.iOS.Helpers
{
    public class UserSession
    {
        public static string ErrorMsg = string.Empty;

        private static string _Token;

        public static string Token
        {
            get { return _Token; }
            set { _Token = value; }
        }

        public static string AccountType { get; set; }

        private static Account _account;

        public static Account Account
        {
            get { return _account; }
        }

        public static void SaveAccount(Account account)
        {
            _account = account;
            _Token = account.Properties["access_token"];
        }

        public static bool Logout()
        {
            NSError error;
            var signedOut = Firebase.Auth.Auth.DefaultInstance.SignOut(out error);
            if (!signedOut)
            {
                AuthErrorCode errorCode;
                if (IntPtr.Size == 8) // 64 bits devices
                    errorCode = (AuthErrorCode)((long)error.Code);
                else // 32 bits devices
                    errorCode = (AuthErrorCode)((int)error.Code);

                // Posible error codes that SignOut method with credentials could throw
                // Visit https://firebase.google.com/docs/auth/ios/errors for more information
                switch (errorCode)
                {
                    case AuthErrorCode.KeychainError:
                    default:
                        // Print error
                        break;
                }
                return false;
            }
            else
            {
                // handle successful signout
                _account = null;
                _Token = null;
                Settings.FirebaseLoggedInUser = null;
                return true;
            }
        }
    }
}
