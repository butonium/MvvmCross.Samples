using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace PersistentBottomSheet.Touch.Components
{
    public class BottomSheetView : UIView
    {
        UIScrollView scrollView;
        UIImageView imageView;
        UIView mainSubView;
        UIImage headerImage;
        UIImageView bluredImageView;
        public UILabel headerLabelView;
        CGRect kDefaultHeaderFrame = new CGRect(0, 0, 50, 50);
        static float kParallaxDeltaFactor = 0.5f;
        static float kMaxTitleAlphaOffset = 100.0f;
        static float kLabelPaddingDist = 8.0f;

        public BottomSheetView BottomSheetViewWithImage(UIImage image, CGSize headerSize)
        {
            BottomSheetView headerView = new BottomSheetView(new CGRect(0, 0, headerSize.Width, headerSize.Height));
            //headerView.headerImage = image;
            InitialSetupForDefaultHeader();
            return headerView;
        }

        public BottomSheetView BottomSheetViewWithImage(UIView subView)
        {
            BottomSheetView headerView = new BottomSheetView(new CGRect(0, 0, subView.Frame.Size.Width, subView.Frame.Size.Height));
            InitialSetupForCustomSubView(subView);
            return headerView;
        }

        public BottomSheetView(CGRect size) : base(size)
        {

        }

        [Export("awakeFromNib")]
        public void AwakeFromNib()
        {
            if (mainSubView != null)
                InitialSetupForCustomSubView(mainSubView);
            else
                InitialSetupForDefaultHeader();

            RefreshBlurViewForNewImage();
        }

        public void LayoutHeaderViewForScrollViewOffset(CGPoint offset)
        {
            CGRect frame = scrollView.Frame;

            if (offset.Y > 0)
            {
                var max = Math.Max(offset.Y * kParallaxDeltaFactor, 0f);
                frame.Y = float.Parse(max.ToString());
                scrollView.Frame = frame;
                bluredImageView.Alpha = 1 / kDefaultHeaderFrame.Size.Height * offset.Y * 2;
                ClipsToBounds = true;
            }
            else
            {
                var delta = 0.0f;
                CGRect rect = kDefaultHeaderFrame;
                var min = Math.Abs(Math.Min(0.0f, offset.Y));
                delta = float.Parse(min.ToString());
                rect.Y -= delta;
                //rect.Size.Height += delta;
                scrollView.Frame = rect;
                ClipsToBounds = false;
                //self.headerTitleLabel.alpha = 1 - (delta) * 1 / kMaxTitleAlphaOffset;
            }
        }

        public void RefreshBlurViewForNewImage()
        {
            //UIImage screenShot = Capture();
            //screenShot.. [screenShot applyBlurWithRadius: 5 tintColor:[UIColor colorWithWhite: 0.6 alpha: 0.2] saturationDeltaFactor: 1.0 maskImage: nil];
            //self.bluredImageView.image = screenShot;
        }

        private void InitialSetupForDefaultHeader()
        {
            scrollView = new UIScrollView(Bounds);
            UIImageView tImageView = new UIImageView(Bounds);
            tImageView.AutoresizingMask = UIViewAutoresizing.FlexibleLeftMargin | UIViewAutoresizing.FlexibleRightMargin | UIViewAutoresizing.FlexibleTopMargin | UIViewAutoresizing.FlexibleBottomMargin | UIViewAutoresizing.FlexibleHeight | UIViewAutoresizing.FlexibleWidth;
            tImageView.ContentMode = UIViewContentMode.ScaleAspectFill;
            tImageView.Image = headerImage;
            imageView = tImageView;
            scrollView.AddSubview(tImageView);
            
            CGRect labelRect = scrollView.Bounds;
            labelRect.X = labelRect.Y = kLabelPaddingDist;
            //labelRect.Size.Width = labelRect.size.width - 2 * kLabelPaddingDist;
            //labelRect.Size.Height = labelRect.size.height - 2 * kLabelPaddingDist;
            UILabel headerLabel = new UILabel(labelRect);
            //headerLabel.TextAlignment = NSTextAlignmentCenter;
            headerLabel.Lines = 0;
            //headerLabel.LineBreakMode = NSLineBreakByWordWrapping;
            headerLabel.AutoresizingMask = imageView.AutoresizingMask;
            headerLabel.TextColor = UIColor.White;
            //headerLabel.Font = new UIFontfontWithName:@"AvenirNextCondensed-Regular" size:23];
            headerLabelView = headerLabel;
            scrollView.AddSubview(headerLabelView);
            
            bluredImageView = new UIImageView(imageView.Frame);
            bluredImageView.AutoresizingMask = imageView.AutoresizingMask;
            bluredImageView.Alpha = 0.0f;
            scrollView.AddSubview(bluredImageView);

            AddSubview(scrollView);
            
            RefreshBlurViewForNewImage();
        }

        private void InitialSetupForCustomSubView(UIView subView)
        {
            scrollView = new UIScrollView(Bounds);
            mainSubView = subView;
            subView.AutoresizingMask = UIViewAutoresizing.FlexibleLeftMargin | UIViewAutoresizing.FlexibleRightMargin | UIViewAutoresizing.FlexibleTopMargin | UIViewAutoresizing.FlexibleBottomMargin | UIViewAutoresizing.FlexibleHeight | UIViewAutoresizing.FlexibleWidth;
            scrollView.AddSubview(subView);

            bluredImageView = new UIImageView(subView.Frame);
            bluredImageView.AutoresizingMask = subView.AutoresizingMask;
            bluredImageView.Alpha = 0.0f;
            scrollView.AddSubview(bluredImageView);

            AddSubview(scrollView);
            RefreshBlurViewForNewImage();
        }

        private void SetHeaderImage(UIImage headerImage)
        {
            this.headerImage = headerImage;
            imageView.Image = headerImage;
            RefreshBlurViewForNewImage();
        }

        private UIImage ScreenShotOfView(UIView view)
        {
            UIGraphics.BeginImageContextWithOptions(kDefaultHeaderFrame.Size, true, 0.0f);
            DrawViewHierarchy(kDefaultHeaderFrame, false);
            UIImage image = UIGraphics.GetImageFromCurrentImageContext();
            UIGraphics.EndImageContext();
            
            return image;
        }
    }
}