using CoreGraphics;
using MvvmCross.Platforms.Ios.Views;
using PersistentBottomSheet.Core.ViewModels;
using PersistentBottomSheet.Touch.Components;

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


            // Create ParallaxHeaderView with specified size, and set it as uitableView Header, that's it
            BottomSheetView headerView = new BottomSheetView(new CGRect(10, 10, bottomView.Frame.Size.Width, 300f));
            //headerView.headerLabelView.Text = "test";

            bottomView = headerView;
            //[self.mainTableView setTableHeaderView:headerView];
        }

        
    }
}