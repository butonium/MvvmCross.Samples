using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Views;
using MvvmCross.Binding;
using MvvmCross.Binding.Bindings.Target;
using PersistentBottomSheet.Droid.Components;
using System;
using System.Reflection;
using static Android.Support.Design.Widget.BottomSheetBehavior;

namespace PersistentBottomSheet.Droid.Targets
{
    public class BottomSheetCback : BottomSheetCallback
    {
        public int State;
        public event EventHandler StateSwaped;
        public override void OnSlide(View bottomSheet, float slideOffset)
        {

        }

        public override void OnStateChanged(View bottomSheet, int newState)
        {
            State = newState;
            StateSwaped.Invoke(this,new EventArgs());
        }
    }

    public class BottomSheetTargetBinding : MvxPropertyInfoTargetBinding<BottomSheetView>
    {
        private bool subscribed;

        private BottomSheetCback callback;

        public override MvxBindingMode DefaultMode => MvxBindingMode.TwoWay;

        public BottomSheetTargetBinding(object target, PropertyInfo targetPropertyInfo) : base(target,targetPropertyInfo){}

        protected override void SetValueImpl(object target, object value)
        {
            var view = target as BottomSheetView;

            var nested = view.FindViewById<NestedScrollView>(Resource.Id.bottomSheet);

            if (nested == null) return;

            var beh = BottomSheetBehavior.From(nested);
            beh.State = int.Parse((string)value);

            if (!subscribed)
            {
                callback = new BottomSheetCback();
                callback.StateSwaped += OnStateSwaped;
                beh.SetBottomSheetCallback(callback);
                subscribed = true;
            }

            view.State = (string)value;

        }

        public override void SubscribeToEvents()
        {
            var view = View;
            view.StateChanged += OnStateChanged;
        }

        private void OnStateSwaped(object sender, System.EventArgs e)
        {
            FireValueChanged(callback.State);
        }

        private void OnStateChanged(object sender, System.EventArgs e)
        {
            var view = View;
            if (view == null)
                return;

            FireValueChanged(view.State);
        }

        protected override void Dispose(bool isDisposing)
        {
            base.Dispose(isDisposing);

            if(isDisposing)
            {
                var view = View;
                if(view != null && subscribed)
                {
                    view.StateChanged -= OnStateChanged;
                    subscribed = false;
                }
            }
        }
    }
}