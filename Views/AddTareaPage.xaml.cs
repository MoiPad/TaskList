using TaskList.Models;
using TaskList.ViewModels;
using System.Collections.Generic;

namespace TaskList.Views;

public partial class AddTareaPage : ContentPage
{
    private AddTareaPageViewModel viewModel;
    public AddTareaPage()
    {
        InitializeComponent();
        viewModel = new AddTareaPageViewModel();
        this.BindingContext = viewModel;
    }


    public AddTareaPage(Tarea tarea)
    {
        InitializeComponent();
        viewModel = new AddTareaPageViewModel(tarea);
        this.BindingContext = viewModel;
    }

}