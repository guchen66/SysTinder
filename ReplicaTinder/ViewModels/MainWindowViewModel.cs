using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System.Threading;
using System.Windows;
using Thinder.Utils.Common;
using Tinder.UI.Views;

namespace ReplicaTinder.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {

        private readonly IRegionManager _regionManager;
       // private readonly IUserService _userService;
        private readonly IDialogService _dialogService;
        IRegionNavigationJournal _navigationJournal;//导航日志，上一页，下一页
        public MainWindowViewModel(IRegionManager regionManager,IDialogService dialogService, IRegionNavigationJournal navigationJournal)
        {
            _regionManager = regionManager;
            _dialogService = dialogService;
            _navigationJournal = navigationJournal;
            // _regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(TestView));
            //_regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(ContentView));

        }

        #region Xaml设置全局初始化命令

        private DelegateCommand _initializingCommand;
        public DelegateCommand InitializingCommand =>
            _initializingCommand ?? (_initializingCommand = new DelegateCommand(ExecuteInitializingCommand));

        void ExecuteInitializingCommand()
        {
            //_regionManager.RequestNavigate(RegionNames.LoginContentRegion, "LoginMainContent");
            IRegion region = _regionManager.Regions[RegionNames.ContentRegion];
            region.RequestNavigate("ContentView", NavigationCompelted);
        }
        #endregion

        private bool CanExecuteCommand(string parameter)
        {
            return true;
        }

        #region  放大缩小关闭

        private DelegateCommand<string> _MaxCommand;
        public DelegateCommand<string> MaxCmd =>
            _MaxCommand ?? (_MaxCommand = new DelegateCommand<string>(ExecuteMaxCommand, CanExecuteCommand));

        private void ExecuteMaxCommand(string parameter)
        {

        }

        private DelegateCommand<object> _MinCommand;
        public DelegateCommand<object> MinCommand =>
            _MinCommand ?? (_MinCommand = new DelegateCommand<object>(ExecuteMinCommand));

        private void ExecuteMinCommand(object parameter)
        {
            //WindowState = WindowState.Minimized;
        }

        private DelegateCommand<string> _closeCommand;
        public DelegateCommand<string> CloseCmd =>
            _closeCommand ?? (_closeCommand = new DelegateCommand<string>(ExecuteCloseCommand, CanExecuteCommand));

        private void ExecuteCloseCommand(string parameter)
        {
            Application.Current.Shutdown();
        }
        #endregion

        private void NavigationCompelted(NavigationResult result)
        {
            if (result.Result == true)
            {
                Thread.Sleep(1000);
                _dialogService.Show("SuccessDialog", new DialogParameters($"message={"导航到ContentView页面成功"}"), null);
            }
            else
            {
                _dialogService.Show("WarningDialog", new DialogParameters($"message={"导航到ContentView页面失败"}"), null);
            }
        }


        #region  前进后退
        private DelegateCommand _goBackCommand;
        public DelegateCommand GoBackCommand =>
            _goBackCommand ?? (_goBackCommand = new DelegateCommand(DoGoBack));

        public void DoGoBack()
        {
            //返回有这种，其他的应该也有类似的 在我的理解中，这种应该自带注册
            _regionManager.Regions["ContentRegion"].NavigationService.Journal.GoBack();
            //_navigationJournal.GoBack();   失败
        }

        private DelegateCommand _forWardCommand;
        public DelegateCommand GoForwardCommand =>
            _forWardCommand ?? (_forWardCommand = new DelegateCommand(DoForWard));

        public void DoForWard()
        {
            _regionManager.Regions["ContentRegion"].NavigationService.Journal.GoForward();
            //_navigationJournal.GoForward();
        }


        #endregion


        private bool _visible;

        public bool IsCanVisible
        {
            get { return _visible; }
            set { SetProperty<bool>(ref _visible, value); }
        }

        //默认返回是隐藏的，除了病毒查杀，其他控件都带有返回
        private DelegateCommand _backCommand;
        public DelegateCommand BackCommand =>
            _backCommand ?? (_backCommand = new DelegateCommand(DoBackCmd));

        public void DoBackCmd()
        {
            _regionManager.Regions["ContentRegion"].NavigationService.Journal.GoBack();
        }
    }
}
