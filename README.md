
# MauiMTAdmob

#### Package name: Plugin.MauiMTAdmob
#### Latest version: 2.0.2
#### Nuget link: https://www.nuget.org/packages/Plugin.MauiMTAdmob/
#### Guide: https://hightouchinnovation.com/MMTAdmobGuide
#### To buy the license visit https://hightouchinnovation.com/MMTAdmob


**The licensed version unlocks the mandatory Consent required by Google since the 16th of January. 
If you like, you can use the unlicensed version of the plugin and implement your choice of Certified CMP.
The license will help me to continue updating and supporting this plugin adding all the newer features that Google implements.**

**App Open Ads and Native Ads are available only in the licensed version**
**The licensed version allows to preload multiple ads and show them when you prefer**


If you are looking for the Xamarin version of this plugin, you can visit: [MTAdmob](https://github.com/marcojak/MTAdmob)

## Current Status (Version 2.0.2)

|                       | **Android** | **iOS** | **Windows** | **Mac** |
|-----------------------|:-------------:|:---------:|:---------:|:---------:|
| Banner                |     :heavy_check_mark:     |   :heavy_check_mark:      |    :x:  |    :x:  |
| Collapsible Banner    |     :heavy_check_mark:     |   :heavy_check_mark:      |    :x:  |    :x:  |
| Interstitial          |     :heavy_check_mark:     |  :heavy_check_mark:       |    :x:  |    :x:  |
| Rewarded              |    :heavy_check_mark:    |    :heavy_check_mark:     |    :x:  |    :x:  |
| Rewarded Interstitial |   :heavy_check_mark:    |    :heavy_check_mark:  |    :x:  |    :x:  |
| App Open Ads          |     :heavy_check_mark:     |   :heavy_check_mark:      |    :x:  |    :x:  |
| Native Ads            |     :heavy_check_mark:     |   :x:*      |    :x:  |    :x:  |

* I'm planning to add them in one of the next version, as soon as I fix some issues with the iOS SDK.

## Methods
|           **Consent**           |       **Banner**       | **Interstitial**     | **Rewarded**     | **Rewarded Interstitial**  | **App Open Ads**  |
|:-------------------------------:|:----------------------:|--------------------|----------------|--------------------------|--------------------------|
|               InitialiseAndShowConsentForm                  |         LoadAd         |   LoadInterstitial   | LoadRewarded     | LoadRewardedInterstitial     | - |
|                                 |                        |   ShowInterstitial   | ShowRewarded     | ShowRewardedInterstitial     ||
|                                 |                        | IsInterstitialLoaded | IsRewardedLoaded | IsRewardedInterstitialLoaded ||


## Events
| **Banner**      | **Interstitial**           | **Rewarded**         | **Rewarded Interstitial** | **App Open Ads** | **Native Ads** |
|-----------------|----------------------------|----------------------|---------------------------|------------------|------------------|
| AdsLoaded       | OnInterstitialLoaded       | OnRewardedLoaded     | OnRewardedLoaded          |OnAppOpenAdLoaded|OnNativeAdLoaded|
| AdsFailedToLoad | OnInterstitialFailedToLoad | OnRewardedFailedToLoad| OnRewardedFailedToLoad|OnAppOpenFailedToLoad|OnNativeFailedToLoad|
| AdsImpression   | OnInterstitialImpression   | OnRewardedImpression | OnRewardedImpression |OnAppOpenImpression**|OnNativeImpression**|
| AdsClicked      | OnInterstitialOpened	   | OnRewardedOpened	  | OnRewardedOpened	  |OnAppOpenOpened**|OnNativeOpened**|
| AdsOpened		  | OnInterstitialFailedToShow | OnRewardedFailedToShow| OnRewardedFailedToShow|OnAppOpenFailedToShow**|OnNativeFailedToShow**|
| AdsClosed       | OnInterstitialClosed	   | OnRewardedClosed	  | OnRewardedClosed	  |OnAppOpenClosed**|OnNativeClosed**|
| AdsSwiped 	  | OnInterstitialClicked*     | OnRewardedClicked*   | OnRewardedClicked*|OnAppOpenClicked**|OnNativeClicked**|
|  				  | 						   | OnUserEarnedReward   | OnUserEarnedReward||

*Only supported on iOS

**Currently only working on Android. I plan to add them on iOS in the next version

## Important for iOS

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
