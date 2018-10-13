using MvvmCross.Binding.Bindings.Target.Construction;
using MvvmCross.Platforms.Android.Core;
using MvvmCross.ViewModels;
using PersistentBottomSheet.Core;
using PersistentBottomSheet.Droid.Components;
using PersistentBottomSheet.Droid.Targets;

namespace PersistentBottomSheet.Droid
{
    public class Setup : MvxAndroidSetup<App>
    {
        public Setup() : base()
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new App();
        }

        protected override void FillTargetFactories(IMvxTargetBindingFactoryRegistry registry)
        {
            registry.RegisterFactory(
                new MvxSimplePropertyInfoTargetBindingFactory(
                    typeof(BottomSheetTargetBinding),
                    typeof(BottomSheetView),
                    "State"));

            base.FillTargetFactories(registry);
        }

        protected override System.Collections.Generic.IDictionary<string, string> ViewNamespaceAbbreviations
        {
            get
            {
                var toReturn = base.ViewNamespaceAbbreviations;
                toReturn["butonium"] = "PersistentBottomSheet.Droid.Components";
                return toReturn;
            }
        }
    }
}
