using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using SERVOSA.SAIR.WEB.Models;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.WEB.Controllers
{
    public partial class UsersController : Controller
    {
        private ApplicationUserManager _userManager;

        [HttpGet]
        public virtual ActionResult Manage()
        {
            return View();
        }

        [HttpPost]
        public virtual ActionResult ListAllUsers()
        {
            try
            {
                var collectionUsers = UserManager.Users.ToList();

                return Json(new { Result = "OK", Records = collectionUsers, TotalRecordCount = collectionUsers.Count });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public virtual async Task<JsonResult> UpdateUser(ApplicationUser model)
        {
            try
            {
                var updateResult = await UserManager.UpdateAsync(model);
                if (updateResult.Succeeded)
                    return Json(new { Result = "OK" });
                else
                    return Json(new { Result = "ERROR" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
    }
}