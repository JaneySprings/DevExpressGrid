using DevExpress.XamarinForms.DataGrid;
using DevExpressGrid.domain;
using DevExpressGrid.extensions;
using DevExpressGrid.network;
using DevExpressGrid.ui;
using System;
using Xamarin.Forms;

namespace DevExpressGrid {
    public partial class MainPage: ContentPage, IResultListener {

        private MainViewModel viewModel = new MainViewModel();
        private MainPage context;

        public MainPage() {
            Initializer.Init();
            InitializeComponent();

            BindingContext = viewModel;
            context = this;
        }

        public void onPageResult(EmployeeItem item, ResultApiCodes arg) {
            if (arg == ResultApiCodes.Delete) viewModel.replaceItem(item);
            else if (arg == ResultApiCodes.Create) viewModel.addItem(item);
        }

        protected override void OnAppearing() {
            base.OnAppearing();

            viewModel.requestEmployees();
        }

        private async void gridLayout_Tap(object sender, DataGridGestureEventArgs e) {
            await Navigation.PushAsync(new ProfilePage((EmployeeItem)e.Item, context));
        }

        private void SwipeItem_Tap(object sender, SwipeItemTapEventArgs e) {
            viewModel.removeItem(e.RowHandle);
        }

        private async void ImageButton_Clicked(object sender, EventArgs e) {
            await Navigation.PushAsync(new EditorPage(context));
        }
    }
}