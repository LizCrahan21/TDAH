using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TDAH.Flyout
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListUsers : ContentPage
    {
        public ListUsers()
        {
            InitializeComponent();
            LlenarDatosUsuarios();
        }

        public async void LlenarDatosUsuarios()
        {
            var UsuarioLista = await App.SQLiteDB.GetUsuariosAsync();

            if (UsuarioLista != null)
            {
                Lst_Usuarios.ItemsSource = UsuarioLista;
            }
        }

    }
}