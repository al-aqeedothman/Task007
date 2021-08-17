using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task007.BusinessLogic.Enum;
using Task007.BusinessLogic.Manager;

namespace Task_007.Controllers
{
    public class AccountController : Controller
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(AccountController));
        private readonly IAccountManager _manager; 
        public AccountController(IAccountManager manager)
        {
            _manager = manager;
        }
        [ActionName("Details")]
        public ActionResult Details(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult((int)HttpStatusCodeEnum.BadRequest);
            }
            try
            {
                var account = _manager.GetAccountById(id);
                if (account == null)
                {
                    return new HttpStatusCodeResult((int)HttpStatusCodeEnum.NotFound);
                }             
                else
                {
                    return View(account);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                return new HttpStatusCodeResult((int)HttpStatusCodeEnum.InternalServerError);
                throw;
            }
           
        }
    }
}
