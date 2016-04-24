using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.DATAACCESS.Models.DB
{
    public class ColumnModel
    {
        public string NormalizedTableName { get; set; }
        public string ColumnName { get; set; }
        public string NormalizedColumnaName { get; set; }
        public string DataType { get; set; }
    }
}
