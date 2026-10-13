using Foundation;
using Plugin.MauiMtAdmob;
using UIKit;

namespace MMTAdmobSample10;

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{
    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    
    public AppDelegate()
    {
        string license = "ZIrXQSue3vFYNfMSzKXkStXSLUgy6vEfkwHfvSnCkx1Vk+FwzixDZaE4UnYdcD6h+tqWdo1LWRxQ+E3Z6eYhwjAb4JLnSeDNL+M="; //<-- Your license key here
        string[]? deviceIds =  ["CCB5C6D9-189B-491E-956D-BD30E55D9C87"]; //<--- Your test device id here
        string OPENADS_AD_UNIT_ID="ca-app-pub-3940256099942544/5575463023";
        string NATIVEADS_AD_UNIT_ID=""; //= "";
        bool areOpenAdsEnabled = true;
        bool initialiseConsentAtStartup = true;
        bool debugMode = true;
        bool handleTrackingAuthorization = true;
        
        //If you have a license code and for some reason you want to skip the consent dialog or it doesn't work for you, uncomment the line below:
        //CrossMauiMTAdmob.Current.SkipConsent = true;
        
        CrossMauiMTAdmob.Current.Init(license, NATIVEADS_AD_UNIT_ID, OPENADS_AD_UNIT_ID, areOpenAdsEnabled, false, deviceIds, Plugin.MauiMtAdmob.Extra.DebugGeography.DEBUG_GEOGRAPHY_EEA, initialiseConsentAtStartup, debugMode, handleTrackingAuthorization);
    }

    public override void OnActivated(UIApplication application)
    {
        base.OnActivated(application);
        CrossMauiMTAdmob.Current.OnResume();
    }
}