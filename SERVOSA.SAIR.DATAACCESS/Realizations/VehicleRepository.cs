using SERVOSA.SAIR.DATAACCESS.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SERVOSA.SAIR.DATAACCESS.Models.Vehicle;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace SERVOSA.SAIR.DATAACCESS.Realizations
{
    public class VehicleRepository : IVehicleRepository
    {
        private Database _servosaDB;

        public VehicleRepository()
        {
            DatabaseProviderFactory _databaseFactory = new DatabaseProviderFactory();
            _servosaDB = _databaseFactory.CreateDefault();
        }

        public int Create(VehicleModel entity)
        {
            object[] parameters = new object[] { entity.PlacaTracto, entity.PlacaTolva, entity.TYPE_cTABBRND, entity.TYPE_cCODBRND, entity.TYPE_cTABVSTA, entity.TYPE_cCODVSTA, null };
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
            IRowMapper<VehicleModel> vehicleRowMapper = MapBuilder<VehicleModel>.MapAllProperties().DoNotMap(prop => prop.Marca)
                .DoNotMap(prop => prop.Estado).Build();
            var vehicleCollection = _servosaDB.ExecuteSprocAccessor("SAIR_VEHIS_Filtrado", vehicleRowMapper, parameters);
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
            object[] parameters = new object[] { entity.Codigo, entity.PlacaTracto, entity.PlacaTolva, entity.TYPE_cTABBRND, entity.TYPE_cCODBRND, entity.TYPE_cTABVSTA, entity.TYPE_cCODVSTA };
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
                            headModel.DataForRow.Add(new VehicleDetailRowDataModel()
                            {
                                Value = readerProcedure.IsDBNull(i)? String.Empty : readerProcedure.GetValue(i).ToString()
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

        public IList<RelatedTableToVehicleModel> GetRelatedTablesToVehicle()
        {
            object[] parameters = new object[] { };
            IRowMapper<RelatedTableToVehicleModel> relatedTablesMapper = MapBuilder<RelatedTableToVehicleModel>.MapAllProperties().Build();
            var relatedTableCollection = _servosaDB.ExecuteSprocAccessor("SAIR_ALLTABLESREFERENCINGVEHICLES", relatedTablesMapper, parameters);
            return relatedTableCollection.ToList();
        }

        private IRowMapper<VehicleModel> GetMapperSimple()
        {
            return MapBuilder<VehicleModel>.MapAllProperties().DoNotMap(prop => prop.RowNumber)
                .DoNotMap(prop => prop.TotalRows).DoNotMap(prop => prop.RowNumber).Build();
        }

        private IRowMapper<VehicleModel> GetMapperForOldSP()
        {
            return MapBuilder<VehicleModel>.MapAllProperties().DoNotMap(prop => prop.RowNumber)
                .DoNotMap(prop => prop.TotalRows).DoNotMap(prop => prop.Marca).DoNotMap(prop => prop.Estado).DoNotMap(prop => prop.RowNumber).Build();
        }
    }
}
