using Plugin.MauiMTAdmob;
using Plugin.MauiMTAdmob.Extra;
using System.Diagnostics;

namespace MMTAdmobSample
{
    public partial class MainPage : ContentPage
    {
        private bool _shouldSetEvents = true;
        public string INTERSTITIALID = DeviceInfo.Platform == DevicePlatform.Android ? "ca-app-pub-3940256099942544/1033173712" : "ca-app-pub-3940256099942544/1033173712";
        public string REWARDEDID = DeviceInfo.Platform == DevicePlatform.Android ? "ca-app-pub-3940256099942544/5224354917" : "ca-app-pub-3940256099942544/5224354917";
        public string REWARDINTERSTITIALID = DeviceInfo.Platform == DevicePlatform.Android ? "ca-app-pub-3940256099942544/5354046379" : "ca-app-pub-3940256099942544/5354046379";

        public MainPage()
        {
            InitializeComponent();

            CrossMauiMTAdmob.Current.TestDevices = new List<string> { "C44999673C1A6EDCE0DA791B8E5436C1" };

            CrossMauiMTAdmob.Current.TagForChildDirectedTreatment = MTTagForChildDirectedTreatment.TagForChildDirectedTreatmentUnspecified;
            CrossMauiMTAdmob.Current.TagForUnderAgeOfConsent = MTTagForUnderAgeOfConsent.TagForUnderAgeOfConsentUnspecified;
            CrossMauiMTAdmob.Current.MaxAdContentRating = MTMaxAdContentRating.MaxAdContentRatingG;
            CrossMauiMTAdmob.Current.AdChoicesCorner = AdChoicesCorner.ADCHOICES_BOTTOM_RIGHT;
            CrossMauiMTAdmob.Current.MaximumNumberOfAdsCached = 3;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            SetEvents();
            if (CrossMauiMTAdmob.Current.IsLicensed)
                LabelLicense.Text = "Licensed";
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            DisableEvents();
        }

        void SetEvents()
        {
            if (_shouldSetEvents)
            {
                _shouldSetEvents = false;
                CrossMauiMTAdmob.Current.OnRewardedLoaded += Current_OnRewardedAdLoaded;
                CrossMauiMTAdmob.Current.OnRewardedFailedToLoad += Current_OnRewardedAdFailedToLoad;
                CrossMauiMTAdmob.Current.OnRewardedFailedToShow += Current_OnRewardFailedToShow;
                CrossMauiMTAdmob.Current.OnRewardedOpened += Current_OnRewardOpened;
                CrossMauiMTAdmob.Current.OnRewardedClosed += Current_OnRewardClosed;
                CrossMauiMTAdmob.Current.OnRewardedImpression += Current_OnRewardImpression;

                CrossMauiMTAdmob.Current.OnUserEarnedReward += Current_OnUserEarnedReward;

                CrossMauiMTAdmob.Current.OnInterstitialLoaded += Current_OnInterstitialLoaded;
                CrossMauiMTAdmob.Current.OnInterstitialFailedToLoad += Current_OnInterstitialFailedToLoad;
                CrossMauiMTAdmob.Current.OnInterstitialFailedToShow += Current_OnInterstitialFailedToShow;
                CrossMauiMTAdmob.Current.OnInterstitialOpened += Current_OnInterstitialOpened;
                CrossMauiMTAdmob.Current.OnInterstitialClosed += Current_OnInterstitialClosed;

                CrossMauiMTAdmob.Current.OnAppOpenAdLoaded += Current_OnAppOpenAdLoaded;
                CrossMauiMTAdmob.Current.OnAppOpenOpened += Current_OnAppOpenOpened;
                CrossMauiMTAdmob.Current.OnAppOpenClosed += Current_OnAppOpenClosed;
                CrossMauiMTAdmob.Current.OnAppOpenFailedToLoad += Current_OnAppOpenFailedToLoad;
                CrossMauiMTAdmob.Current.OnAppOpenFailedToShow += Current_OnAppOpenFailedToShow;
                CrossMauiMTAdmob.Current.OnAppOpenImpression += Current_OnAppOpenImpression;
                CrossMauiMTAdmob.Current.OnAppOpenClicked += Current_OnAppOpenClicked;
                
                CrossMauiMTAdmob.Current.OnMobileAdsInitialized += Current_OnMobileAdsInitialized;
              
                CrossMauiMTAdmob.Current.OnNativeAdLoaded += Current_OnNativeAdLoaded;
                CrossMauiMTAdmob.Current.OnNativeAdFailedToLoad += Current_OnNativeAdFailedToLoad;
                CrossMauiMTAdmob.Current.OnNativeAdImpression += Current_OnNativeAdImpression;
                CrossMauiMTAdmob.Current.OnNativeAdClicked += Current_OnNativeAdClicked;
                CrossMauiMTAdmob.Current.OnNativeAdOpened += Current_OnNativeAdOpened;
                CrossMauiMTAdmob.Current.OnNativeAdClosed += Current_OnNativeAdClosed;
                
                CrossMauiMTAdmob.Current.OnConsentFormLoadSuccess += Current_OnConsentFormLoadSuccess;
                CrossMauiMTAdmob.Current.OnConsentFormLoadFailure += Current_OnConsentFormLoadFailure;
                CrossMauiMTAdmob.Current.OnConsentFormDismissed += Current_OnConsentFormDismissed;
                CrossMauiMTAdmob.Current.OnConsentInfoUpdateSuccess += Current_OnConsentInfoUpdateSuccess;
                CrossMauiMTAdmob.Current.OnConsentInfoUpdateFailure += Current_OnConsentInfoUpdateFailure;
            }
        }
        
