using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foundation;
using Microsoft.WindowsAzure.MobileServices;
using UIKit;

namespace AzureMobileApp.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate, IAuthenticate
    {
        // Define a authenticated user.
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
                if (user == null)
                {
                    user = await client.LoginAsync(UIApplication.SharedApplication.KeyWindow.RootViewController,
                       ServiceProvider);
                    if (user != null)
                    {
                        message = string.Format("You are now signed-in as {0}.", user.UserId);
                        success = true;
                    }
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            // Display the success or failure message.
            UIAlertView avAlert = new UIAlertView("Sign-in result", message, null, "OK", null);
            avAlert.Show();

            return success;
        }

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            AzureMobileAppPage.Init((IAuthenticate)this);

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
