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

        public int Create(ColumnModel entity)
        {
            object[] parameters = new object[] { entity.TableName, entity.ColumnName, entity.DataType };
            using (var createCommand = _servosaDB.GetStoredProcCommand("SAIR_ADDCOLUMNTABLE", parameters))
            {
                var resultExecution = _servosaDB.ExecuteNonQuery(createCommand);
                return resultExecution;
            }
        }

        public int Delete(TableModel entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(ColumnModel entity)
        {
            object[] parameters = new object[] { entity.TableName, entity.ColumnName };
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
            throw new NotImplementedException();
        }

        TableModel IRepository<TableModel>.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
