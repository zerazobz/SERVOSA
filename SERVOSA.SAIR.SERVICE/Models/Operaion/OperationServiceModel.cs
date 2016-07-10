using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.SERVICE.Models.Operaion
{
    public class OperationServiceModel
    {
        public int OperationId { get; set; }
        public string OperationName { get; set; }
        public int DataBaseId { get; set; }
        public string DataBaseName { get; set; }
        public string UserName { get; set; }
    }
}
