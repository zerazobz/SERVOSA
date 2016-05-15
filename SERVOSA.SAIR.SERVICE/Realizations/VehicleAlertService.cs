using SERVOSA.SAIR.SERVICE.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SERVOSA.SAIR.SERVICE.Models.TableData;
using SERVOSA.SAIR.DATAACCESS.Contracts;
using SERVOSA.SAIR.DATAACCESS.Models.Alerts;
using Elibom.APIClient;

namespace SERVOSA.SAIR.SERVICE.Realizations
{
    public class VehicleAlertService : IVehicleAlertService
    {
        private readonly IVehicleAlertRepository _vehicleAlertRepo;

        public VehicleAlertService(IVehicleAlertRepository injectedVehicleAlert)
        {
            _vehicleAlertRepo = injectedVehicleAlert;
        }

        public IList<VehicleAlert> GetAlertsNotSeneded()
        {
            VehicleAlert vehicleAlertModel = null;
            var vehicleCollection = _vehicleAlertRepo.GetAlertsNotSeneded().Select(va =>
            {
                VehicleAlert.ToServiceModel(va, ref vehicleAlertModel);
                return vehicleAlertModel;
            }).ToList();
            return vehicleCollection;
        }

        public int RegisterAlert(VehicleAlert model)
        {
            VehicleAlertDataModel dataModel = null;
            VehicleAlert.ToDataModel(model, ref dataModel);
            var insertResult = _vehicleAlertRepo.RegisterAlert(dataModel);
            return insertResult;
        }

        public string SendAlertBySMS(IEnumerable<string> phonesNumbers, string message, int alertId)
        {
            ElibomClient elibom = new ElibomClient("erickastooblitas@gmail.com", "740fB4OGc6");
            string deliveryToken = "TMPTEST";
            //var deliveryToken = elibom.sendMessage(String.Join(",", phonesNumbers), message);
            UpdateAlertSended(alertId, deliveryToken);
            Console.WriteLine(deliveryToken);
            return deliveryToken;
        }

        public int UpdateAlertSended(int alertId, string smsToken)
        {
            var updateResult = _vehicleAlertRepo.UpdateAlertSended(alertId, smsToken);
            return updateResult;
        }
    }
}
