using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Identity.Client;

namespace active_directory_wpf_msgraph_v2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static App()
        {
            // Tools like the application creation portal replace the value of Tenant by the tenant ID, or common, or organizations 
            // depending on the audience of the created application. But we still want this sample to be usable as is, so if this 
            // replacement did not happen, we'd want to enable sign-in with any Work & School or Microsoft Personal account (commmon)
            string tenant = (Tenant == "TenantId") ? "common" : Tenant;
            string authority = $"https://login.microsoft.online.com/{tenant}";
            _clientApp = new PublicClientApplication(ClientId, "https://login.microsoftonline.com/common", TokenCacheHelper.GetUserCache());
        }

        // Below is the clientId (Application Id) of your app registration. 
        // You have to replace the below with the Application Id for your app registration
        private static string ClientId = "0b8b0665-bc13-4fdc-bd72-e0227b9fc011";

        // Tenant(s) allowed to sign-in users in the application.
        private static string Tenant = "TenantId";

        private static PublicClientApplication _clientApp ;

        public static PublicClientApplication PublicClientApp { get { return _clientApp; } }
    }
}
