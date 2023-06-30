using Aplicacion.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace TDAH.ViewModels.Startup
{
    //public class NewAdminViewModel

    public class NewAdminViewModel : INotifyPropertyChanged
    {

        private string nombre;
        private string apellidoPaterno;
        private string apellidoMaterno;
        private string correo;
        private string contrasena;
        private int? idUsuario;
        private int? idCurso;
        private int? idTipoPregunta;

        public int? IdUsuario
        {
            get => idUsuario;
            set => SetProperty(ref idUsuario, value);
        }

        public int? IdCurso
        {
            get => idCurso;
            set => SetProperty(ref idCurso, value);
        }

        public int? IdTipoPregunta
        {
            get => idTipoPregunta;
            set => SetProperty(ref idTipoPregunta, value);
        }

        public string Nombre
        {
            get => nombre;
            set => SetProperty(ref nombre, value);
        }

        public string ApellidoPaterno
        {
            get => apellidoPaterno;
            set => SetProperty(ref apellidoPaterno, value);
        }

        public string ApellidoMaterno
        {
            get => apellidoMaterno;
            set => SetProperty(ref apellidoMaterno, value);
        }

        public string Correo
        {
            get => correo;
            set => SetProperty(ref correo, value);
        }

        public string Contrasena
        {
            get => contrasena;
            set => SetProperty(ref contrasena, value);
        }

        public Command RegistrarCommand { get; }

        public NewAdminViewModel()
        {
            RegistrarCommand = new Command(Registrar);
        }

        /// <summary>
        /// Método para validar si algunos datos estan vacios, sino, llama a la funcion RealizarRegistro().
        /// </summary>
        private void Registrar()
        {
            if (string.IsNullOrWhiteSpace(Nombre) || string.IsNullOrWhiteSpace(ApellidoPaterno) ||
                string.IsNullOrWhiteSpace(ApellidoMaterno) || string.IsNullOrWhiteSpace(Correo) ||
                string.IsNullOrWhiteSpace(Contrasena))
            {
                // Mostrar alerta de campos vacíos
                Application.Current.MainPage.DisplayAlert("Error", "Por favor, completa todos los campos.", "Aceptar");
                return;
            }

            RealizarRegistro();
        }

        /// <summary>
        /// Método que se encarga de realizar el registro de administrador
        /// </summary>
        private async void RealizarRegistro()
        {
            var admin = new AdministradorModels
            {
                Nombre = Nombre,
                App = ApellidoPaterno,
                Apm = ApellidoMaterno,
                Correo = Correo,
                Contrasena = Contrasena,
                Id_usuario = IdUsuario,
                Id_cursos = IdCurso,
                Id_tipo_pregunta = IdTipoPregunta,
            };

            await App.SQLiteDB.SaveOfAdministradorAsync(admin);

            await App.Current.MainPage.DisplayAlert("Registro", "Se guardó de manera exitosa el registro", "Ok");

            //await App.Current.MainPage.Navigation.PushAsync(new Login());


            // Retroceder a la página anterior (quitar la página de registro del historial de navegación)
            await App.Current.MainPage.Navigation.PopAsync();

            // Navegar al inicio de sesión
            await App.Current.MainPage.Navigation.PushAsync(new MainPage());

        }



        // -------------------------------------------------------------------

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #endregion

    }

}
