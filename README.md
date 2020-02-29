# Source Code for Jack Xu's Book

This is example code for the  book "Practical PayPal Integration in ASP.NET Core".

This repository accompanies <a href="https://drxudotnet.com">Practical PayPal Integration in ASP.NET Core</a> by Jack Xu (2020)

Download the file as a zip using the green button, or clone the repository to your machine using GIT.

## Run the Project

To run the projetc, you need to replace teh PayPal ClientId and Secret in the appsettings.json file:

```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*",
  "Paypal": {
    "ApiAppName": "Default Application", 
    "Account": "your business account",
    "ClientID": "your-paypal-clientid",
    "Secret": "your-paypal-secret"
  }
}
```

You can obtain your PayApl ClientID and Secret credentials for the Sandbox account by following teh instruction given in my book. 

## Update

### NuGet Package

I have converted the PayPal Subscriptions .NET SDK implemneted in my book into a NuGet package at https://www.nuget.org/packages/PayPalSubscriptionNetSdk/1.0.0.
You can install it in your .NET or .NET Core applications using the following command:

__PM> Install-Package PayPalSubscriptionNetSdk -Version 1.0.0__

### SDK Repository

I publish a PayPal Subscription .NET SDK repository at GitHub:

https://github.com/jack1232/PayPalSubscription. 

For contributing to this repository, you can fork this repository.
