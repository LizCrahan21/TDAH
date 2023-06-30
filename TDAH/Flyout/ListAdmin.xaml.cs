using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDAH.ViewModels.Dashboard;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TDAH.Flyout
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListAdmin : ContentPage
    {
        public ListAdmin()
        {
            InitializeComponent();
            LlenarDatosAdmin();
        }

        public async void LlenarDatosAdmin()
        {
            var adminLista = await App.SQLiteDB.GetOfAdministradorAsync();

            if (adminLista != null)
            {
                Lst_Administradores.ItemsSource = adminLista;
            }
        }

    }
}