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
    public class DBRepository : IDBColumnsRepository, IDBTablesRepository
    {
        private Database _servosaDB;

        public DBRepository()
        {
            DatabaseProviderFactory _databaseFactory = new DatabaseProviderFactory();
            _servosaDB = _databaseFactory.CreateDefault();
        }

        public int Create(TableModel entity)
        {
            object[] parameters = new object[] { entity.TableName, null };

            using (var dbCommand = _servosaDB.GetStoredProcCommand("SAIR_CREATETABLE", parameters))
            {
                var resultExecution = _servosaDB.ExecuteNonQuery(dbCommand);
                var outputValue = _servosaDB.GetParameterValue(dbCommand, "@tableNormalizedName");
                return resultExecution;
            }
        }

        public Tuple<int, TableModel> CreateTableAndReturnsNormalizedName(TableModel entity)
        {
            try
            {
                object[] parameters = new object[] { entity.TableName, null };

                using (var dbCommand = _servosaDB.GetStoredProcCommand("SAIR_CREATETABLE", parameters))
                {
                    var resultExecution = _servosaDB.ExecuteNonQuery(dbCommand);
                    var outputValue = Convert.ToString(_servosaDB.GetParameterValue(dbCommand, "@tableNormalizedName"));
                    return new Tuple<int, TableModel>(resultExecution, new TableModel()
                    {
                        TableName = entity.TableName,
                        TableNormalizedName = outputValue
                    });
                }
            }
            catch (Exception ex)
            {
                return new Tuple<int, TableModel>(-1, entity);
            }
        }

        public Tuple<int, ColumnModel> CreateColumnAndReturnNormalizedName(ColumnModel model)
        {
            try
            {
                object[] parameters = new object[] { model.NormalizedTableName, model.ColumnName, model.DataType, null };
                using (var createCommand = _servosaDB.GetStoredProcCommand("SAIR_ADDCOLUMNTABLE", parameters))
                {
                    var resultExecutionj = _servosaDB.ExecuteNonQuery(createCommand);
                    var outputValue = _servosaDB.GetParameterValue(createCommand, "@normalizedColumnName").ToString();
                    return new Tuple<int, ColumnModel>(resultExecutionj, new ColumnModel()
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
                return new Tuple<int, ColumnModel>(-1, model);
            }
        }

        public int Create(ColumnModel entity)
        {
            throw new NotImplementedException();
            //object[] parameters = new object[] { entity.TableName, entity.ColumnName, entity.DataType };
            //using (var createCommand = _servosaDB.GetStoredProcCommand("SAIR_ADDCOLUMNTABLE", parameters))
            //{
            //    var resultExecution = _servosaDB.ExecuteNonQuery(createCommand);
            //    return resultExecution;
            //}
        }

        public int Delete(TableModel entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(ColumnModel entity)
        {
            object[] parameters = new object[] { entity.NormalizedTableName, entity.ColumnName };
            using (var deleteColumnCommand = _servosaDB.GetStoredProcCommand("SAIR_DROPCOLUMNTABLE", parameters))
            {
                var resultExecution = _servosaDB.ExecuteNonQuery(deleteColumnCommand);
                return resultExecution;
            }
        }

        public IList<ColumnModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public ColumnModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(TableModel entity)
        {
            throw new NotImplementedException();
        }

        public int Update(ColumnModel entity)
        {
            throw new NotImplementedException();
        }

        IList<TableModel> IRepository<TableModel>.GetAll()
        {
            object[] parameters = new object[] { };
            IRowMapper<TableModel> tableRowMapper = MapBuilder<TableModel>.MapAllProperties().Build();
            var allTables = _servosaDB.ExecuteSprocAccessor("SAIR_SELECTTABLES", tableRowMapper, parameters);
            return allTables.ToList();
        }

        public IList<TableColumnModel> ListAllDataTables()
        {
            object[] parameters = new object[] { "vehiclevars" };
            IRowMapper<TableColumnModel> tableRowMapper = MapBuilder<TableColumnModel>.MapAllProperties().Build();
            var allTables = _servosaDB.ExecuteSprocAccessor("SAIR_LISTTABLESANDCOLUMNS", tableRowMapper, parameters);
            return allTables.ToList();
        }

        TableModel IRepository<TableModel>.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
