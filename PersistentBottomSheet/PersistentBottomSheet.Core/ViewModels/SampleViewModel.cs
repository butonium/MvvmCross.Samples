using MvvmCross.Commands;
using MvvmCross.ViewModels;

namespace PersistentBottomSheet.Core.ViewModels
{
    public class SampleViewModel : MvxViewModel
    {
        public enum States:int { COLLAPSED=4,EXPANDED=3,HIDDEN=5};
        private string state;
        public string State { get { return state; } set { state = value; RaisePropertyChanged(() => State); } }

        public MvxCommand CollapseCommand => new MvxCommand(Change);

        public SampleViewModel()
        {
            State = $"{(int)States.COLLAPSED}";
        }
        private void Change()
        {
            if (State == $"{(int)States.COLLAPSED}")
                State = $"{(int)States.EXPANDED}";
            else
                State = $"{(int)States.COLLAPSED}";
        }
    }
}
