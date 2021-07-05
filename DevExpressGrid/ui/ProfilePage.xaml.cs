using DevExpressGrid.Network;
using System;
using DevExpressGrid.Domain;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DevExpressGrid.Extensions;

namespace DevExpressGrid.UI {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage {
        private readonly ProfileViewModel viewModel;
        private readonly IResultListener listener;


        public ProfilePage(EmployeeItem item, IResultListener listener) {
            InitializeComponent();

            this.viewModel = new ProfileViewModel(item);
            BindingContext = this.viewModel;

            this.listener = listener;
        }


        private void Button_Clicked(object sender, EventArgs e) {
            this.listener.OnPageResult(this.viewModel.Item, ResultApiCodes.Delete);
            Navigation.PopAsync();
        }
    }
}