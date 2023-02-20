// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using WinUICommunity.LandingsPage.Controls;
using WinUICommunity.Shared.DataModel;

namespace WinUICommunity.DemoApp.Pages
{
    public sealed partial class SectionPage : Page
    {
        public SectionPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            sectionPage.GetDataAsync(e);
        }

        private void SectionPage_OnItemClick(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            var args = (ItemClickEventArgs)e;
            var item = (ControlInfoDataItem)args.ClickedItem;
            WinUICommunity.Common.Helpers.NavigationViewHelper.GetCurrent().Navigate(typeof(ItemPage), item.UniqueId);
        }
    }
}
