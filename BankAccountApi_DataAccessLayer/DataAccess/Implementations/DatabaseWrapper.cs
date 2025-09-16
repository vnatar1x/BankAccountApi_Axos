using Dapper;
using System;
using System.Data;
using System.Linq;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using BanAccountApi_Models.DataModels;
using BanAccountApi_Logging.Implementations;
using BankAccountApi_DataAccessLayer.DataAccess.Interfaces;

namespace BankAccountApi_DataAccessLayer.DataAccess.Implementations
{
    /// <summary>
    /// Data provider class for database connectivity
    /// </summary>
    [AopLog]
    public class DatabaseWrapper : IDatabaseWrapper
    {
        public List<AccountDataModel> GetAccounts()
        {
            IDbConnection connection = new SqlConnection(ConfigurationManager.AppSettings["DbConnStr"]);
            List<AccountDataModel> lstAccounts = new List<AccountDataModel>();

            try
            {
                connection.Open();

                lstAccounts = connection.Query<AccountDataModel>("sp_GetAccounts", commandTimeout: 180, commandType: CommandType.StoredProcedure).ToList<AccountDataModel>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }

            return lstAccounts;
        }

        public AccountDataModel GetAccount(int accountId)
        {
            IDbConnection connection = new SqlConnection(ConfigurationManager.AppSettings["DbConnStr"]);
            AccountDataModel account = new AccountDataModel();

            try
            {
                connection.Open();

                //this avoids sql injection attack sine we are using params
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@AccountID", accountId);

                account = connection.Query<AccountDataModel>("sp_GetAccount", dynamicParameters, commandTimeout: 180, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }

            return account;
        }

        public List<CustomerDataModel> GetCustomers()
        {
            IDbConnection connection = new SqlConnection(ConfigurationManager.AppSettings["DbConnStr"]);
            List<CustomerDataModel> lstCustomers = new List<CustomerDataModel>();

            try
            {
                connection.Open();

                lstCustomers = connection.Query<CustomerDataModel>("sp_GetCustomers", commandTimeout: 180, commandType: CommandType.StoredProcedure).ToList<CustomerDataModel>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }

            return lstCustomers;
        }

        public CustomerDataModel GetCustomer(int customerId)
        {
            IDbConnection connection = new SqlConnection(ConfigurationManager.AppSettings["DbConnStr"]);
            CustomerDataModel customer = new CustomerDataModel();

            try
            {
                connection.Open();

                //this avoids sql injection attack sine we are using params
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@CustomerID", customerId);

                customer = connection.Query<CustomerDataModel>("sp_GetCustomer", new { CustomerId = customerId }, commandTimeout: 180, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }

            return customer;
        }

        public List<TransactionDataModel> GetTransactionsBasedonAccountId(int accountId)
        {
            IDbConnection connection = new SqlConnection(ConfigurationManager.AppSettings["DbConnStr"]);
            List<TransactionDataModel> lstTransactions = new List<TransactionDataModel>();

            try
            {
                connection.Open();

                lstTransactions = connection.Query<TransactionDataModel>("sp_GetTransactionsBasedonAccountId", new { AccountId = accountId }, commandTimeout: 180, commandType: CommandType.StoredProcedure).ToList<TransactionDataModel>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }

            return lstTransactions;
        }

        public TransactionDataModel GetTransactionsBasedonTransactionId(int transId)
        {
            IDbConnection connection = new SqlConnection(ConfigurationManager.AppSettings["DbConnStr"]);
            TransactionDataModel transaction = new TransactionDataModel();

            try
            {
                connection.Open();

                //this avoids sql injection attack sine we are using params
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@TransactionId", transId);

                transaction = connection.Query<TransactionDataModel>("sp_GetTransactionsBasedonTransactionId", dynamicParameters, commandTimeout: 180, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }

            return transaction;
        }
    }
}
