using DevExpressGrid.network;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace DevExpressGrid.domain {
    public class ProfileViewModel: INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        private EmployeeItem item = null;

        public EmployeeItem Item {
            get { return item; }
            set { 
                item = value;
                OnPropertyChanged("Item");
            }
        }
        public ImageSource ImageSrc {
            get { return item.ImageSrc; }
        }
        public string Title {
            get { return item.FullName; }
        }

        public ProfileViewModel(EmployeeItem item) {
            this.item = item;
        }


        protected void OnPropertyChanged(string propName) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
