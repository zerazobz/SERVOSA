using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.SERVICE.Core
{
    public enum SERVOSASqlTypes
    {
        [Description("int")]
        Int = 1,
        [Description("decimal")]
        Decimal = 2,
        [Description("nvarchar")]
        NVarChar = 3,
        [Description("datetime")]
        DateTime = 4
    }
}
