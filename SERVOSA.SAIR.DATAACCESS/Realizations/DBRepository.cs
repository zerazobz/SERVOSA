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
            _servosaDB = DatabaseFactory.CreateDatabase();
        }

        public int Create(TableModel entity)
        {
            object[] parameters = new object[] { entity.TableName };

            using (var dbCommand = _servosaDB.GetStoredProcCommand("SAIR_CREATETABLE", parameters))
            {
                var resultExecution = _servosaDB.ExecuteNonQuery(dbCommand);
                return resultExecution;
            }
        }

        public int Create(ColumnModel entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(TableModel entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(ColumnModel entity)
        {
            throw new NotImplementedException();
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
