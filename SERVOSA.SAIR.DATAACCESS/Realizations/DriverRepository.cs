using SERVOSA.SAIR.DATAACCESS.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SERVOSA.SAIR.DATAACCESS.Models.Driver;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using SERVOSA.SAIR.DATAACCESS.Core;

namespace SERVOSA.SAIR.DATAACCESS.Realizations
{
    public class DriverRepository : IDriverRepository
    {
        private Database _servosaDB;

        public DriverRepository()
        {
            DatabaseProviderFactory _databaseFactory = new DatabaseProviderFactory();
            _servosaDB = DataAccessDatabaseConfiguration.GetDataBase();
        }

        public int Create(DriverModel entity)
        {
            object[] parameters = new object[] { entity.TYPE_cTABBRND, entity.TYPE_cCODBRND, entity.TYPE_cTABVSTA, entity.TYPE_cCODVSTA, entity.VEHI_UnitType, entity.VEHI_VehiclePlate, entity.DRIV_dBirthDate, entity.DRIV_cAddress, null };
            using (var insertCommand = _servosaDB.GetStoredProcCommand("SAIR_DRIVI", parameters))
            {
                var resultExecution = _servosaDB.ExecuteNonQuery(insertCommand);
                var driverCode = Convert.ToInt32(_servosaDB.GetParameterValue(insertCommand, "Codigo"));
                entity.Codigo = driverCode;
                return resultExecution;
            }
        }

        public int Delete(DriverModel entity)
        {
            object[] parameters = new object[] { entity.Codigo };
            var resultExecution = _servosaDB.ExecuteNonQuery("SAIR_DRIVD", parameters);
            return resultExecution;
        }

        public IList<DriverModel> GetAll()
        {
            object[] parameters = new object[] { };
            IRowMapper<DriverModel> driverRowMapper = GetMapperSimple();
            var vehicleCollection = _servosaDB.ExecuteSprocAccessor("SAIR_DRIVS", driverRowMapper, parameters);
            return vehicleCollection.ToList();
        }

        public IList<DriverModel> GetAllFiltered(int minRow, int maxRow)
        {
            object[] parameters = new object[] { minRow, maxRow };
            IRowMapper<DriverModel> vehicleRowMapper = GetMapperForFilteredSP();
            var vehicleCollection = _servosaDB.ExecuteSprocAccessor("SAIR_DRIVS_Filtrado", vehicleRowMapper, parameters);
            return vehicleCollection.ToList();
        }

        public IList<DriverModel> GetAllFilteredBySearchTerm(string searchTerm)
        {
            object[] parameters = new object[] { searchTerm };
            IRowMapper<DriverModel> vehicleRowMapper = GetMapperForSearchFilteredByTerm();
            var vehicleCollection = _servosaDB.ExecuteSprocAccessor("SAIR_DRIVS_FilterByText", vehicleRowMapper, parameters);
            return vehicleCollection.ToList();
        }

        public DriverModel GetById(int id)
        {
            object[] parameteres = new object[] { id };
            IRowMapper<DriverModel> vehicleRowMapper = GetMapperForOldSP();
            var vehicleCollection = _servosaDB.ExecuteSprocAccessor("SAIR_DRIVS_UnReg", vehicleRowMapper, parameteres);
            return vehicleCollection.FirstOrDefault();
        }

        public int Update(DriverModel entity)
        {
            object[] parameters = new object[] { entity.Codigo, entity.TYPE_cTABBRND, entity.TYPE_cCODBRND, entity.TYPE_cTABVSTA, entity.TYPE_cCODVSTA, entity.VEHI_UnitType, entity.VEHI_VehiclePlate, entity.DRIV_dBirthDate, entity.DRIV_cAddress };
            using (var updateCommand = _servosaDB.GetStoredProcCommand("SAIR_DRIVIU", parameters))
            {
                var executionResult = _servosaDB.ExecuteNonQuery(updateCommand);
                return executionResult;
            }
        }

