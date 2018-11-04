// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace PersistentBottomSheet.Touch.Views
{
    [Register ("SampleViewController")]
    partial class SampleViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        PersistentBottomSheet.Touch.BottomSheetView bottomView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (bottomView != null) {
                bottomView.Dispose ();
                bottomView = null;
            }
        }
    }
}