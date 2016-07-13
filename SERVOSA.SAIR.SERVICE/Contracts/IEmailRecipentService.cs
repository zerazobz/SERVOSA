using SERVOSA.SAIR.SERVICE.Models.EmailRecipent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.SERVICE.Contracts
{
    public interface IEmailRecipentService
    {
        ICollection<EmailRecipentServiceModel> GetAll();
        int Insert(EmailRecipentServiceModel model);
        int Delete(EmailRecipentServiceModel model);
    }
}
