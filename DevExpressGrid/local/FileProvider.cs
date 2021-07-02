
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace DevExpressGrid.local {
    public class FileProvider {
        private const string PATH = "C:\\Users\\student21\\source\\repos\\DevExpressGrid\\DevExpressGrid\\local\\";
        private const string FILE_NAME = "data.json";

        public EmployeesDTO provideModels() {
            string meta = File.ReadAllText(PATH + FILE_NAME);
            var jsonSerializer = new DataContractJsonSerializer(typeof(EmployeesDTO));

            return (EmployeesDTO)jsonSerializer.ReadObject(new MemoryStream(Encoding.UTF8.GetBytes(meta)));
        }
    }
}
