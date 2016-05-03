using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.DATAACCESS.Models.Vehicle
{
    public class VehicleHeadDataModel
    {
        public VehicleHeadDataModel()
        {
            DataForRow = new List<VehicleDetailDataModel>();
        }

        public string TableName { get; set; }
        public int ObjectId { get; set; }
        public int VehicleId { get; set; }
        public IList<VehicleDetailDataModel> DataForRow { get; set; }
    }
}
