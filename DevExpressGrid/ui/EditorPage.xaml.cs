using DevExpressGrid.domain;
using DevExpressGrid.extensions;
using DevExpressGrid.network;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DevExpressGrid.ui {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditorPage : ContentPage {
        private EditorViewModel viewModel = new EditorViewModel();
        private IResultListener listener;

        public EditorPage(IResultListener listener) {
            InitializeComponent();

            BindingContext = viewModel;
            this.listener = listener; 
        }

        private void Button_Clicked(object sender, System.EventArgs e) {
            if (editText.Text != null) {
                if (editText.Text == "" || editText.Text.Split(' ').Length != 2) {
                    DisplayAlert("Error", "Name is incorrect format!", "Cancel");
                }
                else {
                    listener.onPageResult(
                        new EmployeeItem(editText.Text, viewModel.ImageSrc),
                        ResultApiCodes.Create);
                    Navigation.PopAsync();
                }
            }
        }

        private async void Button2_Clicked(object sender, System.EventArgs e) {
            var photo = await MediaPicker.PickPhotoAsync();

            if (photo != null) {
                viewModel.setImageResource(photo.FullPath);
            }
        }
    }
}