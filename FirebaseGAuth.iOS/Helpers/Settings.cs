using System;
using FirebaseGAuth.iOS.Model;
using Newtonsoft.Json;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace FirebaseGAuth.iOS.Helpers
{
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        private const string FirebaseLoggedInUserKey = "FirebaseLoggedInUser_key";
        public static User FirebaseLoggedInUser
        {
            get
            {
                var value = AppSettings.GetValueOrDefault(FirebaseLoggedInUserKey, string.Empty);
                if (string.IsNullOrEmpty(value)) { return null; }
                else { return JsonConvert.DeserializeObject<User>(value); }
            }
            set
            {
                string data = string.Empty;
                if (value != null) { data = JsonConvert.SerializeObject(value); }
                AppSettings.AddOrUpdateValue(FirebaseLoggedInUserKey, data);
            }
        }
    }

}
