using SQLiteSample.Maui.Datastore;

namespace SQLiteSample.Maui;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        Task.Run( async() => await SqliteDataStore.InitializeDataStoreAsync());
        MainPage = new AppShell();
    }
}