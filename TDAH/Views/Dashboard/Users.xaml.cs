using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDAH.Flyout;
using TDAH.ViewModels.Dashboard;
using TDAH.Views.FlyoutUsers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TDAH.Views.Dashboard
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Users : FlyoutPage
    {
		public Users ()
		{
			InitializeComponent ();
            FlyoutUser.ListViewUser.ItemSelected += OnSelectedItem;
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void OnSelectedItem(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as FlyoutItemPageUser;
            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetPage));
                FlyoutUser.ListViewUser.SelectedItem = null;
                IsPresented = false;

            }
        }

    }
}