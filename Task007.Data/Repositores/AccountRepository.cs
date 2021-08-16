using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_007.Data.Models;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Client;

namespace Task007.Data.Repositores
{
   public interface IAccountRepository
    {
        AccountModel GetAccountById(string accountId);
    }
   public class AccountRepository : IAccountRepository
    {
        private readonly CrmOrganizationServiceContext _context;
        public AccountRepository()
        {
            _context = CRMContext.CreateCRMContext();
        }

        public AccountModel GetAccountById(string accountId)
        {
            try
            {
                var accountEntity = (from account in _context.CreateQuery("account")
                                     where (string)account["accountid"] == accountId
                                     select account).FirstOrDefault();
                var userId = ((Microsoft.Xrm.Sdk.EntityReference)accountEntity.Attributes["owninguser"]).Id;

                var userEntity = (from owninguser in _context.CreateQuery("systemuser")
                                  where (Guid)owninguser["systemuserid"] == userId
                                  select owninguser).FirstOrDefault();

                return new AccountModel
                {
                    Name = accountEntity.Attributes["name"].ToString(),
                    EmailAddress1 = accountEntity["emailaddress1"].ToString(),
                    IndustryCode = ((Microsoft.Xrm.Sdk.OptionSetValue)accountEntity["industrycode"]).Value.ToString(),
                    AccountNumber = accountEntity["accountnumber"].ToString(),
                    Telephone1 = accountEntity["telephone1"].ToString(),
                    WebSiteUrl = accountEntity["websiteurl"].ToString(),
                    Revenue = ((Microsoft.Xrm.Sdk.Money)accountEntity["revenue"]).Value.ToString(),
                    owninguser = userEntity["fullname"].ToString()
                };
            }
            catch (Exception)
            {

                throw;
            }
            
          

        }

    }
}
