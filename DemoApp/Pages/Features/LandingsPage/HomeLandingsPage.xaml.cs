// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using WinUICommunity.Shared.DataModel;

namespace WinUICommunity.DemoApp.Pages
{
    public sealed partial class HomeLandingsPage : Page
    {
        public HomeLandingsPage()
        {
            this.InitializeComponent();
        }

        private void mainLandingsPage_Loaded(object sender, RoutedEventArgs e)
        {
            mainLandingsPage.GetDataAsync("DataModel/ControlInfoData.json");
        }

        private void mainLandingsPage_OnItemClick(object sender, RoutedEventArgs e)
        {
            var args = (ItemClickEventArgs)e;
            var item = (ControlInfoDataItem)args.ClickedItem;

            ShellPage.Instance.Navigate(item.UniqueId);
        }
    }
}
