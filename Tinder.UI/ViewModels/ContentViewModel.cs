using Prism.Commands;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thinder.Utils.Common;

namespace Tinder.UI.ViewModels
{
    public class ContentViewModel : BindableBase, INavigationAware, IRegionMemberLifetime
    {

        public bool KeepAlive => true;
        private IRegionNavigationJournal _journal;
        private readonly IRegionManager _regionManager;
        private readonly IDialogService _dialogService;

        public ContentViewModel(IDialogService dialogService, IRegionManager regionManager)
        {

            _dialogService = dialogService;

            _regionManager = regionManager;

        }
       

        //打开病毒查杀
        private DelegateCommand<string> _openVirusCmd;
        public DelegateCommand<string> OpenVirusCmd =>
            _openVirusCmd ?? (_openVirusCmd = new DelegateCommand<string>(ExecuteOpenVirusCommand, CanExecuteCommand));

        private void ExecuteOpenVirusCommand(string parameter)
        {

            Navigate("VirusView");
        }

        //打开防护中心
        private DelegateCommand<string> _openProtectionCmd;
        public DelegateCommand<string> OpenProtectionCmd =>
            _openProtectionCmd ?? (_openProtectionCmd = new DelegateCommand<string>(ExecuteOpenProtectionCommand, CanExecuteCommand));

        private void ExecuteOpenProtectionCommand(string parameter)
        {

            Navigate("ProtectionView");
        }

        private DelegateCommand<string> _openTestCmd;
        public DelegateCommand<string> OpenTestCmd =>
            _openTestCmd ?? (_openTestCmd = new DelegateCommand<string>(ExecuteCommand, CanExecuteCommand));

       

        private void ExecuteCommand(string parameter)
        {

            _dialogService.ShowDialog("ExceptView");
        }

        private bool CanExecuteCommand(string parameter)
        {
            return true;
        }


        private void Navigate(string navigatePath)
        {
            if (navigatePath != null)
                _regionManager.RequestNavigate(RegionNames.ContentRegion, navigatePath);
        }


        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
           
        }


        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            _journal = navigationContext.NavigationService.Journal;
        }

    }
}
