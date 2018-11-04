using System;
using System.Collections.Generic;
using CoreGraphics;
using Foundation;
using UIKit;

namespace PersistentBottomSheet.Touch.Components
{
    public class BottomSheetView : UIView
    {
        public override void WillMoveToSuperview(UIView newsuper)
        {
            var scrollView = Superview;
            if (Superview == null)
                return;

            scrollView.RemoveObserver(this, "contentOffset");
        }

        public override void MovedToSuperview()
        {
            var scrollView = Superview;
            if (Superview == null)
                return;

            scrollView.AddObserver(this, "contentOffset", NSKeyValueObservingOptions.New, this.Handle);
        }
    }

    public enum BottomSheetHeaderMode
    {
        /*
         The option to scale the content to fill the size of the header. Some portion of the content may be clipped to fill the header’s bounds.
         */
        Fill,
        /*
         The option to center the content aligned at the top in the header's bounds.
         */
        Top,
        /*
         The option to scale the content to fill the size of the header and aligned at the top in the header's bounds.
         */
        TopFill,
        /*
         The option to center the content in the header’s bounds, keeping the proportions the same.
         */
        Center,
        /*
         The option to scale the content to fill the size of the header and center the content in the header’s bounds.
         */
        CenterFill,
        /*
         The option to center the content aligned at the bottom in the header’s bounds.
         */
        Bottom,
        /*
         The option to scale the content to fill the size of the header and aligned at the bottom in the header's bounds.
         */
        BottomFill
    }

    public class BottomSheetHeader : NSObject
    {
        private UIScrollView scrollView;
        public UIScrollView ScrollView
        {
            get
            {
                return scrollView;
            }
            set
            {
                if (value == scrollView)
                    return;

                scrollView = value;
                scrollView.ContentInset = new UIEdgeInsets(scrollView.ContentInset.Top + Height, scrollView.ContentInset.Left, scrollView.ContentInset.Bottom, scrollView.ContentInset.Right);
                scrollView.AddSubview(contentView);

                LayoutContentView();
            }
        }

        /*
         The content view on top of the UIScrollView's content.
         */
        private UIView contentView;
        public UIView ContentView
        {
            get
            {
                if (ContentView == contentView)
                    return contentView;

                var tContentView = new BottomSheetView();
                //tContentView.Parent = this;
                tContentView.ClipsToBounds = true;

                contentView = tContentView;

                return tContentView;
            }
        }

        /*
         The header's view.
         */
        private UIView view;
        public UIView View
        {
            get
            {
                return view;
            }
            set
            {
                if (value == view)
                    return;
                view = value;
                updateConstraints();
            }
        }

        /*
         The parallax header behavior mode. By default is fill mode.
         */
        private BottomSheetHeaderMode mode = BottomSheetHeaderMode.Fill;
        public BottomSheetHeaderMode Mode
        {
            get
            {
                return mode;
            }
            set
            {
                if (value == mode)
                    return;
                mode = value;
                updateConstraints();
            }
        }

        /*
         The header's default height. 0 0 by default.
         */
        private float height = 0;
        public float Height
        {
            get
            {
                return height;
            }
            set
            {
                if (value == height)
                    return;

                scrollView.ContentInset = new UIEdgeInsets(scrollView.ContentInset.Top + Height, scrollView.ContentInset.Left, scrollView.ContentInset.Bottom, scrollView.ContentInset.Right);

                height = value;

                updateConstraints();
                LayoutContentView();
            }
        }

        /*
         The header's minimum height while scrolling up. 0 by default.
         */
        private float minimumHeight = 0;
        public float MinimumHeight
        {
            get
            {
                return minimumHeight;
            }
            set
            {
                minimumHeight = value;
                LayoutContentView();
            }
        }

        /*
         The parallax header progress value.
         */
        private float progress = 0;
        public float Progress
        {
            get
            {
                return progress;
            }
            set
            {
                if (value == progress)
                    return;

                progress = value;

                //if (ParallaxHeaderDidScrollHandler != null) ? (self);
            }
        }

        private void updateConstraints(bool update = false)
        {
            if (!update)
            {
                view.RemoveFromSuperview();
                ContentView.AddSubview(view);

                view.TranslatesAutoresizingMaskIntoConstraints = false;
            }

            switch (mode)
            {
                case BottomSheetHeaderMode.Fill:
                    SetFillModeConstraints();
                    break;
                case BottomSheetHeaderMode.Top:
                    SetTopModeConstraints();
                    break;
                case BottomSheetHeaderMode.TopFill:
                    SetTopFillModeConstraints();
                    break;
                case BottomSheetHeaderMode.Center:
                    SetCenterModeConstraints();
                    break;
                case BottomSheetHeaderMode.CenterFill:
                    SetCenterFillModeConstraints();
                    break;
                case BottomSheetHeaderMode.Bottom:
                    SetBottomModeConstraints();
                    break;
                case BottomSheetHeaderMode.BottomFill:
                    SetBottomFillModeConstraints();
                    break;
            }
        }

        private void SetFillModeConstraints()
        {
            var binding = new Dictionary<string, object>{
                {"v", view}
            };

            ContentView.AddConstraints(NSLayoutConstraint.FromVisualFormat("H:|[v]|", NSLayoutFormatOptions.DirectionLeadingToTrailing, null, binding));
            ContentView.AddConstraints(NSLayoutConstraint.FromVisualFormat("V:|[v]|", NSLayoutFormatOptions.DirectionLeadingToTrailing, null, binding));
        }

