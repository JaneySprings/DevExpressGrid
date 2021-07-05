using DevExpressGrid.Network;
using System.ComponentModel;
using Xamarin.Forms;

namespace DevExpressGrid.Domain {
    public class ProfileViewModel: INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        private EmployeeItem item = null;

        public EmployeeItem Item {
            get => this.item;
            set {
                this.item = value;
                OnPropertyChanged("Item");
            }
        }
        public ImageSource ImageSrc => this.item.ImageSrc;
        public string Title => this.item.FullName;

        public ProfileViewModel(EmployeeItem item) {
            this.item = item;
        }


        protected void OnPropertyChanged(string propName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
