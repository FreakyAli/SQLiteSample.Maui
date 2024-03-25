using AsyncAwaitBestPractices;
using SQLiteSample.Maui.Datastore;

namespace SQLiteSample.Maui;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        SqliteDataStore.InitializeDataStoreAsync().SafeFireAndForget();
        MainPage = new AppShell();
    }
}