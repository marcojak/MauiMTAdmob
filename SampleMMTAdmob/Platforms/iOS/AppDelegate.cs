using Foundation;
using Plugin.MauiMTAdmob;

namespace MMTAdmobSample
{
    [Register("AppDelegate")]
    public class AppDelegate : MauiUIApplicationDelegate
    {
        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

        public AppDelegate()
        {
            string license = "ZIrXQSue3vFYNfMSzKXkSpLDaAdnqa4B0ByE/n2Tm1JUiOBuzmBCKac7WnAQ5PlWgfJT/KAPyX9D0ImZ"; //<-- Your license key here
            string deviceId = ""; //<--- Your test device id here

            //If you have a license code:
            CrossMauiMTAdmob.Current.Init(license, false, deviceId, Plugin.MauiMTAdmob.Extra.DebugGeography.DEBUG_GEOGRAPHY_EEA);

            //If you don't have a license code, you can use the following line instead:
            //CrossMauiMTAdmob.Current.Init();
        }
    }
}