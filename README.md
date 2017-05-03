---
services: active-directory
platforms: dotnet
author: jmprieur
---

WPF application signing in users with Microsoft and calling the Microsoft Graph

This simple sample demonstrates how to use MSAL.net to get an access token and call the Microsoft Graph (doing oAuth 2.0 against the AAD v2.0 endpoint).

## Steps to Run

You can get full explaination about this sample, and built it from scratch by going to [Mobile and desktop app guided setup](https://github.com/Microsoft/azure-docs/blob/master/articles/active-directory/develop/GuidedSetups/MobileAndDesktopApp/active-directory-mobileanddesktopapp-windowsdesktop-intro.md)

If you just want to quickly run it, use the following instructions:

1. Register your Azure AD v2.0 (converged) app. 
    - Navigate to the [App Registration Portal](https://identity.microsoft.com). 
    - Go to the the `My Apps` page, click `Add an App`, and name your app.  
    - Set a platform by clicking `Add Platform`, select `Native`.
    - copy to the clipboard your Application Id

2. Clone the code.
  ```
  git clone https://github.com/Azure-Samples/active-directory-dotnet-desktop-msgraph-v2.git
  ```

3. In the `App.xmal.cs` file, set your application/client id copied from the App Registration Portal.

    ``private static string ClientId = "[Application Id pasted from the application registration portal]"``

4. Run the application from Visual Studio (Debug | Start without Debugging)

## Questions and Issues

Please file any questions or problems with the sample as a github issue.  You can also post on StackOverflow with the tag ```azure-active-directory```.  For oAuth2.0 library issues, please see note above. 

## More information

This sample is the result of following the : https://github.com/Azure-Samples/active-directory-javascript-graphapi-web-v2

## Contributing

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.
