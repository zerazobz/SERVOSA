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
            Container.RegisterType<IVehicleRepository, VehicleRepository>();
            Container.RegisterType<IOldDriverRepository, OldDriverRepository>();
            Container.RegisterType<IDBTablesRepository, DBRepository>();
            Container.RegisterType<IDBColumnsRepository, DBRepository>();
            Container.RegisterType<ITableDataRepository, TableDataRepository>();
            Container.RegisterType<IVehicleAlertRepository, VehicleAlertRepository>();
            Container.RegisterType<IVehicleAlertService, VehicleAlertService>();
            Container.RegisterType<ITypeRepository, TypeRepository>();
            Container.RegisterType<IVehicleFilesRepository, VehicleFilesRepository>();
            Container.RegisterType<IDriverRepository, DriverRepository>();
            Container.RegisterType<IDriverDBTablesRepository, DriverDBRepository>();
            Container.RegisterType<IDriverDBColumnsRepository, DriverDBRepository>();
            Container.RegisterType<IDriverTableDataRepository, DriverTableDataRepository>();
            Container.RegisterType<IDriverAlertRepository, DriverAlertRepository>();
            Container.RegisterType<IDriverAlertService, DriverAlertService>();
            Container.RegisterType<IDriverTypeRepository, DriverTypeRepository>();
            Container.RegisterType<IDriverFilesRepository, DriverFilesRepository>();
        }
    }
}
