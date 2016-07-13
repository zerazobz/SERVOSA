using SERVOSA.SAIR.DATAACCESS.Core;
using SERVOSA.SAIR.DATAACCESS.Models.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.DATAACCESS.Contracts
{
    public interface IEmailRecipentsRepository : IRepository<EmailRecipentModel>
    {
    }
}
