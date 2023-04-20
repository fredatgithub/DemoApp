using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using WinUICommunity.DemoApp.Pages;

namespace WinUICommunity.DemoApp;

public sealed partial class MainWindow : Window
{
    public Grid ApplicationTitleBar => AppTitleBar;
    internal static MainWindow Instance { get; private set; }
    public NavigationManager navigationManager { get; set; }
    public MainWindow()
    {
        this.InitializeComponent();

        Instance = this;
        var titleBarHelper = TitleBarHelper.Initialize(this, TitleTextBlock, AppTitleBar, LeftPaddingColumn, IconColumn, TitleColumn, LeftDragColumn, SearchColumn, RightDragColumn, RightPaddingColumn);
        titleBarHelper.LeftPadding = 420;
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
