using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.DATAACCESS.Models.Operations
{
    public class OperationDbModel
    {
        public int OperationId { get; set; }
        public string OperationName { get; set; }
        public int DataBaseId { get; set; }
        public string DataBaseName { get; set; }
    }
}
