using SERVOSA.SAIR.SERVICE.Contracts;
using SERVOSA.SAIR.SERVICE.Core;
using SERVOSA.SAIR.SERVICE.Models;
using SERVOSA.SAIR.SERVICE.Models.TableData;
using SERVOSA.SAIR.SERVICE.Models.Driver;
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
    public partial class DriverDataController : Controller
    {
        private readonly IDriverService _driverService;
        private readonly IDriverTableDataService _tableDataService;
        private readonly IDriverFileService _driverFileDataService;

        public DriverDataController(IDriverService injectedDriverSer, IDriverTableDataService injectedTableDataSer, IDriverFileService injectedVehiFileSer)
        {
            _driverService = injectedDriverSer;
            _tableDataService = injectedTableDataSer;
            _driverFileDataService = injectedVehiFileSer;
        }

        [HttpGet]
        public virtual ActionResult Data(int driverCode)
        {
            ViewBag.DriverCode = driverCode;
            var listRelatedTablesDriver = _driverService.GetListRelatedTablesToDriver();
            return View(listRelatedTablesDriver);
        }

        [HttpGet]
        public virtual ActionResult CabeceraVehiculo(int driverCode)
        {
            var model = _driverService.GetById(driverCode);
            if (model == null)
                throw new ArgumentException("El vehiculo no puede ser nulo, el código esta mal provisto: ", driverCode.ToString());
            return PartialView(model);
        }

        [HttpGet]
        public virtual ActionResult DatosVariableVehiculo(int driverCode, string variableName)
        {
            var data = _driverService.GetDriverVariableTableData(variableName, driverCode);
            var driverIdVarColumn = data.ColumnsCollection.Where(col => col.ColumnName == "SAIR_VEHIID").FirstOrDefault();
            var driverIdConsColumn = data.ColumnsCollection.Where(col => col.ColumnName == "CSAIR_VEHIID").FirstOrDefault();

            if (driverIdVarColumn != null && String.IsNullOrWhiteSpace(driverIdVarColumn.TableValue))
                driverIdVarColumn.TableValue = driverCode.ToString();
            if (driverIdConsColumn != null && String.IsNullOrWhiteSpace(driverIdConsColumn.TableValue))
                driverIdConsColumn.TableValue = driverCode.ToString();

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
        public virtual ActionResult GetFileModalManager(string tableName, int driverCode)
        {
            DriverFiles driverFileModel = new DriverFiles();
            IDriverServiceModel driverData = _driverService.GetById(driverCode);
            driverFileModel.Placa = driverData.Placa;
            driverFileModel.CodigoTipoUnidad = driverData.CodigoTipoUnidad;
            driverFileModel.Marca = driverData.Marca;
            driverFileModel.TableName = tableName;
            driverFileModel.Codigo = driverCode;
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
                                DriverId = model.Codigo
                            };

                            if (!Directory.Exists(destinationDirectory))
                                Directory.CreateDirectory(destinationDirectory);
                            var fileDestination = Path.Combine(destinationDirectory, iFile.FileName);
                            iFile.SaveAs(fileDestination);

                            var resultInsert = _driverFileDataService.InsertDriverFile(fileModelToinsert);
                        }
                    }
                }
            }

            return PartialView(model);
        }

        public virtual JsonResult ListFilesByTableAndDriver(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null, string tableName = null, int? driverCode = null)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(tableName) && driverCode.HasValue)
                {
                    int totalRecordsCount = 0;
                    var listCollection = _driverFileDataService.GetFilesByTableNameAndDriverId(tableName, driverCode.Value);

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
                var resultDelete = _driverFileDataService.DeleteDriverFile(new DriverFileServiceModel()
                {
                    TableName = fileCodes[1],
                    DriverId = Convert.ToInt32(fileCodes[0]),
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
                _driverService.GenerateReportForTable(tableName, memStream);
                string fileName = String.Format(" Datos de {0}_{1}.xlsx", tableName, DateTime.Now.ToString("ddMMyyyy_HHmm"));
                return File(memStream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
            }
            //return View();
        }

        public virtual FileResult DownloadDriverData(int driverId)
        {
            using (var memStream = new MemoryStream())
            {
                _driverService.GenerateReportForDriver(driverId, memStream);
                string fileName = String.Format(" Datos del Conductor {0}_{1}.xlsx", driverId, DateTime.Now.ToString("ddMMyyyy_HHmm"));
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