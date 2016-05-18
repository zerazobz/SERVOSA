using SERVOSA.SAIR.SERVICE.Contracts;
using SERVOSA.SAIR.SERVICE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SERVOSA.SAIR.WEB.Controllers
{
    public partial class VehicleController : Controller
    {
        private IVehicleService _vehicleService;
        private ITypeService _typeService;

        public VehicleController(IVehicleService injectedVehicleServ, ITypeService injectedTypeService)
        {
            _vehicleService = injectedVehicleServ;
            _typeService = injectedTypeService;
        }

        [HttpGet]
        public virtual ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public virtual JsonResult ListVehicles(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                var collectionVehicles = _vehicleService.GetAllFiltered(jtStartIndex, jtStartIndex + jtPageSize);
                int totalRows = 0;
                if (collectionVehicles != null && collectionVehicles.Count > 0)
                    totalRows = collectionVehicles.FirstOrDefault().TotalRows;

                return Json(new { Result = "OK", Records = collectionVehicles, TotalRecordCount = totalRows });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public virtual JsonResult DeleteVehicle(int Codigo)
        {
            try
            {
                var deleteResult = _vehicleService.Delete(new VehicleServiceModel()
                {
                    Codigo = Codigo
                });
                if (deleteResult > 0)
                    return Json(new { Result = "OK" });
                else
                    return Json(new { Result = "ERROR", Message = "No se elimino ningún registro." });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public virtual JsonResult UpdateVehicle(VehicleServiceModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return Json(new { Result = "ERROR", Message = "Los campos insertados no són validos." });

                var updateResult = _vehicleService.Update(model);
                if (updateResult > 0)
                    return Json(new { Result = "OK" });
                else
                    return Json(new { Result = "ERROR", Message = "No se actualizo ningún registro." });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public virtual JsonResult CreateVehicle(VehicleServiceModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return Json(new { Result = "ERROR", Message = "Los campos insertados no són validos." });

                var createResult = _vehicleService.Create(model);
                if (createResult > 0)
                    return Json(new { Result = "OK", Record = model });
                else
                    return Json(new { Result = "ERROR", Message = "No se creo ningún registro." });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public virtual JsonResult LoadTablaData(string tableName)
        {
            var dataResult = _vehicleService.GetVehicleRowDataForTable(tableName);
            return Json(dataResult);
        }

        [HttpPost]
        public virtual JsonResult GetVehiculos()
        {
            try
            {
                var allVehiculos = _vehicleService.GetAll().Select(op => new { DisplayText = op.PlacaTolva + '/' +op.PlacaTracto, Value = op.Codigo});
                return Json(new { Result = "OK", Options = allVehiculos });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public virtual JsonResult GetVehicleBrands()
        {
            try
            {
                var allTypes = _typeService.GetAllTypesByTable("BRND").Select(bT => new { DisplayText = bT.Description, Value = bT.ConcatenatedCode });
                return Json(new { Result = "OK", Options = allTypes });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public virtual JsonResult GetVehicleStates()
        {
            try
            {
                var vehicleStates = _typeService.GetAllTypesByTable("VSTA").Select(vS => new { DisplayText = vS.Description, Value = vS.ConcatenatedCode });
                return Json(new { Result = "OK", Options = vehicleStates });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
    }
}