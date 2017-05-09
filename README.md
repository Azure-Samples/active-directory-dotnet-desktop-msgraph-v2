---
services: active-directory
platforms: dotnet
author: jmprieur
---


# WPF application signing in users with Microsoft and calling the Microsoft Graph

| [Getting Started](https://apps.dev.microsoft.com/portal/register-app)| [Library](https://github.com/AzureAD/microsoft-authentication-library-for-dotnet) | [Docs](https://aka.ms/aaddev) | [Support](README.md#community-help-and-support) 
| --- | --- | --- | --- |

This simple sample demonstrates how to use the [Microsoft Authentication Library (MSAL) for .NET](https://github.com/AzureAD/microsoft-authentication-library-for-dotnet) to get an access token and call the Microsoft Graph (using OAuth 2.0 against the Azure AD v2.0 endpoint).

## Steps to Run

You can get full explaination about this sample, and build it from scratch by going to [Windows desktop .NET guided walkthrough](https://docs.microsoft.com/azure/active-directory/develop/guidedsetups/active-directory-mobileanddesktopapp-windowsdesktop-intro).

If you just want to quickly run it, use the following instructions:

1. Register an Azure AD v2.0 (converged) app. 
    - Navigate to the [App Registration Portal](https://identity.microsoft.com). 
    - Go to the the `My Apps` page, click `Add an App`, and name your app.  
    - Set a platform by clicking `Add Platform`, select `Native`.
    - Copy to the clipboard your Application Id

2. Clone the code.
  ```
  git clone https://github.com/Azure-Samples/active-directory-dotnet-desktop-msgraph-v2.git
  ```

3. In the `App.xaml.cs` file, set your application/client id copied from the App Registration Portal.

    ``private static string ClientId = "[Application Id pasted from the application registration portal]"``

4. Run the application from Visual Studio (Debug | Start without Debugging)

## Community Help and Support

We use [Stack Overflow](http://stackoverflow.com/questions/tagged/msal) with the community to provide support. We highly recommend you ask your questions on Stack Overflow first and browse existing issues to see if someone has asked your question before. Make sure that your questions or comments are tagged with [msal.dotnet].

If you find and bug in the sample please raise the issue on [GitHub Issues](../../issues).

If you find a bug in msal.Net, please raise the issue on [MSAL.NET GitHub Issues](https://github.com/AzureAD/microsoft-authentication-library-for-dotnet/issues).

To provide a recommendation, visit our [User Voice page](https://feedback.azure.com/forums/169401-azure-active-directory).

## Contributing

If you'd like to contribute to this sample, see [CONTRIBUTING.MD](/CONTRIBUTING.md).

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.
