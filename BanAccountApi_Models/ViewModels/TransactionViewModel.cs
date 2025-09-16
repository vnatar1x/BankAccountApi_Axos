using System;

namespace BanAccountApi_Models.ViewModels
{
    public class TransactionViewModel
    {
        public int TrasactionId { get; set; }
        public string TrasactionName { get; set; }
        public int AccountId { get; set; }
        public decimal TrasactionAmount { get; set; }
        public decimal CurrentBalance { get; set; }
        public DateTime Created_DateTime { get; set; }
        public DateTime Modified_DateTime { get; set; }
    }
}
