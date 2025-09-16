using System;

namespace BanAccountApi_Models.DataModels
{
    public class AccountDataModel
    {
        public int AccountId { get; set; }
        public string Account_Category { get; set; }
        public float Current_Balance { get; set; }
        public string Status { get; set; }
        public float Defined_Interest { get; set; }
        public DateTime Created_DateTime { get; set; }
        public DateTime Modified_DateTime { get; set; }
    }
}
