using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SERVOSA.SAIR.WEB;
using SERVOSA.SAIR.WEB.Controllers;
using SERVOSA.SAIR.SERVICE.Contracts;
using Microsoft.Practices.Unity;
using SERVOSA.SAIR.WEB.Tests.App_Start;

namespace SERVOSA.SAIR.WEB.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            var container = UnityConfig.GetConfiguredContainer();
            var repository = container.Resolve<IVehicleService>();
            var dbServices = container.Resolve<IDBServices>();
            var vehicleAlertServices = container.Resolve<IVehicleAlertService>();
            var emailServices = container.Resolve<IEmailRecipentService>();
            // Arrange
            HomeController controller = new HomeController(repository, dbServices, vehicleAlertServices, emailServices);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
