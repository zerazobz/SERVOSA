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
    public partial class DriverDashboardController : Controller
    {
        private IDriverService _driverServices;
        private readonly IDBServices _dbServices;
        private readonly IDriverDBServices _dbDriverServices;
        private IDriverAlertService _driverAlertService;

        public DriverDashboardController(IDriverService injectedDriverRep, IDriverDBServices injectedDriverDbService, IDriverAlertService vehiceAlertInjectedService, IDBServices injectedDbService)
        {
            _driverServices = injectedDriverRep;
            _dbDriverServices = injectedDriverDbService;
            _driverAlertService = vehiceAlertInjectedService;
            _dbServices = injectedDbService;
        }

        [HttpGet]
        public virtual ActionResult Index()
        {
            int alertsSended = _driverAlertService.ProcessAlerts(new string[] { "51950313361" });
            
            var allCompleteTable = _dbDriverServices.ListDriversVarsTablesWithDefinition();
            var tableDataGrouped = allCompleteTable.GroupBy(t => t.TableNormalizedName);

            IList<DriverTableColumnViewModel> collectionTables = new List<DriverTableColumnViewModel>();

            foreach (var iTableColumn in tableDataGrouped)
            {
                DriverTableColumnViewModel nTable = new DriverTableColumnViewModel();
                nTable.TableNormalizedName = iTableColumn.Key;
                nTable.Columns = new List<DriverColumnViewModel>();
                nTable.TableName = iTableColumn.FirstOrDefault()?.TableName;
                nTable.TableId = (iTableColumn.FirstOrDefault()?.TableId)?? 0;

                DriverColumnViewModel nColumn;
                foreach (var iDisaggregated in iTableColumn.Where(c => !String.IsNullOrWhiteSpace(c.ColumnName)))
                {
                    //nTable.TableName = iDisaggregated.TableName;
                    //nTable.TableId = iDisaggregated.TableId;
                    nColumn = new DriverColumnViewModel();
                    nColumn.ColumnName = iDisaggregated.ColumnName;
                    nColumn.ColumnNormalizedName = iDisaggregated.ColumnNormalizedName;
                    nColumn.SystemType = iDisaggregated.SystemType;
                    nColumn.TypeName = iDisaggregated.TypeName;
                    nColumn.UserType = iDisaggregated.UserType;
                    nTable.Columns.Add(nColumn);
                }
                collectionTables.Add(nTable);
            }

            return View(MVC.DriverDashboard.Views.Index, collectionTables);
        }

        [ChildActionOnly]
        [HttpGet]
        public virtual ActionResult DriverTable()
        {
            var driverData = _driverServices.GetAll();

            return PartialView(MVC.DriverDashboard.Views.DriverTable, driverData);
        }

        [HttpGet]
        public virtual ActionResult DriverDataTable(DriverTableServiceModel model)
        {
            return PartialView(MVC.DriverDashboard.Views.DriverDataTable, model);
        }

        [HttpPost]
        public JsonResult ChangeTableName(string oldTableName, string newTableName)
        {
            var executionResult = _dbServices.ChangeDriverTableName(oldTableName, newTableName);
            return Json(executionResult);
        }

        [HttpPost]
        public JsonResult RemoveTable(string tableName)
        {
            var executionResult = _dbServices.RemoveDriverTable(tableName);
            return Json(executionResult);
        }
    }
}