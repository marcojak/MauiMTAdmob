# MauiMTAdmob

#### Package name: Plugin.MauiMTAdmob
#### Latest version: 1.0.0
#### Nuget link: https://www.nuget.org/packages/Plugin.MauiMTAdmob/
#### Tutorial: https://www.mauiexpert.it/admob-for-maui-made-easy/


If you are looking for the newer version of my plugin for Xamarin, you can visit: [MTAdmob](https://github.com/marcojak/MTAdmob)

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


## Important for Android
if you are receiving some errors about UMP while compiling your projects, add the following code to your csproj file:

	<ItemGroup Condition="'$(TargetFramework)' == 'net6.0-android'">		
		<AndroidLibrary Include="Dependencies\user-messaging-platform-2.0.0.aar" Bind="false" />
	</ItemGroup>

Now, follow these steps:


<ul>
<li>Create a folder "Dependencies" in your project</li>
<li>download the file user-messaging-platform-2.0.0.aar from internet or from this repository.</li>
<li>Copy the file in this folder</li>
<li>Build your project and everything will compile correctly</li>
</ul>
