using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.DATAACCESS.Models.Alerts
{
    public class DriverAlertDataModel
    {
        public int VEAL_Id { get; set; }
        public string VEAL_TableName { get; set; }
        public int VEAL_DaysToAlert { get; set; }
        public DateTime VEAL_DateToAlert { get; set; }
        public string VEAL_AlertName { get; set; }
        public bool VEAL_AlertSended { get; set; }
        public int VEHI_ID { get; set; }
    }
}
