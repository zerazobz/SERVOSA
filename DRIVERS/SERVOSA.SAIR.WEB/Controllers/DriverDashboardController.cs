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
        private readonly IDriverDBServices _dbServices;
        private IDriverAlertService _driverAlertService;

        public DriverDashboardController(IDriverService injectedDriverRep, IDriverDBServices injectedDbService, IDriverAlertService vehiceAlertInjectedService)
        {
            _driverServices = injectedDriverRep;
            _dbServices = injectedDbService;
            _driverAlertService = vehiceAlertInjectedService;
        }

        [HttpGet]
        public virtual ActionResult Index()
        {
            int alertsSended = _driverAlertService.ProcessAlerts(new string[] { "51950313361" });
            
            var allCompleteTable = _dbServices.ListDriversVarsTablesWithDefinition();
            var tableDataGrouped = allCompleteTable.GroupBy(t => t.TableNormalizedName);

            IList<TableColumnViewModel> collectionTables = new List<TableColumnViewModel>();

            foreach (var iTableColumn in tableDataGrouped)
            {
                TableColumnViewModel nTable = new TableColumnViewModel();
                nTable.TableNormalizedName = iTableColumn.Key;
                nTable.Columns = new List<ColumnViewModel>();
                nTable.TableName = iTableColumn.FirstOrDefault()?.TableName;
                nTable.TableId = (iTableColumn.FirstOrDefault()?.TableId)?? 0;

                ColumnViewModel nColumn;
                foreach (var iDisaggregated in iTableColumn.Where(c => !String.IsNullOrWhiteSpace(c.ColumnName)))
                {
                    //nTable.TableName = iDisaggregated.TableName;
                    //nTable.TableId = iDisaggregated.TableId;
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
    }
}