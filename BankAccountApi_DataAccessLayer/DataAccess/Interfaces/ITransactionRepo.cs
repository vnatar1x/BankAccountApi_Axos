using System.Collections.Generic;
using BanAccountApi_Models.DataModels;

namespace BankAccountApi_DataAccessLayer.DataAccess.Interfaces
{
    public interface ITransactionRepo
    {
        List<TransactionDataModel> GetTransactionsBasedonAccountId(int accountId);

        TransactionDataModel GetTransactionsBasedonTransactionId(int transId);
    }
}
