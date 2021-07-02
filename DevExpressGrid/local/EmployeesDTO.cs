using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using Xamarin.Forms;

namespace DevExpressGrid.local {

    [DataContract]
    public class EmployeesDTO {

        [DataMember(Name = "Employees")]
        public List<Employee> employees;
    }

    [DataContract]
    public class Employee {
        public Employee() {
            id = 1331;
            firstName = "Abbc";
            lastName = "Xyyz";
            jobTitle = "Freelance";
            image = "-1";
        }

        [DataMember(Name = "Id")]
        public int id;

        [DataMember(Name = "FirstName")]
        public string firstName;

        [DataMember(Name = "LastName")]
        public string lastName;

        [DataMember(Name = "JobTitle")]
        public string jobTitle;

        [DataMember(Name = "ImageData")]
        public string image;

        public ImageSource src {
            get {
                var bytes = Convert.FromBase64String(image);
                //byte[] bytes = new byte[12];
                var stream = new MemoryStream(bytes);

                return ImageSource.FromStream(() => stream);
            }
        }
        public string fullName {
            get { return firstName + " " + lastName; }
        }

    }
}
