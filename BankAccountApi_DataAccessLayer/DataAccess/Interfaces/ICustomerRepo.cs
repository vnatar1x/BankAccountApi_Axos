using System.Collections.Generic;
using BanAccountApi_Models.DataModels;

namespace BankAccountApi_DataAccessLayer.DataAccess.Interfaces
{
    public interface ICustomerRepo
    {
        List<CustomerDataModel> GetCustomers();

        CustomerDataModel GetCustomer(int customerId);
    }
}
