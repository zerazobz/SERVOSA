using Microsoft.Practices.Unity;
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
            Container.RegisterType<IDriverRepository, DriverRepository>();
            Container.RegisterType<IDriverOldRepository, OldDriverRepository>();
            Container.RegisterType<IDriverDBTablesRepository, DriverDBRepository>();
            Container.RegisterType<IDriverDBColumnsRepository, DriverDBRepository>();
            Container.RegisterType<IDriverTableDataRepository, DriverTableDataRepository>();
            Container.RegisterType<IDriverVehicleAlertRepository, DriverAlertRepository>();
            Container.RegisterType<IDriverAlertService, DriverAlertService>();
            Container.RegisterType<IDriverTypeRepository, DriverTypeRepository>();
            Container.RegisterType<IDriverVehicleFilesRepository, DriverFilesRepository>();
        }
    }
}
