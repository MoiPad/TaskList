using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TaskList.Models;
using TaskList.Services;
using TaskList.Views;

namespace TaskList.ViewModels
{
    public partial class TareasMainPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Tarea> tareaCollection = new ObservableCollection<Tarea>();

        private readonly TareaService _tareaService;

        public TareasMainPageViewModel()
        {
            _tareaService = new TareaService();
        }

        /// <summary>
        /// Obtiene el listado de Tareas
        /// </summary>
        public void GetAll()
        {
            var getAll = _tareaService.GetAll();

            if (getAll?.Count > 0)
            {
                TareaCollection.Clear();
                foreach (var tarea in getAll)
                {
                    TareaCollection.Add(tarea);
                }
            }
        }

        /// <summary>
        /// Redirecciona al formulario de Estudiantes
        /// </summary>
        /// <returns></returns>
        [RelayCommand]
        private async Task GoToAddTareaPage()
        {
            await App.Current!.MainPage!.Navigation.PushAsync(new AddTareaPage());
        }

        /// <summary>
        /// Selecciona el registro para editar o eliminar
        /// </summary>
        /// <param name="tarea">Objeto a editar o eliminar</param>
        /// <returns>Actualizar: Nos lleva al formulario de Empleado, Eliminar: Elimina el registro</returns>
        [RelayCommand]
        private async Task SelectEstudiantes(Tarea tarea)
        {
            try
            {
                string res = await App.Current!.MainPage!.DisplayActionSheet("Operación", "Cancelar", null, "Actualizar", "Eliminar");

                switch (res)
                {
                    case "Actualizar":
                        await App.Current.MainPage.Navigation.PushAsync(new AddTareaPage(tarea));
                        break;
                    case "Eliminar":
                        bool respuesta = await App.Current!.MainPage!.DisplayAlert("Eliminar Tarea", "¿Desea eliminar la tarea?", "Si", "No");

                        if (respuesta)
                        {
                            int del = _tareaService.Delete(tarea);
                            if (del > 0)
                            {
                                TareaCollection.Remove(tarea);
                            }
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                Alerta("ERROR", ex.Message);
            }
        }

        /// <summary>
        /// Método personalizado para construir alertas
        /// </summary>
        /// <param name="Tipo">Tipo de Alerta</param>
        /// <param name="Mensaje">Mensaje de Alerta</param>
        private void Alerta(String Tipo, String Mensaje)
        {
            MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(Tipo, Mensaje, "Aceptar"));
        }
    }
}
