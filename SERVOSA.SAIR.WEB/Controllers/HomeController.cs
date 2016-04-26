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

        public HomeController(IVehicleService injectedVehicleRep, IDBServices _injectedDbService)
        {
            _vehicleServices = injectedVehicleRep;
            _dbServices = _injectedDbService;
        }

        [HttpGet]
        public virtual ActionResult Index()
        {
            var allCompleteTable = _dbServices.ListTablesColumnCompleteData();
            var tableDataGrouped = allCompleteTable.GroupBy(t => t.TableNormalizedName);

            IList<TableColumnViewModel> collectionTables = new List<TableColumnViewModel>();

            foreach (var iTableColumn in tableDataGrouped)
            {
                TableColumnViewModel nTable = new TableColumnViewModel();
                nTable.TableNormalizedName = iTableColumn.Key;
                nTable.Columns = new List<ColumnViewModel>();

                ColumnViewModel nColumn;
                foreach (var iDisaggregated in iTableColumn)
                {
                    nTable.TableId = iDisaggregated.TableId;
                    nColumn = new ColumnViewModel();
                    nColumn.ColumnName = iDisaggregated.ColumnName;
                    nColumn.ColumnNormalizedName = iDisaggregated.ColumnNormalizedName;
                    nColumn.SystemType = iDisaggregated.SystemType;
                    nColumn.TypeName = iDisaggregated.TypeName;
                    nColumn.UserType = iDisaggregated.UserType;
                    nTable.Columns.Add(nColumn);
                }
            }

            var allTables = _dbServices.ListAllTables();

            //List<TableViewModel> data = new List<TableViewModel>()
            //{
            //    new TableViewModel() { TableName = "INMIGRACIONES", TableNormalizedName = "INMIGRACIONES" }
            //};
            return View(MVC.Home.Views.Index, allTables);
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