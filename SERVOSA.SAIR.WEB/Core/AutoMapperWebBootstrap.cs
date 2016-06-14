using AutoMapper;
using SERVOSA.SAIR.SERVICE.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.WEB.Core
{
    public class AutoMapperWebBootstrap
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new AutoMapperServiceConfiguration());
                //cfg.AddProfile(new PostProfile());
            });
        }
    }
}
