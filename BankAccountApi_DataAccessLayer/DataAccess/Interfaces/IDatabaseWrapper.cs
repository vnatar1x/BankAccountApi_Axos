using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BanAccountApi_Models.DataModels;

namespace BankAccountApi_DataAccessLayer.DataAccess.Interfaces
{
    public interface IDatabaseWrapper
    {
        List<AccountDataModel> GetAccounts();

        AccountDataModel GetAccount(int accountId);

        List<CustomerDataModel> GetCustomers();

        CustomerDataModel GetCustomer(int customerId);

        List<TransactionDataModel> GetTransactionsBasedonAccountId(int accountId);

        TransactionDataModel GetTransactionsBasedonTransactionId(int transId);
    }
}
