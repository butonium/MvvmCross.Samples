using Foundation;
using PersistentBottomSheet.Touch.Components;
using System;
using UIKit;

namespace PersistentBottomSheet.Touch
{
    public partial class BottomSheetView : UITableView
    {
        public BottomSheetView (IntPtr handle) : base (handle)
        {
        }

        private struct AssociatedKeys
        {
            static string descriptiveName = "AssociatedKeys.DescriptiveName.parallaxHeader";
        }

        /*
         The parallax header.
         */
        private BottomSheetHeader bottomHeader;
        public BottomSheetHeader BottomHeader
        {
            get
            {
                return bottomHeader;
            }
            set
            {
                bottomHeader = value;
            }
        }
    }
}