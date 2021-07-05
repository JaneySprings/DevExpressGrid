using DevExpressGrid.Network;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DevExpressGrid.Domain {
    class MainViewModel: DevExpressApi.IRequestStateListener, INotifyPropertyChanged {
        public ObservableCollection<EmployeeItem> EmployeeItems { get; } = new ObservableCollection<EmployeeItem>();

        private readonly DevExpressApi apiProvider;

        public event PropertyChangedEventHandler PropertyChanged;

        private string pageTitle = "";
        public string PageTitle {
            get => this.pageTitle;
            set {
                this.pageTitle = value;
                OnPropertyChanged("PageTitle");
            }
        }

        private bool isLoading = false;
        public bool IsLoading {
            get => this.isLoading;
            set {
                this.isLoading = value;
                OnPropertyChanged("IsLoading");
            }
        }


        public MainViewModel() {
            this.apiProvider = new DevExpressApi(this);
        }

        public async void RequestEmployees() {
            if (EmployeeItems.Count == 0) {
                EmployeesDTO result = await this.apiProvider.RequestEmployees();

                foreach (Employee model in result.employees) {
                    EmployeeItems.Add(new EmployeeItem(model));
                }
            }
        }
        public void RemoveItem(int position) {
            if (position >= 0 && position < EmployeeItems.Count) {
                EmployeeItems.RemoveAt(position);
            }
        }
        public void ReplaceItem(EmployeeItem item) {
            for (int i = 0; i < EmployeeItems.Count; i++) {
                if (EmployeeItems[i].id == item.id) {
                    EmployeeItems[i] = item;
                    return;
                }
            }
        }
        public void AddItem(EmployeeItem item) {
            EmployeeItems.Insert(0, item);
        }



        public void OnStateChanged(DevExpressApi.LoadStates state) {
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
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
