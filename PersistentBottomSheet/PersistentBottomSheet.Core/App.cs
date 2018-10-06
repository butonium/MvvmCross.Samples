using MvvmCross.ViewModels;
using PersistentBottomSheet.Core.ViewModels;

namespace PersistentBottomSheet.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            RegisterAppStart<SampleViewModel>();
        }
    }
}
