using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace WinUICommunity.DemoApp.Pages;

public sealed partial class ThemeManagerPage : Page
{
    public ThemeManagerPage()
    {
        this.InitializeComponent();
    }

    private void OnThemeRadioButtonChecked(object sender, RoutedEventArgs e)
    {
        (Application.Current as App).themeManager.OnThemeRadioButtonChecked(sender);
    }
    private void OnBackdropRadioButtonChecked(object sender, RoutedEventArgs e)
    {
        (Application.Current as App).themeManager.OnBackdropRadioButtonChecked(sender);
    }
    private void cmbTheme_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        (Application.Current as App).themeManager.OnThemeComboBoxSelectionChanged(sender);
    }
    private void cmbBackdrop_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        (Application.Current as App).themeManager.OnBackdropComboBoxSelectionChanged(sender);
    }
    private void SettingsPageControl_Loaded(object sender, RoutedEventArgs e)
    {
        (Application.Current as App).themeManager.SetThemeRadioButtonDefaultItem(themePanel);
        (Application.Current as App).themeManager.SetBackdropRadioButtonDefaultItem(backdropPanel);
        (Application.Current as App).themeManager.SetThemeComboBoxDefaultItem(cmbTheme);
        (Application.Current as App).themeManager.SetBackdropComboBoxDefaultItem(cmbBackdrop);
    }
}
