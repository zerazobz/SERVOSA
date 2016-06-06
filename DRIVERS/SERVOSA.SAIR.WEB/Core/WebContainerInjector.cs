using Microsoft.Practices.Unity;
using SERVOSA.SAIR.SERVICE.Contracts;
using SERVOSA.SAIR.SERVICE.Realizations;
using System;
using System.Collections.Generic;
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
            Container.RegisterType<IOldDriverService, OldDriverService>();
            Container.RegisterType<IDriverDBServices, DriverDBServices>();
            Container.RegisterType<IDriverTableDataService, DriverTableDataService>();
            Container.RegisterType<IDriverAlertService, DriverAlertService>();
            Container.RegisterType<IDriverTypeService, DriverTypeService>();
            Container.RegisterType<IDriverFileService, DriverFileService>();
        }
    }
}
