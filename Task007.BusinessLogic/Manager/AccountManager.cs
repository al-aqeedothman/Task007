using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_007.Data.Models;
using Task007.Data.Repositores;

namespace Task007.BusinessLogic.Manager
{
    public interface IAccountManager
    {
        AccountModel GetAccountById(string accountId);
    }

    public  class AccountManager : IAccountManager
     {
        private readonly IAccountRepository _repository;
        private static readonly ILog log = LogManager.GetLogger(typeof(AccountManager));

        public AccountManager(IAccountRepository repository )
        {
            _repository = repository;
        }

      public  AccountModel GetAccountById(string accountId)
        {
            try
            {
                return _repository.GetAccountById(accountId);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                throw;
            }
        
        }

    
    }
}
