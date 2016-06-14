using SERVOSA.SAIR.DATAACCESS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.SERVICE.Core
{
    public class ServiceDataConfiguration
    {
        public static void SetOperation(string operationName)
        {
            DataAccessDatabaseConfiguration.SetOperation(operationName);
        }
    }
}
