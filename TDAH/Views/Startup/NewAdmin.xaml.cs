using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDAH.ViewModels.Startup;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TDAH.Views.Startup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewAdmin : ContentPage
    {
        public NewAdmin()
        {
            InitializeComponent();
            BindingContext = new NewAdminViewModel();
        }
    }
}