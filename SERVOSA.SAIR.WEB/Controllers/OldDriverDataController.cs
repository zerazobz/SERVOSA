using SERVOSA.SAIR.SERVICE.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SERVOSA.SAIR.WEB.Controllers
{
    public class OldDriverDataController : Controller
    {
        private readonly IOldDriverService _driverService;

        public OldDriverDataController(IOldDriverService injectedDriverService)
        {
            _driverService = injectedDriverService;
        }

        [HttpGet]
        public ActionResult Data(int driverCode)
        {
            ViewBag.DriverCode = driverCode;
            var listRelatedTablesVehicle = _driverService.GetListRelatedTablesToDriver();
            return View(listRelatedTablesVehicle);
        }
    }
}