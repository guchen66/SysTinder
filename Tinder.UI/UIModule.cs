using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Tinder.UI.ViewModels;
using Tinder.UI.ViewModels.Dialogs;
using Tinder.UI.ViewModels.Protection;
using Tinder.UI.ViewModels.SafeUtils;
using Tinder.UI.ViewModels.Virus;
using Tinder.UI.ViewModels.Visit;
using Tinder.UI.Views;
using Tinder.UI.Views.Dialogs;
using Tinder.UI.Views.Protection;
using Tinder.UI.Views.SafeUtils;
using Tinder.UI.Views.Virus;
using Tinder.UI.Views.Visit;

namespace Tinder.UI
{
    public class UIModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

           
            containerRegistry.RegisterForNavigation<ContentView, ContentViewModel>();
            containerRegistry.RegisterForNavigation<VirusView, VirusViewModel>();
            containerRegistry.RegisterForNavigation<ProtectionView, ProtectionViewModel>();
            containerRegistry.RegisterForNavigation<VisitView, VisitViewModel>();
            containerRegistry.RegisterForNavigation<SafeUtilsView, SafeUtilsViewModel>();
            containerRegistry.RegisterForNavigation<TestView, TestViewModel>();


           

            //注册对话框
            containerRegistry.RegisterDialog<SuccessDialog, SuccessDialogViewModel>();
            containerRegistry.RegisterDialog<WarningDialog, WarningDialogViewModel>();
        }
    }
}