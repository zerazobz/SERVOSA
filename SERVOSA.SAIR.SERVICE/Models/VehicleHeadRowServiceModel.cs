using SERVOSA.SAIR.DATAACCESS.Models.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.SERVICE.Models
{
    public class VehicleHeadRowServiceModel
    {
        public VehicleHeadRowServiceModel()
        {
            DataForRow = new List<VehicleDetailRowServiceModel>();
        }

        public string TableName { get; set; }
        public int ObjectId { get; set; }
        public int VehicleId { get; set; }
        public IList<VehicleDetailRowServiceModel> DataForRow { get; set; }

        public static void ToDataModel(VehicleHeadRowServiceModel serviceModel, ref VehicleHeadRowDataModel dataModel)
        {
            if (serviceModel != null)
            {
                dataModel = new VehicleHeadRowDataModel()
                {
                    ObjectId = serviceModel.ObjectId,
                    TableName = serviceModel.TableName,
                    VehicleId = serviceModel.VehicleId
                };

                var tmp = new List<VehicleDetailRowDataModel>();

                serviceModel.DataForRow.ToList().ForEach(dR => tmp.Add(new VehicleDetailRowDataModel
                {
                    Type = String.Empty,
                    Value = dR.Value
                }));
                dataModel.DataForRow = tmp;
            }
            else
                dataModel = null;
        }

        public static void ToServiceModel(VehicleHeadRowDataModel dataModel, ref VehicleHeadRowServiceModel serviceModel)
        {
            if(dataModel != null)
            {
                serviceModel = new VehicleHeadRowServiceModel()
                {
                    ObjectId = dataModel.ObjectId,
                    TableName = dataModel.TableName,
                    VehicleId = dataModel.VehicleId
                };

                var tmp = new List<VehicleDetailRowServiceModel>();
                dataModel.DataForRow.ToList().ForEach(dr => tmp.Add(new VehicleDetailRowServiceModel
                {
                    Type = String.Empty,
                    Value = dr.Value
                }));
                serviceModel.DataForRow = tmp;
            }
        }
    }
}
