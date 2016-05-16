using SERVOSA.SAIR.DATAACCESS.Models.Alerts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.DATAACCESS.Contracts
{
    public interface IVehicleAlertRepository
    {
        IList<VehicleAlertDataModel> GetAlertsNotSeneded();
        int RegisterAlert(VehicleAlertDataModel model);
        int UpdateAlertSended(int alertId, string tokenSMS, DateTime sendDate, string recipients);
    }
}
