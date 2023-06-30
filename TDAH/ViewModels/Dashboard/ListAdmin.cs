using Aplicacion.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using TDAH.Flyout;

namespace TDAH.ViewModels.Dashboard
{
    public class ListAdmin : INotifyPropertyChanged
    {
        private ObservableCollection<AdministradorModels> _lst_Administradores;
        public ObservableCollection<AdministradorModels> Lst_Administradores
        {
            get { return _lst_Administradores; }
            set
            {
                _lst_Administradores = value;
                OnPropertyChanged();
            }
        }

        public ListAdmin()
        {
            LlenarDatosAdmin();
        }

        public async void LlenarDatosAdmin()
        {
            var adminLista = await App.SQLiteDB.GetOfAdministradorAsync();

            if (adminLista != null)
            {
                Lst_Administradores = new ObservableCollection<AdministradorModels>(adminLista);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
