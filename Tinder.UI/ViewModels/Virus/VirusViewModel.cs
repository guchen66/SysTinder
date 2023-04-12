using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tinder.UI.ViewModels.Virus
{
    public class VirusViewModel : BindableBase, INavigationAware, IConfirmNavigationRequest
    {
        private readonly IRegionManager _regionManager;
        private readonly IDialogService _dialogService;
        private IRegionNavigationJournal _journal;

        public VirusViewModel(IDialogService dialogService, IRegionManager regionManager, IRegionNavigationJournal journal)
        {

            _dialogService = dialogService;

            _regionManager = regionManager;
            // _journal = journal;
        }


        private DelegateCommand<string> _backContentCmd;
        public DelegateCommand<string> BackContentCmd =>
            _backContentCmd ?? (_backContentCmd = new DelegateCommand<string>(ExecuteBackContentCommand));

        private void ExecuteBackContentCommand(string parameter)
        {
            //_regionManager.Regions["ContentRegion"].NavigationService.Journal.GoBack();
            _journal.GoBack();
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            _journal = navigationContext.NavigationService.Journal;
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            /*var result = false;
            if (MessageBox.Show("是否需要导航到ContentView页面?", "Naviagte?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                result = true;
            }
            continuationCallback(result);
*/
            //允许跳转
            continuationCallback(true);
        }
    }
}
