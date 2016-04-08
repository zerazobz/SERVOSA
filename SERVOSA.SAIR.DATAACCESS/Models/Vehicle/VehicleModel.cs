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
        public string PlacaTracto { get; set; }
        public string PlacaTolva { get; set; }
        public int CodigoMarca { get; set; }
        public string Marca { get; set; }
        public int CodigoEstado { get; set; }

        public int RowNumber { get; set; }
        public int TotalRows { get; set; }
    }
}
