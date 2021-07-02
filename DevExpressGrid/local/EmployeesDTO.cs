using DevExpress.XamarinForms.DataForm;
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

        [DataFormDisplayOptions(IsVisible = false)]
        [DataMember(Name = "Id")]
        public int id;

        [DataFormDisplayOptions(IsVisible = false)]
        [DataMember(Name = "ParentId")]
        public int parentId;

        [DataFormDisplayOptions(IsVisible = false)]
        [DataMember(Name = "FirstName")]
        public string firstName;

        [DataFormDisplayOptions(IsVisible = false)]
        [DataMember(Name = "LastName")]
        public string lastName;

        [DataFormDisplayOptions(GroupName = "Additional")]
        [DataMember(Name = "JobTitle")]
        public string jobTitle { get; set; }

        [DataFormDisplayOptions(GroupName = "Contacts")]
        [DataMember(Name = "Phone")]
        public string phone { get; set; }

        [DataFormDisplayOptions(GroupName = "Contacts")]
        [DataMember(Name = "EmailAddress")]
        public string emailAddress { get; set; }

        [DataFormDisplayOptions(GroupName = "Contacts")]
        [DataMember(Name = "AddressLine1")]
        public string addressLine1 { get; set; }

        [DataFormDisplayOptions(GroupName = "Contacts")]
        [DataMember(Name = "City")]
        public string city { get; set; }

        [DataFormDisplayOptions(GroupName = "Contacts")]
        [DataMember(Name = "PostalCode")]
        public string postalCode { get; set; }

        [DataFormDisplayOptions(GroupName = "Contacts")]
        [DataMember(Name = "countryRegionName")]
        public string countryRegionName { get; set; }

        [DataFormDisplayOptions(GroupName = "Additional")]
        [DataMember(Name = "GroupName")]
        public string groupName { get; set; }

        [DataMember(Name = "BirthDate")]
        private string _birthDate;

        [DataMember(Name = "HireDate")]
        private string _hireDate;

        [DataMember(Name = "Gender")]
        private string _gender;

        [DataMember(Name = "MaritalStatus")]
        private string _maritalStatus;
   
        [DataMember(Name = "ImageData")]
        private string _image;


        [DataFormDisplayOptions(IsVisible = false)]
        public ImageSource image {
            get {
                var bytes = Convert.FromBase64String(_image);   
                var stream = new MemoryStream(bytes);

                return ImageSource.FromStream(() => stream);
            }
        }

        [DataFormDisplayOptions(IsVisible = false)]
        public string fullName {
            get { return firstName + " " + lastName; }
        }

        [DataFormDisplayOptions(GroupName = "Profile")]
        public DateTime birthDate {
            get { return DateTime.Parse(_birthDate); }
            set { _birthDate = value.ToString(); }
        }

        [DataFormDisplayOptions(GroupName = "Additional")]
        public DateTime hireDate {
            get { return DateTime.Parse(_hireDate); }
        }

        [DataFormDisplayOptions(GroupName = "Profile")]
        public Gender gender {
            get { return _gender == "M" ? Gender.Male : Gender.Female;  }
        }

        [DataFormDisplayOptions(GroupName = "Profile")]
        public Marital maritalStatus {
            get { return _maritalStatus == "S" ? Marital.Single : Marital.Marred; }
        }

        public enum Gender { Male, Female }
        public enum Marital { Marred, Single  }
    }
}
