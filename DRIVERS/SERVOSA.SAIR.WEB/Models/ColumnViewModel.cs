using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.WEB.Models
{
    public class ColumnViewModel
    {
        public string ColumnNormalizedName { get; set; }
        public string ColumnName { get; set; }
        public int UserType { get; set; }
        public int SystemType { get; set; }
        public string TypeName { get; set; }
    }
}