        private void Current_OnConsentInfoUpdateFailure(object sender, MTEventArgs e)
        {
            MyStack.Add(new Label { Text = "On Consent Info Update Failure" });
            Debug.WriteLine($"Current_OnConsentInfoUpdateFailure: {e.ErrorCode} - {e.ErrorMessage}");
        }
        
        private void Current_OnConsentInfoUpdateSuccess(object sender, EventArgs e)
        {
            MyStack.Add(new Label { Text = "On Consent Info Update Success" });
            Debug.WriteLine("Current_OnConsentInfoUpdateSuccess");
        }
        
        private void Current_OnConsentFormDismissed(object sender, EventArgs e)
        {
            MyStack.Add(new Label { Text = "On Consent Form Dismissed" });
            Debug.WriteLine("Current_OnConsentFormDismissed");
        }
        
        private void Current_OnConsentFormLoadFailure(object sender, MTEventArgs e)
        {
            MyStack.Add(new Label { Text = "On Consent Form Load Failure" });
            Debug.WriteLine($"Current_OnConsentFormLoadFailure: {e.ErrorCode} - {e.ErrorMessage}");
        }
        
        private void Current_OnConsentFormLoadSuccess(object sender, EventArgs e)
        {
            MyStack.Add(new Label { Text = "On Consent Form Load Success" });
            Debug.WriteLine("Current_OnConsentFormLoadSuccess");
        }

