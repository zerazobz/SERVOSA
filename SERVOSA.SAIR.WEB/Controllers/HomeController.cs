using SERVOSA.SAIR.DATAACCESS.Contracts;
using SERVOSA.SAIR.DATAACCESS.Models.DB;
using SERVOSA.SAIR.DATAACCESS.Models.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SERVOSA.SAIR.WEB.Controllers
{
    public partial class HomeController : Controller
    {
        private IVehicleRepository _vehicleRepository;

        public HomeController(IVehicleRepository injectedVehicleRep)
        {
            _vehicleRepository = injectedVehicleRep;
        }

        [HttpGet]
        public virtual ActionResult Index()
        {
            List<TableModel> data = new List<TableModel>()
            {
                new TableModel() { TableName = "SUNAT" },
                new TableModel() { TableName = "INMIGRACIONES" },
                new TableModel() { TableName = "PEAJE" }
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
        public ActionResult VehicleDataTable(TableModel model)
        {
            return PartialView(model);
        }
    }
}