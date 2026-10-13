
# MauiMTAdmob

#### Package name: Plugin.MauiMTAdmob
#### Latest version: 2.5.1 ([what's new](CHANGELOG.md))
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
- Android and iOS (iOS 15.4 or later).

## Sample
[MMTAdmobS10](MMTAdmobS10) is a complete .NET 10 sample app showing every ad type, consent and App Tracking Transparency.
Its license key only works with the sample's own application ID: replace it with yours.

If you are looking for the Xamarin version of this plugin, you can visit: [MTAdmob](https://github.com/marcojak/MTAdmob)

## Current Status (Version 2.5.1)

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
