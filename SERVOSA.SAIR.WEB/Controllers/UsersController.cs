using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using SERVOSA.SAIR.WEB.Models;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

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


        [HttpPost]
        public async Task<JsonResult> UpdateUserPassword(string userId, string currentPassword, string newPassword)
        {
            try
            {
                var userModel = UserManager.Users.Where(u => u.Id == userId).FirstOrDefault();
                var passwordHashVerification = UserManager.PasswordHasher.VerifyHashedPassword(userModel.PasswordHash, currentPassword);
                bool passwordVerificationResult = false;

                switch (passwordHashVerification)
                {
                    case PasswordVerificationResult.Failed:
                        passwordVerificationResult = false;
                        break;
                    case PasswordVerificationResult.Success:
                        passwordVerificationResult = true;
                        break;
                    case PasswordVerificationResult.SuccessRehashNeeded:
                        passwordVerificationResult = true;
                        break;
                    default:
                        passwordVerificationResult = false;
                        break;
                }

                if (!passwordVerificationResult)
                    return Json(new { Result = "ERROR", Message = "La contraseña actual especificada es invalida." });

                var updatePasswordResult = await UserManager.ChangePasswordAsync(userId, currentPassword, newPassword);
                if(updatePasswordResult.Succeeded)
                    return Json(new { Result = "OK" });
                else
                    return Json(new { Result = "ERROR", Message = "No se pudo actualizar la contraseña del Usuario" });
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