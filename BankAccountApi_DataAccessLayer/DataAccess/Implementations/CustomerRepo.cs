using System.Collections.Generic;
using BanAccountApi_Models.DataModels;
using BanAccountApi_Logging.Implementations;
using BankAccountApi_DataAccessLayer.DataAccess.Interfaces;

namespace BankAccountApi_DataAccessLayer.DataAccess.Implementations
{
    /// <summary>
    /// Data provider class for customer
    /// </summary>
    [AopLog]
    public class CustomerRepo : ICustomerRepo
    {
        private IDatabaseWrapper _databaseWrapper { get; set; }

        public CustomerRepo(IDatabaseWrapper databaseWrapper)
        {
            _databaseWrapper = databaseWrapper;
        }

        /// <summary>
        /// Retreive customers
        /// </summary>
        /// <returns></returns>
        public List<CustomerDataModel> GetCustomers()
        {
            return _databaseWrapper.GetCustomers();
        }

        /// <summary>
        /// Retreive customer based on customer ID
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public CustomerDataModel GetCustomer(int customerId)
        {
            return _databaseWrapper.GetCustomer(customerId);
        }
    }
}
