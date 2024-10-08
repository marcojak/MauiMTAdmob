using System.Diagnostics;
using Plugin.DroidMTAdmob;
using Plugin.DroidMTAdmob.Controls;
using Plugin.DroidMTAdmob.Extra;
using Activity = Android.App.Activity;

namespace MTAdmobDroidSample;

[Activity(Label = "@string/app_name", MainLauncher = true)]
public class MainActivity : Activity
{
    LinearLayout MyStack;
    private TextView msgLabel;
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        
        // Set our view from the "main" layout resource
        SetContentView(Resource.Layout.activity_main);

        SetUpView();
        
        string license = "7oyIFbp3nG7ozwSiyaSmTpXBkei628CrxVMiYNuTKQTlzXHGnJZpRmlsUzc2BV5WN3c8xHDHugzs4gTbpaFDjxJAiGWhEQk3Ng==";

        string nativeAdsId = "ca-app-pub-3940256099942544/2247696110";
        DroidMTAdmob.Current.Init(this, "ca-app-pub-3940256099942544~3347511713", license, nativeAdsId);
        DroidMTAdmob.Current.AdsId = "ca-app-pub-3940256099942544/2014213617";
        msgLabel.Text = $"Version: {DroidMTAdmob.Current.GetAdmobVersion()}";
    }

    protected override void OnResume()
    {
        base.OnResume();
        DroidMTAdmob.Current.OnResume();
    }

    private void SetUpView()
    {
        MyStack = FindViewById<LinearLayout>(Resource.Id.MyStack);
        msgLabel = FindViewById<TextView>(Resource.Id.txtMessageLabel);

        var _adView = FindViewById<MTAdView>(Resource.Id.adView);

        _adView.AdsLoaded += (sender, e) =>
        {
            Console.WriteLine("AdsLoaded");
            MyStack.AddView(new TextView(this) { Text = $"Banner collapsible? {_adView.IsCollapsible}" });
        };

        var rbNone = FindViewById<RadioButton>(Resource.Id.rbNone);
        var rbTop = FindViewById<RadioButton>(Resource.Id.rbTop);
        var rbBottom = FindViewById<RadioButton>(Resource.Id.rbBottom);

        var button = FindViewById<Button>(Resource.Id.loadBannerButton);
        button.Click += (sender, e) =>
        {
            CollapsibleBannerMode mode = CollapsibleBannerMode.None;
            if (rbTop.Checked)
            {
                mode = CollapsibleBannerMode.Top;
            }
            else if (rbBottom.Checked)
            {
                mode = CollapsibleBannerMode.Bottom;
            }

            _adView.LoadAd(mode);
        };

        FindViewById<Button>(Resource.Id.showConsentButton).Click += (sender, e) => { DroidMTAdmob.Current.InitialiseAndShowConsentForm(); };

        FindViewById<Button>(Resource.Id.loadInterstitialButton).Click += (sender, e) => { DroidMTAdmob.Current.LoadInterstitial("ca-app-pub-3940256099942544/1033173712"); };
        FindViewById<Button>(Resource.Id.showInterstitialButton).Click += (sender, e) => { DroidMTAdmob.Current.ShowInterstitial(); };
        FindViewById<Button>(Resource.Id.IsLoadedInterstitialButton).Click += (sender, e) => { msgLabel.Text = $@"Interstitial loaded: {DroidMTAdmob.Current.IsInterstitialLoaded()}"; };
        FindViewById<Button>(Resource.Id.getNumInterstitialButton).Click += (sender, e) => { msgLabel.Text = $@"Num Interstitial loaded: {DroidMTAdmob.Current.GetNumberOfInterstitialsLoaded()}"; };

        FindViewById<Button>(Resource.Id.loadRewardedButton).Click += (sender, e) => { DroidMTAdmob.Current.LoadRewarded("ca-app-pub-3940256099942544/5224354917"); };
        FindViewById<Button>(Resource.Id.showRewardedButton).Click += (sender, e) => { DroidMTAdmob.Current.ShowRewarded(); };
        FindViewById<Button>(Resource.Id.IsLoadedRewardedButton).Click += (sender, e) => { msgLabel.Text = $@"Rewarded loaded: {DroidMTAdmob.Current.IsRewardedLoaded()}"; };
        FindViewById<Button>(Resource.Id.getNumRewardedButton).Click += (sender, e) => { msgLabel.Text = $@"Num Rewarded loaded: {DroidMTAdmob.Current.GetNumberOfRewardedLoaded()}"; };

        FindViewById<Button>(Resource.Id.loadRewardedInterstitialButton).Click += (sender, e) => { DroidMTAdmob.Current.LoadRewardInterstitial("ca-app-pub-3940256099942544/5354046379"); };
        FindViewById<Button>(Resource.Id.showRewardedInterstitialButton).Click += (sender, e) => { DroidMTAdmob.Current.ShowRewardInterstitial(); };
        FindViewById<Button>(Resource.Id.IsLoadedRewardedInterstitialButton).Click += (sender, e) => { msgLabel.Text = $@"Rewarded Interstitial loaded: {DroidMTAdmob.Current.IsRewardInterstitialLoaded()}"; };
        FindViewById<Button>(Resource.Id.getNumRewardedInterstitialButton).Click += (sender, e) => { msgLabel.Text = $@"Num Rewarded Interstitial loaded: {DroidMTAdmob.Current.GetNumberOfRewardedInterstitialsLoaded()}"; };

        FindViewById<Button>(Resource.Id.ShowFormButton).Click += (sender, e) => { DroidMTAdmob.Current.ShowPrivacyOptionsForm(); };
        FindViewById<Button>(Resource.Id.ResetFormButton).Click += (sender, e) => { DroidMTAdmob.Current.Reset(); };
        FindViewById<Button>(Resource.Id.CheckConsentButton).Click += (sender, e) => { msgLabel.Text = $@"Consent status: {DroidMTAdmob.Current.GetConsentStatus()}"; };
        FindViewById<Button>(Resource.Id.CheckPAButton).Click += (sender, e) => { msgLabel.Text = $@"Personalised Ads: {DroidMTAdmob.Current.CanShowPersonalisedAds()}"; };
        FindViewById<Button>(Resource.Id.CheckNPAButton).Click += (sender, e) => { msgLabel.Text = $@"Non-Personalised Ads: {DroidMTAdmob.Current.CanShowNonPersonalisedAds()}"; };
        FindViewById<Button>(Resource.Id.CheckLAButton).Click += (sender, e) => { msgLabel.Text = $@"Limited Ads: {DroidMTAdmob.Current.CanShowLimitedAds()}"; };

        FindViewById<TextView>(Resource.Id.clearEventsButton).Click += (sender, e) => { MyStack.RemoveAllViews();};
        //FindViewById<TextView>(Resource.Id.showInspectorButton).Click += (sender, e) => { DroidMTAdmob.Current.OpenInspector();};
        //FindViewById<TextView>(Resource.Id.showDebugMenuButton).Click += (sender, e) => { DroidMTAdmob.Current.OpenDewbugMenu("ca-app-pub-3940256099942544/2014213617");};
        
        var myNativeAds = FindViewById<MTNativeAdView>(Resource.Id.myNativeAds);
        
        FindViewById<Button>(Resource.Id.loadNativeButton).Click += (sender, e) => { DroidMTAdmob.Current.LoadNativeAd(); };
        FindViewById<Button>(Resource.Id.showNativeButton).Click += (sender, e) => { myNativeAds.ShowNativeAd(); };
        
        SetEvents();
    }

    void SetEvents()
    {
        DroidMTAdmob.Current.OnRewardedLoaded += Current_OnRewardedAdLoaded;
        DroidMTAdmob.Current.OnRewardedFailedToLoad += Current_OnRewardedAdFailedToLoad;
        DroidMTAdmob.Current.OnRewardedFailedToShow += Current_OnRewardFailedToShow;
        DroidMTAdmob.Current.OnRewardedOpened += Current_OnRewardOpened;
        DroidMTAdmob.Current.OnRewardedClosed += Current_OnRewardClosed;
        DroidMTAdmob.Current.OnRewardedImpression += Current_OnRewardImpression;
        DroidMTAdmob.Current.OnUserEarnedReward += Current_OnUserEarnedReward;
        DroidMTAdmob.Current.OnInterstitialLoaded += Current_OnInterstitialLoaded;
        DroidMTAdmob.Current.OnInterstitialFailedToLoad += Current_OnInterstitialFailedToLoad;
        DroidMTAdmob.Current.OnInterstitialFailedToShow += Current_OnInterstitialFailedToShow;
        DroidMTAdmob.Current.OnInterstitialOpened += Current_OnInterstitialOpened;
        DroidMTAdmob.Current.OnInterstitialClosed += Current_OnInterstitialClosed;
        DroidMTAdmob.Current.OnAppOpenAdLoaded += Current_OnAppOpenAdLoaded;
        DroidMTAdmob.Current.OnAppOpenOpened += Current_OnAppOpenOpened;
        DroidMTAdmob.Current.OnAppOpenClosed += Current_OnAppOpenClosed;
        DroidMTAdmob.Current.OnAppOpenFailedToLoad += Current_OnAppOpenFailedToLoad;
        DroidMTAdmob.Current.OnAppOpenFailedToShow += Current_OnAppOpenFailedToShow;
        DroidMTAdmob.Current.OnAppOpenImpression += Current_OnAppOpenImpression;
        DroidMTAdmob.Current.OnAppOpenClicked += Current_OnAppOpenClicked;
        DroidMTAdmob.Current.OnMobileAdsInitialized += Current_OnMobileAdsInitialized;
        DroidMTAdmob.Current.OnNativeAdLoaded += Current_OnNativeAdLoaded;
        DroidMTAdmob.Current.OnNativeAdFailedToLoad += Current_OnNativeAdFailedToLoad;
        DroidMTAdmob.Current.OnNativeAdImpression += Current_OnNativeAdImpression;
        DroidMTAdmob.Current.OnNativeAdClicked += Current_OnNativeAdClicked;
        DroidMTAdmob.Current.OnNativeAdOpened += Current_OnNativeAdOpened;
        DroidMTAdmob.Current.OnNativeAdClosed += Current_OnNativeAdClosed;
        DroidMTAdmob.Current.OnConsentFormLoadSuccess += Current_OnConsentFormLoadSuccess;
        DroidMTAdmob.Current.OnConsentFormLoadFailure += Current_OnConsentFormLoadFailure;
        DroidMTAdmob.Current.OnConsentFormDismissed += Current_OnConsentFormDismissed;
        DroidMTAdmob.Current.OnConsentInfoUpdateSuccess += Current_OnConsentInfoUpdateSuccess;
        DroidMTAdmob.Current.OnConsentInfoUpdateFailure += Current_OnConsentInfoUpdateFailure;
    }

    private void Current_OnConsentInfoUpdateFailure(object sender, MTEventArgs e)
    {
        
        MyStack.AddView(new TextView(this) { Text = "On Consent Info Update Failure" });
        Debug.WriteLine($"Current_OnConsentInfoUpdateFailure: {e.ErrorCode} - {e.ErrorMessage}");
    }

    private void Current_OnConsentInfoUpdateSuccess(object sender, EventArgs e)
    {
        MyStack.AddView(new TextView(this) { Text = "On Consent Info Update Success" });
        Debug.WriteLine("Current_OnConsentInfoUpdateSuccess");
    }

    private void Current_OnConsentFormDismissed(object sender, EventArgs e)
    {
        MyStack.AddView(new TextView(this) { Text = "On Consent Form Dismissed" });
        Debug.WriteLine("Current_OnConsentFormDismissed");
    }

    private void Current_OnConsentFormLoadFailure(object sender, MTEventArgs e)
    {
        MyStack.AddView(new TextView(this) { Text = "On Consent Form Load Failure" });
        Debug.WriteLine($"Current_OnConsentFormLoadFailure: {e.ErrorCode} - {e.ErrorMessage}");
    }

    private void Current_OnConsentFormLoadSuccess(object sender, EventArgs e)
    {
        MyStack.AddView(new TextView(this) { Text = "On Consent Form Load Success" });
        Debug.WriteLine("Current_OnConsentFormLoadSuccess");
    }
    private void Current_OnRewardImpression(object sender, EventArgs e)
    {
        MyStack.AddView(new TextView(this) { Text = "On Reward Impression" });
        Debug.WriteLine("Current_OnRewardImpression");
    }

    private void Current_OnRewardClosed(object sender, EventArgs e)
    {
        MyStack.AddView(new TextView(this) { Text = "On Reward Closed" });
        Debug.WriteLine("Current_OnRewardClosed");
    }

    private void Current_OnRewardOpened(object sender, EventArgs e)
    {
        MyStack.AddView(new TextView(this) { Text = "On Reward Opened" });
        Debug.WriteLine("Current_OnRewardOpened");
    }

    private void Current_OnUserEarnedReward(object sender, MTEventArgs e)
    {
        MyStack.AddView(new TextView(this) { Text = "On User Earned Reward" });
        Console.WriteLine($"Current_OnUserEarnedReward: {e.RewardType} - {e.RewardAmount}");
    }

    private void Current_OnRewardFailedToShow(object sender, MTEventArgs e)
    {
        MyStack.AddView(new TextView(this) { Text = "On Reward Failed To Show" });
        Console.WriteLine($"Current_OnRewardFailedToShow: {e.ErrorCode} - {e.ErrorMessage}");
    }

    private void Current_OnInterstitialClosed(object sender, EventArgs e)
    {
        MyStack.AddView(new TextView(this) { Text = "On Interstitial Closed" });
        Debug.WriteLine("OnInterstitialClosed");
    }

    private void Current_OnInterstitialOpened(object sender, EventArgs e)
    {
        MyStack.AddView(new TextView(this) { Text = "On Interstitial Opened" });
        Debug.WriteLine("OnInterstitialOpened");
    }

    private void Current_OnInterstitialLoaded(object sender, EventArgs e)
    {
        MyStack.AddView(new TextView(this) { Text = "On Interstitial Loaded" });
        msgLabel.Text = "Interstitial loaded: true";
        Debug.WriteLine("OnInterstitialLoaded");
    }

    private void Current_OnInterstitialFailedToLoad(object sender, MTEventArgs e)
    {
        MyStack.AddView(new TextView(this) { Text = "On Interstitial Failed To Load" });
        msgLabel.Text = "Interstitial loaded: false";
        Debug.WriteLine($"Current_OnInterstitialFailedToLoad: {e.ErrorCode} - {e.ErrorMessage}");
    }

    private void Current_OnInterstitialFailedToShow(object sender, MTEventArgs e)
    {
        MyStack.AddView(new TextView(this) { Text = "On Interstitial Failed To Show" });
        Console.WriteLine($"Current_OnInterstitialFailedToShow: {e.ErrorCode} - {e.ErrorMessage}");
    }

    private void Current_OnRewardedAdLoaded(object sender, EventArgs e)
    {
        MyStack.AddView(new TextView(this) { Text = "On Rewarded Video Ad Loaded" });
        msgLabel.Text = "Rewarded loaded: true";
        Debug.WriteLine("OnRewardedVideoAdLoaded");
    }

    private void Current_OnRewardedAdFailedToLoad(object sender, MTEventArgs e)
    {
        MyStack.AddView(new TextView(this) { Text = "On Rewarded Video Ad Failed To Load" });
        msgLabel.Text = "Rewarded loaded: false";
        Debug.WriteLine($"OnRewardedVideoAdFailedToLoad: {e.ErrorCode} - {e.ErrorMessage}");
    }

    private void Current_OnAppOpenAdLoaded(object sender, EventArgs e)
    {
        MyStack.AddView(new TextView(this) { Text = "On App Open Ad Loaded" });
        Debug.WriteLine("OnAppOpenAdLoaded");
    }

    private void Current_OnAppOpenOpened(object sender, EventArgs e)
    {
        MyStack.AddView(new TextView(this) { Text = "On App Open Opened" });
        Debug.WriteLine("OnAppOpenOpened");
    }

    private void Current_OnAppOpenClosed(object sender, EventArgs e)
    {
        MyStack.AddView(new TextView(this) { Text = "On App Open Closed" });
        Debug.WriteLine("OnAppOpenClosed");
    }

    private void Current_OnAppOpenFailedToLoad(object sender, MTEventArgs e)
    {
        MyStack.AddView(new TextView(this) { Text = "On App Open Failed To Load" });
        Debug.WriteLine($"Current_OnAppOpenFailedToLoad: {e.ErrorCode} - {e.ErrorMessage}");
    }

    private void Current_OnAppOpenFailedToShow(object sender, MTEventArgs e)
    {
        MyStack.AddView(new TextView(this) { Text = "On App Open Failed To Show" });
        Console.WriteLine($"Current_OnAppOpenFailedToShow: {e.ErrorCode} - {e.ErrorMessage}");
    }

    private void Current_OnAppOpenImpression(object sender, EventArgs e)
    {
        MyStack.AddView(new TextView(this) { Text = "On App Open Impression" });
        Debug.WriteLine("Current_OnAppOpenImpression");
    }

    private void Current_OnAppOpenClicked(object sender, EventArgs e)
    {
        MyStack.AddView(new TextView(this) { Text = "On App Open Clicked" });
        Debug.WriteLine("Current_OnAppOpenClicked");
    }

    private void Current_OnMobileAdsInitialized(object sender, EventArgs e)
    {
        MyStack.AddView(new TextView(this) { Text = "On Mobile Ads Initialized" });
        Debug.WriteLine("Current_OnMobileAdsInitialized");
    }

    private void Current_OnNativeAdLoaded(object sender, EventArgs e)
    {
        MyStack.AddView(new TextView(this) { Text = "On Native Ad Loaded" });
        Debug.WriteLine("Current_OnNativeAdLoaded");
    }

    private void Current_OnNativeAdFailedToLoad(object sender, MTEventArgs e)
    {
        MyStack.AddView(new TextView(this) { Text = "On Native Ad Failed To Load" });
        Debug.WriteLine($"Current_OnNativeAdFailedToLoad: {e.ErrorCode} - {e.ErrorMessage}");
    }

    private void Current_OnNativeAdImpression(object sender, EventArgs e)
    {
        MyStack.AddView(new TextView(this) { Text = "On Native Ad Impression" });
        Debug.WriteLine("Current_OnNativeAdImpression");
    }

    private void Current_OnNativeAdClicked(object sender, EventArgs e)
    {
        MyStack.AddView(new TextView(this) { Text = "On Native Ad Clicked" });
        Debug.WriteLine("Current_OnNativeAdClicked");
    }

    private void Current_OnNativeAdOpened(object sender, EventArgs e)
    {
        MyStack.AddView(new TextView(this) { Text = "On Native Ad Opened" });
        Debug.WriteLine("Current_OnNativeAdOpened");
    }

    private void Current_OnNativeAdClosed(object sender, EventArgs e)
    {
        MyStack.AddView(new TextView(this) { Text = "On Native Ad Closed" });
        Debug.WriteLine("Current_OnNativeAdClosed");
    }
}