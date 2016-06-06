using SERVOSA.SAIR.DATAACCESS.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SERVOSA.SAIR.DATAACCESS.Models.DB;
using SERVOSA.SAIR.DATAACCESS.Core;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace SERVOSA.SAIR.DATAACCESS.Realizations
{
    public class DBRepository : IDriverDBColumnsRepository, IDBTablesRepository
    {
        private Database _servosaDB;

        public DBRepository()
        {
            DatabaseProviderFactory _databaseFactory = new DatabaseProviderFactory();
            _servosaDB = _databaseFactory.CreateDefault();
        }

        public int Create(DriverTableModel entity)
        {
            object[] parameters = new object[] { entity.TableName, null, null };

            using (var dbCommand = _servosaDB.GetStoredProcCommand("SAIR_CREATETABLE", parameters))
            {
                var resultExecution = _servosaDB.ExecuteNonQuery(dbCommand);
                var normalizedNameOutput = _servosaDB.GetParameterValue(dbCommand, "@tableNormalizedName");
                var objectIdOutput = _servosaDB.GetParameterValue(dbCommand, "@objectId");
                int tmpValue;
                if (Int32.TryParse(objectIdOutput.ToString(), out tmpValue))
                    entity.ObjectId = tmpValue;
                entity.TableNormalizedName = normalizedNameOutput.ToString();
                return resultExecution;
            }
        }

        public Tuple<int, DriverTableModel> CreateTableAndReturnsNormalizedName(DriverTableModel entity)
        {
            try
            {
                object[] parameters = new object[] { entity.TableName, null, null };

                using (var dbCommand = _servosaDB.GetStoredProcCommand("SAIR_CREATETABLE", parameters))
                {
                    var resultExecution = _servosaDB.ExecuteNonQuery(dbCommand);
                    var normalizedNameOutput = Convert.ToString(_servosaDB.GetParameterValue(dbCommand, "@tableNormalizedName"));
                    var objectIdOutput = _servosaDB.GetParameterValue(dbCommand, "@objectId");
                    int tmpValue;
                    Int32.TryParse(objectIdOutput.ToString(), out tmpValue);

                    return new Tuple<int, DriverTableModel>(resultExecution, new DriverTableModel()
                    {
                        TableName = entity.TableName,
                        TableNormalizedName = normalizedNameOutput,
                        ObjectId = tmpValue
                    });
                }
            }
            catch (Exception ex)
            {
                return new Tuple<int, DriverTableModel>(-1, entity);
            }
        }

        public Tuple<int, DriverColumnModel> CreateColumnAndReturnNormalizedName(DriverColumnModel model)
        {
            try
            {
                object[] parameters = new object[] { model.NormalizedTableName, model.ColumnName, model.DataType, null };
                using (var createCommand = _servosaDB.GetStoredProcCommand("SAIR_ADDCOLUMNTABLE", parameters))
                {
                    var resultExecutionj = _servosaDB.ExecuteNonQuery(createCommand);
                    var outputValue = _servosaDB.GetParameterValue(createCommand, "@normalizedColumnName").ToString();
                    return new Tuple<int, DriverColumnModel>(resultExecutionj, new DriverColumnModel()
                    {
                        NormalizedTableName = model.NormalizedTableName,
                        ColumnName = model.ColumnName,
                        NormalizedColumnaName = outputValue,
                        DataType = model.DataType
                    });
                }
            }
            catch (Exception ex)
            {
                return new Tuple<int, DriverColumnModel>(-1, model);
            }
        }

        public int Create(DriverColumnModel entity)
        {
            throw new NotImplementedException();
            //object[] parameters = new object[] { entity.TableName, entity.ColumnName, entity.DataType };
            //using (var createCommand = _servosaDB.GetStoredProcCommand("SAIR_ADDCOLUMNTABLE", parameters))
            //{
            //    var resultExecution = _servosaDB.ExecuteNonQuery(createCommand);
            //    return resultExecution;
            //}
        }

        public int Delete(DriverTableModel entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(DriverColumnModel entity)
        {
            object[] parameters = new object[] { entity.NormalizedTableName, entity.ColumnName };
            using (var deleteColumnCommand = _servosaDB.GetStoredProcCommand("SAIR_DROPCOLUMNTABLE", parameters))
            {
                var resultExecution = _servosaDB.ExecuteNonQuery(deleteColumnCommand);
                return resultExecution;
            }
        }

        public IList<DriverColumnModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public DriverColumnModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(DriverTableModel entity)
        {
            throw new NotImplementedException();
        }

        public int Update(DriverColumnModel entity)
        {
            throw new NotImplementedException();
        }

        IList<DriverTableModel> IRepository<DriverTableModel>.GetAll()
        {
            object[] parameters = new object[] { };
            IRowMapper<DriverTableModel> tableRowMapper = MapBuilder<DriverTableModel>.MapAllProperties().Build();
            var allTables = _servosaDB.ExecuteSprocAccessor("SAIR_SELECTTABLES", tableRowMapper, parameters);
            return allTables.ToList();
        }

        public IList<DriverTableColumnModel> ListAllVehicleVarsTablesWithDefinition()
        {
            object[] parameters = new object[] { "vehiclevars" };
            IRowMapper<DriverTableColumnModel> tableRowMapper = MapBuilder<DriverTableColumnModel>.MapAllProperties().Build();
            var allTables = _servosaDB.ExecuteSprocAccessor("SAIR_LISTTABLESANDCOLUMNS", tableRowMapper, parameters);
            return allTables.ToList();
        }

        public IList<DriverTableColumnModel> ListAllDriverVarsTablesWithDefinition()
        {
            object[] parameters = new object[] { "drivervars" };
            IRowMapper<DriverTableColumnModel> tableRowMapper = MapBuilder<DriverTableColumnModel>.MapAllProperties().Build();
            var allTables = _servosaDB.ExecuteSprocAccessor("SAIR_LISTTABLESANDCOLUMNS", tableRowMapper, parameters);
            return allTables.ToList();
        }

        DriverTableModel IRepository<DriverTableModel>.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
