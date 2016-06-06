using SERVOSA.SAIR.SERVICE.Contracts;
using SERVOSA.SAIR.SERVICE.Core;
using SERVOSA.SAIR.SERVICE.Models;
using SERVOSA.SAIR.SERVICE.Models.TableData;
using SERVOSA.SAIR.SERVICE.Models.Vehicle;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SERVOSA.SAIR.WEB.Controllers
{
    [Authorize]
    public partial class VehicleDataController : Controller
    {
        private readonly IDriverService _vehicleService;
        private readonly IDriverTableDataService _tableDataService;
        private readonly IDriverFileService _vehicleFileDataService;

        public VehicleDataController(IDriverService injectedVehicleSer, IDriverTableDataService injectedTableDataSer, IDriverFileService injectedVehiFileSer)
        {
            _vehicleService = injectedVehicleSer;
            _tableDataService = injectedTableDataSer;
            _vehicleFileDataService = injectedVehiFileSer;
        }

        [HttpGet]
        public virtual ActionResult Data(int vehicleCode)
        {
            ViewBag.VehicleCode = vehicleCode;
            var listRelatedTablesVehicle = _vehicleService.GetListRelatedTablesToVehicle();
            return View(listRelatedTablesVehicle);
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
            var vehicleIdVarColumn = data.ColumnsCollection.Where(col => col.ColumnName == "SAIR_VEHIID").FirstOrDefault();
            var vehicleIdConsColumn = data.ColumnsCollection.Where(col => col.ColumnName == "CSAIR_VEHIID").FirstOrDefault();

            if (vehicleIdVarColumn != null && String.IsNullOrWhiteSpace(vehicleIdVarColumn.TableValue))
                vehicleIdVarColumn.TableValue = vehicleCode.ToString();
            if (vehicleIdConsColumn != null && String.IsNullOrWhiteSpace(vehicleIdConsColumn.TableValue))
                vehicleIdConsColumn.TableValue = vehicleCode.ToString();

            PopulateColumnsValues(data);

            return PartialView(data);
        }

        [HttpPost]
        public virtual ActionResult DatosVariableVehiculo(DriverVariableDataServiceModel model)
        {
            if (ModelState.IsValid)
            {
                int rowsAffected;
                var executionResponse = _tableDataService.InsertOrUpdateData(model);
                rowsAffected = executionResponse.Item2;
                model.IsSuccessful = executionResponse.Item1;
                model.Message = executionResponse.Item3;

                //var tableDictionaryData = new Dictionary<string, Tuple<SERVOSASqlTypes, Object>>();
                //tableDictionaryData = model.ColumnsCollection.ToDictionary(col => col.ColumnName, col => new Tuple<SERVOSASqlTypes, object>(col.ColumnNamedType, col.ColumnValue));

                //var columnFK = model.ColumnsCollection.Where(c => c.ColumnName == "SAIR_VEHIID").FirstOrDefault();
                //string fkValue = String.Empty;
                //var rawFkConvertion = columnFK.ColumnValue as string[];
                //if (rawFkConvertion.Length > 0)
                //    fkValue = rawFkConvertion[0];

                //var columnIdentity = model.ColumnsCollection.Where(c => c.ColumnName == "id").FirstOrDefault();
                //string identityValue = String.Empty;
                //var rawIdentityConvertion = columnIdentity.ColumnValue as string[];
                //if (rawIdentityConvertion.Length > 0)
                //    identityValue = rawIdentityConvertion[0];

                
                //if (columnIdentity != null && !String.IsNullOrWhiteSpace(identityValue))
                //{
                //    var updateResponse = _tableDataService.UpdateTableData(model.TableName, Convert.ToInt32(fkValue), tableDictionaryData);
                //    rowsAffected = updateResponse.Item2;
                //    model.IsSuccessful = updateResponse.Item1;
                //    model.Message = updateResponse.Item3;
                //}
                //else
                //{
                //    var insertResponse = _tableDataService.InsertTableData(model.TableName, tableDictionaryData);
                //    rowsAffected = insertResponse.Item2;
                //    model.IsSuccessful = insertResponse.Item1;
                //    model.Message = insertResponse.Item3;
                //}

                Debug.WriteLine("La ejecución termino con un: {0}", rowsAffected);
            }
            else
            {
                model.IsSuccessful = false;
                model.Message = "Por favor revisar la conformidad de los datos.";
            }
            return PartialView(model);
        }

        [HttpGet]
        public virtual ActionResult GetFileModalManager(string tableName, int vehicleCode)
        {
            DriverFiles driverFileModel = new DriverFiles();
            IDriverServiceModel driverData = _vehicleService.GetById(vehicleCode);
            driverFileModel.Placa = driverData.Placa;
            driverFileModel.CodigoTipoUnidad = driverData.CodigoTipoUnidad;
            driverFileModel.Marca = driverData.Marca;
            driverFileModel.TableName = tableName;
            driverFileModel.Codigo = vehicleCode;
            driverFileModel.Address = driverData.Address;
            driverFileModel.BirthDate = driverData.BirthDate;
            return PartialView(driverFileModel);
        }

        [HttpPost]
        public virtual ActionResult GetFileModalManager(DriverFiles model)
        {
            if (ModelState.IsValid)
            {
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var iFile = Request.Files[i];
                    if (iFile != null && iFile.ContentLength > 0)
                    {
                        var filename = Path.GetFileName(iFile.FileName);
                        byte[] data;

                        using (Stream inputStream = iFile.InputStream)
                        {
                            MemoryStream memoryStream = inputStream as MemoryStream;
                            if (memoryStream == null)
                            {
                                memoryStream = new MemoryStream();
                                inputStream.CopyTo(memoryStream);
                            }
                            data = memoryStream.ToArray();
                        }
                        if (data.Length > 0)
                        {
                            var destinationDirectory = Path.Combine(Server.MapPath("~"), "Files", model.TableName, model.Codigo.ToString());

                            DriverFileServiceModel fileModelToinsert = new DriverFileServiceModel()
                            {
                                DataFile = data,
                                DateCreated = DateTime.Now,
                                FileContentType = iFile.ContentType,
                                FileLocationStored = destinationDirectory,
                                FileName = iFile.FileName,
                                TableName = model.TableName,
                                VehicleId = model.Codigo
                            };

                            if (!Directory.Exists(destinationDirectory))
                                Directory.CreateDirectory(destinationDirectory);
                            var fileDestination = Path.Combine(destinationDirectory, iFile.FileName);
                            iFile.SaveAs(fileDestination);

                            var resultInsert = _vehicleFileDataService.InsertVehicleFile(fileModelToinsert);
                        }
                    }
                }
            }

            return PartialView(model);
        }

        public virtual JsonResult ListFilesByTableAndVehicle(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null, string tableName = null, int? vehicleCode = null)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(tableName) && vehicleCode.HasValue)
                {
                    int totalRecordsCount = 0;
                    var listCollection = _vehicleFileDataService.GetFilesByTableNameAndVehicleId(tableName, vehicleCode.Value);

                    return Json(new { Result = "OK", Records = listCollection, TotalRecordCount = listCollection.Count });
                }
                else
                    return Json(new { Result = "ERROR", Message = "Error en la Integridad de Datos" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        public virtual JsonResult DeleteFile(string ComposedPrimaryKey)
        {
            try
            {
                string[] fileCodes = ComposedPrimaryKey.Split(new string[] { "|@|" }, StringSplitOptions.RemoveEmptyEntries);
                string pathToRemove = Path.Combine(Server.MapPath("~"), "Files", fileCodes[1], fileCodes[0], fileCodes[2]);
                System.IO.File.Delete(pathToRemove);
                var resultDelete = _vehicleFileDataService.DeleteVehicleFile(new DriverFileServiceModel()
                {
                    TableName = fileCodes[1],
                    VehicleId = Convert.ToInt32(fileCodes[0]),
                    FileName = fileCodes[2]
                });

                if (resultDelete.Item1)
                    return Json(new { Result = "OK" });
                else
                    return Json(new { Result = "ERROR", Message = resultDelete.Item3 });
                //var destinationDirectory = Path.Combine(Server.MapPath("~"), "Files", model.TableName, model.Codigo.ToString());
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        public virtual ActionResult DownloadVariable(string tableName)
        {
            using (var memStream = new MemoryStream())
            {
                _vehicleService.GenerateReportForTable(tableName, memStream);
                string fileName = String.Format(" Datos de {0}_{1}.xlsx", tableName, DateTime.Now.ToString("ddMMyyyy_HHmm"));
                return File(memStream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
            }
            //return View();
        }

        public virtual FileResult DownloadVehicleData(int vehicleId)
        {
            using (var memStream = new MemoryStream())
            {
                _vehicleService.GenerateReportForVehicle(vehicleId, memStream);
                string fileName = String.Format(" Datos del Conductor {0}_{1}.xlsx", vehicleId, DateTime.Now.ToString("ddMMyyyy_HHmm"));
                return File(memStream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
            }
        }

        private void PopulateColumnsValues(DriverVariableDataServiceModel dataToWork)
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