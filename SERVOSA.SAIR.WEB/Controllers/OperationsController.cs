using SERVOSA.SAIR.SERVICE.Contracts;
using SERVOSA.SAIR.SERVICE.Models.Operaion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using SERVOSA.SAIR.WEB.Models;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using SERVOSA.SAIR.SERVICE.Core;
using SERVOSA.SAIR.WEB.App_Start;
using System.Configuration;
using SERVOSA.SAIR.WEB.Resources;

namespace SERVOSA.SAIR.WEB.Controllers
{
    public partial class OperationsController : Controller
    {
        private readonly IOperationService _operationService;
        private ApplicationUserManager _userManager;

        public OperationsController(IOperationService injectedOperationService, ApplicationUserManager userManager)
        {
            _operationService = injectedOperationService;
            UserManager = userManager;
        }

        [HttpGet]
        public virtual ActionResult Manage()
        {
            return View();
        }

        [HttpGet]
        public virtual ActionResult Choose()
        {
            return View();
        }

        [HttpPost]
        public virtual ActionResult ListOperations(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                var operationsList = _operationService.ListAllOperations();

                return Json(new { Result = "OK", Records = operationsList, TotalRecordCount = operationsList.Count });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }

        }

        [HttpPost]
        [AsyncTimeout(300000)]
        public virtual async Task<ActionResult> CreateOperation(OperationServiceModel model)
        {
            try
            {
                bool resultExecution = false;
                bool azureRemoteGeneration = Convert.ToBoolean(ConfigurationManager.AppSettings[SAIRApplicationResources.AzureRemoteExecution]);
                var operationResult = _operationService.CreateOperation(model.OperationName, azureRemoteGeneration);
                if(operationResult != null)
                {
                    model.OperationId = operationResult.OperationId;

                    var user = new ApplicationUser();
                    user.UserName = $"{operationResult.DataBaseName}_user";
                    user.Email = $"{operationResult.DataBaseName}@gmail.com";
                    user.OperationId = operationResult.OperationId;

                    string userPWD = $"{operationResult.DataBaseName}_123456";
                    model.DataBaseName = operationResult.DataBaseName;

                    IdentityResult userAdminResultCreation = await UserManager.CreateAsync(user, userPWD);

                    if (userAdminResultCreation.Succeeded)
                    {
                        var addRoleResult = await UserManager.AddToRoleAsync(user.Id, "UserForOperation");
                        resultExecution = addRoleResult.Succeeded;
                        model.UserName = user.UserName;
                    }
                }

                if(resultExecution)
                    return Json(new { Result = "OK", Record = model });
                else
                    return Json(new { Result = "ERROR", Message = "No se pudo crear correctamente la Operación" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpGet]
        public virtual ActionResult LoadOperation(string operationName, int operationId)
        {
            Session[Resources.SAIRApplicationResources.OperationID] = operationId;
            ServiceDataConfiguration.SetOperation(operationName);
            UnityWebActivator.Start();
            return RedirectToAction(MVC.Home.Index());
        }

        [HttpPost]
        public virtual JsonResult DeleteOperation(int operationId, string databaseName)
        {
            int executionResult = _operationService.DeleteOperation(operationId, databaseName);
            return Json(new { Result = executionResult > 0 ? "OK" : "ERROR" });
        }


        [HttpPost]
        public virtual JsonResult ChangeOperationName(int operationId, string newOperationName)
        {
            int executionResult = _operationService.UpdateOperationName(operationId, newOperationName);
            string executionResultMessage = executionResult > 0 ? "OK" : "ERROR";
            return Json(new { Result = executionResultMessage });
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