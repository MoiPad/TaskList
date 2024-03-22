using TaskList.ViewModels;

namespace TaskList.Views;

public partial class TareaMainPage : ContentPage
{
    private TareasMainPageViewModel viewModel;
    public TareaMainPage()
    {
        InitializeComponent();
        viewModel = new TareasMainPageViewModel();
        this.BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        viewModel.GetAll();
    }
}