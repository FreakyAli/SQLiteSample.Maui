using System.Collections;
using System.Linq.Expressions;

namespace SQLiteSample.Maui.Datastore;

public class SqliteService : ISqliteService
{
    // <summary>
    // Deletes all the data from a specific table
    // </summary>
    // <typeparam name="T"> Table that you'd like to clear </typeparam>
    // <returns> a boolean that represents if all the data was deleted or not </returns>
    public async Task<bool> DeleteAllDataAsync<T>()
    {
        return await SqliteDataStore.Instance.Database.DeleteAllAsync<T>() != 0;
    }

    // <summary>
    // Deletes the specific row whos primary key is passed as an argument
    // </summary>
    // <typeparam name="T"> Table that you'd like to delete data from </typeparam>
    // <param name="primaryKey"> primary key of that row entry </param>
    // <returns> a boolean that represents if the deletion was sucessful </returns>
    public async Task<bool> DeleteDataAsync<T>(object primaryKey)
    {
        return await SqliteDataStore.Instance.Database.DeleteAsync<T>(primaryKey) != 0;
    }

    // <summary>
    // Creates an SQLiteCommand of the given command text(SQL) with arguments
    // </summary>
    // <param name="query">the SQLite command you'd like to fire</param>
    // <param name="args">required arguments for that command</param>
    // <returns></returns>
    public async Task<bool> ExecuteAsync(string query, params object[] args)
    {
        return await SqliteDataStore.Instance.Database.ExecuteAsync(query, args) != 0;
    }

    // <summary>
    // Get all data of type
    // </summary>
    // <typeparam name="T"> Table that you want to query </typeparam>
    // <returns> list of your data if exists or an empty collection </returns>
    public async Task<List<T>> GetAllDataAsync<T>() where T : new()
    {
        return await SqliteDataStore.Instance.Database.Table<T>().ToListAsync();
    }

    // <summary>
    // Get data that matches the pk
    // </summary>
    // <typeparam name="T"> Table that you want to query </typeparam>
    // <returns> data if exists or null </returns>
    public async Task<T> GetDataByPkAsync<T>(object pk) where T : new()
    {
        return await SqliteDataStore.Instance.Database.GetAsync<T>(pk);
    }

    // <summary>
    // Get the first item that macthes the expression.
    // </summary>
    // <typeparam name="T"> Table that you want to query </typeparam>
    // <returns> data if exists or null </returns>
    public async Task<T> GetDataAsync<T>(Expression<Func<T, bool>> predicate) where T : new()
    {
        try
        {
            return await SqliteDataStore.Instance.Database.GetAsync<T>(predicate);
        }
        catch (Exception)
        {
            //Todo: Log this exception.
            return default(T);
        }
    }

    // <summary>
    // Insert all data into the specific table
    // </summary>
    // <typeparam name="T"> Table that you'd like to insert into </typeparam>
    // <param name="Data"> Data to insert </param>
    // <returns> a boolean that represents if the data was inserted successfully </returns>
    public async Task<bool> InsertAllDataAsync<T>(IEnumerable<T> Data)
    {
        return await SqliteDataStore.Instance.Database.InsertAllAsync(Data, typeof(T), true) != 0;
    }

    // <summary>
    // Insert single row into a specific table
    // </summary>
    // <typeparam name="T"> Table that you'd like to insert into </typeparam>
    // <param name="Data"> Data to insert </param>
    // <returns>
    // a boolean, integer tuple. The boolean represents if the transaction was successful and
    // the integer returns the integer autoincrement primary key if any.
    // </returns>
    public async Task<bool> InsertDataAsync<T>(T Data)
    {
        return await SqliteDataStore.Instance.Database.InsertAsync(Data, typeof(T)) != 0;
    }

    // <summary>
    // Insert single row into a specific table
    // </summary>
    // <typeparam name="T"> Table that you'd like to insert/replace into </typeparam>
    // <param name="Data"> Data to insert </param>
    // <returns>
    // a boolean, integer tuple. The boolean represents if the transaction was successful and
    // the integer returns the integer autoincrement primary key if any.
    // </returns>
    public async Task<bool> InsertOrReplace<T>(T Data)
    {
        return await SqliteDataStore.Instance.Database.InsertOrReplaceAsync(Data, typeof(T)) != 0;
    }

    // <summary>
    // Updates all specified objects
    // </summary>
    // <param name="Data"> </param>
    // <returns> a boolean that represents if the update was successful </returns>
    public async Task<bool> UpdateAllDataAsync(IEnumerable Data)
    {
        return await SqliteDataStore.Instance.Database.UpdateAllAsync(Data, true) != 0;
    }

    // <summary>
    // Updates the specified object
    // </summary>
    // <typeparam name="T"> Table that you'd like to update </typeparam>
    // <param name="Data"> Data you'd like to update </param>
    // <returns> a boolean that represents if the update was successful </returns>
    public async Task<bool> UpdateDataAsync<T>(T Data)
    {
        return await SqliteDataStore.Instance.Database.UpdateAsync(Data, typeof(T)) != 0;
    }

    // <summary>
    // Get all data of type with a predicate LINQ query
    // </summary>
    // <typeparam name="T"> Table that you want to query </typeparam>
    // <typeparam name="predicate"> LINQ predicate query </typeparam>
    // <returns>
    // list of your data if exists or an empty collection based on the result of predicate search
    // </returns>

    public async Task<List<T>> GetAllDataQueryAsync<T>(Expression<Func<T, bool>> predicate = null) where T : new()
    {
        return await SqliteDataStore.Instance.Database.Table<T>().Where(predicate).ToListAsync();
    }
}