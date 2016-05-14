﻿using SERVOSA.SAIR.SERVICE.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SERVOSA.SAIR.SERVICE.Core;
using SERVOSA.SAIR.DATAACCESS.Contracts;

namespace SERVOSA.SAIR.SERVICE.Realizations
{
    public class TableDataService : ITableDataService
    {
        private readonly ITableDataRepository _tableDataRepository;

        public TableDataService(ITableDataRepository injectedTableDataRepo)
        {
            _tableDataRepository = injectedTableDataRepo;
        }

        public int InsertTableData(string tableName, Dictionary<string, Tuple<SERVOSASqlTypes, object>> tableData)
        {
            Dictionary<string, string> dataPrepared = PrepareData(tableData, false);

            return _tableDataRepository.InsertDataToTable(tableName, dataPrepared);
        }

        public Tuple<bool, int, string> UpdateTableData(string tableName, int vehicleId, Dictionary<string, Tuple<SERVOSASqlTypes, object>> tableData)
        {
            string messageResult = String.Empty;
            bool updateResult = false;

            Dictionary<string, string> dataPrepared = PrepareData(tableData, true);
            int rowsAffected = _tableDataRepository.UpdateDataToTable(tableName, vehicleId, dataPrepared);
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

        private Dictionary<string, string> PrepareData(Dictionary<string, Tuple<SERVOSASqlTypes, object>> tableData, bool isUpdate)
        {
            string[] dataToFilter = isUpdate? new string[] { "id", "SAIR_VEHIID", "RutaDocumento" } : new string[] { "id", "RutaDocumento" };

            var preCollectionData = tableData.Where(kvp => !dataToFilter.Contains(kvp.Key)).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            Dictionary<string, string> dataPrepared = new Dictionary<string, string>();
            foreach (var iDataKVP in preCollectionData)
            {
                string dataValueFormatted;
                switch (iDataKVP.Value.Item1)
                {
                    case SERVOSASqlTypes.Int:
                        dataValueFormatted = GetValueFromObject(iDataKVP.Value.Item2);
                        break;
                    case SERVOSASqlTypes.Decimal:
                        dataValueFormatted = GetValueFromObject(iDataKVP.Value.Item2);
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
    }
}
