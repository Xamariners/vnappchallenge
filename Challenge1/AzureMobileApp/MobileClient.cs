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

        public static string ApplicationURL = @"http://vnlala.azurewebsites.net";
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
