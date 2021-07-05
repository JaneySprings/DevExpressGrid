using DevExpress.XamarinForms.DataGrid;
using DevExpressGrid.Domain;
using DevExpressGrid.Extensions;
using DevExpressGrid.Network;
using DevExpressGrid.UI;
using System;
using Xamarin.Forms;

namespace DevExpressGrid {
    public partial class MainPage: ContentPage, IResultListener {

        private readonly MainViewModel viewModel = new MainViewModel();
        private readonly MainPage context;

        public MainPage() {
            Initializer.Init();
            InitializeComponent();

            BindingContext = this.viewModel;
            this.context = this;
        }

        public void OnPageResult(EmployeeItem item, ResultApiCodes arg) {
            if (arg == ResultApiCodes.Delete) {
                this.viewModel.ReplaceItem(item);
            } else if (arg == ResultApiCodes.Create) {
                this.viewModel.AddItem(item);
            }
        }

        protected override void OnAppearing() {
            base.OnAppearing();

            this.viewModel.RequestEmployees();
        }

        private async void GridLayout_Tap(object sender, DataGridGestureEventArgs e) {
            await Navigation.PushAsync(new ProfilePage((EmployeeItem)e.Item, this.context));
        }

        private void SwipeItem_Tap(object sender, SwipeItemTapEventArgs e) {
            this.viewModel.RemoveItem(e.RowHandle);
        }

        private async void ImageButton_Clicked(object sender, EventArgs e) {
            await Navigation.PushAsync(new EditorPage(this.context));
        }
    }
}