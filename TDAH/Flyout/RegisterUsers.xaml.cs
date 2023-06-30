using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDAH.ViewModels.Startup;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TDAH.Flyout
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterUsers : ContentPage
    {
        public RegisterUsers()
        {
            InitializeComponent();
            BindingContext = new RegisterUserConfig();
        }
    }
}