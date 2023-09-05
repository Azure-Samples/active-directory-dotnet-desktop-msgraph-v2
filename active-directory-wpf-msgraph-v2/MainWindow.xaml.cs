using Microsoft.Identity.Client;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;

namespace active_directory_wpf_msgraph_v2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        //Set the API Endpoint to Graph 'me' endpoint. 
        // To change from Microsoft public cloud to a national cloud, use another value of graphAPIEndpoint.
        // Reference with Graph endpoints here: https://docs.microsoft.com/graph/deployments#microsoft-graph-and-graph-explorer-service-root-endpoints
        string graphAPIEndpoint = "https://graph.microsoft.com/v1.0/me";



        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Call AcquireToken - to acquire a token requiring user to sign-in
        /// </summary>
        private async void CallGraphButton_Click(object sender, RoutedEventArgs e)
        {
            AuthenticationResult authResult = null;
            var app = App.PublicClientApp;
            ResultText.Text = string.Empty;
            TokenInfoText.Text = string.Empty;

            // if the user signed-in before, remember the account info from the cache
            IAccount firstAccount = (await app.GetAccountsAsync()).FirstOrDefault();

            //Set the scope for API call to user.read
            string[] graphScope = new string[] { "user.read" };
            string[] sharepointScope = new string[] { "https://microsoft.sharepoint.com/Sites.Search.All" };


            try
            {
                // 1.Try to get a token (silently) for Graph
                authResult = await app.AcquireTokenSilent(graphScope, firstAccount)
                    .ExecuteAsync();
            }
            catch (MsalUiRequiredException ex)
            {
                // 2. If it fails for whatever reason, make sure to use .WithExtraScopesToConsent(sharepointScope)
                authResult = await app.AcquireTokenInteractive(graphScope)
                    .WithAccount(firstAccount)
                    .WithParentActivityOrWindow(new WindowInteropHelper(this).Handle) 
                    .WithPrompt(Prompt.SelectAccount)
                    .WithExtraScopesToConsent(sharepointScope)
                    .ExecuteAsync();
            }

            // 3. at this point we should have a refresh token for the user, and we can use it to get a token for the SharePoint API
            try
            {
                
                authResult = await app.AcquireTokenSilent(sharepointScope, authResult.Account)
                    .ExecuteAsync();
            }
            // it's possible that this will fail, for example if MFA is needed for Sharepoint. So always make sure to fallback to interactive
            catch (MsalUiRequiredException ex)
            {
                authResult = await app.AcquireTokenInteractive(sharepointScope)
                    .WithAccount(authResult.Account)
                    .WithParentActivityOrWindow(new WindowInteropHelper(this).Handle)
                    .WithPrompt(Prompt.SelectAccount)
                    .WithExtraScopesToConsent(sharepointScope)
                    .ExecuteAsync();
            }

        }

        /// <summary>
        /// Perform an HTTP GET request to a URL using an HTTP Authorization header
        /// </summary>
        /// <param name="url">The URL</param>
        /// <param name="token">The token</param>
        /// <returns>String containing the results of the GET operation</returns>
        public async Task<string> GetHttpContentWithToken(string url, string token)
        {
            var httpClient = new System.Net.Http.HttpClient();
            System.Net.Http.HttpResponseMessage response;
            try
            {
                var request = new System.Net.Http.HttpRequestMessage(System.Net.Http.HttpMethod.Get, url);
                //Add the token in Authorization header
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                response = await httpClient.SendAsync(request);
                var content = await response.Content.ReadAsStringAsync();
                return content;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        /// <summary>
        /// Sign out the current user
        /// </summary>
        private async void SignOutButton_Click(object sender, RoutedEventArgs e)
        {
            var accounts = await App.PublicClientApp.GetAccountsAsync();
            if (accounts.Any())
            {
                try
                {
                    await App.PublicClientApp.RemoveAsync(accounts.FirstOrDefault());
                    this.ResultText.Text = "User has signed-out";
                    this.CallGraphButton.Visibility = Visibility.Visible;
                    this.SignOutButton.Visibility = Visibility.Collapsed;
                }
                catch (MsalException ex)
                {
                    ResultText.Text = $"Error signing-out user: {ex.Message}";
                }
            }
        }

        /// <summary>
        /// Display basic information contained in the token
        /// </summary>
        private void DisplayBasicTokenInfo(AuthenticationResult authResult)
        {
            TokenInfoText.Text = "";
            if (authResult != null)
            {
                TokenInfoText.Text += $"Username: {authResult.Account.Username}" + Environment.NewLine;
                TokenInfoText.Text += $"Token Expires: {authResult.ExpiresOn.ToLocalTime()}" + Environment.NewLine;
            }
        }
    }
}
