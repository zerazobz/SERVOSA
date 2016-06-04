using SERVOSA.SAIR.DATAACCESS.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SERVOSA.SAIR.DATAACCESS.Models.Vehicle;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace SERVOSA.SAIR.DATAACCESS.Realizations
{
    public class VehicleFilesRepository : IVehicleFilesRepository
    {
        private Database _servosaDb;
        public VehicleFilesRepository()
        {
            DatabaseProviderFactory providerFactory = new DatabaseProviderFactory();
            _servosaDb = providerFactory.CreateDefault();
        }

        public int DeleteVehicle(VehicleFileModel model)
        {
            object[] deleteParameters = new object[] { model.VEHI_VEHIID, model.VEFI_TableName, model.VEFI_FileName };
            var deleteResult = _servosaDb.ExecuteNonQuery("SAIR_VEFID", deleteParameters);
            return deleteResult;
        }

        public IList<VehicleFileModel> GetListVehicles(string tableName, int vehicleCode)
        {
            IRowMapper<VehicleFileModel> vehicleFileMapper = MapBuilder<VehicleFileModel>.MapAllProperties().Build();
            object[] listVehicleParameters = new object[] { vehicleCode, tableName };
            var listVehicles = _servosaDb.ExecuteSprocAccessor("SAIR_VEFIS_ByTableNameVehicle", vehicleFileMapper, listVehicleParameters);
            return listVehicles.ToList();
        }

        public int InsertVehicle(VehicleFileModel model)
        {
            object[] insertParameters = new object[] { model.VEHI_VEHIID, model.VEFI_TableName, model.VEFI_DataFile, model.VEFI_FileName, model.VEFI_FileContentType, model.VEFI_FileLocationStored, model.VEFI_DateCreated };
            var insertResult = _servosaDb.ExecuteNonQuery("SAIR_VEFII", insertParameters);
            return insertResult;
        }
    }
}
