﻿using MauiLib2;
using Plugin.MauiMTAdmob;

namespace SampleMMTAdmob
{
    public partial class App : Application
    {
        public App(ITestService testService)
        {
            InitializeComponent();

            CrossMauiMTAdmob.Current.UserPersonalizedAds = true;
            CrossMauiMTAdmob.Current.ComplyWithFamilyPolicies = true;
            CrossMauiMTAdmob.Current.UseRestrictedDataProcessing = true;
            CrossMauiMTAdmob.Current.AdsId = DeviceInfo.Platform == DevicePlatform.Android ? "ca-app-pub-3940256099942544/6300978111" : "ca-app-pub-3940256099942544/2934735716";
            CrossMauiMTAdmob.Current.TestDevices = new List<string>() { };

            //MainPage = new NavigationPage(new MainPage());
            MainPage = new MainPage(testService);
        }
    }
}