﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TDAH.ViewModels.Dashboard
{
    public class UsersViewModel
    {
        public Command CerrarSesionCommand { get; }

        public UsersViewModel()
        {
            CerrarSesionCommand = new Command(CerrarSesion);
        }

        private async void CerrarSesion()
        {
            Preferences.Remove("IsLoggedIn");
            Preferences.Remove("UserEmail");

            if (App.Current.MainPage != null)
            {
                await App.Current.MainPage.Navigation.PushAsync(new MainPage());
            }
        }

    }
}
