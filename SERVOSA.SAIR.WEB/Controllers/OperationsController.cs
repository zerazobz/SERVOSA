using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SERVOSA.SAIR.WEB.Controllers
{
    public class OperationsController : Controller
    {
        [HttpGet]
        public ActionResult Manage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ListOperations(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            return Json(true);
        }

        [HttpPost]
        public ActionResult CreateOperation()
        {
            return Json(true);
        }
    }

    public class OperationModel
    {
        public string OperationId { get; set; }
        public string OperationName { get; set; }
    }
}