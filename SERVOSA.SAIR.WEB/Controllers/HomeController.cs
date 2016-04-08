using SERVOSA.SAIR.DATAACCESS.Models.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SERVOSA.SAIR.WEB.Controllers
{
    public partial class HomeController : Controller
    {
        [HttpGet]
        public virtual ActionResult Index()
        {
            return View(MVC.Home.Views.Index);
        }

        [ChildActionOnly]
        [HttpGet]
        public virtual ActionResult VehicleTable()
        {
            List<VehicleModel> model = new List<VehicleModel>();
            model.Add(new VehicleModel()
            {
                Item = 1,
                Codigo = 1,
                PlacaTracto = "COM-791",
                PlacaTolva = "C35-870",
                CodigoMarca = 1,
                Marca = "Toyota",
                CodigoEstado = 1
            });
            model.Add(new VehicleModel()
            {
                Item = 2,
                Codigo = 2,
                PlacaTracto = "COM-653",
                PlacaTolva = "C63-205",
                CodigoMarca = 2,
                Marca = "Hyundai",
                CodigoEstado = 0
            });
            model.Add(new VehicleModel()
            {
                Item = 3,
                Codigo = 3,
                PlacaTracto = "COM-204",
                PlacaTolva = "C85-120",
                CodigoMarca = 3,
                Marca = "Mercedes",
                CodigoEstado = 2
            });

            return PartialView(MVC.Home.Views.VehicleTable, model);
        }
    }
}