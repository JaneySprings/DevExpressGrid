using DevExpress.XamarinForms.DataGrid;
using DevExpressGrid.local;
using DevExpressGrid.network;
using DevExpressGrid.ui;
using Xamarin.Forms;

namespace DevExpressGrid {
    public partial class MainPage: ContentPage {

        public MainPage() {
            Initializer.Init();
            InitializeComponent();
        }

        protected override void OnAppearing() {
            base.OnAppearing();
           
            gridLayout.ItemsSource = DevExpressApi.provideObservable();


            DevExpressApi.requestSalesViewer(/*"2020-05-10", "2020-05-15"*/);
        }

        private void SwipeItem_Tap(object sender, SwipeItemTapEventArgs e)  {
            DevExpressApi.provideObservable().Remove((Employee)e.Item);
        }

        private async void gridLayout_SelectionChanged(object sender, DevExpress.XamarinForms.DataGrid.SelectionChangedEventArgs e) {
            var item = DevExpressApi.getItemByPosition(e.RowHandle);

            if (item != null) 
                await Navigation.PushAsync(new ProfilePage(item));
        }

        private async void ImageButton_Clicked(object sender, System.EventArgs e) {
            await DisplayAlert("WARNING!", "Your mom is so big", "ok");
        }
    }
}