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
        public static string GetOperationId(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("OperationId");
            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }
    }
}
