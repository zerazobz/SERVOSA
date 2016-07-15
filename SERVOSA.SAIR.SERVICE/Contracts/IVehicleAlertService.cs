using SERVOSA.SAIR.SERVICE.Models.TableData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.SERVICE.Contracts
{
    public interface IVehicleAlertService
    {
        IList<VehicleAlert> GetAlertsNotSended();
        Task<int> ProcessAlerts(IEnumerable<string> phoneNumbers);
        int RegisterAlert(VehicleAlert model);
        int UpdateAlertSended(int alertId, string smsToken, DateTime sendDate, string recipients);
        string SendAlertBySMS(IEnumerable<string> phonesNumbers, string message, int alertId);
        string SendAlertByEmail(IEnumerable<string> phonesNumbers, string message, int alertId, string document, string vehiclePlate);
    }
}