        private void DisableEvents()
        {
            _shouldSetEvents = true;
            CrossMauiMTAdmob.Current.OnRewardedLoaded -= Current_OnRewardedAdLoaded;
            CrossMauiMTAdmob.Current.OnRewardedFailedToLoad -= Current_OnRewardedAdFailedToLoad;
            CrossMauiMTAdmob.Current.OnRewardedFailedToShow -= Current_OnRewardFailedToShow;
            CrossMauiMTAdmob.Current.OnRewardedOpened -= Current_OnRewardOpened;
            CrossMauiMTAdmob.Current.OnRewardedClosed -= Current_OnRewardClosed;
            CrossMauiMTAdmob.Current.OnRewardedImpression -= Current_OnRewardImpression;

            CrossMauiMTAdmob.Current.OnUserEarnedReward -= Current_OnUserEarnedReward;

            CrossMauiMTAdmob.Current.OnInterstitialLoaded -= Current_OnInterstitialLoaded;
            CrossMauiMTAdmob.Current.OnInterstitialFailedToLoad -= Current_OnInterstitialFailedToLoad;
            CrossMauiMTAdmob.Current.OnInterstitialFailedToShow -= Current_OnInterstitialFailedToShow;
            CrossMauiMTAdmob.Current.OnInterstitialOpened -= Current_OnInterstitialOpened;
            CrossMauiMTAdmob.Current.OnInterstitialClosed -= Current_OnInterstitialClosed;

            CrossMauiMTAdmob.Current.OnAppOpenAdLoaded -= Current_OnAppOpenAdLoaded;
            CrossMauiMTAdmob.Current.OnAppOpenOpened -= Current_OnAppOpenOpened;
            CrossMauiMTAdmob.Current.OnAppOpenClosed -= Current_OnAppOpenClosed;
            CrossMauiMTAdmob.Current.OnAppOpenFailedToLoad -= Current_OnAppOpenFailedToLoad;
            CrossMauiMTAdmob.Current.OnAppOpenFailedToShow -= Current_OnAppOpenFailedToShow;
            CrossMauiMTAdmob.Current.OnAppOpenImpression -= Current_OnAppOpenImpression;
            CrossMauiMTAdmob.Current.OnAppOpenClicked -= Current_OnAppOpenClicked;

            CrossMauiMTAdmob.Current.OnMobileAdsInitialized -= Current_OnMobileAdsInitialized;

            CrossMauiMTAdmob.Current.OnNativeAdLoaded -= Current_OnNativeAdLoaded;
            CrossMauiMTAdmob.Current.OnNativeAdFailedToLoad -= Current_OnNativeAdFailedToLoad;
            CrossMauiMTAdmob.Current.OnNativeAdImpression -= Current_OnNativeAdImpression;
            CrossMauiMTAdmob.Current.OnNativeAdClicked -= Current_OnNativeAdClicked;
            CrossMauiMTAdmob.Current.OnNativeAdOpened -= Current_OnNativeAdOpened;
            CrossMauiMTAdmob.Current.OnNativeAdClosed -= Current_OnNativeAdClosed;
            
            CrossMauiMTAdmob.Current.OnConsentFormLoadSuccess -= Current_OnConsentFormLoadSuccess;
            CrossMauiMTAdmob.Current.OnConsentFormLoadFailure -= Current_OnConsentFormLoadFailure;
            CrossMauiMTAdmob.Current.OnConsentFormDismissed -= Current_OnConsentFormDismissed;
            CrossMauiMTAdmob.Current.OnConsentInfoUpdateSuccess -= Current_OnConsentInfoUpdateSuccess;
            CrossMauiMTAdmob.Current.OnConsentInfoUpdateFailure -= Current_OnConsentInfoUpdateFailure;
        }

        private void Current_OnRewardImpression(object sender, EventArgs e)
        {
            MyStack.Add(new Label { Text = "On Reward Impression" });
            Debug.WriteLine("Current_OnRewardImpression");
        }

        private void Current_OnRewardClosed(object sender, EventArgs e)
        {
            MyStack.Add(new Label { Text = "On Reward Closed" });
            Debug.WriteLine("Current_OnRewardClosed");
        }

        private void Current_OnRewardOpened(object sender, EventArgs e)
        {
            MyStack.Add(new Label { Text = "On Reward Opened" });
            Debug.WriteLine("Current_OnRewardOpened");
        }

        private void Current_OnUserEarnedReward(object sender, MTEventArgs e)
        {
            MyStack.Add(new Label { Text = "On User Earned Reward" });
            Console.WriteLine($"Current_OnUserEarnedReward: {e.RewardType} - {e.RewardAmount}");
        }

        private void Current_OnRewardFailedToShow(object sender, MTEventArgs e)
        {
            MyStack.Add(new Label { Text = "On Reward Failed To Show" });
            Console.WriteLine($"Current_OnRewardFailedToShow: {e.ErrorCode} - {e.ErrorMessage}");
        }

