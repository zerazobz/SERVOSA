using SERVOSA.SAIR.SERVICE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SERVOSA.SAIR.WEB.Controllers
{
    public partial class VariableTasksController : Controller
    {
        [HttpGet]
        public virtual ActionResult CreateTable()
        {
            TableViewModel model = new TableViewModel();
            return PartialView(MVC.VariableTasks.Views.CreateTable, model);
        }

        [HttpPost]
        public virtual ActionResult CreateTable(TableViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                viewModel.IsSuccessful = true;
                viewModel.TableNormalizedName = viewModel.TableName.Trim().Replace(" ", String.Empty);
                viewModel.Message = "Se creo correctamente el Encabezado de Variable.";
            }
            else
            {
                viewModel.IsSuccessful = false;
                viewModel.Message = "Ocurrio un error al intentar crear el encabezado de Variable.";
            }

            return PartialView(MVC.VariableTasks.Views.CreateTable, viewModel);
        }
    }
}