using SERVOSA.SAIR.DATAACCESS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.DATAACCESS.Contracts
{
    public interface IBrandsRepository
    {
        ICollection<BrandDataModel> GetAll();
        BrandDataModel GetById(string codeBrand);
        int Insert(BrandDataModel model);
        int Update(BrandDataModel model);
    }
}
