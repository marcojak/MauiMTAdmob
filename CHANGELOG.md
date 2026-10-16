# Changelog

Release notes for [Plugin.MauiMTAdmob](https://www.nuget.org/packages/Plugin.MauiMTAdmob/).

## 3.0.0

Android moves to Google's [Mobile Ads Next-Gen SDK](https://developers.google.com/admob/android/next-gen). The public API is unchanged: update the package, raise your Android `SupportedOSPlatformVersion` to `24.0`, and keep your code as it is. The 2.x line, on the legacy SDK, is still maintained for apps that cannot move yet.

- Android: Google Mobile Ads Next-Gen SDK 1.4.0, through Microsoft's binding `Xamarin.Google.Android.Libraries.Ads.Mobile.Sdk`, replaces `Xamarin.GooglePlayServices.Ads.Lite`.
- Android minSdk is now 24 (was 21), as the Next-Gen SDK requires.
- iOS is unchanged: Google Mobile Ads SDK 12.12.0. Google has not released a Next-Gen SDK for iOS.
- New (Android and iOS): `OnAdPaid` (impression-level ad revenue for every format), `OpenAdInspector()` and `OnAdInspectorClosed`, `PublisherPrivacyPersonalizationState`, `ContentUrl` / `NeighboringContentUrls` and `CustomTargeting`.
- Fixed (Android): native ads now resize to their template, so assets no longer spill outside the native ad view (the native ad validator reported "assets outside native ad view" and "MediaView too small").
- Android: `Load*`, `SetAppMuted`, `SetAppVolume` and `OpenAdInspector` called before the SDK has finished initialising are queued instead of failing.
- Android: the request configuration (test devices, content rating, child-directed / under-age tags) applies from the first request. The child-directed and under-age tags are mapped to the Next-Gen age treatment as Google documents.
- Android: `ErrorCode` keeps Google's numeric codes (3 = no fill, ...); `ErrorDomain` is now `com.google.android.libraries.ads.mobile.sdk`.
- Android banners: destroyed when removed, as Google requires; refreshes raise `AdsLoaded` and update the height; `AnchoredAdaptive` and `Smart` use Google's large anchored adaptive size.
- Android native ads are destroyed when replaced or when their view is removed.
- Android interstitials ignore the back key (Next-Gen SDK behaviour).
- Only AdMob mediation is supported on Android. Stay on 2.x if you mediate through another platform or need minSdk below 24.
- Licensing: a "1 Major Version" licence key bought for 2.x does not unlock the licensed features on 3.x; you need a 3.x key. Perpetual ("Supporter") licences are valid for all versions.

## 2.6.0

Release of the 2.x line, which keeps Android on the legacy Google Mobile Ads SDK (minSdk 21). Version 3.x moves Android to the Next-Gen SDK with the same API.

- New (Android and iOS): `OnAdPaid`, impression-level ad revenue for banners, interstitials, rewarded, rewarded interstitial, app open and native ads (format, ad unit, value, currency, precision, ad source, response id).
- New: `OpenAdInspector()` and `OnAdInspectorClosed`, to open Google's Ad Inspector and debug requests and mediation.
- New: `PublisherPrivacyPersonalizationState` (Google's publisher privacy treatment), `ContentUrl` and `NeighboringContentUrls` (content mapping) and `CustomTargeting` (key-value targeting for Google Ad Manager).
- Fixed (Android): native ads now resize to their template, so assets no longer spill outside the native ad view (the native ad validator reported "assets outside native ad view" and "MediaView too small").
- Fixed (iOS): App Open Ads now load when `SkipConsent` is set.
- The XML documentation is now named after the assembly, so IntelliSense shows it.
- Licensing: a "1 Major Version" licence key is valid only for the major version it was issued for, without the previous one-year grace for keys from an earlier major version. 2.x keys keep working on 2.6.0; perpetual licences are valid for all versions.

## 2.5.1

iOS consent and App Tracking Transparency fixes (licensed version):

- Fixed the consent form never appearing, and ads never starting, when consent was requested at launch before the app window existed. The plugin now waits up to 5 seconds for the window; if there is still none, ads start anyway when consent allows it.
- The App Tracking Transparency dialog is now requested only once the app is active, because iOS silently ignores earlier requests. If iOS still skips it, it is asked again the next time the app becomes active; ads do not wait for it.
- If NSUserTrackingUsageDescription is missing from Info.plist, the plugin now logs it instead of failing silently (without it iOS never shows the tracking dialog).
- With DebugMode enabled, each step of the consent flow is logged (consent status, form status, whether ads can be requested).

## 2.5.0

- Removed support for .NET 9: the package now targets .NET 10 only
- Fixed OnNativeAdLoaded being raised before the ad was available
- Native ads older than one hour are discarded before showing, as required by Google
- ShowInterstitial, ShowRewarded, ShowRewardInterstitial and the Ad Manager Show methods can now be called from a background thread
- iOS: an ad that can no longer be presented now raises OnInterstitialFailedToShow / OnRewardedFailedToShow and is removed from the queue
- Fixed banner handlers never being released (memory leak) and banners now release their native view when removed
- Android: the Load methods (interstitial, rewarded, rewarded interstitial, Ad Manager, native) can now be called from a background thread instead of throwing "Must be called on the main UI thread"
- Android: Ad Manager banners now use the control's BannerMode instead of always the global DefaultBannerMode
- Android: Init can be called again when MainActivity is recreated; the plugin follows the new activity instead of starting over
- Android: OnResume no longer throws when called before Init

## 2.4.0

- Added Google Ads Manager implementation on iOS
- Updated Xamarin.GooglePlayServices.Ads.Lite to version 124.0.0.4 (Android)
- Updated Xamarin.Google.UserMessagingPlatform to version 4.0.0.2 (Android)

## 2.3.1

- Added possibility to manually call the iOS tracking authorization request (licensed version only).
- Added GetTrackingAuthorizationStatus() method to get ATT status on iOS
- Fixed GetSdkVersion() method to properly format GADVersionNumber on iOS
- Fixed SetAppMuted() and SetAppVolume() methods for iOS

## 2.3.0

- Added support for .NET 10
- Fixed an issue preventing to disable the automatic plugin initialization on iOS
- Minor improvements

## 2.2.0

- Updated native iOS bindings to version 12.12 to fix crashes on iOS
- Fixed an issue with Rewarded Interstitial on iOS that was preventing to receiving the UserEarnedReward event

## 2.1.0

- Renamed MauiMTAdmob to MauiMtAdmob (BREAKING CHANGE)
- Added support for Native Ads on iOS
- Added ATTrackingManager request (licensed version) - Remember to add `NSUserTrackingUsageDescription` to your Info.plist
- Updated to support new version of MTAdmob.iOS.Binding (12.9.0)
- Updated to support new version of MTAdmob.UMP.iOS.Binding (3.0.0)
- Added support for new version of Xamarin.GooglePlayServices.Ads.Lite (124.0.0.3)
- Added support for new version of Xamarin.Google.UserMessagingPlatform (3.2.0.3)
- Removed support for .Net8

## 2.0.2

- Updated to support new version of MTAdmob.iOS.Binding (11.2.0.3) to reduce the length of the binding path that was causing compilation issues on iOS
- Updated to support new version of MTAdmob.UMP.iOS.Binding (2.7.0.2) to reduce the length of the binding path that was causing compilation issues on iOS
- Breaking changes: Now the Init and InitialiseConsent methods on iOS accepts an array of strings for test devices rather than a single test device ID.

## 2.0.1

- Updated Xamarin.GooglePlayServices.Ads.Lite to version 124.0.0.1
- Updated Xamarin.Google.UserMessagingPlatform to version 3.2.0.1
- Fixed crash happening on iOS with Rewarded ads

## 2.0.0

- This version now uses a new custom binding library for iOS
- Added DebugMode property to show/hide logs during development. The property is set to false by default. You can change it in the Init method.
- Removed Obsolete from UserPersonalizedAds property
- Added the banner AdSwipeGestureClicked event on Android
- Removed the banner AdLeftApplication event on Android
- Removed OnRewardedVideoAdCompleted event on iOS
- Renamed property AdsId to BannerAdsId
- Updated DebugGeography enum
- Refactored most of the code to improve performance and stability

## 1.7.2

- Updated Xamarin.GooglePlayServices.Ads to version 123.6.0 (Android)

## 1.7.1

- Added .Net8 and .Net9 as TargetFrameworks

## 1.7.0

- Added support for .NET 9
- Updated Xamarin.GooglePlayServices.Ads.Lite to version 123.4.0 (Android)
- Added support for Ad Manager: Banner, Native, Interstitial, Rewarded, Rewarded interstitial (Android, licensed version)
- Added UseAdManagerForNativeAds property to use Ad Manager for Native Ads
- Use SkipConsent as workaround to solve issue with UMP and .Net9
- Minor improvements

## 1.6.4

- Minor improvements
- Updated Xamarin.GooglePlayServices.Ads.Lite to version 123.1.0.1 (Android)
- Updated Xamarin.Google.UserMessagingPlatform to version 3.0.0.1 (Android)

## 1.6.3

- AdLoaded and AdFailedToLoad events are now properly registered on iOS

## 1.6.2

- Fixed Server Side Verification on both Android and iOS

## 1.6.1

- Updated Xamarin.GooglePlayServices.Ads.Lite to version 123.1.0 (Android)
- Fixed bug on iOS

## 1.6.0

- Updated Xamarin.GooglePlayServices.Ads.Lite to version 123.0.0 (Android)

## 1.5.1

- Added property SkipConsent to skip the consent form. (Set it before Initialising the plugin)

## 1.5.0

- Fixed issue preventing consent form to be shown on iOS in some cases
- Fixed a possible crash on iOS when registering the events
- Improved code for both Android and iOS

## 1.4.5

- Added support for new MAUI Multi project format
- Minor improvements

## 1.4.4

- Added back support for Windows projects

## 1.4.3

- Added collapsible banners for Android (licensed version)
- Added possibility to manually load the consent form (licensed version)
- Minor code improvements
- Updated Xamarin.GooglePlayServices.Ads.Lite to version="122.3.0.3" (Android)
- Updated Xamarin.Google.UserMessagingPlatform to version="2.1.0.3" (Android)

## 1.4.2

- Fixed an issue on iOS that caused the plugin to crash when it's not possible to complete an Ad Request

## 1.4.1

- Minor update

## 1.4.0

- The licensed version now allows to load and cache multiple ads and show them as needed.
- Several new methods have been added to the plugin to allow you to manage the ads in a more flexible way.

## 1.3.3

- Fixed bug on iOS where Rewarded ads were loaded only once

## 1.3.2

- Fixed possible crash when Loading a banner

## 1.3.1

- Improved automatic loading of banners

## 1.3.0

- Added PREVIEW support for Native Ads on Android (iOS will be added soon) (LICENSED VERSION ONLY)
- Added automatic loading of banners
- Added properties IsPluginInitialised and IsMobileAdsReady
- Minor code improvements

## 1.2.1

- Added support for .Net7
- Added event OnMobileAdsInitialized

## 1.2.0

- Added support for Open Ads on both Android and iOS

## 1.1.3

- Fixed crash that might happen on iOS simulator

## 1.1.2

- Fixed issue with ARM64

## 1.1.1

- Fixed issue with Xamarin.Build.Download
- Replaced problematic iOS.UserMessagingPlatform with custom one

## 1.1.0

- Support for .Net8
- Added UMP support for mandatory consent for EU users (available only in the licensed version)
- Updated Xamarin.GooglePlayServices.Ads.Lite to 122.3.0.2

## 1.0.4

- Added support for .Net6

## 1.0.3

- Solved crash showing banners on iOS
- Updated Xamarin.GooglePlayServices.Ads.Lite to 121.4.0

## 1.0.2

- Fixed issue with interstitials on iOS
- Added code to avoid compatibility problems with Windows (this platforms is still not supported as Admob is not available here.)

## 1.0.1

- Added user-messaging-platform-2.0.0 for Android

## 1.0.0

- First version supporting MAUI
