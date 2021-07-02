using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DevExpressGrid.network {
    [DataContract]
    public class ResponseDTO {
        [DataMember(Name = "odata.metadata")]
        public string odataMetadata;
        
        [DataMember(Name = "value")]
        public List<ValueModel> value;
    }

    [DataContract]
    public class ValueModel {
        [DataMember(Name = "Region")]
        public string region;

        [DataMember(Name = "Sector")]
        public string sector;

        [DataMember(Name = "Channel")]
        public string channel;

        [DataMember(Name = "Units")]
        public int units;

        [DataMember(Name = "Customer")]
        public string customer;

        [DataMember(Name = "Product")]
        public string product;

        [DataMember(Name = "Amount")]
        public float amount;

        [DataMember(Name = "Discount")]
        public float discount;

        [DataMember(Name = "SaleDate")]
        public string _saleDate {
            get { return saleDate.ToString(); }
            set { saleDate = DateTime.Parse(value); }
        }
        public DateTime saleDate { get; set; }

        [DataMember(Name = "Id")]
        public int id;
    }
}
