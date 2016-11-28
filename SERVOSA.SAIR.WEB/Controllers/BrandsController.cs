using SERVOSA.SAIR.SERVICE.Contracts;
using SERVOSA.SAIR.SERVICE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SERVOSA.SAIR.WEB.Controllers
{
    [Authorize]
    public partial class BrandsController : Controller
    {
        private readonly IBrandService _brandsService;

        public BrandsController(IBrandService injectedBrandService)
        {
            _brandsService = injectedBrandService;
        }

        [HttpGet]
        public virtual ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public virtual ActionResult ListBrands(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                var allBrands = _brandsService.GetAll();
                int totalRecords = allBrands.Count;
                allBrands = allBrands.Skip(jtStartIndex).Take(jtPageSize).ToList();

                return Json(new { Result = "OK", Records = allBrands, TotalRecordCount = totalRecords });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public virtual ActionResult UpdateBrand(BrandModel model)
        {
            try
            {
                var codes = model.ConcatenatedCode.Split(new string[] { "|@|" }, StringSplitOptions.RemoveEmptyEntries);
                model.TableCode = codes[0];
                model.TypeCode = codes[1];
                var updateResult = _brandsService.Update(model);
                if (updateResult > 0)
                    return Json(new { Result = "OK" });
                else
                    return Json(new { Result = "ERROR", Message = "No se pudo actualizar el registro." });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public virtual ActionResult CreateBrand(BrandModel model)
        {
            try
            {
                var insertResult = _brandsService.Create(model);
                if (insertResult > 0)
                    return Json(new { Result = "OK", Record = model });
                else
                    return Json(new { Result = "ERROR", Message = "No se pudo insertar el registro." });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
    }
}