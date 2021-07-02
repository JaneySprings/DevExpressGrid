using DevExpressGrid.local;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;

namespace DevExpressGrid.network {
    static class DevExpressApi {

        /* Old task -> https://js.devexpress.com/Demos/SalesViewer/odata/DaySaleDtoes */
        /* TODO: VK update media hash after 24h */
        private const string BASE_URL = "https://vk.com/doc474604959_603599666?hash=c3e3bd5e5cfc222e35&dl=GQ3TINRQGQ4TKOI:1625230011:dd7a9e62b179cf876c&api=1&no_preview=1";
        private static ObservableCollection<Employee> response = new ObservableCollection<Employee>();

        /* Set listener for network request */
        public static ObservableCollection<Employee> provideObservable() { return response; }

        /* Load data from database */
        public static async void requestSalesViewer() {
            using (WebClient webClient = new WebClient()) {
                try {
                    Uri uri = new Uri(BASE_URL);
                    byte[] data = await webClient.DownloadDataTaskAsync(uri);

                    using (Stream stream = new MemoryStream(data)) {
                        var jsonSerializer = new DataContractJsonSerializer(typeof(EmployeesDTO));
                        var dto = (EmployeesDTO)jsonSerializer.ReadObject(stream);

                        foreach(var item in dto.employees)
                            response.Add(item);
                    }
                }
                catch { }
            }
        }

        /* Get data from position */
        public static Employee getItemByPosition(int position) {
            return response.Count != 0 ? response[position] : null;
        }

        /* Update element */
        public static void updateElement(Employee item) {
            for (int i = 0; i < response.Count; i++) { 
                if (response[i].id == item.id) {
                    response[i] = item;
                    break;
                }
            }
        }
    }
}