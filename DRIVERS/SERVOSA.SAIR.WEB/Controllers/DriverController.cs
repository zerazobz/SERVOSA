using SERVOSA.SAIR.SERVICE.Contracts;
using SERVOSA.SAIR.SERVICE.Models;
using SERVOSA.SAIR.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SERVOSA.SAIR.WEB.Controllers
{
    [Authorize]
    public partial class DriverController : Controller
    {
        private IOldDriverService _driverService;
        private readonly IDriverDBServices _dbServices;

        public DriverController(IOldDriverService injectedDriverServ, IDriverDBServices injectedDBService)
        {
            _driverService = injectedDriverServ;
            _dbServices = injectedDBService;
        }

        [HttpGet]
        public virtual ActionResult Index()
        {
            return View();
        }

        public virtual ActionResult DriversMainData()
        {
            var allCompleteTable = _dbServices.ListVehicleVarsTablesWithDefinition();
            var tableDataGrouped = allCompleteTable.GroupBy(t => t.TableNormalizedName);

            IList<TableColumnViewModel> collectionTables = new List<TableColumnViewModel>();

            foreach (var iTableColumn in tableDataGrouped)
            {
                TableColumnViewModel nTable = new TableColumnViewModel();
                nTable.TableNormalizedName = iTableColumn.Key;
                nTable.Columns = new List<ColumnViewModel>();

                ColumnViewModel nColumn;
                foreach (var iDisaggregated in iTableColumn.Where(c => !String.IsNullOrWhiteSpace(c.ColumnName)))
                {
                    nTable.TableName = iDisaggregated.TableName;
                    nTable.TableId = iDisaggregated.TableId;
                    nColumn = new ColumnViewModel();
                    nColumn.ColumnName = iDisaggregated.ColumnName;
                    nColumn.ColumnNormalizedName = iDisaggregated.ColumnNormalizedName;
                    nColumn.SystemType = iDisaggregated.SystemType;
                    nColumn.TypeName = iDisaggregated.TypeName;
                    nColumn.UserType = iDisaggregated.UserType;
                    nTable.Columns.Add(nColumn);
                }
                collectionTables.Add(nTable);
            }
            return View(collectionTables);
        }

        [ChildActionOnly]
        [HttpGet]
        public virtual ActionResult DriversTable()
        {
            var driversData = _driverService.GetAll();

            return PartialView(driversData);
        }

        [HttpGet]
        public virtual ActionResult DriverDataTable(DriverTableServiceModel model)
        {
            return PartialView(model);
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
        public virtual JsonResult DeleteDriver(int CodigoOperario)
        {
            try
            {
                var deleteResult = _driverService.Create(new OldDriverServiceModel()
                {
                    CodigoOperario = CodigoOperario
                });
                if (deleteResult > 0)
                    return Json(new { Result = "OK" });
                else
                    return Json(new { Result = "ERROR", Message = "No se elimino ningún registro." });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = "No se puede eliminar el operario por que el operario esta asignado a un vehiculo" });
            }
        }


        [HttpPost]
        public virtual JsonResult UpdateDriver(OldDriverServiceModel model)
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
        public virtual JsonResult CreateDriver(OldDriverServiceModel model)
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
        public virtual ActionResult UploadFile(HttpPostedFileBase excelFile)
        {
            return View("Index");
        }
        [HttpGet]
        public virtual ActionResult LoadFiles()
        {
            OldDriverServiceModel model = new OldDriverServiceModel();
            return PartialView("LoadFiles", model);
        }
    }
}
