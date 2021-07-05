using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace DevExpressGrid.Network {
    public class DevExpressApi {
        /* Repo:[https://raw.githubusercontent.com/JaneySprings/DevExpressGrid]
         * Path:[DevExpressGrid/local/data.json]
         */
        private const string BASE_URL = "https://raw.githubusercontent.com/JaneySprings/DevExpressGrid/main/DevExpressGrid/local/data.json";
        private readonly IRequestStateListener listener;

        public DevExpressApi(IRequestStateListener listener) {
            this.listener = listener;
        }

        /* Load data from database */
        public async Task<EmployeesDTO> RequestEmployees() {
            this.listener.OnStateChanged(LoadStates.Loading);

            using (WebClient webClient = new WebClient()) {
                try {
                    Uri uri = new Uri(BASE_URL);
                    byte[] data = await webClient.DownloadDataTaskAsync(uri);

                    using (Stream stream = new MemoryStream(data)) {
                        this.listener.OnStateChanged(LoadStates.Success);

                        DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(EmployeesDTO));
                        return (EmployeesDTO)jsonSerializer.ReadObject(stream);
                    }
                } catch (WebException exception) {
                    Console.WriteLine("EXCEPTION: " + exception.Message);
                    this.listener.OnStateChanged(LoadStates.Error);
                    return null;
                }
            }
        }

        public interface IRequestStateListener {
            void OnStateChanged(LoadStates state);
        }

        public enum LoadStates { Success, Loading, Error }
    }
}