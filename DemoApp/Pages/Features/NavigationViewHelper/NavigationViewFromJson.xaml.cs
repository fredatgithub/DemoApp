// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using WinUICommunity.Common.Helpers;
using WinUICommunity.Shared.DataModel;

namespace WinUICommunity.DemoApp.Pages
{
    public sealed partial class NavigationViewFromJson : Page
    {
        internal static NavigationViewFromJson Instance { get; private set; }
        public NavigationViewFromJson()
        {
            this.InitializeComponent();
            Instance = this;
            Loaded += NavigationViewFromJson_Loaded;
        }

        private void NavigationViewFromJson_Loaded(object sender, RoutedEventArgs e)
        {
            NavigationViewHelper.GetCurrent().
                Initialize("DataModel/ControlInfoData.json", typeof(NavigationViewFromJson), rootFrame, NavigationViewControl)
                .WithAutoSuggestBox(controlsSearchBox);
        }
        private void controlsSearchBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            if (args.ChosenSuggestion != null && args.ChosenSuggestion is ControlInfoDataItem)
            {
                var infoDataItem = args.ChosenSuggestion as ControlInfoDataItem;
                var hasChangedSelection = NavigationViewHelper.GetCurrent().EnsureItemIsVisibleInNavigation(infoDataItem.Title);

                // In case the menu selection has changed, it means that it has triggered
                // the selection changed event, that will navigate to the page already
                if (!hasChangedSelection)
                {
                    NavigationViewHelper.GetCurrent().Navigate(typeof(ItemPage), infoDataItem.UniqueId);
                }
            }
        }
        public void Navigate(Type type)
        {
            NavigationViewHelper.GetCurrent().Navigate(type);
        }

        private void OnNavigationViewSelectionChanged(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewSelectionChangedEventArgs args)
        {
            if (!args.IsSettingsSelected)
            {
                var selectedItem = args.SelectedItemContainer;
                if (selectedItem.DataContext is ControlInfoDataGroup)
                {
                    var itemId = ((ControlInfoDataGroup)selectedItem.DataContext).UniqueId;
                    NavigationViewHelper.GetCurrent().Navigate(typeof(SectionPage), itemId);
                }
                else if (selectedItem.DataContext is ControlInfoDataItem)
                {
                    var item = (ControlInfoDataItem)selectedItem.DataContext;
                    NavigationViewHelper.GetCurrent().Navigate(typeof(ItemPage), item.UniqueId);
                }
            }
        }
    }
}
