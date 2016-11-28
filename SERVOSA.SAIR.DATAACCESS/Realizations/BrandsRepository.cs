using SERVOSA.SAIR.DATAACCESS.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SERVOSA.SAIR.DATAACCESS.Models;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SERVOSA.SAIR.DATAACCESS.Core;

namespace SERVOSA.SAIR.DATAACCESS.Realizations
{
    public class BrandsRepository : IBrandsRepository
    {
        private readonly Database _servosaDB;

        public BrandsRepository()
        {
            DatabaseProviderFactory databaseFactory = new DatabaseProviderFactory();
            _servosaDB = DataAccessDatabaseConfiguration.GetDataBase();
        }

        public ICollection<BrandDataModel> GetAll()
        {
            object[] parameters = new object[] { };
            IRowMapper<BrandDataModel> brandRowMapper = MapBuilder<BrandDataModel>.MapAllProperties().Build();
            var brandsCollection = _servosaDB.ExecuteSprocAccessor("SAIR_TYPES_Brands", brandRowMapper, parameters);
            return brandsCollection.ToList();
        }

        public BrandDataModel GetById(string codeBrand)
        {
            throw new NotImplementedException();
        }

        public int Insert(BrandDataModel model)
        {
            object[] parameters = new object[] { model.TYPE_cDescription, model.TYPE_cNotes, null, null };
            using (var insertCommand = _servosaDB.GetStoredProcCommand("SAIR_TYPEI_Brands", parameters))
            {
                var resultExecution = _servosaDB.ExecuteNonQuery(insertCommand);
                if(resultExecution > 0)
                {
                    var brandCode = _servosaDB.GetParameterValue(insertCommand, "@TYPE_cCodTable").ToString();
                    var typeCode = _servosaDB.GetParameterValue(insertCommand, "@TYPE_cCodType").ToString();
                    model.TYPE_cCodTable = brandCode;
                    model.TYPE_cCodType = typeCode;
                }
                return resultExecution;
            }
        }

        public int Update(BrandDataModel model)
        {
            object[] parameters = new object[] { model.TYPE_cCodType, model.TYPE_cDescription, model.TYPE_cNotes };
            var updateResult = _servosaDB.ExecuteNonQuery("SAIR_TYPEU_Brands", parameters);
            return updateResult;
        }
    }
}
