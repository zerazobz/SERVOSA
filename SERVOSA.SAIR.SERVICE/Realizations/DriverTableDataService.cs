using SERVOSA.SAIR.SERVICE.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SERVOSA.SAIR.SERVICE.Core;
using SERVOSA.SAIR.DATAACCESS.Contracts;
using SERVOSA.SAIR.SERVICE.Models.TableData;
using System.Globalization;
using SERVOSA.SAIR.SERVICE.Models;

namespace SERVOSA.SAIR.SERVICE.Realizations
{
    public class DriverTableDataService : IDriverTableDataService
    {
        private readonly IDriverTableDataRepository _tableDataRepository;
        private readonly IDriverAlertService _vehicleAlertService;

        public DriverTableDataService(IDriverTableDataRepository injectedTableDataRepo, IDriverAlertService injectedVehiceAlertService)
        {
            _tableDataRepository = injectedTableDataRepo;
            _vehicleAlertService = injectedVehiceAlertService;
        }

        public Tuple<bool, int, string> InsertTableData(string tableName, Dictionary<string, Tuple<SERVOSASqlTypes, object>> tableData, bool variableData)
        {
            bool executionResult;
            string messageResult;
            bool isUpdate = false;
            Dictionary<string, string> dataPrepared = PrepareData(tableData, isUpdate, variableData);
            int rowsAffected = 0;
            rowsAffected = _tableDataRepository.InsertDataToTable(tableName, dataPrepared, variableData);

            if(!variableData)
            {
                var alertModel = GetAlertModelFromDataDictionary(dataPrepared);
                if (alertModel != null)
                {
                    alertModel.TableName = tableName;
                    var alertInsertResult = _vehicleAlertService.RegisterAlert(alertModel);
                    rowsAffected += alertInsertResult;
                }
            }

            if (rowsAffected > 0)
            {
                executionResult = true;
                messageResult = "La inserción de datos se realizó satisfactoriamente.";
            }
            else
            {
                executionResult = false;
                messageResult = "La inserción de datos no se pudo concretar.";
            }
            return new Tuple<bool, int, string>(executionResult, rowsAffected, messageResult);
        }

        public Tuple<bool, int, string> UpdateTableData(string tableName, int vehicleId, Dictionary<string, Tuple<SERVOSASqlTypes, object>> tableData, bool isVariableData)
        {
            string messageResult = String.Empty;
            bool updateResult = false;
            bool isUpdate = true;

            Dictionary<string, string> dataPrepared = PrepareData(tableData, isUpdate, isVariableData);
            int rowsAffected = _tableDataRepository.UpdateDataToTable(tableName, vehicleId, dataPrepared, isVariableData);
            if (rowsAffected > 0)
            {
                updateResult = true;
                messageResult = "La actualización de datos culmino satisfactoriamente.";
            }
            else
            {
                updateResult = false;
                messageResult = "La actualización de datos no se pudo concretar.";
            }
            return new Tuple<bool, int, string>(updateResult, rowsAffected, messageResult);
        }

        //public Tuple<bool, int, string> InsertOrUpdateVariableData(VehicleVariableDataServiceModel model, Dictionary<string, Tuple<SERVOSASqlTypes, Object>> tableData)
        //{
        //    var columnFK = model.ColumnsCollection.Where(c => c.ColumnName == "SAIR_VEHIID").FirstOrDefault();
        //    string fkValue = String.Empty;
        //    var rawFkConvertion = columnFK.ColumnValue as string[];
        //    if (rawFkConvertion.Length > 0)
        //        fkValue = rawFkConvertion[0];

        //    var columnIdentity = model.ColumnsCollection.Where(c => c.ColumnName == "id").FirstOrDefault();
        //    string identityValue = String.Empty;
        //    var rawIdentityConvertion = columnIdentity.ColumnValue as string[];
        //    if (rawIdentityConvertion.Length > 0)
        //        identityValue = rawIdentityConvertion[0];

        //    if (columnIdentity != null && !String.IsNullOrWhiteSpace(identityValue))
        //        return UpdateTableData(model.TableName, Convert.ToInt32(fkValue), tableData);
        //    else
        //        return InsertTableData(model.TableName, tableData);
        //}

