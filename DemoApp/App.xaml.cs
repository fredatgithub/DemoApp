using Microsoft.UI.Xaml;
using Microsoft.Windows.AppNotifications;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;
using WinUICommunity.DemoApp.AppNotification;
using WinUICommunity.DemoApp.Pages;

namespace WinUICommunity.DemoApp;

public partial class App : Application
{
    public ThemeManager themeManager { get; set; }
    private NotificationManager notificationManager;
    public App()
    {
        this.InitializeComponent();
        if (!ApplicationHelper.IsPackaged)
        {
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);
            var c_notificationHandlers = new Dictionary<int, Action<AppNotificationActivatedEventArgs>>();
            c_notificationHandlers.Add(ToastWithAvatar.Instance.ScenarioId, ToastWithAvatar.Instance.NotificationReceived);
            c_notificationHandlers.Add(ToastWithTextBox.Instance.ScenarioId, ToastWithTextBox.Instance.NotificationReceived);
            c_notificationHandlers.Add(ToastWithPayload.Instance.ScenarioId, ToastWithPayload.Instance.NotificationReceived);
            notificationManager = new NotificationManager(c_notificationHandlers);
        }
    }

    private static string StringsFolderPath { get; set; } = string.Empty;

    private async Task InitializeLocalizer(params string[] languages)
    {
        // Initialize a "Strings" folder in the "LocalFolder" for the packaged app.
        if (ApplicationHelper.IsPackaged)
        {
            // Create string resources file from app resources if doesn't exists.
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFolder stringsFolder = await localFolder.CreateFolderAsync(
              "Strings",
               CreationCollisionOption.OpenIfExists);
            string resourceFileName = "Resources.resw";
            foreach (var item in languages)
            {
                await LocalizerBuilder.CreateStringResourceFileIfNotExists(stringsFolder, item, resourceFileName);
            }

            StringsFolderPath = stringsFolder.Path;
        }
        else
        {
            // Initialize a "Strings" folder in the executables folder.
            StringsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "Strings");
            //StorageFolder localFolder = await StorageFolder.GetFolderFromPathAsync(Directory.GetCurrentDirectory());
            var stringsFolder = await StorageFolder.GetFolderFromPathAsync(StringsFolderPath);
        }


        ILocalizer localizer = await new LocalizerBuilder()
            .AddStringResourcesFolderForLanguageDictionaries(StringsFolderPath)
            .SetOptions(options =>
            {
                options.DefaultLanguage = "en-US";
                options.UseUidWhenLocalizedStringNotFound = true;
            })
            .Build();
    }
   
    protected override async void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
    {
        m_window = new MainWindow();
        themeManager = new ThemeManager(m_window, new ThemeOptions
        {
            BackdropType = BackdropType.MicaAlt,
            ElementTheme = ElementTheme.Default,
            TitleBarCustomization = new TitleBarCustomization
            {
                TitleBarType = TitleBarType.AppWindow
            }
        });
        if (!ApplicationHelper.IsPackaged)
        {
            notificationManager.Init(notificationManager, OnNotificationInvoked);
        }
       await InitializeLocalizer("fa-IR", "en-US");

        m_window.Activate();
    }
    private void OnNotificationInvoked(string message)
    {
        AppNotificationPage.Instance.NotificationInvoked(message);
    }

    void OnProcessExit(object sender, EventArgs e)
    {
        notificationManager.Unregister();
    }
    private Window m_window;
}
