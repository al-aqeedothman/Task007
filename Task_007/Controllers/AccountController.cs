using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task007.BusinessLogic.Manager;

namespace Task_007.Controllers
{
    public class AccountController : Controller
    {
        private static readonly ILog log = LogManager.GetLogger("Task_007.Controllers.AccountController");
        private readonly IAccountManager _manager; 
        public AccountController(IAccountManager manager)
        {
            _manager = manager;
        }
        [ActionName("Details")]
        public ActionResult Details(string id)
        {
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    var account = _manager.GetAccountById(id);

                    return View(account);
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {

                throw;
            }
           
        }
    }
}