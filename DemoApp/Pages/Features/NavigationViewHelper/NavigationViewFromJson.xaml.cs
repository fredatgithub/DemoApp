// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using WinUICommunity.Common.Helpers;

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
                Initialize("DataModel/ControlInfoData.json", rootFrame, NavigationViewControl)
                .WithAutoSuggestBox(controlsSearchBox);
        }
        private void controlsSearchBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            NavigationViewHelper.GetCurrent().AutoSuggestBoxQuerySubmitted(args, typeof(WinUICommunity.DemoApp.Pages.ItemPage));
        }
        public void Navigate(Type type)
        {
            NavigationViewHelper.GetCurrent().Navigate(type);
        }

        private void OnNavigationViewSelectionChanged(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewSelectionChangedEventArgs args)
        {
            NavigationViewHelper.GetCurrent().OnNavigationViewSelectionChanged(args, typeof(WinUICommunity.DemoApp.Pages.SectionPage), typeof(WinUICommunity.DemoApp.Pages.ItemPage));
        }
    }
}
