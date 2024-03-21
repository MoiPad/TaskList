using TaskList.Models;
using TaskList.ViewModels;
using System.Collections.Generic;

namespace TaskList.Views;

public partial class AddTareaPage : ContentPage
{  
    private String Estado2;

    private AddTareaPageViewModel _viewModel;
    public AddTareaPage()
    {
        InitializeComponent();
        _viewModel = new AddTareaPageViewModel();
        this.BindingContext = _viewModel;
    }

    public AddTareaPage(Tarea tarea)
    {
        
        tarea.Estado = Estado2;
        
        InitializeComponent();
        _viewModel = new AddTareaPageViewModel(tarea);
        this.BindingContext = _viewModel;
    }

    private void OnPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;

        if (selectedIndex != -1)
        {
            Estado2 = picker.Items[selectedIndex];
            //MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert("AVISO", "Seleccionado "+ Estado2, "Aceptar"));
        }
    }
}