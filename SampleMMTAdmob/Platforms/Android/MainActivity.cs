using Android.App;
using Android.Content.PM;
using Android.OS;
using Plugin.MauiMTAdmob;

namespace MMTAdmobSample
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            string license = "ZIrXQSue3vFYNfMSzKXkSpLDaAdnqa4B0ByE/n2Tm1JUiOBuzmBCKac7WnAQ5PlWgfJT/KAPyX9D0ImZ"; //<-- Your license key here
            string deviceId = ""; //<--- Your test device id here
            string OPENADS_AD_UNIT_ID = "ca-app-pub-3940256099942544/9257395921";
            //If you have a license code:
            CrossMauiMTAdmob.Current.Init(this, "ca-app-pub-3940256099942544~3347511713", license, OPENADS_AD_UNIT_ID, true, false, deviceId, true, Plugin.MauiMTAdmob.Extra.DebugGeography.DEBUG_GEOGRAPHY_EEA);

            //If you don't have a license code, you can use the following line instead:
            //CrossMauiMTAdmob.Current.Init(this, "ca-app-pub-3940256099942544~3347511713");
        }

        // Add the following code to the MainActivity class to handle the lifecycle events:
        // CrossMauiMTAdmob.Current.OnResume() allows to load and show the app open ad when the app is resumed.
        // You need to add your logic to decide if and when show the app open ad.
        // You can use CrossMauiMTAdmob.Current.AreOpenAdsEnabled to enable or disable the app open ads.
        protected override void OnResume()
        {
            base.OnResume();
            CrossMauiMTAdmob.Current.OnResume();
        }
    }
}