        public Tuple<bool, int, string> InsertOrUpdateData(DriverVariableDataServiceModel model)
        {
            Tuple<bool, int, string> resultForConstants = null;
            Tuple<bool, int, string> resultForVariables = null;

            {
                bool isVariableData = true;
                Dictionary<string, Tuple<SERVOSASqlTypes, Object>> tableData = model.ColumnsCollection.Where(col => !ServosaDriverSingleton.Instance.AllConstantColumns.Contains(col.ColumnName))
                .ToDictionary(col => col.ColumnName, col => new Tuple<SERVOSASqlTypes, object>(col.ColumnNamedType, col.ColumnValue));

                var columnFK = model.ColumnsCollection.Where(c => c.ColumnName == ServosaDriverSingleton.Instance.ConstantVehicleId).FirstOrDefault();
                string fkValue = String.Empty;
                var rawFkConvertion = columnFK.ColumnValue as string[];
                if (rawFkConvertion.Length > 0)
                    fkValue = rawFkConvertion[0];

                var columnIdentity = model.ColumnsCollection.Where(c => c.ColumnName == ServosaDriverSingleton.Instance.ConstantIdentity).FirstOrDefault();
                string identityValue = String.Empty;
                var rawIdentityConvertion = columnIdentity.ColumnValue as string[];
                if (rawIdentityConvertion.Length > 0)
                    identityValue = rawIdentityConvertion[0];

                if (columnIdentity != null && !String.IsNullOrWhiteSpace(identityValue))
                    resultForConstants = UpdateTableData(model.TableName, Convert.ToInt32(fkValue), tableData, isVariableData);
                else
                    resultForConstants = InsertTableData(model.TableName, tableData, isVariableData);
            }

            {
                bool isVariableData = false;
                Dictionary<string, Tuple<SERVOSASqlTypes, Object>> tableData = model.ColumnsCollection.Where(col => ServosaDriverSingleton.Instance.AllConstantColumns.Contains(col.ColumnName))
                .ToDictionary(col => col.ColumnName, col => new Tuple<SERVOSASqlTypes, object>(col.ColumnNamedType, col.ColumnValue));

                var columnFK = model.ColumnsCollection.Where(c => c.ColumnName == ServosaDriverSingleton.Instance.VariableVehicleId).FirstOrDefault();
                string fkValue = String.Empty;
                var rawFkConvertion = columnFK.ColumnValue as string[];
                if (rawFkConvertion.Length > 0)
                    fkValue = rawFkConvertion[0];

                var columnIdentity = model.ColumnsCollection.Where(c => c.ColumnName == ServosaDriverSingleton.Instance.VariableIdentity).FirstOrDefault();
                string identityValue = String.Empty;
                var rawIdentityConvertion = columnIdentity.ColumnValue as string[];
                if (rawIdentityConvertion.Length > 0)
                    identityValue = rawIdentityConvertion[0];

                if (columnIdentity != null && !String.IsNullOrWhiteSpace(identityValue))
                    resultForVariables = UpdateTableData(model.TableName, Convert.ToInt32(fkValue), tableData, isVariableData);
                else
                    resultForVariables = InsertTableData(model.TableName, tableData, isVariableData);
            }

            return resultForVariables;
        }

        private Dictionary<string, string> PrepareData(Dictionary<string, Tuple<SERVOSASqlTypes, object>> tableData, bool isUpdate, bool variableData)
        {
            string[] dataToFilter = isUpdate?
                variableData ? ServosaDriverSingleton.Instance.VariableNonUpdateColumns.ToArray() : ServosaDriverSingleton.Instance.ConstantNonUpdateColumns.ToArray()
                : variableData ? ServosaDriverSingleton.Instance.VariableNonInsertColumns.ToArray() : ServosaDriverSingleton.Instance.ConstantNonInsertColumns.ToArray();

            var preCollectionData = tableData.Where(kvp => !dataToFilter.Contains(kvp.Key)).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            Dictionary<string, string> dataPrepared = new Dictionary<string, string>();
            foreach (var iDataKVP in preCollectionData)
            {
                string dataValueFormatted;
                string dataParsed = String.Empty;
                switch (iDataKVP.Value.Item1)
                {
                    case SERVOSASqlTypes.Int:
                        dataParsed = GetValueFromObject(iDataKVP.Value.Item2);
                        dataValueFormatted = String.IsNullOrWhiteSpace(dataParsed) ? "NULL": dataParsed;
                        break;
                    case SERVOSASqlTypes.Decimal:
                        dataParsed = GetValueFromObject(iDataKVP.Value.Item2);
                        dataValueFormatted = String.IsNullOrWhiteSpace(dataParsed)? "NULL" : dataParsed;
                        break;
                    case SERVOSASqlTypes.NVarChar:
                        dataValueFormatted = String.Format("'{0}'", GetValueFromObject(iDataKVP.Value.Item2));
                        break;
                    case SERVOSASqlTypes.DateTime:
                        dataValueFormatted = String.Format("'{0}'", GetValueFromObject(iDataKVP.Value.Item2));
                        break;
                    default:
                        dataValueFormatted = GetValueFromObject(iDataKVP.Value.Item2);
                        break;
                }

                dataPrepared.Add(iDataKVP.Key, dataValueFormatted);
            }
            return dataPrepared;
        }

        private string GetValueFromObject(object valueToAnalyze)
        {
            string result = String.Empty;
            var rawData = valueToAnalyze as string[];
            if (rawData.Length > 0)
                result = rawData[0];
            return result;
        }

        private DriverAlert GetAlertModelFromDataDictionary(Dictionary<string, string> prmDataToSearch)
        {
            DriverAlert modelToInsert = null;
            string dateName = String.Empty;
            DateTime dateAlert = DateTime.MinValue;

            int vehicleId;
            int daysToAlert;
            Int32.TryParse(prmDataToSearch.Where(kvp => kvp.Key == ServosaDriverSingleton.Instance.ConstantVehicleId).Select(kvp => kvp.Value).FirstOrDefault(), out vehicleId);
            Int32.TryParse(prmDataToSearch.Where(kvp => kvp.Key == ServosaDriverSingleton.Instance.ConstantDayToAlert).Select(kvp => kvp.Value).FirstOrDefault(), out daysToAlert);

            var dataFilterred = prmDataToSearch.Where(kvp => ServosaDriverSingleton.Instance.ConstantExpirationDate.Contains(kvp.Key));
            foreach (var iKVP in dataFilterred)
            {
                if (DateTime.TryParse(iKVP.Value.Replace("'", ""), out dateAlert))
                    dateName = iKVP.Key;
            }

            if (!String.IsNullOrWhiteSpace(dateName))
                modelToInsert = new DriverAlert()
                {
                    AlertName = dateName,
                    DateToAlert = dateAlert,
                    DaysToAlert = daysToAlert,
                    DriverId = vehicleId
                };
            return modelToInsert;
        }
    }
}
