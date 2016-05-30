using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.DATAACCESS.Contracts
{
    public interface ITableDataRepository
    {
        List<int> TestDataStructured();
        int InsertDataToTable(string tableName, Dictionary<string, string> dataPrepared, bool variableData);
        int UpdateDataToTable(string tableName, int vehicleId, Dictionary<string, string> dataPrepared, bool variableData);
    }
}
