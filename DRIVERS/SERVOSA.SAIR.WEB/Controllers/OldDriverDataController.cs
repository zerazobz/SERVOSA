using SERVOSA.SAIR.SERVICE.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SERVOSA.SAIR.WEB.Controllers
{
    [Authorize]
    public partial class OldDriverDataController : Controller
    {
        private readonly IOldDriverService _driverService;

        public OldDriverDataController(IOldDriverService injectedDriverService)
        {
            _driverService = injectedDriverService;
        }

        [HttpGet]
        public virtual ActionResult Data(int driverCode)
        {
            ViewBag.DriverCode = driverCode;
            var listRelatedTablesDriver = _driverService.GetListRelatedTablesToDriver();
            return View(listRelatedTablesDriver);
        }
    }
}