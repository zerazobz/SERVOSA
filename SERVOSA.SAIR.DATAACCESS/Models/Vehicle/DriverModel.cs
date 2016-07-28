using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.DATAACCESS.Models.Driver
{
    public class DriverModel
    {
        public int Item { get; set; }
        public int Codigo { get; set; }
        public string TYPE_cTABBRND { get; set; }
        public string TYPE_cCODBRND { get; set; }
        public string Marca { get; set; }
        public string TYPE_cTABVSTA { get; set; }
        public string TYPE_cCODVSTA { get; set; }
        public string Estado { get; set; }
        public string VEHI_UnitType { get; set; }
        public string VEHI_DescriptionUnitType { get; set; }
        public string VEHI_VehiclePlate { get; set; }
        public DateTime? DRIV_dBirthDate { get; set; }
        public string DRIV_cAddress { get; set; }
        public string DRIV_Company { get; set; }

        public int RowNumber { get; set; }
        public int TotalRows { get; set; }
    }
}
