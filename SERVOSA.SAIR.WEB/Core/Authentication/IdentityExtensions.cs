using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.WEB.Core.Authentication
{
    public static class IdentityExtensions
    {
        public static int? GetOperationId(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("OperationId");
            // Test for null to avoid issues during local testing
            int tempValue;
            int? operationId = (claim != null) && Int32.TryParse(claim.Value, out tempValue)? tempValue: (int?)null;
            return operationId;
        }
    }
}
