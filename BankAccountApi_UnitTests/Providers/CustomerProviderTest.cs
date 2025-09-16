using Moq;
using AutoMapper;
using System.Collections.Generic;
using BanAccountApi_Models.DataModels;
using BanAccountApi_Models.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountApi_DataAccessLayer.DataAccess.Interfaces;
using BankAccountApi_BusinessLayer.Providers.Implementations;

namespace BankAccountApi_UnitTests.Providers
{
    [TestClass]
    public class CustomerProviderTest
    {
        [TestMethod]
        public void GetCustomers_Success()
        {
            //Setup
            Mock<ICustomerRepo> mckCustomerRepo = new Mock<ICustomerRepo>();
            CustomerDataModel customerDataModel = new CustomerDataModel { CustomerId = 5001, AccountId = 1001 };
            mckCustomerRepo.Setup(x => x.GetCustomers()).Returns(new List<CustomerDataModel> { customerDataModel });

            Mock<IMapper> mckMapper = new Mock<IMapper>();
            mckMapper.Setup(x => x.Map<List<CustomerViewModel>>(new List<CustomerDataModel>())).Returns(new List<CustomerViewModel>());

            CustomerProvider researchProvider = new CustomerProvider(mckCustomerRepo.Object, mckMapper.Object);
            List<CustomerViewModel> lstCustomers = researchProvider.GetCustomers();

            //Assert
            Assert.IsInstanceOfType(lstCustomers, typeof(List<CustomerViewModel>));
        }
    }
}
