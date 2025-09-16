using System.Collections.Generic;
using BanAccountApi_Models.DataModels;
using BanAccountApi_Logging.Implementations;
using BankAccountApi_DataAccessLayer.DataAccess.Interfaces;

namespace BankAccountApi_DataAccessLayer.DataAccess.Implementations
{
    /// <summary>
    /// Data provider class for account
    /// </summary>
    [AopLog]
    public class AccountRepo : IAccountRepo
    {
        private IDatabaseWrapper _databaseWrapper { get; set; }

        public AccountRepo(IDatabaseWrapper databaseWrapper)
        {
            _databaseWrapper = databaseWrapper;
        }

        /// <summary>
        /// Retreive accounts
        /// </summary>
        /// <returns></returns>
        public List<AccountDataModel> GetAccounts()
        {
            return _databaseWrapper.GetAccounts();
        }

        /// <summary>
        /// Retreive account based on account ID
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public AccountDataModel GetAccount(int accountId)
        {
            return _databaseWrapper.GetAccount(accountId);
        }
    }
}
