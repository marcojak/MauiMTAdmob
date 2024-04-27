
# MauiMTAdmob

#### Package name: Plugin.MauiMTAdmob
#### Latest version: 1.4.2
#### Nuget link: https://www.nuget.org/packages/Plugin.MauiMTAdmob/
#### Guide: https://hightouchinnovation.com/MMTAdmobGuide
#### To buy the license visit https://hightouchinnovation.com/MMTAdmob


**The licensed version unlocks the mandatory Consent required by Google since the 16th of January. 
If you like, you can use the unlicensed version of the plugin and implement your choice of Certified CMP.
The license will help me to continue updating and supporting this plugin adding all the newer features that Google implements.**

**App Onen Ads and Native Ads are available only in the licensed version**


If you are looking for the Xamarin version of this plugin, you can visit: [MTAdmob](https://github.com/marcojak/MTAdmob)

## Current Status (Version 1.4.2)

|                       | **Android** | **iOS** | **Windows** | **Mac** |
|-----------------------|:-------------:|:---------:|:---------:|:---------:|
| Banner                |     :heavy_check_mark:     |   :heavy_check_mark:      |    :x:  |    :x:  |
| Interstitial          |     :heavy_check_mark:     |  :heavy_check_mark:       |    :x:  |    :x:  |
| Rewarded              |    :heavy_check_mark:    |    :heavy_check_mark:     |    :x:  |    :x:  |
| Rewarded Interstitial |   :heavy_check_mark:    |    :x:*  |    :x:  |    :x:  |
| App Open Ads          |     :heavy_check_mark:     |   :heavy_check_mark:      |    :x:  |    :x:  |
| Native Ads          |     :heavy_check_mark:     |   :x:**      |    :x:  |    :x:  |

*They are implemented but currently, they are not working. Probably something in the Admob SDK. I'm investigating it.

** I'm planning to add them in one of the next version, as soon as I fix some issues with the iOS SDK.

## Methods
| **Banner** | **Interstitial**     | **Rewarded**     | **Rewarded Interstitial**  | **App Open Ads**  |
|:----------:|--------------------|----------------|--------------------------|--------------------------|
| LoadAd     | LoadInterstitial     | LoadRewarded     | LoadRewardedInterstitial     | - |
|            | ShowInterstitial     | ShowRewarded     | ShowRewardedInterstitial     ||
|            | IsInterstitialLoaded | IsRewardedLoaded | IsRewardedInterstitialLoaded ||


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
