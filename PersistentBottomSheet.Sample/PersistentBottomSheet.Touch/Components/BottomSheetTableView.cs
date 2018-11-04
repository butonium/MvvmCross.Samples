using System;
using UIKit;

namespace PersistentBottomSheet.Touch.Components
{
    public class BottomSheetTableView : UITableView
    {
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
                if (bottomHeader != null)
                    return bottomHeader;

                bottomHeader = new BottomSheetHeader();
                return bottomHeader;
            }
            set
            {
                bottomHeader = value;
            }
        }
    }
}
