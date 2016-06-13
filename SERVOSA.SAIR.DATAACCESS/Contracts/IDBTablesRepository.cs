using SERVOSA.SAIR.DATAACCESS.Core;
using SERVOSA.SAIR.DATAACCESS.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.DATAACCESS.Contracts
{
    public interface IDBTablesRepository : IRepository<TableModel>
    {
        Tuple<int, TableModel> CreateTableAndReturnsNormalizedName(TableModel entity);
        IList<TableColumnModel> ListAllVehicleVarsTablesWithDefinition();
        IList<TableColumnModel> ListAllDriverVarsTablesWithDefinition();
        string ChangeTableName(string schemaName, string tableName, string newTableName);
    }
}
