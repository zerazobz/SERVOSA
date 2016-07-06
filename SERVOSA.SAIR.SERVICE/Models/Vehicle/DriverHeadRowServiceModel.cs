using SERVOSA.SAIR.DATAACCESS.Models.Driver;
using SERVOSA.SAIR.SERVICE.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.SERVICE.Models
{
    public class DriverHeadRowServiceModel
    {
        public DriverHeadRowServiceModel()
        {
            DataForRow = new List<DriverDetailRowServiceModel>();
        }

        public string TableName { get; set; }
        public int ObjectId { get; set; }
        public int DriverId { get; set; }
        public int ColumnIdValue { get; set; }
        public bool WithAlert { get; set; }
        public IList<DriverDetailRowServiceModel> DataForRow { get; set; }

        public static void ToDataModel(DriverHeadRowServiceModel serviceModel, ref DriverHeadRowDataModel dataModel)
        {
            if (serviceModel != null)
            {
                dataModel = new DriverHeadRowDataModel()
                {
                    ObjectId = serviceModel.ObjectId,
                    TableName = serviceModel.TableName,
                    VehicleId = serviceModel.DriverId
                };

                var tmp = new List<DriverDetailRowDataModel>();

                serviceModel.DataForRow.ToList().ForEach(dR => tmp.Add(new DriverDetailRowDataModel
                {
                    Type = String.Empty,
                    Value = dR.Value
                }));
                dataModel.DataForRow = tmp;
                //tmp.Where(dR=> dR.Type)
                //dataModel.DataForRow.Where(dR => dR.t)
            }
            else
                dataModel = null;
        }

        public static void ToServiceModel(DriverHeadRowDataModel dataModel, ref DriverHeadRowServiceModel serviceModel)
        {
            if(dataModel != null)
            {
                serviceModel = new DriverHeadRowServiceModel()
                {
                    ObjectId = dataModel.ObjectId,
                    TableName = dataModel.TableName,
                    DriverId = dataModel.VehicleId
                };

                DateTime? dateToAlert = null;
                int? daysToAlert = null;

                var tmpList = new List<DriverDetailRowServiceModel>();
                dataModel.DataForRow.ToList().ForEach(dr =>
                {
                    tmpList.Add(new DriverDetailRowServiceModel
                    {
                        Type = String.Empty,
                        Value = dr.Value
                    });
                });
                serviceModel.DataForRow = tmpList;

                var rawDateToAlert = tmpList.Where(d => !String.IsNullOrWhiteSpace(d.ColumnName) && ServosaDriverSingleton.Instance.ConstantExpirationDate.Contains(d.ColumnName)).Select(data => data.Value).FirstOrDefault();
                DateTime tmpDate;
                if (DateTime.TryParse(rawDateToAlert, out tmpDate))
                    dateToAlert = tmpDate;

                var rawDaysToAlert = tmpList.Where(d => !String.IsNullOrWhiteSpace(d.ColumnName) && ServosaDriverSingleton.Instance.ConstantDayToAlert.Contains(d.ColumnName)).Select(data => data.Value).FirstOrDefault();
                int tmpInt;
                if (Int32.TryParse(rawDaysToAlert, out tmpInt))
                    daysToAlert = tmpInt;

                if (dateToAlert.HasValue && daysToAlert.HasValue)
                    serviceModel.WithAlert = DateTime.Today >= dateToAlert.Value.AddDays(-daysToAlert.Value);
            }
        }
    }
}