        private void Current_OnInterstitialClosed(object sender, EventArgs e)
        {
            MyStack.Add(new Label { Text = "On Interstitial Closed" });
            Debug.WriteLine("OnInterstitialClosed");
        }

        private void Current_OnInterstitialOpened(object sender, EventArgs e)
        {
            MyStack.Add(new Label { Text = "On Interstitial Opened" });
            Debug.WriteLine("OnInterstitialOpened");
        }

        private void Current_OnInterstitialLoaded(object sender, EventArgs e)
        {
            MyStack.Add(new Label { Text = "On Interstitial Loaded" });
            myLabel.Text = "Interstitial loaded: true";
            Debug.WriteLine("OnInterstitialLoaded");
        }
        private void Current_OnInterstitialFailedToLoad(object sender, MTEventArgs e)
        {
            MyStack.Add(new Label { Text = "On Interstitial Failed To Load" });
            myLabel.Text = "Interstitial loaded: false";
            Debug.WriteLine($"Current_OnInterstitialFailedToLoad: {e.ErrorCode} - {e.ErrorMessage}");
        }

        private void Current_OnInterstitialFailedToShow(object sender, MTEventArgs e)
        {
            MyStack.Add(new Label { Text = "On Interstitial Failed To Show" });
            Console.WriteLine($"Current_OnInterstitialFailedToShow: {e.ErrorCode} - {e.ErrorMessage}");
        }

        private void Current_OnRewardedAdLoaded(object sender, EventArgs e)
        {
            MyStack.Add(new Label { Text = "On Rewarded Video Ad Loaded" });
            myLabel.Text = "Rewarded loaded: true";
            Debug.WriteLine("OnRewardedVideoAdLoaded");
        }
        private void Current_OnRewardedAdFailedToLoad(object sender, MTEventArgs e)
        {
            MyStack.Add(new Label { Text = "On Rewarded Video Ad Failed To Load" });
            myLabel.Text = "Rewarded loaded: false";
            Debug.WriteLine($"OnRewardedVideoAdFailedToLoad: {e.ErrorCode} - {e.ErrorMessage}");
        }

        private void NextPage(object sender, EventArgs e)
        {
            App.Current.MainPage = new MainPage();
        }

        private void LoadBanner(object sender, EventArgs e)
        {            
            myAds.LoadAd(GetCollapsibleMode());
        }

        private CollapsibleBannerMode GetCollapsibleMode()
        {
            if (rbNone.IsChecked)
                return CollapsibleBannerMode.None;
            if (rbTop.IsChecked)
                return CollapsibleBannerMode.Top;
            if (rbBottom.IsChecked)
                return CollapsibleBannerMode.Bottom;

            return CollapsibleBannerMode.None;
        }

        private void LoadInterstitial_OnClicked(object sender, EventArgs e)
        {
            CrossMauiMTAdmob.Current.LoadInterstitial(INTERSTITIALID);
        }

        private void ShowInterstitial_OnClicked(object sender, EventArgs e)
        {
            CrossMauiMTAdmob.Current.ShowInterstitial();
        }

		private void IsLoadedInterstitial_OnClicked(object sender, EventArgs e)
		{
			myLabel.Text = "Interstitial loaded: " + CrossMauiMTAdmob.Current.IsInterstitialLoaded().ToString();
		}

		private void GetNumOfLoadedInterstitials(object sender, EventArgs e)
		{
			myLabel.Text = "Loaded Interstitials: " + CrossMauiMTAdmob.Current.GetNumberOfInterstitialsLoaded().ToString();
		}

		private void EmptyInterstitialList(object sender, EventArgs e)
		{
			CrossMauiMTAdmob.Current.EmptyInterstitialAdsList();
		}

		private void LoadReward_OnClicked(object sender, EventArgs e)
        {
            CrossMauiMTAdmob.Current.LoadRewarded(REWARDEDID);
        }

        private void ShowReward_OnClicked(object sender, EventArgs e)
        {
            CrossMauiMTAdmob.Current.ShowRewarded();
        }

