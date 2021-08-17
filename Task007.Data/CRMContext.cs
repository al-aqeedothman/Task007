using log4net;
using Microsoft.Xrm.Client;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task007.Data
{
    public class CRMContext 
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(CRMContext));

      
        public static CrmOrganizationServiceContext CreateCRMContext()
        {
            try
            {
                var connString = ConfigurationManager.ConnectionStrings["DynamicCRMconnectionstring"].ConnectionString;
                if (!String.IsNullOrEmpty(connString))
                {
                    CrmServiceClient conn = new CrmServiceClient(connString);
                    if (conn.IsReady)
                    {
                        log.Info("Your Connection to " + conn.OrganizationDetail.FriendlyName + "is ready");
                        IOrganizationService service = conn.OrganizationWebProxyClient == null ? (IOrganizationService)conn.OrganizationServiceProxy : (IOrganizationService)conn.OrganizationWebProxyClient;
                        var context = new CrmOrganizationServiceContext(service);
                        return context;
                    }
                    else if (conn.OrganizationDetail is null)
                    {
                        log.Info("Your Connection to Dynamic 365 CRM  is faild");
                        return null;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    log.Info("Check your ConnectionString");
                    return null;
                }
            }
            catch (Exception ex)
            {

                log.Error(ex.Message, ex);
                throw;
            }




        }
    }
}
