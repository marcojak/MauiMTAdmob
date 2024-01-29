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
            //If you have a license code:
            CrossMauiMTAdmob.Current.Init(this, "ca-app-pub-3940256099942544~3347511713", license, false, deviceId, true, Plugin.MauiMTAdmob.Extra.DebugGeography.DEBUG_GEOGRAPHY_EEA);

            //If you don't have a license code, you can use the following line instead:
            //CrossMauiMTAdmob.Current.Init(this, "ca-app-pub-3940256099942544~3347511713");
        }
    }
}