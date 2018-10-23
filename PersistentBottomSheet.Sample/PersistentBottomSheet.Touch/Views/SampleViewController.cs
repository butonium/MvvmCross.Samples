using MvvmCross.Platforms.Ios.Views;
using PersistentBottomSheet.Core.ViewModels;

namespace PersistentBottomSheet.Touch.Views
{
    public partial class SampleViewController : MvxViewController<SampleViewModel>
    {
        public SampleViewController() : base("SampleViewController", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}