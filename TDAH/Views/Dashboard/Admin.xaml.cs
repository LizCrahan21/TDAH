using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDAH.Flyout;
using TDAH.ViewModels.Dashboard;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TDAH.Views.Dashboard
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Admin : FlyoutPage
    {
		public Admin ()
		{
			InitializeComponent ();
            Flyout.ListView.ItemSelected += OnSelectedItem;
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void OnSelectedItem(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as FlyoutItemPage;
            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetPage));
                Flyout.ListView.SelectedItem = null;
                IsPresented = false;

            }
        }

    }
}