using SERVOSA.SAIR.DATAACCESS.Models.Alerts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.SERVICE.Models.TableData
{
    public class DriverAlert
    {
        public int VehicleAlertId { get; set; }
        public string TableName { get; set; }
        public int DaysToAlert { get; set; }
        public DateTime DateToAlert { get; set; }
        public string AlertName { get; set; }
        public bool AlertSended { get; set; }
        public int VehicleId { get; set; }

        public static void ToServiceModel(DriverAlertDataModel model, ref DriverAlert serviceModel)
        {
            if (model != null)
                serviceModel = new DriverAlert()
                {
                    AlertName = model.VEAL_AlertName,
                    AlertSended = model.VEAL_AlertSended,
                    DateToAlert = model.VEAL_DateToAlert,
                    DaysToAlert = model.VEAL_DaysToAlert,
                    TableName = model.VEAL_TableName,
                    VehicleAlertId = model.VEAL_Id,
                    VehicleId = model.VEHI_ID
                };
            else
                serviceModel = null;
        }
        
        public static void ToDataModel(DriverAlert servicemodel, ref DriverAlertDataModel dataModel)
        {
            if (servicemodel != null)
                dataModel = new DriverAlertDataModel()
                {
                    VEAL_AlertName = servicemodel.AlertName,
                    VEAL_AlertSended = servicemodel.AlertSended,
                    VEAL_DateToAlert = servicemodel.DateToAlert,
                    VEAL_DaysToAlert = servicemodel.DaysToAlert,
                    VEAL_Id = servicemodel.VehicleAlertId,
                    VEAL_TableName = servicemodel.TableName,
                    VEHI_ID = servicemodel.VehicleId
                };
            else
                dataModel = null;
        }
    }
}
