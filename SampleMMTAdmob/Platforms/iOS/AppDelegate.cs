using Foundation;
using Plugin.MauiMTAdmob;
using UIKit;

namespace MMTAdmobSample
{
    [Register("AppDelegate")]
    public class AppDelegate : MauiUIApplicationDelegate
    {
        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

        public AppDelegate()
        {
            
            string license = "ZIrXQSue3vFYNfMSzKXkStXSLUgy6vEfkwHfvSnC1lBKifhqgmAOL6QzX3YZdz6q/9yWdo1LWRxQy3pBHuapiubn7tcVNE8Z8A=="; //<-- Your license key here
            string deviceId = ""; //<--- Your test device id here
            string OPENADS_AD_UNIT_ID = "ca-app-pub-3940256099942544/5575463023";
            string NATIVEADS_AD_UNIT_ID = "ca-app-pub-3940256099942544/3986624511";
            bool areOpenAdsEnabled = false;
            bool initialiseConsentAtStartup = true;
            
            CrossMauiMTAdmob.Current.SkipConsent = true;
            
            //If you have a license code:
            CrossMauiMTAdmob.Current.Init(license, NATIVEADS_AD_UNIT_ID, OPENADS_AD_UNIT_ID, areOpenAdsEnabled, false, deviceId, Plugin.MauiMTAdmob.Extra.DebugGeography.DEBUG_GEOGRAPHY_EEA, initialiseConsentAtStartup);
            //Or as simple as:
            //CrossMauiMTAdmob.Current.Init(license);
            //If you don't have a license code, you can use the following line instead:
            //CrossMauiMTAdmob.Current.Init();
        }

        public override void OnActivated(UIApplication application)
        {
            base.OnActivated(application);
            CrossMauiMTAdmob.Current.OnResume();
        }
    }
}