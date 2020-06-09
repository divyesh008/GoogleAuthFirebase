using FFImageLoading;
using FirebaseGAuth.iOS.Helpers;
using System;
using UIKit;

namespace FirebaseGAuth.iOS
{
    public partial class ProfileView : UIViewController
    {
        public ProfileView (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            lblUsername.Text = Settings.FirebaseLoggedInUser.DisplayName;
            lblEmail.Text = Settings.FirebaseLoggedInUser.Email;

            imgProfile.Layer.CornerRadius = imgProfile.Frame.Width / 2;
            ImageService.Instance.LoadUrl(Settings.FirebaseLoggedInUser.PhotoUrl.ToString())
                        .Into(imgProfile);

            btnLogout.TouchUpInside += BtnLogout_TouchUpInside;
        }

        private void BtnLogout_TouchUpInside(object sender, EventArgs e)
        {
            bool signout = UserSession.Logout();
            if (signout)
            {
                NavigationController.PopViewController(false);
            }
        }
    }
}
