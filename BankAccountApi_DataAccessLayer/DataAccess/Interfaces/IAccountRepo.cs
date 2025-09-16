using System.Collections.Generic;
using BanAccountApi_Models.DataModels;

namespace BankAccountApi_DataAccessLayer.DataAccess.Interfaces
{
    public interface IAccountRepo
    {
        List<AccountDataModel> GetAccounts();

        AccountDataModel GetAccount(int accountId);
    }
}
