using SERVOSA.SAIR.SERVICE.Contracts;
using SERVOSA.SAIR.SERVICE.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
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
        public virtual ActionResult Data(int vehicleCode, string variableName)
        {
            ViewBag.VehicleCode = vehicleCode;
            ViewBag.TableName = variableName;
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
            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-PE");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-PE");
            var currentThread = Thread.CurrentThread.CurrentCulture;
            var currentThreadUI = Thread.CurrentThread.CurrentUICulture;
            //TempHeadModel model = new TempHeadModel();
            //model.SomeName = "Nombre Cabecera";
            //model.ChildData = new List<TempChildModel>();
            //model.ChildData.Add(new TempChildModel() { Type = "string" });
            //model.ChildData.Add(new TempChildModel() { Type = "decimal" });
            //model.ChildData.Add(new TempChildModel() { Type = "datetime" });
            //return PartialView(model);
            var data = _vehicleService.GetVehicleVariableTableData(variableName, vehicleCode);
            data.ColumnsCollection.ForEach(cL =>
            {
                switch (cL.ColumnType)
                {
                    case "nvarchar":
                        cL.ColumnValue = cL.TableValue;
                        break;
                    case "decimal":
                        cL.ColumnValue = Convert.ToDecimal(cL.TableValue);
                        break;
                    case "datetime":
                        cL.ColumnValue = Convert.ToDateTime(cL.TableValue);
                        break;
                    default:
                        cL.ColumnValue = cL.TableValue;
                        break;
                }
            });

            return PartialView(data);
        }

        [HttpPost]
        public virtual ActionResult DatosVariableVehiculo(VehicleVariableDataServiceModel model)
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