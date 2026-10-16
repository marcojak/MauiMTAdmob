
# MauiMTAdmob

#### Package name: Plugin.MauiMTAdmob
#### Latest version: 3.0.0 ([what's new](CHANGELOG.md)) - Android on the Google Mobile Ads Next-Gen SDK
#### Previous line: 2.x (legacy Google Mobile Ads SDK on Android), still maintained
#### Nuget link: https://www.nuget.org/packages/Plugin.MauiMTAdmob/
#### Guide: https://hightouchinnovation.com/MMTAdmobGuide
#### To buy the license visit https://hightouchinnovation.com/MMTAdmob


**The licensed version unlocks the mandatory Consent required by Google since the 16th of January. 
If you like, you can use the unlicensed version of the plugin and implement your choice of Certified CMP.
The license will help me to continue updating and supporting this plugin, adding all the newer features that Google implements.**

**App Open Ads and Native Ads are available only in the licensed version**
**The licensed version allows to preload multiple ads and show them when you prefer**


## Requirements
- .NET 10 (version 2.5.0 and later). If you are still on .NET 9, use version 2.4.0.
- iOS 15.4 or later.
- Android 7.0 (API 24) or later for version 3.x; Android 5.0 (API 21) or later for version 2.x.

## Version 3: Google Mobile Ads Next-Gen SDK
From version 3.0, Android runs on Google's [Google Mobile Ads Next-Gen SDK](https://developers.google.com/admob/android/next-gen),
which Google has made the preferred SDK for Android. iOS keeps using the Google Mobile Ads SDK 12.x,
because Google has not released a Next-Gen SDK for iOS.

**The public API is the same as in 2.x.** To update:
1. Update `Plugin.MauiMTAdmob` to 3.0.0.
2. Raise your Android `SupportedOSPlatformVersion` to `24.0` in your app's csproj.
3. Leave your code as it is.

Stay on 2.x if you need Android minSdk below 24, or if you mediate through a platform other than AdMob
(the Next-Gen SDK only supports AdMob mediation). 2.x keeps receiving fixes.

**Licence keys:** a "1 Major Version" licence is valid for the major version it was bought for. A key bought
for 2.x keeps working on every 2.x release but does not unlock the licensed features on 3.x: for those you
need a 3.x key. Perpetual ("Supporter") licences are valid for all versions, including 3.x.

Behaviour differences on Android in 3.x:
- `MTEventArgs.ErrorCode` keeps Google's numeric codes; `ErrorDomain` is now `com.google.android.libraries.ads.mobile.sdk`.
- Interstitials ignore the back key, as the Next-Gen SDK does.
- `AnchoredAdaptive` and `Smart` banners use Google's large anchored adaptive size.
- Ads loaded before the SDK has finished initialising are queued and loaded as soon as it is ready.

See the [changelog](CHANGELOG.md) for the full list.

## Sample
[MMTAdmobS10](MMTAdmobS10) is a complete .NET 10 sample app showing every ad type, consent and App Tracking Transparency.
Its license key only works with the sample's own application ID: replace it with yours.

