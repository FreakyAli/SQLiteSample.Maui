using SQLite;

namespace SQLiteSample.Maui;

public class GroceryModel
{
    [PrimaryKey,AutoIncrement]
    public int Id { get; set; }
    public string? Name { get; set; }
}