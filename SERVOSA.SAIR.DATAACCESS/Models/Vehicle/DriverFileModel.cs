using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.DATAACCESS.Models.Driver
{
    public class DriverFileModel
    {
        public int VEFI_Identity { get; set; }
        public int VEHI_VEHIID { get; set; }
        public string VEFI_TableName { get; set; }
        public byte[] VEFI_DataFile { get; set; }
        public string VEFI_FileName { get; set; }
        public string VEFI_FileContentType { get; set; }
        public string VEFI_FileLocationStored { get; set; }
        public DateTime VEFI_DateCreated { get; set; }
    }
}
