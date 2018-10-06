using Android.App;
using Android.Content.PM;
using MvvmCross.Platforms.Android.Core;
using MvvmCross.Platforms.Android.Views;

namespace PersistentBottomSheet.Droid
{
    [Activity(
        Label = "SplashScreen"
        , MainLauncher = true
        , NoHistory = true
        , ScreenOrientation = ScreenOrientation.Portrait)]

public class SplashScreen : MvxSplashScreenActivity<Setup, Core.App>
{
    public SplashScreen()
         : base(Resource.Layout.SplashScreen)
    {
    }
}
}