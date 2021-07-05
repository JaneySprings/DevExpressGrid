using DevExpressGrid.Domain;
using DevExpressGrid.Extensions;
using DevExpressGrid.Network;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DevExpressGrid.UI {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditorPage : ContentPage {
        private readonly EditorViewModel viewModel = new EditorViewModel();
        private readonly IResultListener listener;

        public EditorPage(IResultListener listener) {
            InitializeComponent();

            BindingContext = this.viewModel;
            this.listener = listener;
        }

        private void Button_Clicked(object sender, System.EventArgs e) {
            if (this.editText.Text != null) {
                if (this.editText.Text == "" || this.editText.Text.Split(' ').Length != 2) {
                    DisplayAlert("Error", "Name is incorrect format!", "Cancel");
                } else {
                    this.listener.OnPageResult(
                        new EmployeeItem(this.editText.Text, this.viewModel.ImageSrc),
                        ResultApiCodes.Create);
                    Navigation.PopAsync();
                }
            }
        }

        private async void Button2_Clicked(object sender, System.EventArgs e) {
            FileResult photo = await MediaPicker.PickPhotoAsync();

            if (photo != null) {
                this.viewModel.SetImageResource(photo.FullPath);
            }
        }
    }
}