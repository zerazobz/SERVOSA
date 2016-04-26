using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.WEB.Models
{
    public class TableColumnViewModel
    {
        public int TableId { get; set; }
        public string TableNormalizedName { get; set; }
        public int SchemaId { get; set; }
        public string SchemaName { get; set; }
        public IList<ColumnViewModel> Columns { get; set; }
    }
}
