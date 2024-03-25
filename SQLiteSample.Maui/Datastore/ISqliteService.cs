#nullable disable
using System.Collections;
using System.Linq.Expressions;

namespace SQLiteSample.Maui.Datastore;

public interface ISqliteService
{
    Task<bool> ExecuteAsync(string query, params object[] args);

    Task<bool> InsertDataAsync<T>(T Data);

    Task<bool> DeleteDataAsync<T>(object primaryKey);

    Task<bool> UpdateDataAsync<T>(T Data);

    Task<bool> InsertAllDataAsync<T>(IEnumerable<T> Data);

    Task<bool> InsertOrReplace<T>(T Data);

    Task<bool> DeleteAllDataAsync<T>();

    Task<bool> UpdateAllDataAsync(IEnumerable Data);

    Task<List<T>> GetAllDataAsync<T>() where T : new();

    Task<T> GetDataByPkAsync<T>(object pk) where T : new();

    Task<T> GetDataAsync<T>(Expression<Func<T, bool>> predicate) where T : new();

    Task<List<T>> GetAllDataQueryAsync<T>(Expression<Func<T, bool>> predicate = null) where T : new();
}