using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.DATAACCESS.Models.Driver
{
    public class DriverModel
    {
        public int OPER_Id { get; set; }
        public string OPER_cApellidoPaterno { get; set;}
        public string OPER_cApellidoMaterno { get; set; }
        public string OPER_cNombre { get; set; }
        public string OPER_cCorreo { get; set; }
        public int VEHI_Id {get;set;}
        public string VEHI_cDescripcion { get; set; }
        public int PUES_Id { get; set; }
        public int RowNumber { get; set; }
        public int TotalRows { get; set; }
    }
}
