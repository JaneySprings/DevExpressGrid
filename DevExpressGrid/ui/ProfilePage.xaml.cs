using DevExpressGrid.local;
using DevExpressGrid.network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DevExpressGrid.ui {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage {
        private Employee user = null;


        public ProfilePage(Employee user) {
            InitializeComponent();

            this.user = user;
        }

        protected override void OnAppearing() {
            base.OnAppearing();

            tag.Text = "#" + user.firstName;

            photo.Source = user.image;
            title.Text = user.fullName;

            dataForm.DataObject = user;
        }


        private void Button_Clicked(object sender, EventArgs e) {
            DevExpressApi.updateElement((Employee)(dataForm.DataObject));
            Navigation.PopAsync();
        }
    }
}