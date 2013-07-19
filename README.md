RdioSdkBindings
===============

C# bindings for the Rdio SDKs (Android supported, iOS supported)

Usage
-----

### Android
Just add the Rdio.Android.csproj to your Xamarin.Android project and add a reference to Rdio.Android.

### iOS
Just add the RdioSdk.iOS.csproj or RdioSdk.iOS.dll to your Xamarin.iOS project and add a reference to RdioSdk.iOS.

Also a simple sample demoing RdioSdk.iOS its included.

Android
-------
The C# namespaces for the Android SDK are `Rdio.Android.Sdk` and `Rdio.Android.Sdk.Services`. Also note
that the main `Rdio` class has been renamed to `RdioAPI`.


iOS
---

The C# namespace for the iOS SDK is `RdioSdk.iOS`. 
Also note that some class names have been renamed

* `RDAPIRequestDelegate` (Protocol) => `RequestDelegateHandlers`
* `RDAPIRequestDelegate` (Object) => `RequestDelegate`
* `RDAPIRequest` => `Request`
* `RDPlayerDelegate` => `PlayerDelegate`
* `RDPlayer` => `Player`

Authors
=======

* Brett Duncavage
* Alex Soto

