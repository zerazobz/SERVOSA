using SERVOSA.SAIR.DATAACCESS.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SERVOSA.SAIR.DATAACCESS.Models.Driver;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SERVOSA.SAIR.DATAACCESS.Core;

namespace SERVOSA.SAIR.DATAACCESS.Realizations
{
    public class DriverFilesRepository : IDriverFilesRepository
    {
        private Database _servosaDb;
        public DriverFilesRepository()
        {
            DatabaseProviderFactory providerFactory = new DatabaseProviderFactory();
            _servosaDb = DataAccessDatabaseConfiguration.GetDataBase();
        }

        public int DeleteDriver(DriverFileModel model)
        {
            object[] deleteParameters = new object[] { model.VEHI_VEHIID, model.VEFI_TableName, model.VEFI_FileName };
            var deleteResult = _servosaDb.ExecuteNonQuery("SAIR_DRFID", deleteParameters);
            return deleteResult;
        }

        public IList<DriverFileModel> GetListDrivers(string tableName, int vehicleCode)
        {
            IRowMapper<DriverFileModel> driverFileMapper = MapBuilder<DriverFileModel>.MapAllProperties().Build();
            object[] listDriverParameters = new object[] { vehicleCode, tableName };
            var listDrivers = _servosaDb.ExecuteSprocAccessor("SAIR_DRFIS_ByTableNameDriver", driverFileMapper, listDriverParameters);
            return listDrivers.ToList();
        }

        public int InsertDriver(DriverFileModel model)
        {
            object[] insertParameters = new object[] { model.VEHI_VEHIID, model.VEFI_TableName, model.VEFI_DataFile, model.VEFI_FileName, model.VEFI_FileContentType, model.VEFI_FileLocationStored, model.VEFI_DateCreated };
            var insertResult = _servosaDb.ExecuteNonQuery("SAIR_DRFII", insertParameters);
            return insertResult;
        }
    }
}
