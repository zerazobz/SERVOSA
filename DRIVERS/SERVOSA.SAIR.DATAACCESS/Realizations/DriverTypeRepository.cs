using SERVOSA.SAIR.DATAACCESS.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SERVOSA.SAIR.DATAACCESS.Models.Types;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace SERVOSA.SAIR.DATAACCESS.Realizations
{
    public class DriverTypeRepository : IDriverTypeRepository
    {
        private Database _servosaDatabase;

        public DriverTypeRepository()
        {
            DatabaseProviderFactory providerFactory = new DatabaseProviderFactory();
            _servosaDatabase = providerFactory.CreateDefault();
        }

        public IList<DriverTypeModel> GetAllByTable(string tableCode)
        {
            object[] parameters = new object[] { tableCode };
            IRowMapper<DriverTypeModel> typeRowMapper = MapBuilder<DriverTypeModel>.MapAllProperties().Build();
            var collectionTypes = _servosaDatabase.ExecuteSprocAccessor("SAIR_TYPES_AllByTableForDriver", typeRowMapper, parameters);
            return collectionTypes.ToList();
        }
    }
}
