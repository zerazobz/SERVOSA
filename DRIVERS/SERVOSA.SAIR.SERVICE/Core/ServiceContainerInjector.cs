﻿using Microsoft.Practices.Unity;
using SERVOSA.SAIR.DATAACCESS.Contracts;
using SERVOSA.SAIR.DATAACCESS.Realizations;
using SERVOSA.SAIR.SERVICE.Contracts;
using SERVOSA.SAIR.SERVICE.Realizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.SERVICE.Core
{
    public class ServiceContainerInjector : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IDriverRepository, VehicleRepository>();
            Container.RegisterType<IDriverOldRepository, DriverRepository>();
            Container.RegisterType<IDBTablesRepository, DBRepository>();
            Container.RegisterType<IDriverDBColumnsRepository, DBRepository>();
            Container.RegisterType<IDriverTableDataRepository, TableDataRepository>();
            Container.RegisterType<IDriverVehicleAlertRepository, VehicleAlertRepository>();
            Container.RegisterType<IVehicleAlertService, VehicleAlertService>();
            Container.RegisterType<IDriverTypeRepository, TypeRepository>();
            Container.RegisterType<IDriverVehicleFilesRepository, VehicleFilesRepository>();
        }
    }
}
