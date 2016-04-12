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
    public class VehicleController : Controller
    {
        private IVehicleRepository _vehicleRepository;

        public VehicleController(IVehicleRepository injectedVehicleRep)
        {
            _vehicleRepository = injectedVehicleRep;
        }

        [HttpGet]
        public ActionResult Index()
        {
            List<TableModel> data = new List<TableModel>()
            {
                new TableModel() { TableName = "SUNAT" },
                new TableModel() { TableName = "INMIGRACIONES" },
                new TableModel() { TableName = "PEAJE" }
            };

            return View(data);
        }
        
        [HttpGet]
        public ActionResult VehicleDataTable(TableModel model)
        {
            return PartialView(model);
        }

        [HttpPost]
        public JsonResult ListVehicles(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                var collectionVehicles = _vehicleRepository.GetAllFiltered(jtStartIndex, jtStartIndex + jtPageSize);
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
        public JsonResult DeleteVehicle(int Codigo)
        {
            try
            {
                var deleteResult = _vehicleRepository.Delete(new VehicleModel()
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
        public JsonResult UpdateVehicle(VehicleModel model)
        {
            try
            {
                if(!ModelState.IsValid)
                    return Json(new { Result = "ERROR", Message = "Los campos insertados no són validos." });

                var updateResult = _vehicleRepository.Update(model);
                if(updateResult > 0)
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
        public JsonResult CreateVehicle(VehicleModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return Json(new { Result = "ERROR", Message = "Los campos insertados no són validos." });

                var createResult = _vehicleRepository.Create(model);
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
    }
}