        private void IsRewardLoaded_OnClicked(object sender, EventArgs e)
        {
            myLabel.Text = "Rewarded loaded: " + CrossMauiMTAdmob.Current.IsRewardedLoaded().ToString();
        }

		private void GetNumOfLoadedRewarded(object sender, EventArgs e)
		{
			myLabel.Text = "Loaded Rewarded: " + CrossMauiMTAdmob.Current.GetNumberOfRewardedLoaded().ToString();
		}

		private void EmptyRewardedList(object sender, EventArgs e)
		{
			CrossMauiMTAdmob.Current.EmptyRewardedAdsList();
		}

		private void LoadRewardInterstitial_OnClicked(object sender, EventArgs e)
        {
            CrossMauiMTAdmob.Current.LoadRewardInterstitial(REWARDINTERSTITIALID);
        }

        private void ShowRewardInterstitial_OnClicked(object sender, EventArgs e)
        {
            CrossMauiMTAdmob.Current.ShowRewardInterstitial();
        }

        private void IsRewardLoadedInterstitial_OnClicked(object sender, EventArgs e)
        {
            myLabel.Text = "Rewarded Interstitial loaded: " + CrossMauiMTAdmob.Current.IsRewardInterstitialLoaded().ToString();
        }

		private void EmptyRewardedInterstitialList(object sender, EventArgs e)
		{
			CrossMauiMTAdmob.Current.EmptyRewardInterstitialAdsList();
		}

		private void GetNumOfLoadedRewardedInterstitial(object sender, EventArgs e)
		{
			myLabel.Text = "Loaded Rewarded Interstitial: " + CrossMauiMTAdmob.Current.GetNumberOfRewardedInterstitialsLoaded().ToString();
		}

		private void MyAds_AdVOpened(object sender, EventArgs e)
        {
            MyStack.Add(new Label { Text = "MyAds_AdVOpened" });
            Debug.WriteLine("MyAds_AdVOpened");
        }

        private void MyAds_AdVImpression(object sender, EventArgs e)
        {
            MyStack.Add(new Label { Text = "Banner Impression" });
            Debug.WriteLine("MyAds_AdVImpression");
        }

        private void MyAds_AdVClosed(object sender, EventArgs e)
        {
            MyStack.Add(new Label { Text = "MyAds_AdVClosed" });
            Debug.WriteLine("MyAds_AdVClosed");
        }

        private void MyAds_AdsClicked(object sender, EventArgs e)
        {
            MyStack.Add(new Label { Text = "MyAds_AdsClicked" });
            Debug.WriteLine("MyAds_AdsClicked");
        }

        private void MyAds_AdFailedToLoad(object sender, MTEventArgs e)
        {
            MyStack.Add(new Label { Text = "MyAds_AdFailedToLoad" });
            Debug.WriteLine($"MyAds_AdFailedToLoad: {e.ErrorCode} - {e.ErrorMessage}");
        }

        private void MyAds_AdLoaded(object sender, EventArgs e)
        {
            MyStack.Add(new Label { Text = "MyAds_AdLoaded" });
            Debug.WriteLine("MyAds_AdLoaded");
        }

        private void ClearEvents(object sender, EventArgs e)
        {
            MyStack.Children.Clear();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            CrossMauiMTAdmob.Current.ShowPrivacyOptionsForm();
        }

        private void ResetForm(object sender, EventArgs e)
        {
            CrossMauiMTAdmob.Current.Reset();
        }

        private void CheckConsent(object sender, EventArgs e)
        {
            var consent = CrossMauiMTAdmob.Current.GetConsentStatus();
            MyStack.Add(new Label { Text = $"Consent: {consent}" });
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            var canShow = CrossMauiMTAdmob.Current.CanShowPersonalisedAds();
            MyStack.Add(new Label { Text = $"PA: {canShow}" });
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            var canShow = CrossMauiMTAdmob.Current.CanShowNonPersonalisedAds();
            MyStack.Add(new Label { Text = $"NPA: {canShow}" });
        }

