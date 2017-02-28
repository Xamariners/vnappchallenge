using System;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;

namespace AzureMobileApp
{
    public interface IAuthenticate
    {
        Task<bool> Authenticate(int Provider);
    }

    public partial class AzureMobileAppPage : ContentPage
    {
        IMobileServiceTable<myTable> myList;
        string serviceProvider = "";

        int Provider;

        public AzureMobileAppPage()
        {
            InitializeComponent();
        }

        public static IAuthenticate Authenticator { get; private set; }

        public static void Init(IAuthenticate authenticator)
        {
            Authenticator = authenticator;
        }

        //Checks which of the authentication button is clicked.
        private async void OnAdd(object sender, EventArgs e)
        {
            var b = sender as Button;
            bool result = false;
            switch (b.Text.ToString())
            {
            case "Google":
                {
                    Provider = 0;
                    serviceProvider = "Google";
                    result = await Authenticator.Authenticate(Provider);
                    break;
                }
            case "Twitter":
                {
                    Provider = 1;
                    serviceProvider = "Twitter";
                    result = await Authenticator.Authenticate(Provider);
                    break;
                }
            case "Microsoft":
                {
                    Provider = 2;
                    serviceProvider = "Microsoft";
                    result = await Authenticator.Authenticate(Provider);
                    break;
                }
            case "Facebook":
                {
                    Provider = 3;
                    serviceProvider = "Facebook";
                    result = await Authenticator.Authenticate(Provider);
                    break;
                }
            }

            if (result)
            { 
                this.myList = MobileClient.GetInstance().MobileServiceClient.GetTable<myTable>();

                //Get the items from the myTable from your Azure Mobile apps table at Azure
                DisplayList.ItemsSource = await myList.Where(myList => myList.Name == serviceProvider).ToEnumerableAsync();
            }
        }
    }
}
