using System;
using CoreGraphics;
using UIKit;

namespace PersistentBottomSheet.Touch.Views
{
    public partial class BottomSheetViewController : UIViewController
    {
        public BottomSheetViewController() : base("BottomSheetViewController", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            var gesture = new UIPanGestureRecognizer((g) => PanGesture(g));
            View.AddGestureRecognizer(gesture);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            PrepareBackgroundView();
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            //UIView.animateAnimateWithDuration(0.3) { [weak self] in
            var frame = this?.View.Frame;
            var yComponent = UIScreen.MainScreen.Bounds.Height - 200;
            View.Frame = new CGRect(0, yComponent, frame.Value.Width, frame.Value.Height);
            //}
        }

        private void PanGesture(UIPanGestureRecognizer recognizer)
        {
            var translation = recognizer.TranslationInView(View);
            var y = View.Frame.GetMinY();
            View.Frame = new CGRect(0, y + translation.Y, View.Frame.Width, View.Frame.Height);
            recognizer.SetTranslation(CGPoint.Empty, View);
        }


        private void PrepareBackgroundView()
        {
            var blurEffect = UIBlurEffect.FromStyle(UIBlurEffectStyle.Dark);
            var visualEffect = new UIVisualEffectView(blurEffect);
            var bluredView = new UIVisualEffectView(blurEffect);
            bluredView.ContentView.AddSubview(visualEffect);

            visualEffect.Frame = UIScreen.MainScreen.Bounds;
            bluredView.Frame = UIScreen.MainScreen.Bounds;

            View.InsertSubview(bluredView, atIndex: 0);
        }
    }
}