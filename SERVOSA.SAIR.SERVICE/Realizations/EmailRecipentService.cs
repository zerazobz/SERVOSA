using SERVOSA.SAIR.SERVICE.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SERVOSA.SAIR.SERVICE.Models.EmailRecipent;
using SERVOSA.SAIR.DATAACCESS.Contracts;
using SERVOSA.SAIR.DATAACCESS.Models.Email;

namespace SERVOSA.SAIR.SERVICE.Realizations
{
    public class EmailRecipentService : IEmailRecipentService
    {
        private readonly IEmailRecipentsRepository _emailRecipentRep;

        public EmailRecipentService(IEmailRecipentsRepository injectedEmailRecipent)
        {
            _emailRecipentRep = injectedEmailRecipent;
        }

        public int Delete(EmailRecipentServiceModel model)
        {
            return _emailRecipentRep.Delete(new EmailRecipentModel { EMRE_Id = model.Id });
        }

        public ICollection<EmailRecipentServiceModel> GetAll()
        {
            return _emailRecipentRep.GetAll().Select(eR =>
            {
                return new EmailRecipentServiceModel()
                {
                    Id = eR.EMRE_Id,
                    Email = eR.EMRE_Email
                };
            }).ToList();
        }

        public int Insert(EmailRecipentServiceModel model)
        {
            var modelToInsert = new EmailRecipentModel() { EMRE_Id = model.Id, EMRE_Email = model.Email };
            var insertResult = _emailRecipentRep.Create(modelToInsert);
            model.Id = modelToInsert.EMRE_Id;
            return insertResult;
        }
    }
}
