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
using System.Threading;
using System.Net.Mail;
using System.Net;

namespace SERVOSA.SAIR.SERVICE.Realizations
{
    public class VehicleAlertService : IVehicleAlertService
    {
        private readonly IVehicleAlertRepository _vehicleAlertRepo;

        public VehicleAlertService(IVehicleAlertRepository injectedVehicleAlert)
        {
            _vehicleAlertRepo = injectedVehicleAlert;
        }

        public IList<VehicleAlert> GetAlertsNotSended()
        {
            VehicleAlert vehicleAlertModel = null;
            var vehicleCollection = _vehicleAlertRepo.GetAlertsNotSeneded().Select(va =>
            {
                VehicleAlert.ToServiceModel(va, ref vehicleAlertModel);
                return vehicleAlertModel;
            }).ToList();
            return vehicleCollection;
        }

        public async Task<int> ProcessAlerts(IEnumerable<string> phoneNumbers)
        {
            int rowsInserted = 0;
            var allVehicleAlerts = GetAlertsNotSended();
            foreach (var iAlert in allVehicleAlerts)
            {
                if (DateTime.Now > iAlert.DateToAlert.AddDays(-iAlert.DaysToAlert))
                {
                    var alertMessage = $"Alerta para el Vehiculo con codigo {iAlert.VehicleId}, del Documento: {iAlert.TableName}-{iAlert.AlertName}. Alerta programada para la fecha: {iAlert.DateToAlert.ToShortDateString()}";
                    //var alertSendResult = await Task.Run(() => SendAlertBySMS(phoneNumbers, alertMessage, iAlert.VehicleAlertId));
                    var alertSendResult = await Task.Run(() => SendAlertByEmail(phoneNumbers, alertMessage, iAlert.VehicleAlertId));
                    rowsInserted++;
                }
            }
            return rowsInserted;
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
            string deliveryToken = String.Empty;
            try
            {
                string processedPhones = String.Join(",", phonesNumbers);
                ElibomClient elibom = new ElibomClient("erickastooblitas@gmail.com", "740fB4OGc6");
                //string deliveryToken = "TMPTEST";
                deliveryToken = elibom.sendMessage(processedPhones, message);
                UpdateAlertSended(alertId, deliveryToken, DateTime.Now, processedPhones);
                Console.WriteLine(deliveryToken);
                return deliveryToken;
            }
            catch (Exception ex)
            {
                return deliveryToken;
            }
        }

        public string SendAlertByEmail(IEnumerable<string> phonesNumbers, string alertmessage, int alertId)
        {
            string deliveryToken = String.Empty;
            try
            {
                string processedEmails = String.Join(",", phonesNumbers);
                var fromAddress = new MailAddress("zdelnaja@gmail.com", "Operador Sistema");
                //var toAddress = new MailAddress("zerazobz@example.com", "To Name");
                const string fromPassword = "doors.inxs88";
                const string subject = "Envio de Alerta";
                string body = alertmessage;

                var smtp = new SmtpClient()
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };
                
                var message = new MailMessage(fromAddress.Address, processedEmails)
                {
                    Subject = subject,
                    Body = body
                };
                
                smtp.SendCompleted += (send, ev) =>
                {
                    if (ev.Cancelled || ev.Error != null)
                        ;
                    else
                        UpdateAlertSended(alertId, deliveryToken, DateTime.Now, processedEmails);
                    smtp.Dispose();

                };
                smtp.SendAsync(message, null);
                Console.WriteLine(deliveryToken);
                return deliveryToken;
            }
            catch (Exception ex)
            {
                return deliveryToken;
            }
        }

        public int UpdateAlertSended(int alertId, string smsToken, DateTime sendDate, string recipients)
        {
            var updateResult = _vehicleAlertRepo.UpdateAlertSended(alertId, smsToken, sendDate, recipients);
            return updateResult;
        }
    }
}
