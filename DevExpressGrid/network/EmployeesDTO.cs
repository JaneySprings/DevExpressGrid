using DevExpress.XamarinForms.DataForm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using Xamarin.Forms;

namespace DevExpressGrid.network {

    [DataContract]
    public class EmployeesDTO {

        [DataMember(Name = "Employees")]
        public List<Employee> employees;
    }

    [DataContract]
    public class Employee {

        [DataMember(Name = "Id")]
        public int id;

        [DataMember(Name = "ParentId")]
        public int parentId;

        [DataMember(Name = "FirstName")]
        public string firstName;
     
        [DataMember(Name = "LastName")]
        public string lastName;

        [DataMember(Name = "JobTitle")]
        public string jobTitle;

        [DataMember(Name = "Phone")]
        public string phone;

        [DataMember(Name = "EmailAddress")]
        public string emailAddress;

        [DataMember(Name = "AddressLine1")]
        public string addressLine1;

        [DataMember(Name = "City")]
        public string city;

        [DataMember(Name = "PostalCode")]
        public string postalCode;

        [DataMember(Name = "countryRegionName")]
        public string countryRegionName;

        [DataMember(Name = "GroupName")]
        public string groupName;

        [DataMember(Name = "BirthDate")]
        public string birthDate;

        [DataMember(Name = "HireDate")]
        public string hireDate;

        [DataMember(Name = "Gender")]
        public string gender;

        [DataMember(Name = "MaritalStatus")]
        public string maritalStatus;
   
        [DataMember(Name = "ImageData")]
        public string image;
    }

    /* Model for displaying info */
    public class EmployeeItem {
        public int id;

        [DataFormDisplayOptions(GroupName = "Additional")]
        public string Job { get; set; }

        [DataFormDisplayOptions(GroupName = "Additional")]
        public string Group { get; set; }

        [DataFormDisplayOptions(GroupName = "Contacts")]
        public string Phone { get; set; }

        [DataFormDisplayOptions(GroupName = "Contacts")]
        public string Email { get; set; }

        [DataFormDisplayOptions(GroupName = "Contacts")]
        public string Address { get; set; }

        [DataFormDisplayOptions(GroupName = "Contacts")]
        public string City { get; set; }

        [DataFormDisplayOptions(GroupName = "Contacts")]
        public string Postal { get; set; }

        [DataFormDisplayOptions(GroupName = "Contacts")]
        public string Region { get; set; }

        [DataFormDisplayOptions(GroupName = "Profile")]
        public DateTime Birthday { get; set; }
        
        [DataFormDisplayOptions(GroupName = "Profile")]
        public GenderStates Gender { get; set; }

        [DataFormDisplayOptions(GroupName = "Profile")]
        public MaritalStates Marital { get; set; }


        [DataFormDisplayOptions(IsVisible = false)]
        public string FullName { get; set; }

        [DataFormDisplayOptions(IsVisible = false)]
        public ImageSource ImageSrc { get; set; }


        public EmployeeItem(string name, ImageSource image) {
            FullName = name;
            ImageSrc = image;
        }

        public EmployeeItem(Employee data) {
            id = data.id;
            Job = data.jobTitle;
            Group = data.groupName;
            Phone = data.phone;
            Email = data.emailAddress;
            Address = data.addressLine1;
            City = data.city;
            Postal = data.postalCode;
            Region = data.countryRegionName;

            Birthday = DateTime.Parse(data.birthDate);
            Gender = (data.gender == "M") ? GenderStates.Female : GenderStates.Female;
            Marital = (data.maritalStatus == "M") ? MaritalStates.Marred : MaritalStates.Single;

            FullName = data.firstName + " " + data.lastName;
            ImageSrc = ImageSource.FromStream(() => {
                var bytes = Convert.FromBase64String(data.image);
                return new MemoryStream(bytes);
            });
        }

        public enum GenderStates { Male, Female }
        public enum MaritalStates { Marred, Single }
    }
}
