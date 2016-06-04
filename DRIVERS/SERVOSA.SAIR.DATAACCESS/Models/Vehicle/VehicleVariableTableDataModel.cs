using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.DATAACCESS.Models.Vehicle
{
    public class VehicleVariableTableDataModel
    {
        public string TableName { get; set; }
        public int ObjectId { get; set; }
        public string ColumnName { get; set; }
        public int ColumnId { get; set; }
        public string TableValue { get; set; }
        public string ColumnType { get; set; }
    }
}
