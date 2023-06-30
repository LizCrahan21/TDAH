using Aplicacion.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TDAH.Views.Dashboard;
using TDAH.Views.Startup;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TDAH
{
    public partial class MainPage : ContentPage
    {
        public ICommand IrARegistrarCommand { get; }
        public MainPage()
        {
            InitializeComponent();
            RedirigirUsuarioSegunInicioSesion();

            IrARegistrarCommand = new Command(async () =>
            {
                await Navigation.PushAsync(new NewUser());
            });
            BindingContext = this;
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void BtnIniciar_Clicked(object sender, EventArgs e)
        {

            string nombreArchivo = "TDAH.db3";
            string rutaCarpeta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);
            string rutaBaseDatos = Path.Combine(rutaCarpeta, nombreArchivo);

            string correo = Txt_Correo.Text;
            string contraseña = Txt_Contrasena.Text;

            using (SQLiteConnection conn = new SQLiteConnection(rutaBaseDatos))
            {

                UsuariosModels usuario = conn.Table<UsuariosModels>().FirstOrDefault(u => u.Correo == correo && u.Contrasena == contraseña);
                AdministradorModels administrador = conn.Table<AdministradorModels>().FirstOrDefault(u => u.Correo == correo && u.Contrasena == contraseña);

                if (usuario != null)
                {
                    // Inicio de sesión exitoso como usuario
                    await DisplayAlert("Excelente", "Datos correctos", "Ok");
                    await Navigation.PushAsync(new Users());
                    NavigationPage.SetHasNavigationBar(this, false);

                    Txt_Correo.Text = "";
                    Txt_Contrasena.Text = "";

                    // Guardar los datos del usuario en las preferencias compartidas
                    Preferences.Set("IsLoggedIn", true);
                    Preferences.Set("UserEmail", usuario.Correo);
                }
                else if (administrador != null)
                {
                    // Inicio de sesión exitoso como administrador
                    await DisplayAlert("Excelente", "Datos correctos", "Ok");
                    NavigationPage.SetHasNavigationBar(this, false);
                    await Navigation.PushAsync(new Admin());

                    Txt_Correo.Text = "";
                    Txt_Contrasena.Text = "";

                    // Guardar los datos del administrador en las preferencias compartidas
                    Preferences.Set("IsLoggedIn", true);
                    Preferences.Set("UserEmail", administrador.Correo);
                }
                else
                {
                    // Inicio de sesión fallido
                    await DisplayAlert("Upss..", "Datos incorrectos", "Ok");
                    Txt_Correo.Text = "";
                    Txt_Contrasena.Text = "";
                }
            }

        }

        private async void RedirigirUsuarioSegunInicioSesion()
        {

            string nombreArchivo = "TDAH.db3";
            string rutaCarpeta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);
            string rutaBaseDatos = Path.Combine(rutaCarpeta, nombreArchivo);

            using (SQLiteConnection conn = new SQLiteConnection(rutaBaseDatos))
            {

                if (Preferences.Get("IsLoggedIn", false))
                {
                    string userEmail = Preferences.Get("UserEmail", string.Empty);
                    UsuariosModels usuario = conn.Table<UsuariosModels>().FirstOrDefault(u => u.Correo == userEmail);
                    AdministradorModels administrador = conn.Table<AdministradorModels>().FirstOrDefault(a => a.Correo == userEmail);
                    if (usuario != null)
                    {

                        NavigationPage.SetHasNavigationBar(this, false);
                        await Navigation.PushAsync(new Users());

                    }
                    else if (administrador != null)
                    {

                        NavigationPage.SetHasNavigationBar(this, false);
                        await Navigation.PushAsync(new Admin());

                    }

                }
            }

        }

    }
}
