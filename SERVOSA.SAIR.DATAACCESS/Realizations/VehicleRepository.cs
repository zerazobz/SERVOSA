using SERVOSA.SAIR.DATAACCESS.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SERVOSA.SAIR.DATAACCESS.Models.Vehicle;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using SERVOSA.SAIR.DATAACCESS.Core;

namespace SERVOSA.SAIR.DATAACCESS.Realizations
{
    public class VehicleRepository : IVehicleRepository
    {
        private Database _servosaDB;

        public VehicleRepository()
        {
            DatabaseProviderFactory _databaseFactory = new DatabaseProviderFactory();
            _servosaDB = DataAccessDatabaseConfiguration.GetDataBase();
        }

        public int Create(VehicleModel entity)
        {
            object[] parameters = new object[] { entity.TYPE_cTABBRND, entity.TYPE_cCODBRND, entity.TYPE_cTABVSTA, entity.TYPE_cCODVSTA, entity.VEHI_UnitType, entity.VEHI_VehiclePlate, entity.VEHI_Company, null };
            using (var insertCommand = _servosaDB.GetStoredProcCommand("SAIR_VEHII", parameters))
            {
                var resultExecution = _servosaDB.ExecuteNonQuery(insertCommand);
                var vehicleCode = Convert.ToInt32(_servosaDB.GetParameterValue(insertCommand, "Codigo"));
                entity.Codigo = vehicleCode;
                return resultExecution;
            }
        }

        public int Delete(VehicleModel entity)
        {
            object[] parameters = new object[] { entity.Codigo };
            var resultExecution = _servosaDB.ExecuteNonQuery("SAIR_VEHID", parameters);
            return resultExecution;
        }

        public IList<VehicleModel> GetAll()
        {
            object[] parameters = new object[] { };
            IRowMapper<VehicleModel> vehicleRowMapper = GetMapperSimple();
            var vehicleCollection = _servosaDB.ExecuteSprocAccessor("SAIR_VEHIS", vehicleRowMapper, parameters);
            return vehicleCollection.ToList();
        }

        public IList<VehicleModel> GetAllFiltered(int minRow, int maxRow)
        {
            object[] parameters = new object[] { minRow, maxRow };
            IRowMapper<VehicleModel> vehicleRowMapper = GetMapperForFilteredSP();
            var vehicleCollection = _servosaDB.ExecuteSprocAccessor("SAIR_VEHIS_Filtrado", vehicleRowMapper, parameters);
            return vehicleCollection.ToList();
        }

        public IList<VehicleModel> GetAllFilteredBySearchTerm(string searchTerm)
        {
            object[] parameters = new object[] { searchTerm };
            IRowMapper<VehicleModel> vehicleRowMapper = GetMapperForSearchFilteredByTerm();
            var vehicleCollection = _servosaDB.ExecuteSprocAccessor("SAIR_VEHIS_FilterByText", vehicleRowMapper, parameters);
            return vehicleCollection.ToList();
        }

        public VehicleModel GetById(int id)
        {
            object[] parameteres = new object[] { id };
            IRowMapper<VehicleModel> vehicleRowMapper = GetMapperForOldSP();
            var vehicleCollection = _servosaDB.ExecuteSprocAccessor("SAIR_VEHIS_UnReg", vehicleRowMapper, parameteres);
            return vehicleCollection.FirstOrDefault();
        }

        public int Update(VehicleModel entity)
        {
            object[] parameters = new object[] { entity.Codigo, entity.TYPE_cTABBRND, entity.TYPE_cCODBRND, entity.TYPE_cTABVSTA, entity.TYPE_cCODVSTA, entity.VEHI_UnitType, entity.VEHI_VehiclePlate, entity.VEHI_Company };
            using (var updateCommand = _servosaDB.GetStoredProcCommand("SAIR_VEHIU", parameters))
            {
                var executionResult = _servosaDB.ExecuteNonQuery(updateCommand);
                return executionResult;
            }
        }

