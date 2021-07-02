using DevExpressGrid.local;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;

namespace DevExpressGrid.network {
    class DevExpressApi {
        //https://js.devexpress.com/Demos/SalesViewer/odata/DaySaleDtoes

        /* TODO */
        private const string BASE_URL = "https://vk.com/doc474604959_603599666?hash=56a52821f5a63bc9fe&dl=GQ3TINRQGQ4TKOI:1625135720:fdc4b81f6d57b0630b&api=1&no_preview=1";
        private ObservableCollection<Employee> response = new ObservableCollection<Employee>();

        /* Set listener for network request */
        public ObservableCollection<Employee> provideObservable() { return response; }

        public async void requestSalesViewer() {
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

        public interface IResponseListener {
            void onSuccess(EmployeesDTO response);
            void onError(string error);
        }
    }
}