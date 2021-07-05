using DevExpressGrid.network;
using System;
using DevExpressGrid.domain;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DevExpressGrid.extensions;

namespace DevExpressGrid.ui {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage {
        private ProfileViewModel viewModel;
        private IResultListener listener;
        

        public ProfilePage(EmployeeItem item, IResultListener listener) {
            InitializeComponent();

            viewModel = new ProfileViewModel(item);
            BindingContext = viewModel;

            this.listener = listener;
        }


        private void Button_Clicked(object sender, EventArgs e) {
            listener.onPageResult(viewModel.Item, ResultApiCodes.Delete);
            Navigation.PopAsync();
        }
    }
}