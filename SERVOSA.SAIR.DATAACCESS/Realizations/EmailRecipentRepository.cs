using SERVOSA.SAIR.DATAACCESS.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SERVOSA.SAIR.DATAACCESS.Models.Email;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SERVOSA.SAIR.DATAACCESS.Core;

namespace SERVOSA.SAIR.DATAACCESS.Realizations
{
    public class EmailRecipentRepository : IEmailRecipentsRepository
    {
        private Database _servosaDatabase;

        public EmailRecipentRepository()
        {
            _servosaDatabase = DataAccessDatabaseConfiguration.GetDataBase();
        }

        public int Create(EmailRecipentModel entity)
        {
            object[] parameters = new object[] { entity.EMRE_Email, null };
            using (var insertCommand = _servosaDatabase.GetStoredProcCommand("SAIR_EMREI", parameters))
            {
                var insertResult = _servosaDatabase.ExecuteNonQuery(insertCommand);
                entity.EMRE_Id = Convert.ToInt32(_servosaDatabase.GetParameterValue(insertCommand, "@EMRE_Id"));
                return insertResult;
            }
        }

        public int Delete(EmailRecipentModel entity)
        {
            object[] parameters = new object[] { entity.EMRE_Id };
            var deleteResult = _servosaDatabase.ExecuteNonQuery("SAIR_EMRED", parameters);
            return deleteResult;
        }

        public IList<EmailRecipentModel> GetAll()
        {
            IRowMapper<EmailRecipentModel> emailRecipentRowMapper = MapBuilder<EmailRecipentModel>.MapAllProperties().Build();
            object[] parameters = new object[] { };
            var emailRecipents = _servosaDatabase.ExecuteSprocAccessor("SAIR_EMRESS", emailRecipentRowMapper, parameters);
            return emailRecipents.ToList();
        }

        public EmailRecipentModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(EmailRecipentModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
