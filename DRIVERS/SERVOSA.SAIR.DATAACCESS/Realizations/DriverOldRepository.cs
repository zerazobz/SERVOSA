﻿using System.Linq;
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
    public class DriverOldRepository : IVehicleRepository
    {
        private Database _servosaDB;

        public DriverOldRepository()
        {
            DatabaseProviderFactory _databaseFactory = new DatabaseProviderFactory();
            _servosaDB = _databaseFactory.CreateDefault();
        }

        public int Create(Models.Driver.DriverModel entity)
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

        public int Delete(Models.Driver.DriverModel entity)
        {
            object[] parameters = new object[] { entity.OPER_Id };
            var resultExecution = _servosaDB.ExecuteNonQuery("SAIR_OPERD", parameters);
            return resultExecution;
        }

        public IList<Models.Driver.DriverModel> GetAll()
        {
            object[] parameters = new object[] { };
            IRowMapper<Models.Driver.DriverModel> driverRowMapper = CreateRowMapperForSAIR_OPERS();
            var driverCollection = _servosaDB.ExecuteSprocAccessor("SAIR_OPERS", driverRowMapper, parameters);
            return driverCollection.ToList();
        }

        public IList<Models.Driver.DriverModel> GetAllFiltered(int minRow, int maxRow)
        {
            object[] parameters = new object[] { minRow, maxRow };
            IRowMapper<Models.Driver.DriverModel> driverRowMapper = MapBuilder<Models.Driver.DriverModel>.MapAllProperties().Build();
            var driverCollection = _servosaDB.ExecuteSprocAccessor("SAIR_OPERS_Filtrado", driverRowMapper, parameters);
            return driverCollection.ToList();
        }

        public DriverModel GetById(int id)
        {
            object[] parameteres = new object[] { id };
            IRowMapper<Models.Driver.DriverModel> driverRowMapper = GetMapperSimple();
            var driverCollection = _servosaDB.ExecuteSprocAccessor("SAIR_OPERS_UnReg", driverRowMapper, parameteres);
            return driverCollection.FirstOrDefault();
        }

        public int Update(Models.Driver.DriverModel entity)
        {
            object[] parameters = new object[] { entity.OPER_Id, entity.OPER_cApellidoPaterno, entity.OPER_cApellidoMaterno, entity.OPER_cNombre, entity.OPER_cCorreo,entity.VEHI_Id,entity.PUES_Id};
            using (var updateCommand = _servosaDB.GetStoredProcCommand("SAIR_OPERU", parameters))
            {
                var executionResult = _servosaDB.ExecuteNonQuery(updateCommand);
                return executionResult;
            }
        }
        private IRowMapper<Models.Driver.DriverModel> GetMapperSimple()
        {
            return MapBuilder<Models.Driver.DriverModel>.MapAllProperties().DoNotMap(prop => prop.RowNumber)
                .DoNotMap(prop => prop.TotalRows).Build();
        }
        public IList<Models.Driver.DriverModel> GetRowDataForTable(string tableName)
        {
            object[] parameters = new object[] { GetMapperSimple() };
            IRowMapper<Models.Driver.DriverModel> driverRowMapper = MapBuilder<Models.Driver.DriverModel>.MapAllProperties().Build();
            var driverCollection = _servosaDB.ExecuteSprocAccessor("SAIR_OPERS", driverRowMapper, parameters);
            return driverCollection.ToList();
        }

        public IList<RelatedTableToEntityModel> GetRelatedTablesToVehicle()
        {
            object[] parameters = new object[] { };
            IRowMapper<RelatedTableToEntityModel> relatedTablesMapper = MapBuilder<RelatedTableToEntityModel>.MapAllProperties().Build();
            var relatedTableCollection = _servosaDB.ExecuteSprocAccessor("SAIR_ALLTABLESREFERENCINGDRIVERS", relatedTablesMapper, parameters);
            return relatedTableCollection.ToList();
        }

        private IRowMapper<Models.Driver.DriverModel> CreateRowMapperForSAIR_OPERS()
        {
            return MapBuilder<Models.Driver.DriverModel>.MapNoProperties().MapByName(prop => prop.OPER_Id).MapByName(prop => prop.OPER_cApellidoPaterno)
                .MapByName(prop => prop.OPER_cApellidoMaterno).MapByName(prop => prop.OPER_cNombre).MapByName(prop => prop.OPER_cCorreo)
                .MapByName(prop => prop.VEHI_Id).MapByName(prop => prop.VEHI_cDescripcion).MapByName(prop => prop.PUES_Id).Build();
        }
    }
}
