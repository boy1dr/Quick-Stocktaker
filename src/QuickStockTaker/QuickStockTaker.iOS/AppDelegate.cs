﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FFImageLoading;
using FFImageLoading.Forms.Platform;
using Foundation;
using MediaManager;
using QuickStockTaker.Common.Services;
using QuickStockTaker.Services;
using UIKit;

namespace QuickStockTaker.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            //global::Xamarin.Forms.Forms.SetFlags("CollectionView_Experimental");
            global::Xamarin.Forms.Forms.Init();

            // initials Nlog
            new LoggerService().InitializeNLog();

            // initials ZXing 
            global::ZXing.Net.Mobile.Forms.iOS.Platform.Init();

            // media player
            CrossMediaManager.Current.Init();

            // ffimageloading
            CachedImageRenderer.Init();
            CachedImageRenderer.InitImageSourceHandler();

            //var config = new FFImageLoading.Config.Configuration()
            //{
            //    VerboseLogging = false,
            //    VerbosePerformanceLogging = false,
            //    VerboseMemoryCacheLogging = false,
            //    VerboseLoadingCancelledLogging = false,
            //    Logger = new CustomLogger(),
            //};
            ImageService.Instance.Initialize();

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
