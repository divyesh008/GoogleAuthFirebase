using System;
namespace FirebaseGAuth.iOS.Model
{
    public class User
    {
        public string Uid { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public bool IsAnonymous { get; set; }
        public string PhoneNumber { get; set; }
        public Uri PhotoUrl { get; set; }
        public string ProviderId { get; set; }
        public bool IsEmailVerified { get; set; }
    }
}
