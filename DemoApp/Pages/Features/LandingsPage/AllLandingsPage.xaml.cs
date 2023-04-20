using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
namespace WinUICommunity.DemoApp.Pages
{
    public sealed partial class AllLandingsPage : Page
    {
        public AllLandingsPage()
        {
            this.InitializeComponent();
        }

        private void allLandingsPage_Loaded(object sender, RoutedEventArgs e)
        {
            allLandingsPage.GetDataAsync("DataModel/ControlInfoData.json", PathType.Relative);
        }


        private void allLandingsPage_OnItemClick(object sender, RoutedEventArgs e)
        {
            var args = (ItemClickEventArgs)e;
            var item = (ControlInfoDataItem)args.ClickedItem;

            MainWindow.Instance.Navigate(item.UniqueId);
        }
    }
}
