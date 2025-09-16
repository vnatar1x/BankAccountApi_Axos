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
    /// Business provider class for customer
    /// </summary>
    [AopLog]
    public class CustomerProvider : ICustomerProvider
    {
        private IMapper _mapper { get; set; }
        private ICustomerRepo _customerRepo { get; set; }

        public CustomerProvider(ICustomerRepo customerRepo, IMapper mapper)
        {
            _mapper = mapper;
            _customerRepo = customerRepo;
        }

        /// <summary>
        /// Retreive customers
        /// </summary>
        /// <returns></returns>
        public List<CustomerViewModel> GetCustomers()
        {
            List<CustomerDataModel> lstCustomers = _customerRepo.GetCustomers();

            List<CustomerViewModel> lstCustomerViewModel = _mapper.Map<List<CustomerViewModel>>(lstCustomers);

            return lstCustomerViewModel;
        }

        /// <summary>
        /// Retreive customer based on customer ID
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public CustomerViewModel GetCustomer(int customerId)
        {
            CustomerDataModel customerDataModel = _customerRepo.GetCustomer(customerId);

            CustomerViewModel customerViewModel = _mapper.Map<CustomerViewModel>(customerDataModel);

            return customerViewModel;
        }
    }
}
