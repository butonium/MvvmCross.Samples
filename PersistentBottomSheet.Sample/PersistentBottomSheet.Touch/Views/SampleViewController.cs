// This file has been autogenerated from a class added in the UI designer.

using System;
using CoreGraphics;
using UIKit;

namespace PersistentBottomSheet.Touch.Views
{
    public partial class SampleViewController : UIViewController//MvxTableViewController<SampleViewModel>
	{
        BottomSheetViewController bottomSheetViewController;

		public SampleViewController (IntPtr handle) : base (handle)
		{
		}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            SetupBottomSheet();
        }

        private void SetupBottomSheet()
        {
            // 1- Init bottomSheetVC
            bottomSheetViewController = new BottomSheetViewController();

            // 2- Add bottomSheetVC as a child view 
            this.AddChildViewController(bottomSheetViewController);
            this.View.AddSubview(bottomSheetViewController.View);
            bottomSheetViewController.DidMoveToParentViewController(this);

            // 3- Adjust bottomSheet frame and initial position.
            var height = View.Frame.Height;
            var width = View.Frame.Width;
            bottomSheetViewController.View.Frame = new CGRect(0, this.View.Frame.GetMaxY(), width, height);

            btMain.TouchUpInside += BtMain_TouchUpInside;

            UITapGestureRecognizer tapGesture = new UITapGestureRecognizer(HandleAction);

            View.AddGestureRecognizer(tapGesture);
        }

        void HandleAction()
        {
            bottomSheetViewController.View.Hidden = true;
        }


        void BtMain_TouchUpInside(object sender, EventArgs e)
        {
            bottomSheetViewController.View.Hidden = false;
        }
    }
}