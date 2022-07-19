# MauiMTAdmob

#### Package name: Plugin.MauiMTAdmob
#### Latest version: 1.0.0
#### Nuget link: https://www.nuget.org/packages/Plugin.MauiMTAdmob/

## Current Status

|                       | **Android** | **iOS** | **Windows** | **Mac** |
|-----------------------|:-------------:|:---------:|:---------:|:---------:|
| Banner                |     :heavy_check_mark:     |   :heavy_check_mark:      |    :x:  |    :x:  |
| Interstitial          |     :heavy_check_mark:     |  :heavy_check_mark:       |    :x:  |    :x:  |
| Rewarded              |    :heavy_check_mark:    |    :heavy_check_mark:     |    :x:  |    :x:  |
| Rewarded Interstitial |   :heavy_check_mark:    |    :x:  |    :x:  |    :x:  |


## Methods
| **Banner** | **Interstitial**     | **Rewarded**     | **Rewarded Interstitial**  |
|:----------:|--------------------|----------------|--------------------------|
| LoadAd     | LoadInterstitial     | LoadRewarded     | LoadRewardInterstitial     |
|            | ShowInterstitial     | ShowRewarded     | ShowRewardInterstitial     |
|            | IsInterstitialLoaded | IsRewardedLoaded | IsRewardInterstitialLoaded |


## Events
| **Banner**      | **Interstitial**           | **Rewarded**         | **Rewarded Interstitial** |
|-----------------|----------------------------|----------------------|---------------------------|
| AdsClicked      | OnInterstitialLoaded       | OnRewardedLoaded     | OnRewardedLoaded          |
| AdsClosed       | OnInterstitialOpened       | OnRewardedOpened     | OnRewardedOpened          |
| AdsFailedToLoad | OnInterstitialClosed       | OnRewardedClosed     | OnRewardedClosed          |
| AdsImpression   | OnInterstitialFailedToLoad | OnRewardedImpression | OnRewardedImpression      |
| AdsLoaded       | OnInterstitialFailedToShow | OnUserEarnedReward   | OnUserEarnedReward        |
| AdsOpened       | OnInterstitialClicked      | OnRewardedClicked    | OnRewardedClicked         |
|                 | OnInterstitialImpression   |  |       |
