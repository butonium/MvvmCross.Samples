using Android.App;
using Android.OS;
using MvvmCross.Platforms.Android.Views;
using PersistentBottomSheet.Core.ViewModels;

namespace PersistentBottomSheet.Droid.Views
{
    [Activity(Label = "SampleView")]
    public class SampleView : MvxActivity<SampleViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.SampleView);
        }
    }
}