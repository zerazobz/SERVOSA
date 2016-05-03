using SERVOSA.SAIR.DATAACCESS.Models.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.SERVICE.Models
{
    public class VehicleHeadServiceModel
    {
        public VehicleHeadServiceModel()
        {
            DataForRow = new List<VehicleDetailServiceModel>();
        }

        public string TableName { get; set; }
        public int ObjectId { get; set; }
        public int VehicleId { get; set; }
        public IList<VehicleDetailServiceModel> DataForRow { get; set; }

        public void ToDataModel(VehicleHeadServiceModel serviceModel, ref VehicleHeadDataModel dataModel)
        {
            if (serviceModel != null)
            {
                dataModel = new VehicleHeadDataModel()
                {
                    ObjectId = serviceModel.ObjectId,
                    TableName = serviceModel.TableName,
                    VehicleId = serviceModel.VehicleId
                };

                var tmp = new List<VehicleDetailDataModel>();

                serviceModel.DataForRow.ToList().ForEach(dR => tmp.Add(new VehicleDetailDataModel
                {
                    Type = String.Empty,
                    Value = dR.Value
                }));
                dataModel.DataForRow = tmp;
            }
            else
                dataModel = null;
        }

        public void ToServiceModel(VehicleHeadDataModel dataModel, ref VehicleHeadServiceModel serviceModel)
        {
            if(dataModel != null)
            {
                serviceModel = new VehicleHeadServiceModel()
                {
                    ObjectId = dataModel.ObjectId,
                    TableName = dataModel.TableName,
                    VehicleId = dataModel.VehicleId
                };

                var tmp = new List<VehicleDetailServiceModel>();
                dataModel.DataForRow.ToList().ForEach(dr => tmp.Add(new VehicleDetailServiceModel
                {
                    Type = String.Empty,
                    Value = dr.Value
                }));
                serviceModel.DataForRow = tmp;
            }
        }
    }
}
