using SERVOSA.SAIR.SERVICE.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SERVOSA.SAIR.SERVICE.Models;
using SERVOSA.SAIR.DATAACCESS.Contracts;
using SERVOSA.SAIR.DATAACCESS.Models;

namespace SERVOSA.SAIR.SERVICE.Realizations
{
    public class BrandService : IBrandService
    {
        private readonly IBrandsRepository _brandsRepo;

        public BrandService(IBrandsRepository injectedBrandRepo)
        {
            _brandsRepo = injectedBrandRepo;
        }

        public int Create(BrandModel model)
        {
            BrandDataModel dataModel = null;
            BrandModel.ToDataModel(model, ref dataModel);
            var insertResult = _brandsRepo.Insert(dataModel);
            return insertResult;

        }

        public ICollection<BrandModel> GetAll()
        {
            BrandModel brandServiceModel = null;
            return _brandsRepo.GetAll().Select(b =>
            {
                BrandModel.ToServiceModel(b, ref brandServiceModel);
                return brandServiceModel;
            }).ToList();
        }

        public int Update(BrandModel model)
        {
            BrandDataModel dataModel = null;
            BrandModel.ToDataModel(model, ref dataModel);
            var updateResult = _brandsRepo.Update(dataModel);
            return updateResult;
        }
    }
}
