using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.WEB.Core
{
    public sealed class WebSingleton
    {
        private static readonly WebSingleton uniqueInstance = new WebSingleton();

        private WebSingleton() { }

        public static WebSingleton Instance
        {
            get
            {
                return uniqueInstance;
            }
        }

        //public List<string> ConstantColumns
        //{
        //    get
        //    {
        //        return new List<string> { "DiasAlerta", "RutaDocumento", "FechaVencimiento" };
        //    }
        //}

        //public List<string> HiddenColumns
        //{
        //    get
        //    {
        //        return new List<string> { "id", "SAIR_VEHIID", "cid", "CSAIR_VEHIID", "RutaDocumento" };
        //    }
        //}

        //public List<string> AllConstantColumns
        //{
        //    get
        //    {
        //        return new List<string> { "cid", "CSAIR_VEHIID", "DiasAlerta", "RutaDocumento", "FechaVencimiento" };
        //    }
        //}
    }
}
