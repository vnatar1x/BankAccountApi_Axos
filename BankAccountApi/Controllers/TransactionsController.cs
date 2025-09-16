using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Collections.Generic;
using BanAccountApi_Models.ViewModels;
using BanAccountApi_Logging.Implementations;
using BankAccountApi_BusinessLayer.Providers.Implementations;

namespace BankAccountApi.Controllers
{
    /// <summary>
    /// Responsible for bank transactions
    /// </summary>
    public class TransactionsController : ApiController
    {
        private TransactionProvider _transactionProvider { get; set; }

        public TransactionsController(TransactionProvider transactionProvider)
        {
            _transactionProvider = transactionProvider;
        }

        /// <summary>
        /// Get transactions based on account ID
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        [AopLog]
        [HttpGet]
        [Route("api/bank/gettransactions/{accountId}")]
        public HttpResponseMessage GetTransactionsBasedonAccountId(int accountId)
        {
            try
            {
                List<TransactionViewModel> lstTransactions = _transactionProvider.GetTransactionsBasedonAccountId(accountId);

                return Request.CreateResponse(HttpStatusCode.OK, lstTransactions);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Get transaction based on transaction ID
        /// </summary>
        /// <param name="transactionId"></param>
        /// <returns></returns>
        [AopLog]
        [HttpGet]
        [Route("api/bank/gettransaction/{transactionId}")]
        public HttpResponseMessage GetTransactionsBasedonTransactionId(int transactionId)
        {
            try
            {
                TransactionViewModel transactionViewModel = _transactionProvider.GetTransactionsBasedonTransactionId(transactionId);

                return Request.CreateResponse(HttpStatusCode.OK, transactionViewModel);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }
    }
}
