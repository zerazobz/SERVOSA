using SERVOSA.SAIR.SERVICE.Contracts;
using SERVOSA.SAIR.SERVICE.Models.Operaion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SERVOSA.SAIR.WEB.Controllers
{
    public partial class OperationsController : Controller
    {
        private readonly IOperationService _operationService;

        public OperationsController(IOperationService injectedOperationService)
        {
            _operationService = injectedOperationService;
        }

        [HttpGet]
        public virtual ActionResult Manage()
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
        public virtual ActionResult CreateOperation(OperationServiceModel model)
        {
            try
            {
                var resultCreation = _operationService.CreateOperation(model.OperationName);
                return Json(new { Result = "OK", Record = model });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
    }

    public class OperationModel
    {
        public string OperationId { get; set; }
        public string OperationName { get; set; }
    }
}