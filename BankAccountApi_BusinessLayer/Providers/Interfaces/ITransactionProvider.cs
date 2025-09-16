using System.Collections.Generic;
using BanAccountApi_Models.ViewModels;

namespace BankAccountApi_BusinessLayer.Providers.Interfaces
{
    public interface ITransactionProvider
    {
        List<TransactionViewModel> GetTransactionsBasedonAccountId(int accountId);

        TransactionViewModel GetTransactionsBasedonTransactionId(int transId);
    }
}
