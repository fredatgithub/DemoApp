using Microsoft.UI.Xaml.Controls;
using System;
using WinUICommunity.DemoApp.Pages;

namespace WinUICommunity.DemoApp;

public sealed partial class ShellPage : Page
{
    public static ShellPage Instance { get; private set; }
    public NavigationManager navigationManager { get; set; }
    public ShellPage()
    {
        this.InitializeComponent();
        Instance = this;
        navigationManager = new NavigationManager(navigationView, new NavigationViewOptions
        {
            DefaultPage = typeof(HomeLandingsPage),
            SettingsPage = typeof(GeneralPage)
        }, shellFrame);
    }

    public void Navigate(string uniqeId)
    {
        Type pageType = Type.GetType(uniqeId);
        shellFrame.Navigate(pageType);
    }
}
