using Microsoft.UI.Xaml.Controls;
using WinUICommunity.DemoApp.Pages;
using WinUICommunity.Common.ViewModel;
using System;

namespace WinUICommunity.DemoApp;

public sealed partial class ShellPage : Page
{
    public static ShellPage Instance { get; private set; }
    public ShellViewModel ViewModel { get; } = new ShellViewModel();

    public ShellPage()
    {
        this.InitializeComponent();
        Instance = this;
        ViewModel.InitializeNavigation(shellFrame, navigationView)
            .WithAutoSuggestBox(autoSuggestBox)
            .WithKeyboardAccelerator(KeyboardAccelerators)
            .WithSettingsPage(typeof(GeneralPage))
            .WithDefaultPage(typeof(HomeLandingsPage));
    }

    public void Navigate(string uniqeId)
    {
        Type pageType = Type.GetType(uniqeId);
        shellFrame.Navigate(pageType);
    }

    private void UserControl_Loaded(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        ViewModel.OnLoaded();
    }

    private void navigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
    {
        ViewModel.OnItemInvoked(args);
    }

    private void OnControlsSearchBoxQuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
    {
        ViewModel.OnAutoSuggestBoxQuerySubmitted(args);
    }

    private void OnControlsSearchBoxTextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
    {
        ViewModel.OnAutoSuggestBoxTextChanged(args);
    }
}