        private void Button_Clicked_3(object sender, EventArgs e)
        {
            var canShow = CrossMauiMTAdmob.Current.CanShowLimitedAds();
            MyStack.Add(new Label { Text = $"LA: {canShow}" });
        }

        private void Current_OnAppOpenAdLoaded(object sender, EventArgs e)
        {
            MyStack.Add(new Label { Text = "On App Open Ad Loaded" });
            Debug.WriteLine("OnAppOpenAdLoaded");
        }

        private void Current_OnAppOpenOpened(object sender, EventArgs e)
        {
            MyStack.Add(new Label { Text = "On App Open Opened" });
            Debug.WriteLine("OnAppOpenOpened");
        }

        private void Current_OnAppOpenClosed(object sender, EventArgs e)
        {
            MyStack.Add(new Label { Text = "On App Open Closed" });
            Debug.WriteLine("OnAppOpenClosed");
        }

        private void Current_OnAppOpenFailedToLoad(object sender, MTEventArgs e)
        {
            MyStack.Add(new Label { Text = "On App Open Failed To Load" });
            Debug.WriteLine($"Current_OnAppOpenFailedToLoad: {e.ErrorCode} - {e.ErrorMessage}");
        }

        private void Current_OnAppOpenFailedToShow(object sender, MTEventArgs e)
        {
            MyStack.Add(new Label { Text = "On App Open Failed To Show" });
            Console.WriteLine($"Current_OnAppOpenFailedToShow: {e.ErrorCode} - {e.ErrorMessage}");
        }

        private void Current_OnAppOpenImpression(object sender, EventArgs e)
        {
            MyStack.Add(new Label { Text = "On App Open Impression" });
            Debug.WriteLine("Current_OnAppOpenImpression");
        }

        private void Current_OnAppOpenClicked(object sender, EventArgs e)
        {
            MyStack.Add(new Label { Text = "On App Open Clicked" });
            Debug.WriteLine("Current_OnAppOpenClicked");
        }

        private void Current_OnMobileAdsInitialized(object sender, EventArgs e)
        {
            MyStack.Add(new Label { Text = "On Mobile Ads Initialized" });
            Debug.WriteLine("Current_OnMobileAdsInitialized");
        }

        private void LoadNative(object sender, EventArgs e)
        {
            CrossMauiMTAdmob.Current.LoadNativeAd();
        }

        private void ShowNative(object sender, EventArgs e)
        {
            myNativeAds.ShowNativeAd();
        }
        private void Current_OnNativeAdLoaded(object sender, EventArgs e)
        {
            MyStack.Add(new Label { Text = "On Native Ad Loaded" });
            Debug.WriteLine("Current_OnNativeAdLoaded");
        }

        private void Current_OnNativeAdFailedToLoad(object sender, MTEventArgs e)
        {
            MyStack.Add(new Label { Text = "On Native Ad Failed To Load" });
            Debug.WriteLine($"Current_OnNativeAdFailedToLoad: {e.ErrorCode} - {e.ErrorMessage}");
        }

        private void Current_OnNativeAdImpression(object sender, EventArgs e)
        {
            MyStack.Add(new Label { Text = "On Native Ad Impression" });
            Debug.WriteLine("Current_OnNativeAdImpression");
        }

        private void Current_OnNativeAdClicked(object sender, EventArgs e)
        {
            MyStack.Add(new Label { Text = "On Native Ad Clicked" });
            Debug.WriteLine("Current_OnNativeAdClicked");
        }

        private void Current_OnNativeAdOpened(object sender, EventArgs e)
        {
            MyStack.Add(new Label { Text = "On Native Ad Opened" });
            Debug.WriteLine("Current_OnNativeAdOpened");
        }

        private void Current_OnNativeAdClosed(object sender, EventArgs e)
        {
            MyStack.Add(new Label { Text = "On Native Ad Closed" });
            Debug.WriteLine("Current_OnNativeAdClosed");
        }

        private void ShowConsent(object sender, EventArgs e)
        {
            CrossMauiMTAdmob.Current.InitialiseAndShowConsentForm();
            Debug.WriteLine("Initialise And Show Consent Form");
        }
    }
}