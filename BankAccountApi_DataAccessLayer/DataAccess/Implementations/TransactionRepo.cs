using System.Collections.Generic;
using BanAccountApi_Models.DataModels;
using BankAccountApi_DataAccessLayer.DataAccess.Interfaces;

namespace BankAccountApi_DataAccessLayer.DataAccess.Implementations
{
    /// <summary>
    /// Data provider class for transaction
    /// </summary>
    public class TransactionRepo : ITransactionRepo
    {
        private IDatabaseWrapper _databaseWrapper { get; set; }

        public TransactionRepo(IDatabaseWrapper databaseWrapper)
        {
            _databaseWrapper = databaseWrapper;
        }

        /// <summary>
        /// Retreive transactions based on account ID
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public List<TransactionDataModel> GetTransactionsBasedonAccountId(int accountId)
        {
            return _databaseWrapper.GetTransactionsBasedonAccountId(accountId);
        }

        /// <summary>
        /// Retreive transaction based on transaction ID
        /// </summary>
        /// <param name="transId"></param>
        /// <returns></returns>
        public TransactionDataModel GetTransactionsBasedonTransactionId(int transId)
        {
            return _databaseWrapper.GetTransactionsBasedonTransactionId(transId);
        }
    }
}
