using SQLite;

namespace SQLiteSample.Maui.Datastore;

public sealed class SqliteDataStore
{
    private readonly SQLiteAsyncConnection database;
    private static Lazy<SqliteDataStore> lazy = null;

    private SqliteDataStore(string path)
    {
        database = new SQLiteAsyncConnection(path);
    }

    public SQLiteAsyncConnection Database => database;

    public static SqliteDataStore Instance
    {
        get
        {
            if (lazy is null)
            {
                throw new InstanceNotCreatedException();
            }
            return lazy.Value;
        }
    }

    private static void CreateSharedDataStore(string path)
    {
        lazy ??= new Lazy<SqliteDataStore>(() => new SqliteDataStore(path));
    }

    public static async Task InitializeDataStoreAsync()
    {
        var databasePath = Path.Combine(
                        Environment.GetFolderPath(
                        Environment.SpecialFolder.LocalApplicationData),
                        DataStoreConstants.DatabaseName
                        );
        SqliteDataStore.CreateSharedDataStore(databasePath);
        await CreateAllTablesAsync();
    }

    private static async Task CreateAllTablesAsync()
    {
        await SqliteDataStore.Instance.Database.CreateTableAsync<GroceryModel>();
    }
}