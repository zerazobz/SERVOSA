using SERVOSA.SAIR.DATAACCESS.Models.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.SERVICE.Models.Vehicle
{
    public class VehicleFileServiceModel
    {
        public int Identity { get; set; }
        public int VehicleId { get; set; }
        public string TableName { get; set; }
        public byte[] DataFile { get; set; }
        public string FileName { get; set; }
        public string FileContentType { get; set; }
        public string FileLocationStored { get; set; }
        public DateTime DateCreated { get; set; }

        public string ComposedPrimaryKey { get; set; }

        public static void ToServiceModel(DriverFileModel dataModel, ref VehicleFileServiceModel serviceModel)
        {
            if (dataModel != null)
                serviceModel = new VehicleFileServiceModel()
                {
                    DataFile = dataModel.VEFI_DataFile,
                    DateCreated = dataModel.VEFI_DateCreated,
                    FileContentType = dataModel.VEFI_FileContentType,
                    FileLocationStored = dataModel.VEFI_FileLocationStored,
                    FileName = dataModel.VEFI_FileName,
                    Identity = dataModel.VEFI_Identity,
                    TableName = dataModel.VEFI_TableName,
                    VehicleId = dataModel.VEHI_VEHIID,
                    ComposedPrimaryKey = String.Format("{0}|@|{1}|@|{2}", dataModel.VEHI_VEHIID, dataModel.VEFI_TableName, dataModel.VEFI_FileName)
                };
            else
                serviceModel = null;
        }

        public static void ToDataModel(VehicleFileServiceModel serviceModel, ref DriverFileModel dataModel)
        {
            if (serviceModel != null)
                dataModel = new DriverFileModel()
                {
                    VEFI_DataFile = serviceModel.DataFile,
                    VEFI_DateCreated = serviceModel.DateCreated,
                    VEFI_FileContentType = serviceModel.FileContentType,
                    VEFI_FileLocationStored = serviceModel.FileLocationStored,
                    VEFI_FileName = serviceModel.FileName,
                    VEFI_Identity = serviceModel.Identity,
                    VEFI_TableName = serviceModel.TableName,
                    VEHI_VEHIID = serviceModel.VehicleId
                };
            else
                dataModel = null;
        }
    }
}
