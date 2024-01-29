# MauiMTAdmob

#### Package name: Plugin.MauiMTAdmob
#### Latest version: 1.1.1
#### Nuget link: https://www.nuget.org/packages/Plugin.MauiMTAdmob/
#### Tutorial: https://www.mauiexpert.it/admob-for-maui-made-easy/
#### Guide: https://hightouchinnovation.com/MMTAdmobGuide
#### To buy the license visit https://hightouchinnovation.com/MMTAdmob


**The licensed version unlocks the mandatory Consent required by Google since the 16th of January. 
If you like, you can use the unlicensed version of the plugin and implement your choice of Certified CMP.
The license will help me to continue updating and supporting this plugin adding all the newer features that Google implements.**

If you are looking for the Xamarin version of this plugin, you can visit: [MTAdmob](https://github.com/marcojak/MTAdmob)

## Current Status (Version 1.1.1)

|                       | **Android** | **iOS** | **Windows** | **Mac** |
|-----------------------|:-------------:|:---------:|:---------:|:---------:|
| Banner                |     :heavy_check_mark:     |   :heavy_check_mark:      |    :x:  |    :x:  |
| Interstitial          |     :heavy_check_mark:     |  :heavy_check_mark:       |    :x:  |    :x:  |
| Rewarded              |    :heavy_check_mark:    |    :heavy_check_mark:     |    :x:  |    :x:  |
| Rewarded Interstitial |   :heavy_check_mark:    |    :x:*  |    :x:  |    :x:  |

*They are implemented but currently, they are not working. Probably something in the Admob SDK. I'm investigating it.

## Methods
| **Banner** | **Interstitial**     | **Rewarded**     | **Rewarded Interstitial**  |
|:----------:|--------------------|----------------|--------------------------|
| LoadAd     | LoadInterstitial     | LoadRewarded     | LoadRewardedInterstitial     |
|            | ShowInterstitial     | ShowRewarded     | ShowRewardedInterstitial     |
|            | IsInterstitialLoaded | IsRewardedLoaded | IsRewardedInterstitialLoaded |


## Events
| **Banner**      | **Interstitial**           | **Rewarded**         | **Rewarded Interstitial** |
|-----------------|----------------------------|----------------------|---------------------------|
| AdsLoaded       | OnInterstitialLoaded       | OnRewardedLoaded     | OnRewardedLoaded          |
| AdsFailedToLoad | OnInterstitialFailedToLoad | OnRewardedFailedToLoad| OnRewardedFailedToLoad|
| AdsImpression   | OnInterstitialImpression   | OnRewardedImpression | OnRewardedImpression |
| AdsClicked      | OnInterstitialOpened	   | OnRewardedOpened	  | OnRewardedOpened	  |
| AdsOpened		  | OnInterstitialFailedToShow | OnRewardedFailedToShow| OnRewardedFailedToShow|
| AdsClosed       | OnInterstitialClosed	   | OnRewardedClosed	  | OnRewardedClosed	  |
| AdsSwiped 	  | OnInterstitialClicked*     | OnRewardedClicked*   | OnRewardedClicked*|
|  				  | 						   | OnUserEarnedReward   | OnUserEarnedReward|

*Only supported on iOS

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

This might not be required anymore since version 1.0.1

## Xamarin.Firebase.iOS.Core 8.10.0.1

If you encounter this error while using this plugin, you can solve it following this comment: https://github.com/xamarin/GoogleApisForiOSComponents/issues/555#issuecomment-1145943195
