using SERVOSA.SAIR.SERVICE.Contracts;
using SERVOSA.SAIR.SERVICE.Core;
using SERVOSA.SAIR.SERVICE.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SERVOSA.SAIR.WEB.Controllers
{
    public partial class VehicleDataController : Controller
    {
        private readonly IVehicleService _vehicleService;
        private readonly ITableDataService _tableDataService;

        public VehicleDataController(IVehicleService injectedVehicleSer, ITableDataService injectedTableDataRepo)
        {
            _vehicleService = injectedVehicleSer;
            _tableDataService = injectedTableDataRepo;
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
            var data = _vehicleService.GetVehicleVariableTableData(variableName, vehicleCode);
            var vehicleIdColumn = data.ColumnsCollection.Where(col => col.ColumnName == "SAIR_VEHIID").FirstOrDefault();
            if (vehicleIdColumn != null && String.IsNullOrWhiteSpace(vehicleIdColumn.TableValue))
                vehicleIdColumn.TableValue = vehicleCode.ToString();
            PopulateColumnsValues(data);

            return PartialView(data);
        }

        [HttpPost]
        public virtual ActionResult DatosVariableVehiculo(VehicleVariableDataServiceModel model)
        {
            if (ModelState.IsValid)
            {
                var tableDictionaryData = new Dictionary<string, Tuple<SERVOSASqlTypes, Object>>();
                tableDictionaryData = model.ColumnsCollection.ToDictionary(col => col.ColumnName, col => new Tuple<SERVOSASqlTypes, object>(col.ColumnNamedType, col.ColumnValue));

                var columnFK = model.ColumnsCollection.Where(c => c.ColumnName == "SAIR_VEHIID").FirstOrDefault();
                string fkValue = String.Empty;
                var rawFkConvertion = columnFK.ColumnValue as string[];
                if (rawFkConvertion.Length > 0)
                    fkValue = rawFkConvertion[0];

                var columnIdentity = model.ColumnsCollection.Where(c => c.ColumnName == "id").FirstOrDefault();
                string identityValue = String.Empty;
                var rawIdentityConvertion = columnIdentity.ColumnValue as string[];
                if (rawIdentityConvertion.Length > 0)
                    identityValue = rawIdentityConvertion[0];

                int resultExecution;
                if (columnIdentity != null && !String.IsNullOrWhiteSpace(identityValue))
                    resultExecution = _tableDataService.UpdateTableData(model.TableName, Convert.ToInt32(fkValue), tableDictionaryData);
                else
                    resultExecution = _tableDataService.InsertTableData(model.TableName, tableDictionaryData);

                Debug.WriteLine("La ejecución termino con un: {0}", resultExecution);
            }
            return PartialView(model);
        }

        private void PopulateColumnsValues(VehicleVariableDataServiceModel dataToWork)
        {
            dataToWork.ColumnsCollection.ForEach(cL =>
            {
                switch (cL.ColumnNamedType)
                {
                    case SERVOSASqlTypes.Int:
                        cL.ColumnValue = cL.TableValue;
                        break;
                    case SERVOSASqlTypes.Decimal:
                        cL.ColumnValue = Convert.ToDecimal(cL.TableValue);
                        break;
                    case SERVOSASqlTypes.NVarChar:
                        cL.ColumnValue = cL.TableValue;
                        break;
                    case SERVOSASqlTypes.DateTime:
                        cL.ColumnValue = Convert.ToDateTime(cL.TableValue);
                        cL.ColumnValue = (DateTime)cL.ColumnValue == DateTime.MinValue ? DateTime.Now : cL.ColumnValue;
                        break;
                    default:
                        cL.ColumnValue = cL.TableValue;
                        break;
                }
            });
        }
    }
}