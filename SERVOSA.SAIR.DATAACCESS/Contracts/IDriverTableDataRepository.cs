using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.DATAACCESS.Contracts
{
    public interface IDriverTableDataRepository
    {
        List<int> TestDataStructured();
        int InsertDataToTable(string tableName, Dictionary<string, string> dataPrepared, bool variableData);
        int UpdateDataToTable(string tableName, int driverId, Dictionary<string, string> dataPrepared, bool variableData);
    }
}
