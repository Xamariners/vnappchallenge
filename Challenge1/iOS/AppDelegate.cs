using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foundation;
using UIKit;

namespace AzureMobileApp.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate, IAuthenticate
    {
        public Task<bool> Authenticate(int Provider)
        {
            throw new NotImplementedException();
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
