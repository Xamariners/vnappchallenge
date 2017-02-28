using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using HockeyApp.Android;

namespace Challenge3.Droid
{


    [Activity(Label = "Challenge3", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {

	public const string HOCKEYAPP_APPID = "03968411b9b74dd385e9a92fcd3612ae";

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

			CrashManager.Register(this, HOCKEYAPP_APPID);


            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());

			var bob = 0;
			var x = 0 / bob;
        }
    }
}

