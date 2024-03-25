namespace SQLiteSample.Maui;

public partial class MainPage : ContentPage
{
    private readonly MainViewModel? viewModel;

    public MainPage()
    {
        InitializeComponent();
        BindingContext = viewModel = Application.Current?.Handler?.MauiContext?.
                                     Services?.GetService<MainViewModel>();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        viewModel?.OnViewAppearing();
    }
}