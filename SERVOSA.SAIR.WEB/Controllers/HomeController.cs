using SERVOSA.SAIR.SERVICE.Contracts;
using SERVOSA.SAIR.SERVICE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SERVOSA.SAIR.WEB.Controllers
{
    public partial class HomeController : Controller
    {
        private IVehicleService _vehicleRepository;

        public HomeController(IVehicleService injectedVehicleRep)
        {
            _vehicleRepository = injectedVehicleRep;
        }

        [HttpGet]
        public virtual ActionResult Index()
        {
            List<TableViewModel> data = new List<TableViewModel>()
            {
                //new TableViewModel() { TableName = "SUNAT" }
                //,
                new TableViewModel() { TableName = "INMIGRACIONES" }
                //, new TableViewModel() { TableName = "PEAJE WTF, sombody explain this please...." }
            };
            return View(MVC.Home.Views.Index, data);
        }

        [ChildActionOnly]
        [HttpGet]
        public virtual ActionResult VehicleTable()
        {
            var vehicleData = _vehicleRepository.GetAll();

            return PartialView(MVC.Home.Views.VehicleTable, vehicleData);
        }

        [HttpGet]
        public virtual ActionResult VehicleDataTable(TableViewModel model)
        {
            return PartialView(MVC.Home.Views.VehicleDataTable, model);
        }
    }
}