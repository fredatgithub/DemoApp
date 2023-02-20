// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using WinUICommunity.Shared.DataModel;
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
            allLandingsPage.GetDataAsync("DataModel/ControlInfoData.json");
        }


        private void allLandingsPage_OnItemClick(object sender, RoutedEventArgs e)
        {
            var args = (ItemClickEventArgs)e;
            var item = (ControlInfoDataItem)args.ClickedItem;

            ShellPage.Instance.Navigate(item.UniqueId);
        }
    }
}
