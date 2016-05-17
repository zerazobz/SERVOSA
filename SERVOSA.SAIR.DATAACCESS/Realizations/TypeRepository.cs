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
    public class TypeRepository : ITypeRepository
    {
        private Database _servosaDatabase;

        public TypeRepository()
        {
            DatabaseProviderFactory providerFactory = new DatabaseProviderFactory();
            _servosaDatabase = providerFactory.CreateDefault();
        }

        public IList<TypeModel> GetAllByTable(string tableCode)
        {
            object[] parameters = new object[] { tableCode };
            IRowMapper<TypeModel> typeRowMapper = MapBuilder<TypeModel>.MapAllProperties().Build();
            var collectionTypes = _servosaDatabase.ExecuteSprocAccessor("SAIR_TYPES_AllByTable", typeRowMapper, parameters);
            return collectionTypes.ToList();
        }
    }
}
