using Prism.Ioc;
using Prism.Modularity;
using ReplicaTinder.Views;
using System.Windows;
using Tinder.UI;

namespace ReplicaTinder
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

            //注册导航
            
        }

        //新建类库，通过模块化传入用户控件
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            //注册模块就行
            moduleCatalog.AddModule<UIModule>();
            base.ConfigureModuleCatalog(moduleCatalog);
        }
    }
}
