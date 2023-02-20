// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Navigation;
using System;
using WinUICommunity.Common.Extensions;
using WinUICommunity.Common.Helpers;
using WinUICommunity.Shared.DataModel;

namespace WinUICommunity.DemoApp.Pages
{
    public sealed partial class ItemPage : Page
    {
        public ControlInfoDataItem Item
        {
            get { return _item; }
            set { _item = value; }
        }

        private ControlInfoDataItem _item;

        public ItemPage()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            NavigationArgs args = (NavigationArgs)e.Parameter;
            var item = await ControlInfoDataSource.Instance.GetItemAsync((String)args.Parameter, args.JsonRelativeFilePath, args.IncludedInBuildMode);

            if (item != null)
            {
                Item = item;

                // Load control page into frame.
                Type pageType = Type.GetType(item.UniqueId);

                if (pageType != null)
                {
                    this.contentFrame.Navigate(pageType);
                }
                args.NavigationView.EnsureNavigationSelection(item?.UniqueId);
            }

            base.OnNavigatedTo(e);
        }

        protected override void OnKeyDown(KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Escape)
            {
                this.Item = null;
                if (this.contentFrame.CanGoBack)
                {
                    this.contentFrame.GoBack();
                }
                else
                {
                    NavigationViewFromJson.Instance.Navigate(typeof(AllLandingsPage));
                }
            }
        }
    }
}
