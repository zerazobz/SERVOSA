using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.DATAACCESS.Models.Vehicle
{
    public class DriverRelatedTableToEntityModel
    {
        public string foreign_key_name { get; set; }
        public string foreign_table { get; set; }
        public string foreign_column { get; set; }
        public string parent_table { get; set; }
        public string parent_column { get; set; }
    }
}
