﻿using SERVOSA.SAIR.SERVICE.Contracts;
using SERVOSA.SAIR.SERVICE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SERVOSA.SAIR.WEB.Controllers
{
    public partial class DriverController : Controller
    {
        private IDriverService _driverService;

        public DriverController(IDriverService injectedDriverServ)
        {
            _driverService = injectedDriverServ;
        }

        [HttpGet]
        public virtual ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public virtual JsonResult ListDrivers(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                var collectionDrivers = _driverService.GetAllFiltered(jtStartIndex, jtStartIndex + jtPageSize);
                int totalRows = 0;
                if (collectionDrivers != null && collectionDrivers.Count > 0)
                    totalRows = collectionDrivers.FirstOrDefault().TotalRows;

                return Json(new { Result = "OK", Records = collectionDrivers, TotalRecordCount = totalRows });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public virtual JsonResult DeleteDriver(int CodigoOperario)
        {
            try
            {
                var deleteResult = _driverService.Create(new DriverServiceModel()
                {
                    CodigoOperario = CodigoOperario
                });
                if (deleteResult > 0)
                    return Json(new { Result = "OK" });
                else
                    return Json(new { Result = "ERROR", Message = "No se elimino ningún registro." });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = "No se puede eliminar el operario por que el operario esta asignado a un vehiculo" });
            }
        }


        [HttpPost]
        public virtual JsonResult UpdateDriver(DriverServiceModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return Json(new { Result = "ERROR", Message = "Los campos insertados no són validos." });

                var updateResult = _driverService.Update(model);
                if (updateResult > 0)
                    return Json(new { Result = "OK" });
                else
                    return Json(new { Result = "ERROR", Message = "No se actualizo ningún registro." });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public virtual JsonResult CreateDriver(DriverServiceModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return Json(new { Result = "ERROR", Message = "Los campos insertados no són validos." });

                var createResult = _driverService.Create(model);
                if (createResult > 0)
                    return Json(new { Result = "OK", Record = model });
                else
                    return Json(new { Result = "ERROR", Message = "No se creo ningún registro." });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }   
    }
}