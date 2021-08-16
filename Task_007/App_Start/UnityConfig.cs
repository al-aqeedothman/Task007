using System.Web.Mvc;
using Task007.BusinessLogic.Manager;
using Task007.Data.Repositores;
using Unity;
using Unity.Mvc5;

namespace Task_007
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IAccountRepository, AccountRepository>();
            container.RegisterType<IAccountManager, AccountManager>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}