using SERVOSA.SAIR.DATAACCESS.Models.Alerts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.DATAACCESS.Contracts
{
    public interface IDriverVehicleAlertRepository
    {
        IList<DriverAlertDataModel> GetAlertsNotSeneded();
        int RegisterAlert(DriverAlertDataModel model);
        int UpdateAlertSended(int alertId, string tokenSMS, DateTime sendDate, string recipients);
    }
}
