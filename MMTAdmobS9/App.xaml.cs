using Plugin.MauiMTAdmob;

namespace MMTAdmobSample9;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        CrossMauiMTAdmob.Current.UserPersonalizedAds = true;
        CrossMauiMTAdmob.Current.ComplyWithFamilyPolicies = true;
        CrossMauiMTAdmob.Current.UseRestrictedDataProcessing = true;
        CrossMauiMTAdmob.Current.BannerAdsId = DeviceInfo.Platform == DevicePlatform.Android ? "ca-app-pub-3940256099942544/6300978111" : "ca-app-pub-3940256099942544/2934735716";
        CrossMauiMTAdmob.Current.TestDevices = new List<string>() { };

        //return new Window(new MainPage());
        return new Window(new NavigationPage(new AdSelection()));
    }
}