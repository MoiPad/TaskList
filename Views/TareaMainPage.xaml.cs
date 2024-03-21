using TaskList.ViewModels;

namespace TaskList.Views;

public partial class TareaMainPage : ContentPage
{
    private TareasMainPageViewModel _viewModel;
    public TareaMainPage()
    {
        InitializeComponent();
        _viewModel = new TareasMainPageViewModel();
        this.BindingContext = _viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.GetAll();
    }
}