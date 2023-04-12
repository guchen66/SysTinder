using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tinder.UI.Views
{
    /// <summary>
    /// ContentView.xaml 的交互逻辑
    /// </summary>
    public partial class ContentView : UserControl
    {
        public ContentView()
        {
            InitializeComponent();
        }

        private void ShowVirusScan()
        {
            var storyBoard = TryFindResource("PopupStoryboard") as Storyboard;
            if (storyBoard != null)
            {
                storyBoard.Begin();
                PopupBorder.Visibility = Visibility.Visible;
            }

            // 如果需要在后台执行病毒扫描操作，可以在此处调用相关方法。
        }

        private void PopupStoryboard_Completed(object sender, EventArgs e)
        {
            PopupBorder.Visibility = Visibility.Collapsed;
        }
    }
}
