using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using WinUICommunity.Common.Helpers;

namespace WinUICommunity.DemoApp.Pages;

public sealed partial class ThemePage : Page
{
    public ThemePage()
    {
        this.InitializeComponent();
    }

    private void OnThemeRadioButtonChecked(object sender, RoutedEventArgs e)
    {
        ThemeHelper.OnRadioButtonChecked(sender);
    }

    private void SettingsPageControl_Loaded(object sender, RoutedEventArgs e)
    {
        ThemeHelper.SetRadioButtonDefaultItem(ThemePanel);
    }
}
