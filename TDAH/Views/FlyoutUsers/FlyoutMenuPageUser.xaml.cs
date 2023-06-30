using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDAH.ViewModels.Dashboard;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TDAH.Views.FlyoutUsers
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FlyoutMenuPageUser : ContentPage
	{
		public FlyoutMenuPageUser ()
		{
			InitializeComponent ();
            BindingContext = new UsersViewModel();
        }
	}
}