        private void SetTopModeConstraints()
        {
            var binding = new Dictionary<string, object>{
                {"v", view}
            };

            var metrics = new Dictionary<string, object>{
                {"height", height}
            };

            ContentView.AddConstraints(NSLayoutConstraint.FromVisualFormat("H:|[v]|", NSLayoutFormatOptions.DirectionLeadingToTrailing, null, binding));
            ContentView.AddConstraints(NSLayoutConstraint.FromVisualFormat("V:|[v(==height)]", NSLayoutFormatOptions.DirectionLeadingToTrailing, null, binding));
        }

        private void SetTopFillModeConstraints()
        {
            var binding = new Dictionary<string, object>{
                {"v", view}
            };

            var metrics = new Dictionary<string, object>{
                {"highPriority", UILayoutPriority.DefaultHigh},
                {"height", height}
            };

            ContentView.AddConstraints(NSLayoutConstraint.FromVisualFormat("H:|[v]|", NSLayoutFormatOptions.DirectionLeadingToTrailing, null, binding));
            ContentView.AddConstraints(NSLayoutConstraint.FromVisualFormat("V:|[v(>=height)]-0.0@highPriority-|", NSLayoutFormatOptions.DirectionLeadingToTrailing, null, binding));
        }


        private void SetCenterModeConstraints()
        {
            var binding = new Dictionary<string, object>{
                {"v", view}
            };

            ContentView.AddConstraints(NSLayoutConstraint.FromVisualFormat("H:|[v]|", NSLayoutFormatOptions.DirectionLeadingToTrailing, null, binding));
            ContentView.AddConstraint(NSLayoutConstraint.Create(view, NSLayoutAttribute.CenterY, NSLayoutRelation.Equal, contentView, NSLayoutAttribute.CenterY, 1, 0));
            ContentView.AddConstraint(NSLayoutConstraint.Create(view, NSLayoutAttribute.CenterX, NSLayoutRelation.Equal, contentView, NSLayoutAttribute.CenterX, 1, 0));
        }

        private void SetCenterFillModeConstraints()
        {
            var binding = new Dictionary<string, object>{
                {"v", view}
            };

            var metrics = new Dictionary<string, object>{
                {"highPriority", UILayoutPriority.DefaultHigh},
                {"height", height}
            };

            ContentView.AddConstraints(NSLayoutConstraint.FromVisualFormat("H:|[v]|", NSLayoutFormatOptions.DirectionLeadingToTrailing, null, binding));
            ContentView.AddConstraints(NSLayoutConstraint.FromVisualFormat("V:|[v(>=height)]-0.0@highPriority-|", NSLayoutFormatOptions.DirectionLeadingToTrailing, null, binding));
            ContentView.AddConstraint(NSLayoutConstraint.Create(view, NSLayoutAttribute.CenterY, NSLayoutRelation.Equal, contentView, NSLayoutAttribute.CenterY, 1, 0));
            ContentView.AddConstraint(NSLayoutConstraint.Create(view, NSLayoutAttribute.CenterX, NSLayoutRelation.Equal, contentView, NSLayoutAttribute.CenterX, 1, 0));
        }

        private void SetBottomModeConstraints()
        {
            var binding = new Dictionary<string, object>{
                {"v", view}
            };

            var metrics = new Dictionary<string, object>{
                {"height", height}
            };

            ContentView.AddConstraints(NSLayoutConstraint.FromVisualFormat("H:|[v]|", NSLayoutFormatOptions.DirectionLeadingToTrailing, null, binding));
            ContentView.AddConstraints(NSLayoutConstraint.FromVisualFormat("V:|[v(==height)]", NSLayoutFormatOptions.DirectionLeadingToTrailing, null, binding));
        }

        private void SetBottomFillModeConstraints()
        {
            var binding = new Dictionary<string, object>{
                {"v", view}
            };

            var metrics = new Dictionary<string, object>{
                {"highPriority", UILayoutPriority.DefaultHigh},
                {"height", height}
            };

            ContentView.AddConstraints(NSLayoutConstraint.FromVisualFormat("H:|[v]|", NSLayoutFormatOptions.DirectionLeadingToTrailing, null, binding));
            ContentView.AddConstraints(NSLayoutConstraint.FromVisualFormat("V:|-0.0@highPriority-[v(>=height)]|", NSLayoutFormatOptions.DirectionLeadingToTrailing, null, binding));
        }

        private void LayoutContentView()
        {
            if (scrollView == null)
                return;

            var minimumHeight = Math.Min(MinimumHeight, Height);
            var relativeYOffset = scrollView.ContentOffset.Y + scrollView.ContentInset.Top - Height;
            var relativeHeight = -relativeYOffset;


            var frame = new CGRect(
                x: 0,
                y: relativeYOffset,
                width: scrollView.Frame.Size.Width,
                height: Math.Max(relativeHeight, minimumHeight));
            contentView.Frame = frame;


            var div = Height - MinimumHeight;
            progress = (float)(ContentView.Frame.Size.Height - MinimumHeight) / div;
        }


        private void AdjustScrollViewTopInset(float top)
        {
            if (scrollView == null)
                return;

            var inset = scrollView.ContentInset;

            //Adjust content offset
            var offset = scrollView.ContentOffset;
            offset.Y += inset.Top - top;
            scrollView.ContentOffset = offset;

            //Adjust content inset
            inset.Top = top;
            scrollView.ContentInset = inset;
        }

        [Export("observeValueForKeyPath:ofObject:change:context:")]
        public void ObserveValue(NSString keyPath, NSObject ofObject, NSDictionary change, IntPtr context)
        {
            if (context != this.Handle)
            {
                ObserveValue(keyPath, ofObject, change, context);
                return;
            }
            if (keyPath == "contentOffset")
            {
                LayoutContentView();
            }
        }
    }
}