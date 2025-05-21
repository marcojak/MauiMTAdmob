using Foundation;
using Plugin.MauiMTAdmob;
using UIKit;

namespace MMTAdmobSample9;

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{
    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    
    public AppDelegate()
    {
        string license = "ZIrXQSue3vFYNfMSzKXkStXSLUgy6vEfkwHfvSnCkx1Vk+FwzixDZaE4UnYdcD6h+tqWdo1LWRxQ+E3Z6eYhwjAb4JLnSeDNL+M="; //<-- Your license key here
        string[]? deviceIds =  ["CCB5C6D9-189B-491E-956D-BD30E55D9C87"]; //<--- Your test device id here
        string OPENADS_AD_UNIT_ID=""; //= "ca-app-pub-6063858643240116/8709323945";
        string NATIVEADS_AD_UNIT_ID=""; //= "";
        bool areOpenAdsEnabled = false;
        bool initialiseConsentAtStartup = true;
        
        //If you have a license code and for some reason you want to skip the consent dialog or it doesn't work for you, uncomment the line below:
        //CrossMauiMTAdmob.Current.SkipConsent = true;
        
        CrossMauiMTAdmob.Current.Init(license, NATIVEADS_AD_UNIT_ID, OPENADS_AD_UNIT_ID, areOpenAdsEnabled, false, deviceIds, Plugin.MauiMTAdmob.Extra.DebugGeography.DEBUG_GEOGRAPHY_EEA, initialiseConsentAtStartup);
    }

    public override void OnActivated(UIApplication application)
    {
        base.OnActivated(application);
        CrossMauiMTAdmob.Current.OnResume();
    }
}