using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.WEB.Models
{
    public class DriverTableColumnViewModel
    {
        public int TableId { get; set; }
        public string TableNormalizedName { get; set; }
        public string TableName { get; set; }
        public int SchemaId { get; set; }
        public string SchemaName { get; set; }
        public IList<DriverColumnViewModel> Columns { get; set; }
    }
}
