using AutoMapper;
using SERVOSA.SAIR.DATAACCESS.Models.Operations;
using SERVOSA.SAIR.SERVICE.Models.Operaion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.SERVICE.Core
{
    public class AutoMapperServiceConfiguration : Profile
    {
        protected override void Configure()
        {
            CreateMap<OperationDbModel, OperationServiceModel>();
        }
    }
}
