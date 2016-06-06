using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SERVOSA.SAIR.DATAACCESS.Models.Driver;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SERVOSA.SAIR.DATAACCESS.Contracts;
using System;
using System.Collections.Generic;
using SERVOSA.SAIR.DATAACCESS.Models.Vehicle;

namespace SERVOSA.SAIR.DATAACCESS.Realizations
{
    public class OldDriverRepository : IDriverOldRepository
    {
        private Database _servosaDB;

        public OldDriverRepository()
        {
            DatabaseProviderFactory _databaseFactory = new DatabaseProviderFactory();
            _servosaDB = _databaseFactory.CreateDefault();
        }

        public int Create(DriverOldModel entity)
        {
            object[] parameters = new object[] { entity.OPER_cApellidoPaterno, entity.OPER_cApellidoMaterno, entity.OPER_cNombre, entity.OPER_cCorreo, entity.VEHI_Id,entity.PUES_Id,null};
            using (var insertCommand = _servosaDB.GetStoredProcCommand("SAIR_OPERI", parameters))
            {
                var resultExecution = _servosaDB.ExecuteNonQuery(insertCommand);
                var driverCode = Convert.ToInt32(_servosaDB.GetParameterValue(insertCommand, "OPER_Id"));
                entity.OPER_Id = driverCode;
                return resultExecution;
            }
        }

        public int Delete(DriverOldModel entity)
        {
            object[] parameters = new object[] { entity.OPER_Id };
            var resultExecution = _servosaDB.ExecuteNonQuery("SAIR_OPERD", parameters);
            return resultExecution;
        }

        public IList<DriverOldModel> GetAll()
        {
            object[] parameters = new object[] { };
            IRowMapper<DriverOldModel> driverRowMapper = CreateRowMapperForSAIR_OPERS();
            var driverCollection = _servosaDB.ExecuteSprocAccessor("SAIR_OPERS", driverRowMapper, parameters);
            return driverCollection.ToList();
        }

        public IList<DriverOldModel> GetAllFiltered(int minRow, int maxRow)
        {
            object[] parameters = new object[] { minRow, maxRow };
            IRowMapper<DriverOldModel> driverRowMapper = MapBuilder<DriverOldModel>.MapAllProperties().Build();
            var driverCollection = _servosaDB.ExecuteSprocAccessor("SAIR_OPERS_Filtrado", driverRowMapper, parameters);
            return driverCollection.ToList();
        }

        public DriverOldModel GetById(int id)
        {
            object[] parameteres = new object[] { id };
            IRowMapper<DriverOldModel> driverRowMapper = GetMapperSimple();
            var driverCollection = _servosaDB.ExecuteSprocAccessor("SAIR_OPERS_UnReg", driverRowMapper, parameteres);
            return driverCollection.FirstOrDefault();
        }

        public int Update(DriverOldModel entity)
        {
            object[] parameters = new object[] { entity.OPER_Id, entity.OPER_cApellidoPaterno, entity.OPER_cApellidoMaterno, entity.OPER_cNombre, entity.OPER_cCorreo,entity.VEHI_Id,entity.PUES_Id};
            using (var updateCommand = _servosaDB.GetStoredProcCommand("SAIR_OPERU", parameters))
            {
                var executionResult = _servosaDB.ExecuteNonQuery(updateCommand);
                return executionResult;
            }
        }
        private IRowMapper<DriverOldModel> GetMapperSimple()
        {
            return MapBuilder<DriverOldModel>.MapAllProperties().DoNotMap(prop => prop.RowNumber)
                .DoNotMap(prop => prop.TotalRows).Build();
        }
        public IList<DriverOldModel> GetRowDataForTable(string tableName)
        {
            object[] parameters = new object[] { GetMapperSimple() };
            IRowMapper<DriverOldModel> driverRowMapper = MapBuilder<DriverOldModel>.MapAllProperties().Build();
            var driverCollection = _servosaDB.ExecuteSprocAccessor("SAIR_OPERS", driverRowMapper, parameters);
            return driverCollection.ToList();
        }

        public IList<DriverRelatedTableToEntityModel> GetRelatedTablesToDriver()
        {
            object[] parameters = new object[] { };
            IRowMapper<DriverRelatedTableToEntityModel> relatedTablesMapper = MapBuilder<DriverRelatedTableToEntityModel>.MapAllProperties().Build();
            var relatedTableCollection = _servosaDB.ExecuteSprocAccessor("SAIR_ALLTABLESREFERENCINGDRIVERS", relatedTablesMapper, parameters);
            return relatedTableCollection.ToList();
        }

        private IRowMapper<DriverOldModel> CreateRowMapperForSAIR_OPERS()
        {
            return MapBuilder<DriverOldModel>.MapNoProperties().MapByName(prop => prop.OPER_Id).MapByName(prop => prop.OPER_cApellidoPaterno)
                .MapByName(prop => prop.OPER_cApellidoMaterno).MapByName(prop => prop.OPER_cNombre).MapByName(prop => prop.OPER_cCorreo)
                .MapByName(prop => prop.VEHI_Id).MapByName(prop => prop.VEHI_cDescripcion).MapByName(prop => prop.PUES_Id).Build();
        }
    }
}
