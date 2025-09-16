using AutoMapper;
using System.Collections.Generic;
using BanAccountApi_Models.DataModels;
using BanAccountApi_Models.ViewModels;
using BankAccountApi_BusinessLayer.Providers.Interfaces;
using BankAccountApi_DataAccessLayer.DataAccess.Interfaces;

namespace BankAccountApi_BusinessLayer.Providers.Implementations
{
    /// <summary>
    /// Business provider class for transaction
    /// </summary>
    public class TransactionProvider : ITransactionProvider
    {
        private IMapper _mapper { get; set; }
        private ITransactionRepo _transactionRepo { get; set; }

        public TransactionProvider(ITransactionRepo transactionRepo, IMapper mapper)
        {
            _mapper = mapper;
            _transactionRepo = transactionRepo;
        }

        /// <summary>
        /// Retreive transactions based on account ID
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public List<TransactionViewModel> GetTransactionsBasedonAccountId(int accountId)
        {
            List<TransactionDataModel> lstTransactionDataModel = _transactionRepo.GetTransactionsBasedonAccountId(accountId);

            List<TransactionViewModel> lstTransactionViewModel = _mapper.Map<List<TransactionViewModel>>(lstTransactionDataModel);

            return lstTransactionViewModel;
        }

        /// <summary>
        /// Retreive transaction based on transaction ID
        /// </summary>
        /// <param name="transId"></param>
        /// <returns></returns>
        public TransactionViewModel GetTransactionsBasedonTransactionId(int transId)
        {
            TransactionDataModel transactionDataModel = _transactionRepo.GetTransactionsBasedonTransactionId(transId);

            TransactionViewModel transactionViewModel = _mapper.Map<TransactionViewModel>(transactionDataModel);

            return transactionViewModel;
        }
    }
}
