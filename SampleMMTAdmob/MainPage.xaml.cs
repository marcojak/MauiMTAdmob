using MauiLib2;
using Plugin.MauiMTAdmob;
using Plugin.MauiMTAdmob.Extra;
using System.Diagnostics;

namespace SampleMMTAdmob
{
    public partial class MainPage : ContentPage
    {
        private bool _shouldSetEvents = true;
        public string INTERSTITIALID = DeviceInfo.Platform == DevicePlatform.Android ? "ca-app-pub-3940256099942544/1033173712" : "ca-app-pub-3940256099942544/1033173712";
        public string REWARDEDID = DeviceInfo.Platform == DevicePlatform.Android ? "ca-app-pub-3940256099942544/5224354917" : "ca-app-pub-3940256099942544/5224354917";
        public string REWARDINTERSTITIALID = DeviceInfo.Platform == DevicePlatform.Android ? "ca-app-pub-3940256099942544/5354046379" : "ca-app-pub-3940256099942544/5354046379";

        private readonly ITestService _testService;
        public MainPage(ITestService testService)
        {
            InitializeComponent();

            CrossMauiMTAdmob.Current.TagForChildDirectedTreatment = MTTagForChildDirectedTreatment.TagForChildDirectedTreatmentUnspecified;
            CrossMauiMTAdmob.Current.TagForUnderAgeOfConsent = MTTagForUnderAgeOfConsent.TagForUnderAgeOfConsentUnspecified;
            CrossMauiMTAdmob.Current.MaxAdContentRating = MTMaxAdContentRating.MaxAdContentRatingG;

            _testService = testService ?? throw new ArgumentNullException(nameof(testService));
            testLabel.Text = _testService.SayHello();
        }

        ~MainPage()
        {
            //Test
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            SetEvents();
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
            }
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
        }

        private void Current_OnRewardImpression(object sender, EventArgs e)
        {
            MyStack.Add(new Label { Text = "Current_OnRewardImpression" });
            Debug.WriteLine("Current_OnRewardImpression");
        }

        private void Current_OnRewardClosed(object sender, EventArgs e)
        {
            MyStack.Add(new Label { Text = "Current_OnRewardClosed" });
            Debug.WriteLine("Current_OnRewardClosed");
        }

        private void Current_OnRewardOpened(object sender, EventArgs e)
        {
            MyStack.Add(new Label { Text = "Current_OnRewardOpened" });
            Debug.WriteLine("Current_OnRewardOpened");
        }

        private void Current_OnUserEarnedReward(object sender, MTEventArgs e)
        {
            MyStack.Add(new Label { Text = "Current_OnUserEarnedReward" });
            Debug.WriteLine("Current_OnUserEarnedReward");
        }

        private void Current_OnRewardFailedToShow(object sender, MTEventArgs e)
        {
            MyStack.Add(new Label { Text = "Current_OnRewardFailedToShow" });
            Debug.WriteLine("Current_OnRewardFailedToShow");
        }

        private void Current_OnInterstitialClosed(object sender, EventArgs e)
        {
            MyStack.Add(new Label { Text = "OnInterstitialClosed" });
            Debug.WriteLine("OnInterstitialClosed");
        }

        private void Current_OnInterstitialOpened(object sender, EventArgs e)
        {
            MyStack.Add(new Label { Text = "OnInterstitialOpened" });
            Debug.WriteLine("OnInterstitialOpened");
        }

        private void Current_OnInterstitialLoaded(object sender, EventArgs e)
        {
            MyStack.Add(new Label { Text = "OnInterstitialLoaded" });
            myLabel.Text = "Interstitial loaded: true";
            Debug.WriteLine("OnInterstitialLoaded");
        }
        private void Current_OnInterstitialFailedToLoad(object sender, MTEventArgs e)
        {
            MyStack.Add(new Label { Text = "Current_OnInterstitialFailedToLoad" });
            myLabel.Text = "Interstitial loaded: false";
            Debug.WriteLine("Current_OnInterstitialFailedToLoad");
        }

        private void Current_OnInterstitialFailedToShow(object sender, MTEventArgs e)
        {
            MyStack.Add(new Label { Text = "Current_OnInterstitialFailedToShow" });
            Debug.WriteLine("Current_OnInterstitialFailedToShow");
        }

        private void Current_OnRewardedAdLoaded(object sender, EventArgs e)
        {
            MyStack.Add(new Label { Text = "OnRewardedVideoAdLoaded" });
            myLabel.Text = "Rewarded loaded: true";
            Debug.WriteLine("OnRewardedVideoAdLoaded");
        }
        private void Current_OnRewardedAdFailedToLoad(object sender, MTEventArgs e)
        {
            MyStack.Add(new Label { Text = "OnRewardedVideoAdFailedToLoad" });
            myLabel.Text = "Rewarded loaded: false";
            Debug.WriteLine("OnRewardedVideoAdFailedToLoad");
        }

        private void NextPage(object sender, EventArgs e)
        {
            App.Current.MainPage = new MainPage(_testService);
        }

        private void LoadBanner(object sender, EventArgs e)
        {
            myAds.LoadAd();
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

        private void MyAds_AdVOpened(object sender, EventArgs e)
        {
            MyStack.Add(new Label { Text = "MyAds_AdVOpened" });
            Debug.WriteLine("MyAds_AdVOpened");
        }

        private void MyAds_AdVImpression(object sender, EventArgs e)
        {
            MyStack.Add(new Label { Text = "MyAds_AdVImpression" });
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
    }
}