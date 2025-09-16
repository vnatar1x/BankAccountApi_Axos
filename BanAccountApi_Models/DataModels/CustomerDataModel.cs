using System;

namespace BanAccountApi_Models.DataModels
{
    public class CustomerDataModel
    {
        public int CustomerId { get; set; }
        public int AccountId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone_Number { get; set; }
        public DateTime Created_DateTime { get; set; }
        public DateTime Modified_DateTime { get; set; }
    }
}
