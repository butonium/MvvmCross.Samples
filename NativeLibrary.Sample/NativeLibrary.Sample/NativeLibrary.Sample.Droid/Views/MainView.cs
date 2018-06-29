using Android.App;
using Android.OS;
using Android.Support.V7.App;
using MvvmCross.Droid.Views;
using System;
using System.Runtime.InteropServices;

namespace NativeLibrary.Sample.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainView : MvxActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.MainView);
        }
    }
}

