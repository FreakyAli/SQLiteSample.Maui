using SQLite;
using SQLiteNetExtensions.Attributes;

namespace SQLiteSample.Maui;

public class GroceryModel
{
    [PrimaryKey,AutoIncrement]
    public int Id { get; set; }

    public string? Name { get; set; }

    [OneToMany(CascadeOperations = CascadeOperation.All)]
    public List<string> OneToManyAll { get; set; }
      = new List<string>
        {
            "This is some random data",
            "To show how relational cascading would be done",
            "for a basic primitive type",
            "Its the same for non primitive types too",
            "This data is hardcoded but can be added from your DTOs as well obviously"
        };
}