        public IList<VehicleHeadRowDataModel> GetRowDataForTable(string tableName)
        {
            List<VehicleHeadRowDataModel> headDataCollection = new List<VehicleHeadRowDataModel>();

            object[] parameters = new object[] { tableName };
            using (var readCommand = _servosaDB.GetStoredProcCommand("SAIR_VEHIS_Datos", parameters))
            {
                VehicleHeadRowDataModel headModel = null;
                using (var readerProcedure = _servosaDB.ExecuteReader(readCommand))
                {
                    while (readerProcedure.Read())
                    {
                        var sizeColumnData = readerProcedure.FieldCount;
                        headModel = new VehicleHeadRowDataModel();
                        headModel.DataForRow = new List<VehicleDetailRowDataModel>(sizeColumnData);

                        headModel.TableName = readerProcedure.GetString(0);
                        headModel.VehicleId = readerProcedure.GetInt32(1);

                        for (int i = 2; i < sizeColumnData; i++)
                        {
                            var rawValueAsString = readerProcedure.IsDBNull(i) ? String.Empty : readerProcedure.GetValue(i).ToString();
                            var valuesSplited = rawValueAsString.Split(new string[] { "|@|" }, StringSplitOptions.None);
                            string valueOfColumn = valuesSplited.Length > 1 ? valuesSplited[1] : valuesSplited.Length > 0 ? valuesSplited.FirstOrDefault() : String.Empty;
                            string nameOfColumn = valuesSplited.Length > 1 ? valuesSplited[0] : String.Empty;

                            DateTime resultParse;
                            if (DateTime.TryParse(valueOfColumn, out resultParse))
                                valueOfColumn = resultParse.ToString("dd/MM/yyyy");

                            headModel.DataForRow.Add(new VehicleDetailRowDataModel()
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

        public IList<VehicleVariableTableDataModel> GetVehicleVariableTableData(string tableName, int vehicleId)
        {
            object[] parameters = new object[] { tableName, vehicleId };
            IRowMapper<VehicleVariableTableDataModel> rowMapper = MapBuilder<VehicleVariableTableDataModel>.MapAllProperties().Build();

            var dataResult = _servosaDB.ExecuteSprocAccessor("SAIR_VEHIS_TableData", rowMapper, parameters);
            return dataResult.ToList();
        }

        public IList<RelatedTableToEntityModel> GetRelatedTablesToVehicle()
        {
            object[] parameters = new object[] { };
            IRowMapper<RelatedTableToEntityModel> relatedTablesMapper = MapBuilder<RelatedTableToEntityModel>.MapAllProperties().Build();
            var relatedTableCollection = _servosaDB.ExecuteSprocAccessor("SAIR_ALLTABLESREFERENCINGVEHICLES", relatedTablesMapper, parameters);
            return relatedTableCollection.ToList();
        }

        public DataSet GetVariableDataToExport(string tableName)
        {
            object[] parameters = new object[] { tableName };
            var resultDataSet = _servosaDB.ExecuteDataSet("SAIR_DatosVariable", parameters);
            return resultDataSet;
        }

        public DataSet GetVehicleDataToExport(int vehicleCode)
        {
            object[] parameters = new object[] { vehicleCode };
            var resultDataSet = _servosaDB.ExecuteDataSet("SAIR_DatosVehiculo", parameters);
            return resultDataSet;
        }

        private IRowMapper<VehicleModel> GetMapperSimple()
        {
            return MapBuilder<VehicleModel>.MapNoProperties().MapByName(prop => prop.Item).MapByName(prop => prop.Codigo)
                .MapByName(prop => prop.TYPE_cTABBRND).MapByName(prop => prop.TYPE_cCODBRND).MapByName(prop => prop.TYPE_cTABVSTA)
                .MapByName(prop => prop.TYPE_cCODVSTA).MapByName(prop => prop.Marca).MapByName(prop => prop.Estado)
                .MapByName(prop => prop.VEHI_UnitType).MapByName(prop => prop.VEHI_VehiclePlate).MapByName(prop => prop.VEHI_DescriptionUnitType)
                .MapByName(prop => prop.VEHI_Company).Build();
        }

        private IRowMapper<VehicleModel> GetMapperForOldSP()
        {
            return MapBuilder<VehicleModel>.MapNoProperties().MapByName(prop => prop.Item).MapByName(prop => prop.Codigo).MapByName(prop => prop.TYPE_cTABBRND)
                .MapByName(prop => prop.TYPE_cCODBRND).MapByName(prop => prop.TYPE_cTABVSTA).MapByName(prop => prop.TYPE_cCODVSTA).MapByName(prop => prop.VEHI_UnitType)
                .MapByName(prop => prop.VEHI_VehiclePlate).MapByName(prop => prop.VEHI_DescriptionUnitType).Build();
        }

        private IRowMapper<VehicleModel> GetMapperForFilteredSP()
        {
            return MapBuilder<VehicleModel>.MapNoProperties().MapByName(prop => prop.RowNumber).MapByName(prop => prop.TotalRows)
                .MapByName(prop => prop.Item).MapByName(prop => prop.Codigo).MapByName(prop => prop.TYPE_cTABBRND).MapByName(prop => prop.TYPE_cCODBRND)
                .MapByName(prop => prop.TYPE_cTABVSTA).MapByName(prop => prop.TYPE_cCODVSTA).MapByName(prop => prop.VEHI_UnitType)
                .MapByName(prop => prop.VEHI_VehiclePlate).Build();
        }

        private IRowMapper<VehicleModel> GetMapperForSearchFilteredByTerm()
        {
            return MapBuilder<VehicleModel>.MapNoProperties().MapByName(prop => prop.Item).MapByName(prop => prop.Codigo)
                .MapByName(prop => prop.TYPE_cTABBRND).MapByName(prop => prop.TYPE_cCODBRND).MapByName(prop => prop.TYPE_cTABVSTA)
                .MapByName(prop => prop.TYPE_cCODVSTA).MapByName(prop => prop.VEHI_UnitType).MapByName(prop => prop.VEHI_VehiclePlate)
                .MapByName(prop => prop.VEHI_DescriptionUnitType).Build();
        }
    }
}
