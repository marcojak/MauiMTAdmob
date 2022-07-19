using Foundation;
using GameKit;
using Google.MobileAds;
using UIKit;

namespace SampleMMTAdmob
{
    [Register("AppDelegate")]
    public class AppDelegate : MauiUIApplicationDelegate
    {
        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            MobileAds.SharedInstance.Start(CompletionHandler);
            return base.FinishedLaunching(application, launchOptions);
        }

        private void CompletionHandler(InitializationStatus status) { }
    }
}