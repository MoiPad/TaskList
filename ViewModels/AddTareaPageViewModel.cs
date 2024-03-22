using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using TaskList.Models;
using TaskList.Services;

namespace TaskList.ViewModels
{
    public partial class AddTareaPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private int id;

        [ObservableProperty]
        private string nombre;

        [ObservableProperty]
        private string estado;

        private readonly TareaService _tareaservice;



        public AddTareaPageViewModel()
        {
            _tareaservice = new TareaService();
        }

        public AddTareaPageViewModel(Tarea tarea)
        {
            Id = tarea.Id;
            Nombre = tarea.Nombre;
            Estado = tarea.Estado;

            _tareaservice = new TareaService();
        }
        public List<string> EstadosDisponibles { get; } = new List<string>
        {
            "Por hacer",
            "En progreso",
            "Finalizada"
        };

   

        /// <summary>
        /// Agrega o actualiza un registro
        /// </summary>
        /// <returns></returns>
        [RelayCommand]
        private async Task AddUpdate()
        {
            
            try
            {
                Tarea tarea = new Tarea
                {
                    Id = Id,
                    Nombre = Nombre,
                    Estado = Estado
                };

                if (Validar(tarea)) {
                    if (Id == 0)
                    {
                        _tareaservice.Insert(tarea);
                    }
                    else
                    {
                        _tareaservice.Update(tarea);
                    }
                    await App.Current!.MainPage!.Navigation.PopAsync();
                }
            }
            catch (Exception ex)
            {
                Alerta("ERROR", ex.Message);
            }
        }

        /// <summary>
        /// Valida que los campos no esten vacíos
        /// </summary>
        /// <param name="Tarea">Objeto a validar</param>
        /// <returns></returns>
        private bool Validar(Tarea tarea)
        {
            try
            {
                if (tarea.Nombre == null || tarea.Nombre == "")
                {
                    Alerta("ADVERTENCIA", "Escriba el nombre de la tarea");
                    return false;
                }

                if (tarea.Estado == "Select Estado")
                {
                    Alerta("ADVERTENCIA", "Seleccione un estado valido");
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Alerta("ERROR", ex.Message);
                return false;
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
