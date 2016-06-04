using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.DATAACCESS.Models.DB
{
    public class TableColumnModel
    {
        public int TableObjectId { get; set; }
        public string TableNormalizedName { get; set; }
        public string TableName { get; set; }
        public int SchemaId { get; set; }
        public string SchemaName { get; set; }
        public string ColumnNormalizedName { get; set; }
        public string ColumnName { get; set; }
        public int UserType { get; set; }
        public int SystemType { get; set; }
        public string TypeName { get; set; }
    }
}
