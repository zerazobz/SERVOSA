using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using SERVOSA.SAIR.WEB.Models;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Data;
using System.Transactions;

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
                var userModel = await UserManager.FindByIdAsync(model.Id);
                if (userModel != null)
                {
                    userModel.UserName = model.UserName;
                    userModel.Email = model.Email;

                    var updateResult = await UserManager.UpdateAsync(userModel);
                    if (updateResult.Succeeded)
                        return Json(new { Result = "OK" });
                    else
                        return Json(new { Result = "ERROR" });
                }
                else
                    return Json(new { Result = "ERROR", Message = "Problema de incoherencia de datos, reporte el nombre de usuario." });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }


        [HttpPost]
        public virtual async Task<JsonResult> UpdateUserPassword(string userId, string newPassword)
        {
            using (var dbContext = HttpContext.GetOwinContext().Get<ApplicationDbContext>())
            {
                using (TransactionScope transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    try
                    {
                        var userModel = UserManager.Users.Where(u => u.Id == userId).FirstOrDefault();
                        var removePasswordResult = await UserManager.RemovePasswordAsync(userId);
                        if (!removePasswordResult.Succeeded)
                        {

                            return Json(new { Result = "ERROR", Message = "No se pudo completar con el cambio de contraseña." });
                        }

                        var updatePasswordResult = await UserManager.AddPasswordAsync(userId, newPassword);
                        if (updatePasswordResult.Succeeded)
                        {
                            transactionScope.Complete();
                            return Json(new { Result = "OK" });
                        }
                        else
                        {
                            transactionScope.Dispose();
                            return Json(new { Result = "ERROR", Message = "No se pudo actualizar la contraseña del Usuario" });
                        }
                    }
                    catch (Exception ex)
                    {
                        transactionScope.Dispose();
                        return Json(new { Result = "ERROR", Message = ex.Message });
                    }
                }
            }

            //try
            //{
            //    var userModel = UserManager.Users.Where(u => u.Id == userId).FirstOrDefault();
            //    var removePasswordResult = await UserManager.RemovePasswordAsync(userId);
            //    if(!removePasswordResult.Succeeded)
            //    {

            //        return Json(new { Result = "ERROR", Message = "No se pudo completar con el cambio de contraseña." });
            //    }

            //    var updatePasswordResult = await UserManager.AddPasswordAsync(userId, newPassword);
            //    if(updatePasswordResult.Succeeded)
            //        return Json(new { Result = "OK" });
            //    else
            //    {
            //        return Json(new { Result = "ERROR", Message = "No se pudo actualizar la contraseña del Usuario" });
            //    }
            //}
            //catch (Exception ex)
            //{
            //    return Json(new { Result = "ERROR", Message = ex.Message });
            //}
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