using Android.Content;
using Android.Support.Design.Widget;
using Android.Util;
using System;

namespace PersistentBottomSheet.Droid.Components
{
    public class BottomSheetView : CoordinatorLayout
    {
        public event EventHandler StateChanged;

        private string state;
        public string State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;


                if (behavior != null)
                {
                    behavior.State = int.Parse(State);
                }
            }
        }

        public BottomSheetView(Context context, IAttributeSet attrs) :
            base(context, attrs)
        {
        }

        public BottomSheetView(Context context, IAttributeSet attrs, int defStyle) :
            base(context, attrs, defStyle)
        {
        }

        private BottomSheetBehavior behavior;
    }
}