If you are looking for the Xamarin version of this plugin, you can visit: [MTAdmob](https://github.com/marcojak/MTAdmob)

## Current Status (Version 3.0.0)

|                       | **Android** | **iOS** | **Windows** | **Mac** |
|-----------------------|:-------------:|:---------:|:---------:|:---------:|
| Banner                |     :heavy_check_mark:     |   :heavy_check_mark:      |    :x:  |    :x:  |
| Collapsible Banner    |     :heavy_check_mark:     |   :heavy_check_mark:      |    :x:  |    :x:  |
| Interstitial          |     :heavy_check_mark:     |  :heavy_check_mark:       |    :x:  |    :x:  |
| Rewarded              |    :heavy_check_mark:    |    :heavy_check_mark:     |    :x:  |    :x:  |
| Rewarded Interstitial |   :heavy_check_mark:    |    :heavy_check_mark:  |    :x:  |    :x:  |
| App Open Ads          |     :heavy_check_mark:     |   :heavy_check_mark:      |    :x:  |    :x:  |
| Native Ads            |     :heavy_check_mark:     |  :heavy_check_mark:      |    :x:  |    :x:  |


## Methods
|            **Consent**             |       **Banner**       | **Interstitial**     | **Rewarded**     | **Rewarded Interstitial**  | **App Open Ads**  |
|:----------------------------------:|:----------------------:|--------------------|----------------|--------------------------|--------------------------|
|    InitialiseAndShowConsentForm    |         LoadAd         |   LoadInterstitial   | LoadRewarded     | LoadRewardedInterstitial     | - |
| RequestTrackingAuthorizationAsync* |                        |   ShowInterstitial   | ShowRewarded     | ShowRewardedInterstitial     ||
|  GetTrackingAuthorizationStatus*   |                        | IsInterstitialLoaded | IsRewardedLoaded | IsRewardedInterstitialLoaded ||


## Events
| **Banner**      | **Interstitial**           | **Rewarded**         | **Rewarded Interstitial** | **App Open Ads** | **Native Ads** |
|-----------------|----------------------------|----------------------|---------------------------|------------------|------------------|
| AdsLoaded       | OnInterstitialLoaded       | OnRewardedLoaded     | OnRewardedLoaded          |OnAppOpenAdLoaded|OnNativeAdLoaded|
| AdsFailedToLoad | OnInterstitialFailedToLoad | OnRewardedFailedToLoad| OnRewardedFailedToLoad|OnAppOpenFailedToLoad|OnNativeFailedToLoad|
| AdsImpression   | OnInterstitialImpression   | OnRewardedImpression | OnRewardedImpression |OnAppOpenImpression|OnNativeImpression|
| AdsClicked      | OnInterstitialOpened	   | OnRewardedOpened	  | OnRewardedOpened	  |OnAppOpenOpened|OnNativeOpened|
| AdsOpened		  | OnInterstitialFailedToShow | OnRewardedFailedToShow| OnRewardedFailedToShow|OnAppOpenFailedToShow|OnNativeFailedToShow|
| AdsClosed       | OnInterstitialClosed	   | OnRewardedClosed	  | OnRewardedClosed	  |OnAppOpenClosed|OnNativeClosed|
| AdsSwiped 	  | OnInterstitialClicked*     | OnRewardedClicked*   | OnRewardedClicked*|OnAppOpenClicked|OnNativeClicked|
|  				  | 						   | OnUserEarnedReward   | OnUserEarnedReward||

*Only supported on iOS

## Ad revenue, Ad Inspector, privacy and targeting (3.0.0)
- `OnAdPaid`: impression-level ad revenue for every format (format, ad unit, value, currency, precision, ad source).
- `OpenAdInspector()` and `OnAdInspectorClosed`: open Google's Ad Inspector on a test device.
- `PublisherPrivacyPersonalizationState`: Google's publisher privacy treatment.
- `ContentUrl` and `NeighboringContentUrls`: content mapping sent with every request.
- `CustomTargeting`: key-value targeting sent with every request (Google Ad Manager).

## Native ads
Give the `MTMediaView` in your native ad template at least 120x120: Google requires it for video ads, and the
native ad validator flags anything smaller. In a `Grid` template, avoid `*` rows around the media view, as they
can shrink it below its requested size. The templates in the sample show working layouts.


## Important for iOS

Add your AdMob app ID to your Info.plist:

```xml
<key>GADApplicationIdentifier</key>
<string>YOUR APPLICATION ID</string>
```

To show the App Tracking Transparency dialog (the plugin asks for it after the consent form), also add:

```xml
<key>NSUserTrackingUsageDescription</key>
<string>This identifier will be used to deliver personalized ads to you.</string>
```

Without this key iOS never shows the dialog and tracking is always denied.

### Consent form not showing?
Turn on debug mode (`debugMode: true` in `Init`, or `CrossMauiMTAdmob.Current.DebugMode = true`). The plugin then logs each step of the consent flow, prefixed with `[MauiMTAdmob]`, so you can tell a form that was not required from one that failed.

### Testing on Windows

As the package Xamarin.Google.Mobile.iOS.MobileAds doesn't work on Windows, you need a MAC to test this library.
If you connect your iOS device directly to Windows and run it, the library will not work.
Unfortunately, this issue doesn't depend on this library so I cannot solve this.

If you get an error saying that the compiler cannot find the Init method, just update your MAUI workload to the latest version.
After that, everything will work correctly.


### FOR MAC USERS WITH Mx PROCESSORS

If you compile the app on a Mac with Mx processors, you could get an error about architecture,
to fix it, add to your csproj file these lines:

    <PropertyGroup Condition="$(TargetFramework.Contains('-ios'))">
        <RuntimeIdentifier>iossimulator-x64</RuntimeIdentifier>
    </PropertyGroup>

    <PropertyGroup>
        <ForceSimulatorX64ArchitectureInIDE>true</ForceSimulatorX64ArchitectureInIDE>
    </PropertyGroup>