        public IList<DriverHeadRowDataModel> GetRowDataForTable(string tableName)
        {
            List<DriverHeadRowDataModel> headDataCollection = new List<DriverHeadRowDataModel>();

            object[] parameters = new object[] { tableName };
            using (var readCommand = _servosaDB.GetStoredProcCommand("SAIR_DRIVS_Datos", parameters))
            {
                DriverHeadRowDataModel headModel = null;
                using (var readerProcedure = _servosaDB.ExecuteReader(readCommand))
                {
                    while (readerProcedure.Read())
                    {
                        var sizeColumnData = readerProcedure.FieldCount;
                        headModel = new DriverHeadRowDataModel();
                        headModel.DataForRow = new List<DriverDetailRowDataModel>(sizeColumnData);

                        headModel.TableName = readerProcedure.GetString(0);
                        headModel.VehicleId = readerProcedure.GetInt32(1);

                        for (int i = 2; i < sizeColumnData; i++)
                        {
                            var rawValueAsString = readerProcedure.IsDBNull(i) ? String.Empty : readerProcedure.GetValue(i).ToString();
                            var valuesSplited = rawValueAsString.Split(new string[] { "|@|" }, StringSplitOptions.RemoveEmptyEntries);
                            string valueOfColumn = valuesSplited.Length > 1 ? valuesSplited[1] : valuesSplited.Length > 0 ? valuesSplited.FirstOrDefault() : String.Empty;
                            string nameOfColumn = valuesSplited.Length > 1 ? valuesSplited[0] : String.Empty;

                            headModel.DataForRow.Add(new DriverDetailRowDataModel()
                            {
                                Value = valueOfColumn,
                                ColumnName = nameOfColumn
                            });
                        }
                        headDataCollection.Add(headModel);
                    }
                }
            }
            return headDataCollection;
        }

        public IList<DriverVariableTableDataModel> GetDriverVariableTableData(string tableName, int vehicleId)
        {
            object[] parameters = new object[] { tableName, vehicleId };
            IRowMapper<DriverVariableTableDataModel> rowMapper = MapBuilder<DriverVariableTableDataModel>.MapAllProperties().Build();

            var dataResult = _servosaDB.ExecuteSprocAccessor("SAIR_DRIVS_TableData", rowMapper, parameters);
            return dataResult.ToList();
        }

        public IList<DriverRelatedTableToEntityModel> GetRelatedTablesToDriver()
        {
            object[] parameters = new object[] { };
            IRowMapper<DriverRelatedTableToEntityModel> relatedTablesMapper = MapBuilder<DriverRelatedTableToEntityModel>.MapAllProperties().Build();
            var relatedTableCollection = _servosaDB.ExecuteSprocAccessor("SAIR_ALLTABLESREFERENCINGDRIVERS", relatedTablesMapper, parameters);
            return relatedTableCollection.ToList();
        }

        public DataSet GetVariableDataToExport(string tableName)
        {
            object[] parameters = new object[] { tableName };
            var resultDataSet = _servosaDB.ExecuteDataSet("SAIR_DatosVariableDriver", parameters);
            return resultDataSet;
        }

        public DataSet GetDriverDataToExport(int vehicleCode)
        {
            object[] parameters = new object[] { vehicleCode };
            var resultDataSet = _servosaDB.ExecuteDataSet("SAIR_DatosConductor", parameters);
            return resultDataSet;
        }

        private IRowMapper<DriverModel> GetMapperSimple()
        {
            return MapBuilder<DriverModel>.MapAllProperties().DoNotMap(prop => prop.RowNumber)
                .DoNotMap(prop => prop.TotalRows).DoNotMap(prop => prop.RowNumber)
                .Build();
        }

        private IRowMapper<DriverModel> GetMapperForOldSP()
        {
            return MapBuilder<DriverModel>.MapAllProperties().DoNotMap(prop => prop.RowNumber)
                .DoNotMap(prop => prop.TotalRows).DoNotMap(prop => prop.Marca).DoNotMap(prop => prop.Estado)
                .DoNotMap(prop => prop.RowNumber).DoNotMap(prop => prop.VEHI_DescriptionUnitType)
                //.DoNotMap(prop => prop.DRIV_dBirthDate).DoNotMap(prop => prop.DRIV_cAddress)
                .Build();
        }

        private IRowMapper<DriverModel> GetMapperForFilteredSP()
        {
            return MapBuilder<DriverModel>.MapAllProperties().DoNotMap(prop => prop.Marca)
                .DoNotMap(prop => prop.Estado).DoNotMap(prop => prop.VEHI_DescriptionUnitType)
                //.DoNotMap(prop => prop.DRIV_dBirthDate).DoNotMap(prop => prop.DRIV_cAddress)
                .Build();
        }

        private IRowMapper<DriverModel> GetMapperForSearchFilteredByTerm()
        {
            return MapBuilder<DriverModel>.MapAllProperties().DoNotMap(prop => prop.RowNumber).DoNotMap(prop => prop.TotalRows)
                .DoNotMap(prop => prop.Marca).DoNotMap(prop => prop.Estado).DoNotMap(prop => prop.VEHI_DescriptionUnitType)
                //.DoNotMap(prop => prop.DRIV_dBirthDate).DoNotMap(prop => prop.DRIV_cAddress)
                .Build();
        }
    }
}
