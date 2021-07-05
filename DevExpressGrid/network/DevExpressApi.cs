using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace DevExpressGrid.network {
    public class DevExpressApi {
        /* Repo:[https://raw.githubusercontent.com/JaneySprings/DevExpressGrid]
         * Path:[DevExpressGrid/local/data.json]
         */
        private const string BASE_URL = "https://raw.githubusercontent.com/JaneySprings/DevExpressGrid/main/DevExpressGrid/local/data.json";
        private IRequestStateListener listener;

        public DevExpressApi(IRequestStateListener listener) {
            this.listener = listener; 
        }

        /* Load data from database */
        public async Task<EmployeesDTO> requestEmployees() {
            listener.onStateChanged(LoadStates.Loading);

            using (WebClient webClient = new WebClient()) {
                try {
                    Uri uri = new Uri(BASE_URL);
                    byte[] data = await webClient.DownloadDataTaskAsync(uri);

                    using (Stream stream = new MemoryStream(data)) {
                        listener.onStateChanged(LoadStates.Success);

                        var jsonSerializer = new DataContractJsonSerializer(typeof(EmployeesDTO));
                        return (EmployeesDTO)jsonSerializer.ReadObject(stream);
                    }
                }
                catch(WebException exception) {
                    Console.WriteLine("EXCEPTION: " + exception.Message);
                    listener.onStateChanged(LoadStates.Error);
                    return null; 
                }
            }
        }

        public interface IRequestStateListener {
            void onStateChanged(LoadStates state);
        }

        public enum LoadStates { Success, Loading, Error }
    }
}