using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using WinUICommunity.Common.Helpers;

namespace WinUICommunity.DemoApp.Pages
{
    public sealed partial class ApplicationDataContainerPage : Page
    {
        ApplicationDataContainerHelper settings;
        public ApplicationDataContainerPage()
        {
            this.InitializeComponent();

            if (ApplicationHelper.IsPackaged)
            {
                settings = ApplicationDataContainerHelper.GetCurrent();
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (ApplicationHelper.IsPackaged)
            {
                settings.Save<string>("stringKey", txtString.Text);
                settings.Save<double>("doubleKey", txtNumber.Value);
                settings.Save<bool>("boolKey", chkBool.IsChecked.Value);
            }
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            if (ApplicationHelper.IsPackaged)
            {
                txtString2.Text = settings.Read<string>("stringKey");
                txtNumber2.Value = settings.Read<double>("doubleKey");
                chkBool2.IsChecked = settings.Read<bool>("boolKey");
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            settings?.Clear();
            btnLoad_Click(null, null);
        }
    }
}
