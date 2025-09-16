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
    /// Responsible for for account and customer data
    /// </summary>
    public class BankController : ApiController
    {
        private AccountProvider _accountProvider { get; set; }
        private CustomerProvider _customerProvider { get; set; }

        public BankController(AccountProvider accountProvider, CustomerProvider customerProvider)
        {
            _accountProvider = accountProvider;
            _customerProvider = customerProvider;
        }

        /// <summary>
        /// Retreives all customers irrespective of state
        /// </summary>
        /// <returns></returns>
        [AopLog]
        [HttpGet]
        [Route("api/bank/getcustomers")]
        public HttpResponseMessage GetCustomers()
        {
            try
            {
                List<CustomerViewModel> lstCustomers = _customerProvider.GetCustomers();

                return Request.CreateResponse(HttpStatusCode.OK, lstCustomers);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Retreives all accounts from database
        /// </summary>
        /// <returns></returns>
        [AopLog]
        [HttpGet]
        [Route("api/bank/getaccounts")]
        public HttpResponseMessage GetAccounts()
        {
            try
            {
                List<AccountViewModel> lstAccounts = _accountProvider.GetAccounts();

                return Request.CreateResponse(HttpStatusCode.OK, lstAccounts);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Get account info based on account ID
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        [AopLog]
        [HttpGet]
        [Route("api/bank/getaccounts/{accountId}")]
        public HttpResponseMessage GetAccount(int accountId)
        {
            try
            {
                AccountViewModel account = _accountProvider.GetAccount(accountId);

                return Request.CreateResponse(HttpStatusCode.OK, account);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Get account info based on customer ID
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        [AopLog]
        [HttpGet]
        [Route("api/bank/getcustomers/{customerId}")]
        public HttpResponseMessage GetCustomer(int customerId)
        {
            try
            {
                CustomerViewModel customer = _customerProvider.GetCustomer(customerId);

                return Request.CreateResponse(HttpStatusCode.OK, customer);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }
    }
}
