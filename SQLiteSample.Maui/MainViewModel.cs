using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using SQLiteSample.Maui.Datastore;

namespace SQLiteSample.Maui;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<GroceryModel>? groceries;
    [ObservableProperty]
    private string? entryText;
    private readonly ISqliteService sqliteService;

    public ICommand AddCommand { get; set; }

    public ICommand DeleteCommand { get; set; }

    public MainViewModel(ISqliteService sqliteService)
    {
        this.sqliteService = sqliteService;
        AddCommand = new Command(ExecuteAdd);
        DeleteCommand = new Command<GroceryModel>(ExecuteDelete);
    }

    private async void ExecuteDelete(GroceryModel obj)
    {
        Groceries?.Remove(obj);
        await sqliteService.DeleteDataAsync<GroceryModel>(obj.Id);
    }

    internal async void OnViewAppearing()
    {
        var getExistingData = await sqliteService.GetAllDataAsync<GroceryModel>();
        Groceries = new ObservableCollection<GroceryModel>(getExistingData);
    }

    private async void ExecuteAdd()
    {
        if (string.IsNullOrWhiteSpace(EntryText))
        {
            return;
        }

        var grocery = new GroceryModel
        {
            Name = this.EntryText
        };

        var added = await sqliteService.InsertDataAsync(grocery);
        if (added)
        {
            Groceries?.Add(grocery);
        }
        this.EntryText = string.Empty;
    }
}