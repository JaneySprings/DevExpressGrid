using DevExpressGrid.network;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DevExpressGrid.domain {
    class MainViewModel: DevExpressApi.IRequestStateListener, INotifyPropertyChanged {
        private ObservableCollection<EmployeeItem> employeeItems = new ObservableCollection<EmployeeItem>();
        public ObservableCollection<EmployeeItem> EmployeeItems {
            get { return employeeItems; }
        }

        private DevExpressApi apiProvider;

        public event PropertyChangedEventHandler PropertyChanged;

        private string pageTitle = "";
        public string PageTitle {
            get { return pageTitle; }
            set { 
                pageTitle = value;
                OnPropertyChanged("PageTitle");
            }
        }

        private bool isLoading = false;
        public bool IsLoading {
            get { return isLoading; }
            set {
                isLoading = value;
                OnPropertyChanged("IsLoading");
            }
        }


        public MainViewModel() { 
            apiProvider = new DevExpressApi(this); 
        }

        /* Get users from network */
        public async void requestEmployees() {
            if (employeeItems.Count == 0) {
                var result = await apiProvider.requestEmployees();

                foreach (Employee model in result.employees) {
                    employeeItems.Add(new EmployeeItem(model));
                }
            }
        }
        /* Delete user from list */
        public void removeItem(int position) {
            if (position >= 0 && position < employeeItems.Count) {
                employeeItems.RemoveAt(position);
            }
        }
        /* Replave user from result */
        public void replaceItem(EmployeeItem item) {
            for (int i = 0; i < employeeItems.Count; i++) {
                if (employeeItems[i].id == item.id) {
                    employeeItems[i] = item;
                    return;
                }
            }
        }
        /* Add new item to top */
        public void addItem(EmployeeItem item) {
            employeeItems.Insert(0, item);
        }



        public void onStateChanged(DevExpressApi.LoadStates state) {
            if (state == DevExpressApi.LoadStates.Success) {
                PageTitle = "Facebook";
                IsLoading = false;
            } else if (state == DevExpressApi.LoadStates.Loading) {
                PageTitle = "Loading...";
                IsLoading = true;
            } else {
                PageTitle = "Error";
                IsLoading = false;
            }
        }

        protected void OnPropertyChanged(string propName) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            } 
        }
    }
}
