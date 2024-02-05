# MauiMTAdmob

#### Package name: Plugin.MauiMTAdmob
#### Latest version: 1.2.0
#### Nuget link: https://www.nuget.org/packages/Plugin.MauiMTAdmob/
#### Tutorial: https://www.mauiexpert.it/admob-for-maui-made-easy/
#### Guide: https://hightouchinnovation.com/MMTAdmobGuide
#### To buy the license visit https://hightouchinnovation.com/MMTAdmob


**The licensed version unlocks the mandatory Consent required by Google since the 16th of January. 
If you like, you can use the unlicensed version of the plugin and implement your choice of Certified CMP.
The license will help me to continue updating and supporting this plugin adding all the newer features that Google implements.**

If you are looking for the Xamarin version of this plugin, you can visit: [MTAdmob](https://github.com/marcojak/MTAdmob)

## Current Status (Version 1.2.0)

|                       | **Android** | **iOS** | **Windows** | **Mac** |
|-----------------------|:-------------:|:---------:|:---------:|:---------:|
| Banner                |     :heavy_check_mark:     |   :heavy_check_mark:      |    :x:  |    :x:  |
| Interstitial          |     :heavy_check_mark:     |  :heavy_check_mark:       |    :x:  |    :x:  |
| Rewarded              |    :heavy_check_mark:    |    :heavy_check_mark:     |    :x:  |    :x:  |
| Rewarded Interstitial |   :heavy_check_mark:    |    :x:*  |    :x:  |    :x:  |
| App Open Ads          |     :heavy_check_mark:     |   :heavy_check_mark:      |    :x:  |    :x:  |

*They are implemented but currently, they are not working. Probably something in the Admob SDK. I'm investigating it.

## Methods
| **Banner** | **Interstitial**     | **Rewarded**     | **Rewarded Interstitial**  | **App Open Ads**  |
|:----------:|--------------------|----------------|--------------------------|--------------------------|
| LoadAd     | LoadInterstitial     | LoadRewarded     | LoadRewardedInterstitial     | - |
|            | ShowInterstitial     | ShowRewarded     | ShowRewardedInterstitial     ||
|            | IsInterstitialLoaded | IsRewardedLoaded | IsRewardedInterstitialLoaded ||


## Events
| **Banner**      | **Interstitial**           | **Rewarded**         | **Rewarded Interstitial** | **App Open Ads** |
|-----------------|----------------------------|----------------------|---------------------------|------------------|
| AdsLoaded       | OnInterstitialLoaded       | OnRewardedLoaded     | OnRewardedLoaded          |OnAppOpenAdLoaded|
| AdsFailedToLoad | OnInterstitialFailedToLoad | OnRewardedFailedToLoad| OnRewardedFailedToLoad|OnAppOpenFailedToLoad|
| AdsImpression   | OnInterstitialImpression   | OnRewardedImpression | OnRewardedImpression |OnAppOpenImpression**|
| AdsClicked      | OnInterstitialOpened	   | OnRewardedOpened	  | OnRewardedOpened	  |OnAppOpenOpened**|
| AdsOpened		  | OnInterstitialFailedToShow | OnRewardedFailedToShow| OnRewardedFailedToShow|OnAppOpenFailedToShow**|
| AdsClosed       | OnInterstitialClosed	   | OnRewardedClosed	  | OnRewardedClosed	  |OnAppOpenClosed**|
| AdsSwiped 	  | OnInterstitialClicked*     | OnRewardedClicked*   | OnRewardedClicked*|OnAppOpenClicked**|
|  				  | 						   | OnUserEarnedReward   | OnUserEarnedReward||

*Only supported on iOS

**Currently only working on Android. I plan to add them on iOS in the next version

## Important for iOS

## Xamarin.Firebase.iOS.Core 8.10.0.1

If you encounter this error while using this plugin, you can solve it following this comment: https://github.com/xamarin/GoogleApisForiOSComponents/issues/555#issuecomment-1145943195
