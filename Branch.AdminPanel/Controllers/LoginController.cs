using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Branch.AdminPanel.Models;
using Branch.AdminPanel.Utils;
using Branch.Data.Core.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Branch.AdminPanel.Controllers
{
    
    public class LoginController : Controller
    {
        RequestHandler requestHandler;

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginModel loginModel)
        {
            var user = await requestHandler.HandelPOSTRequest<LoginModel>("Login/Login", new { loginModel }, "abc");
            if (user != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {

            }
            return View();
        }
        //public ActionResult GetUserInfo()
        //{
        //    User oUser = (User)Session[ShareData.Session.LogedUser];
        //    if (oUser != null)
        //    {
        //        return Json(oUser.UserName, JsonRequestBehavior.AllowGet);
        //    }
        //    return Json("Test", JsonRequestBehavior.AllowGet);

        //}
        //public async Task<ActionResult> Logout()
        //{
        //    var user = (User)Session[ShareData.Session.LogedUser];
        //    logger.Info(string.Format("{0} logout {1}", user.Name, user.MasterLogin == 1 ? "as Masterlogin" : " "), new LogBox { TableName = "user", IsAdmin = user.Admin, TotalShares = user.AllowedShares, ConsumeShares = user.ConsumedShare, IsMasterUser = Convert.ToBoolean(user.MasterLogin), UserId = user.Id, Activity = "logout", partitionKey = GetType().Namespace });
        //    Session[ShareData.Session.LogedUser] = null;
        //    Session.Abandon();
        //    return RedirectToAction(nameof(AccountController.Login));
        //}
    }
}