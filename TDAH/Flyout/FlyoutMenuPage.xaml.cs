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
    public partial class FlyoutMenuPage : ContentPage
    {
        public FlyoutMenuPage()
        {
            InitializeComponent();
            BindingContext = new AdminViewModel();
        }
    }
}