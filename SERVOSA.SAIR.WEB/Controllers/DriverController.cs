using SERVOSA.SAIR.SERVICE.Contracts;
using SERVOSA.SAIR.SERVICE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace SERVOSA.SAIR.WEB.Controllers
{
    [Authorize]
    public partial class DriverController : Controller
    {
        private IDriverService _driverService;
        private IDriverTypeService _typeService;

        public DriverController(IDriverService injectedDriverServ, IDriverTypeService injectedTypeService)
        {
            _driverService = injectedDriverServ;
            _typeService = injectedTypeService;
        }

        [HttpGet]
        public virtual ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public virtual JsonResult ListDrivers(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                var collectionDrivers = _driverService.GetAllFiltered(jtStartIndex, jtStartIndex + jtPageSize);
                int totalRows = 0;
                if (collectionDrivers != null && collectionDrivers.Count > 0)
                    totalRows = collectionDrivers.FirstOrDefault().TotalRows;

                return Json(new { Result = "OK", Records = collectionDrivers, TotalRecordCount = totalRows });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public virtual JsonResult DeleteDriver(int Codigo)
        {
            try
            {
                var deleteResult = _driverService.Delete(new DriverServiceModel()
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
        public virtual JsonResult UpdateDriver(DriverServiceModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return Json(new { Result = "ERROR", Message = "Los campos insertados no són validos." });

                var updateResult = _driverService.Update(model);
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
        public virtual JsonResult CreateDriver(DriverServiceModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return Json(new { Result = "ERROR", Message = "Los campos insertados no són validos." });

                var createResult = _driverService.Create(model);
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
            var dataResult = _driverService.GetDriverRowDataForTable(tableName);
            return Json(dataResult);
        }

        [HttpPost]
        public virtual JsonResult GetVehiculos()
        {
            try
            {
                var allVehiculos = _driverService.GetAll().Select(op => new { DisplayText = op.DescripcionTipoUnidad + '/' +op.Placa, Value = op.Codigo});
                return Json(new { Result = "OK", Options = allVehiculos });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public virtual JsonResult GetDriverBrands()
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
        public virtual JsonResult GetDriverStates()
        {
            try
            {
                var driverStates = _typeService.GetAllTypesByTable("VSTA").Select(vS => new { DisplayText = vS.Description, Value = vS.ConcatenatedCode });
                return Json(new { Result = "OK", Options = driverStates });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public virtual JsonResult GetDriversUnitTypes()
        {
            try
            {
                Dictionary<string, string> driverUnitTypes = new Dictionary<string, string>()
                {
                    { "R", "Remolque" },
                    { "S", "Semi-Remolque" }
                };
                return Json(new { Result = "OK", Options = driverUnitTypes.Select(uT => new { DisplayText = uT.Value, Value = uT.Key }) });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public virtual JsonResult SearchDriverForAutoComplete(string searchText, int maxResults)
        {
            var collectionDrivers = _driverService.GetAllFilteredBySearchTerm(searchText);
            return Json(collectionDrivers);
        }
    }
}