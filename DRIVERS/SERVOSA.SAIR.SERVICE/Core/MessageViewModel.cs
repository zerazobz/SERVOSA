using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.SERVICE.Core
{
    public class MessageViewModel
    {
        public int RowsAffected { get; set; }
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
    }
}
