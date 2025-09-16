using AutoMapper;
using System.Collections.Generic;
using BanAccountApi_Models.DataModels;
using BanAccountApi_Models.ViewModels;
using BanAccountApi_Logging.Implementations;
using BankAccountApi_BusinessLayer.Providers.Interfaces;
using BankAccountApi_DataAccessLayer.DataAccess.Interfaces;

namespace BankAccountApi_BusinessLayer.Providers.Implementations
{
    /// <summary>
    /// Business provider class for account
    /// </summary>
    [AopLog]
    public class AccountProvider : IAccountProvider
    {
        private IMapper _mapper { get; set; }
        private IAccountRepo _accountRepo { get; set; }

        public AccountProvider(IAccountRepo accountRepo, IMapper mapper)
        {
            _mapper = mapper;
            _accountRepo = accountRepo;
        }

        /// <summary>
        /// Retreive accounts
        /// </summary>
        /// <returns></returns>
        public List<AccountViewModel> GetAccounts()
        {
            List<AccountDataModel> lstAccountDataModel = _accountRepo.GetAccounts();

            List<AccountViewModel> lstAccountViewModel = _mapper.Map<List<AccountViewModel>>(lstAccountDataModel);

            return lstAccountViewModel;
        }

        /// <summary>
        /// Retreive account based on account ID
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public AccountViewModel GetAccount(int accountId)
        {
            AccountDataModel accountDataModel = _accountRepo.GetAccount(accountId);

            AccountViewModel accountViewModel = _mapper.Map<AccountViewModel>(accountDataModel);

            return accountViewModel;
        }
    }
}
