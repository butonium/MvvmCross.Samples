using Android.App;
using Android.OS;
using AutoComplete.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Android.Binding.Views;
using MvvmCross.Platforms.Android.Views;

namespace AutoComplete.Droid.Views
{
    [Activity]
    public class SampleView : MvxActivity<SampleViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            SetContentView(Resource.Layout.SampleView);
            base.OnCreate(savedInstanceState);
            AddBindings();
        }

        private void AddBindings()
        {
            var autoComplete = FindViewById<MvxAutoCompleteTextView>(Resource.Id.SearchBox);

            var set = this.CreateBindingSet<SampleView, SampleViewModel>();
            set.Bind(autoComplete)
                .For(v => v.SelectedObject)
                .To(vm => vm.SelectedResult);
            set.Bind(autoComplete)
                .For(v => v.ItemsSource)
                .To(vm => vm.SearchResults);
            set.Bind(autoComplete)
                .For(v => v.PartialText)
                .To(vm => vm.PartialText);
            set.Apply();
        }
    }
}