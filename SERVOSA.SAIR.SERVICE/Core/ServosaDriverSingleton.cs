using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.SERVICE.Core
{
    public sealed class ServosaDriverSingleton
    {
        private static readonly ServosaDriverSingleton uniqueInstance = new ServosaDriverSingleton();

        private ServosaDriverSingleton() { }

        public static ServosaDriverSingleton Instance
        {
            get
            {
                return uniqueInstance;
            }
        }

        public List<string> ConstantColumns
        {
            get
            {
                return new List<string> { "DiasAlerta", "RutaDocumento", "FechaVencimiento" };
            }
        }

        public List<string> HiddenColumnsForMainForm
        {
            get
            {
                return new List<string> { "id", "SAIR_VEHIID", "cid", "CSAIR_VEHIID", "RutaDocumento" };
            }
        }

        public List<string> AllConstantColumns
        {
            get
            {
                return new List<string> { ConstantIdentity, ConstantVehicleId, ConstantDayToAlert, "RutaDocumento", ConstantExpirationDate };
            }
        }

        public List<string> VariableNonInsertColumns
        {
            get
            {
                return new List<string> { "id" };
            }
        }

        public List<string> VariableNonUpdateColumns
        {
            get
            {
                return new List<string> { "id", "SAIR_VEHIID" };
            }
        }

        public List<string> ConstantNonInsertColumns
        {
            get
            {
                return new List<string> { "cid" };
            }
        }

        public List<string> ConstantNonUpdateColumns
        {
            get
            {
                return new List<string> { "cid", "CSAIR_VEHIID" };
            }
        }

        public string ConstantVehicleId
        {
            get
            {
                return "CSAIR_VEHIID";
            }
        }

        public string ConstantIdentity
        {
            get
            {
                return "cid";
            }
        }

        public string ConstantDayToAlert
        {
            get
            {
                return "DiasAlerta";
            }
        }

        public string ConstantExpirationDate
        {
            get
            {
                return "FechaVencimiento";
            }
        }

        public string VariableVehicleId
        {
            get
            {
                return "SAIR_VEHIID";
            }
        }

        public string VariableIdentity
        {
            get
            {
                return "id";
            }
        }
    }
}
