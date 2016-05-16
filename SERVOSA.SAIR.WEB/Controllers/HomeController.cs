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
    public partial class HomeController : Controller
    {
        private IVehicleService _vehicleServices;
        private IDBServices _dbServices;
        private IVehicleAlertService _vehicleAlertService;

        public HomeController(IVehicleService injectedVehicleRep, IDBServices injectedDbService, IVehicleAlertService vehiceAlertInjectedService)
        {
            _vehicleServices = injectedVehicleRep;
            _dbServices = injectedDbService;
            _vehicleAlertService = vehiceAlertInjectedService;
        }

        [HttpGet]
        public virtual ActionResult Index()
        {
            int alertsSended = _vehicleAlertService.ProcessAlerts(new string[] { "51950313361" });
            
            var allCompleteTable = _dbServices.ListTablesWithColumnCompleteData();
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

            return View(MVC.Home.Views.Index, collectionTables);
        }

        [ChildActionOnly]
        [HttpGet]
        public virtual ActionResult VehicleTable()
        {
            var vehicleData = _vehicleServices.GetAll();

            return PartialView(MVC.Home.Views.VehicleTable, vehicleData);
        }

        [HttpGet]
        public virtual ActionResult VehicleDataTable(TableServiceModel model)
        {
            return PartialView(MVC.Home.Views.VehicleDataTable, model);
        }
    }
}