using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Practices.Unity;
using SERVOSA.SAIR.SERVICE.Contracts;
using SERVOSA.SAIR.SERVICE.Realizations;
using SERVOSA.SAIR.WEB.Controllers;
using SERVOSA.SAIR.WEB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.WEB.Core
{
    public class WebContainerInjector : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IDriverService, DriverService>();
            Container.RegisterType<IVehicleService, VehicleService>();
            Container.RegisterType<IOldDriverService, OldDriverService>();
            Container.RegisterType<IDriverDBServices, DriverDBServices>();
            Container.RegisterType<IDriverTableDataService, DriverTableDataService>();
            Container.RegisterType<IDriverAlertService, DriverAlertService>();
            Container.RegisterType<IDriverTypeService, DriverTypeService>();
            Container.RegisterType<IDriverFileService, DriverFileService>();
            Container.RegisterType<IDBServices, DBServices>();
            Container.RegisterType<ITableDataService, TableDataService>();
            Container.RegisterType<IVehicleAlertService, VehicleAlertService>();
            Container.RegisterType<ITypeService, TypeService>();
            Container.RegisterType<IVehicleFileService, VehicleFileService>();
            Container.RegisterType<DbContext, ApplicationDbContext>(new HierarchicalLifetimeManager());
            Container.RegisterType<UserManager<ApplicationUser>>(new HierarchicalLifetimeManager());
            Container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>(new HierarchicalLifetimeManager());
            Container.RegisterType<AccountController>(new InjectionConstructor());
        }
    }
}
