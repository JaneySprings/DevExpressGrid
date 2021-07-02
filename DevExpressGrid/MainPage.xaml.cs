using DevExpress.XamarinForms.DataGrid;
using DevExpressGrid.local;
using DevExpressGrid.network;
using DevExpressGrid.presentation;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace DevExpressGrid {
    public partial class MainPage: ContentPage {
        private DevExpressApi apiProvider = new DevExpressApi();

        public MainPage() {
            Initializer.Init();
            InitializeComponent();
        }

        protected override void OnAppearing() {
            base.OnAppearing();
           
            gridLayout.ItemsSource = apiProvider.provideObservable();
            addButton.Clicked += addButton_Clicked;

            apiProvider.requestSalesViewer(/*"2020-05-10", "2020-05-15"*/);
        }

        private void addButton_Clicked(object sender, System.EventArgs e) {
            apiProvider.provideObservable().Add(new Employee());
        }

        private void SwipeItem_Tap(object sender, SwipeItemTapEventArgs e)  {
            apiProvider.provideObservable().Remove((Employee)e.Item);
        }
    }
}