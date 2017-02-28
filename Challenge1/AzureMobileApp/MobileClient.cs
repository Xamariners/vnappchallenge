using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureMobileApp
{
    using Microsoft.WindowsAzure.MobileServices;

    public class MobileClient
    {

        public static string ApplicationURL = @"https://mobile-85aa742d-c17a-4451-938f-d02d8f8c9eb1.azurewebsites.net";
        MobileServiceClient _client;

        private static MobileClient _mobileClient;

        static MobileClient()
        {
             _mobileClient = new MobileClient();
        }

        public MobileClient()
        {
            _client = new MobileServiceClient(ApplicationURL);
        }

        public static MobileClient GetInstance()
        {
            return _mobileClient;
        }

        public MobileServiceClient MobileServiceClient
        {
            get
            {
                return this._client;
                
            }
        }
    }
}
