using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace AzureMobileApp.Droid
{
    [Activity(Label = "AzureMobileApp.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, IAuthenticate
    {
        private MobileServiceUser user;
        MobileServiceClient client = new MobileServiceClient("https://mobile-85aa742d-c17a-4451-938f-d02d8f8c9eb1.azurewebsites.net");

        public MobileServiceAuthenticationProvider ServiceProvider { get; private set; }

        public async Task<bool> Authenticate(int Provider)
        {
            var success = false;
            var message = string.Empty;

            switch (Provider)
            {
            case 0:
                {
                    ServiceProvider = MobileServiceAuthenticationProvider.Google;
                    break;
                }
            case 1:
                {
                    ServiceProvider = MobileServiceAuthenticationProvider.Twitter;
                    break;
                }
            case 2:
                {
                    ServiceProvider = MobileServiceAuthenticationProvider.MicrosoftAccount;
                    break;
                }
            case 3:
                {
                    ServiceProvider = MobileServiceAuthenticationProvider.Facebook;
                    break;
                }

            }



            try
            {
                // Sign in with Facebook login using a server-managed flow.
                user = await client.LoginAsync(this,
                    ServiceProvider);
                if (user != null)
                {
                    message = string.Format("you are now signed-in as {0}.",
                        user.UserId);
                    success = true;
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            // Display the success or failure message.
            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            builder.SetMessage(message);
            builder.SetTitle("Sign-in result");
            builder.Create().Show();

            return success;
        }

        protected override void OnCreate(Bundle bundle)
        {
            AzureMobileAppPage.Init((IAuthenticate)this);

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            LoadApplication(new App());
        }
    }
}
