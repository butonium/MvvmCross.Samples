using Android.App;
using Android.Content.PM;
using AutoComplete.Core;
using MvvmCross.Platforms.Android.Core;
using MvvmCross.Platforms.Android.Views;

namespace AutoComplete.Droid
{
    [Activity(MainLauncher =true,NoHistory =true,ScreenOrientation =ScreenOrientation.Portrait)]
    public class SplashScreen : MvxSplashScreenActivity<MvxAndroidSetup<App>,App>
    {
        public SplashScreen()
            :base(Resource.Layout.SplashScreen)
        {

        }
    }
}