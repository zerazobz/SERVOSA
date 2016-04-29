using SERVOSA.SAIR.SERVICE.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SERVOSA.SAIR.WEB.Controllers
{
    public partial class VehicleDataController : Controller
    {
        private readonly IVehicleService _vehicleService;

        public VehicleDataController(IVehicleService injectedVehicleSer)
        {
            _vehicleService = injectedVehicleSer;
        }

        [HttpGet]
        public virtual ActionResult Data(int vehicleCode)
        {
            ViewBag.VehicleCode = vehicleCode;
            return View();
        }

        [HttpGet]
        public virtual ActionResult CabeceraVehiculo(int vehicleCode)
        {
            var model = _vehicleService.GetById(vehicleCode);
            if (model == null)
                throw new ArgumentException("El vehiculo no puede ser nulo, el código esta mal provisto: ", vehicleCode.ToString());
            return PartialView(model);
        }

        [HttpGet]
        public virtual ActionResult DatosVariableVehiculo(int vehicleCode, string variableName)
        {
            TempHeadModel model = new TempHeadModel();
            model.SomeName = "Nombre Cabecera";
            model.ChildData = new List<TempChildModel>();
            model.ChildData.Add(new TempChildModel() { Type = "string" });
            model.ChildData.Add(new TempChildModel() { Type = "decimal" });
            model.ChildData.Add(new TempChildModel() { Type = "datetime" });
            return PartialView(model);
        }

        [HttpPost]
        public virtual ActionResult DatosVariableVehiculo(TempHeadModel model)
        {
            if (ModelState.IsValid)
                ;
            return View(model);
        }
    }

    public class TempHeadModel
    {
        public string SomeName { get; set; }
        public IList<TempChildModel> ChildData { get; set; }
    }
    public class TempChildModel
    {
        public string Type { get; set; }
        public string Value { get; set; }
    }
}