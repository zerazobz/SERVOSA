using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.DATAACCESS.Models.Vehicle
{
    public class VehicleModel
    {
        public int Item { get; set; }
        public int Codigo { get; set; }
        //public string PlacaTracto { get; set; }
        //public string PlacaTolva { get; set; }
        public string TYPE_cTABBRND { get; set; }
        public string TYPE_cCODBRND { get; set; }
        public string Marca { get; set; }
        public string TYPE_cTABVSTA { get; set; }
        public string TYPE_cCODVSTA { get; set; }
        public string Estado { get; set; }
        public string VEHI_UnitType { get; set; }
        public string VEHI_DescriptionUnitType { get; set; }
        public string VEHI_VehiclePlate { get; set; }

        public int RowNumber { get; set; }
        public int TotalRows { get; set; }
    }
}
