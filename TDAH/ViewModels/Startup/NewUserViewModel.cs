using Aplicacion.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace TDAH.ViewModels.Startup
{

    public class NewUserViewModel : INotifyPropertyChanged
    {

        private string nombre;
        private string apellidoPaterno;
        private string apellidoMaterno;
        private int telefono;
        private string sexo;
        private string correo;
        private string contrasena;
        private DateTime fechaNacimiento;
        private int? idCurso;
        private int? idPregunta;

        public int? IdPregunta
        {
            get => idPregunta;
            set => SetProperty(ref idPregunta, value);
        }

        public int? IdCurso
        {
            get => idCurso;
            set => SetProperty(ref idCurso, value);
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

        public int Telefono
        {
            get => telefono;
            set => SetProperty(ref telefono, value);
        }

        public string Sexo
        {
            get => sexo;
            set => SetProperty(ref sexo, value);
        }

        public List<string> OpcionesSexo { get; } = new List<string> { "Masculino", "Femenino" };

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
        public DateTime FechaNacimiento
        {
            get => fechaNacimiento;
            set => SetProperty(ref fechaNacimiento, value.Date);
        }

        public Command RegistrarCommand { get; }

        public NewUserViewModel()
        {
            RegistrarCommand = new Command(Registrar);
        }

        /// <summary>
        /// Método para validar si algunos datos estan vacios, sino, llama a la funcion RealizarRegistro().
        /// </summary>
        private void Registrar()
        {
            if (string.IsNullOrWhiteSpace(Nombre) || string.IsNullOrWhiteSpace(ApellidoPaterno) ||
                string.IsNullOrWhiteSpace(ApellidoMaterno) || Telefono == 0 ||
                string.IsNullOrWhiteSpace(Sexo) || string.IsNullOrWhiteSpace(Correo) ||
                string.IsNullOrWhiteSpace(Contrasena) || FechaNacimiento == default(DateTime))
            {
                // Mostrar alerta de campos vacíos
                Application.Current.MainPage.DisplayAlert("Error", "Por favor, completa todos los campos.", "Aceptar");
                return;
            }

            RealizarRegistro();
        }

        /// <summary>
        /// Método que se encarga de realizar el registro de usuarios
        /// </summary>
        private async void RealizarRegistro()
        {
            var usuario = new UsuariosModels
            {
                Nombre = Nombre,
                App = ApellidoPaterno,
                Apm = ApellidoMaterno,
                Telefono = Telefono,
                Sexo = Sexo,
                Fecha_n = FechaNacimiento,
                Correo = Correo,
                Contrasena = Contrasena,
                Id_curso = idCurso,
                Id_pregunta = idPregunta
            };

            await App.SQLiteDB.SaveUsuarioAsync(usuario);

            await App.Current.MainPage.DisplayAlert("Registro", "Se guardó de manera exitosa el usuario", "Ok");

            await App.Current.MainPage.Navigation.PushAsync(new MainPage());
        }


        // -----------------------------------------------------------------------------------------
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
