using SERVOSA.SAIR.SERVICE.Contracts;
using SERVOSA.SAIR.SERVICE.Models.EmailRecipent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SERVOSA.SAIR.WEB.Controllers
{
    public partial class EmailController : Controller
    {
        private readonly IEmailRecipentService _emailService;

        public EmailController(IEmailRecipentService injectedEmailServ)
        {
            _emailService = injectedEmailServ;
        }

        public virtual ActionResult Manage()
        {
            return View();
        }

        [HttpPost]
        public virtual JsonResult ListAllEmail()
        {
            try
            {
                var allEmailCollection = _emailService.GetAll();
                return Json(new { Result = "OK", Records = allEmailCollection, TotalRecordCount = allEmailCollection.Count });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public virtual JsonResult CreateEmail(EmailRecipentServiceModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return Json(new { Result = "ERROR", Message = "Por favor verifique la integridad de la información insertada" });

                var insertResult = _emailService.Insert(model);
                if (insertResult > 0)
                    return Json(new { Result = "OK", Record = model });
                else
                    return Json(new { Result = "ERROR", Message = "No se pudo ingresar la información solicitada." });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public virtual ActionResult DeleteEmail(int emailId)
        {
            try
            {
                var deleteResult = _emailService.Delete(new EmailRecipentServiceModel { Id = emailId });
                if (deleteResult > 0)
                    return Json(new { Result = "OK" });
                else
                    return Json(new { Result = "ERROR", Message = "No se pudo eliminar el registro." });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
    }
}