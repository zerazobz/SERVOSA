using SERVOSA.SAIR.SERVICE.Contracts;
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
        private readonly IDBServices _dbService;

        public VariableTasksController(IDBServices  injectedDbService)
        {
            _dbService = injectedDbService;
        }

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
                var resultCreation = _dbService.CreateTable(viewModel);

                viewModel.IsSuccessful = !String.IsNullOrWhiteSpace(resultCreation.Item2.TableNormalizedName);
                viewModel.TableNormalizedName = resultCreation.Item2.TableNormalizedName;
                viewModel.Message = "Se creo correctamente el Encabezado de Variable.";
            }
            else
            {
                viewModel.IsSuccessful = false;
                viewModel.Message = "Por favor corrija los valores ingresados.";
            }

            return PartialView(MVC.VariableTasks.Views.CreateTable, viewModel);
        }

        [HttpGet]
        public virtual ActionResult CreateColumn()
        {
            ColumnViewModel viewModel = new ColumnViewModel();
            viewModel.ListaTipos = new SelectList(GetListColumnTypes(), "Codigo", "Descripcion");
            return PartialView(MVC.VariableTasks.Views.CreateColumn, viewModel);
        }

        [HttpPost]
        public virtual ActionResult CreateColumn(ColumnViewModel viewModel)
        {
            viewModel.ListaTipos = new SelectList(GetListColumnTypes(), "Codigo", "Descripcion");
            if (ModelState.IsValid)
            {
                viewModel.IsSuccessful = true;
                viewModel.Message = "Se creo correctamente la Columna";
                viewModel.ColumnNormalizedName = viewModel.ColumnName.Trim().Replace(" ", String.Empty);
            }
            else
            {
                viewModel.IsSuccessful = true;
                viewModel.Message = "No se pudo crear la Columna.";
            }

            return PartialView(MVC.VariableTasks.Views.CreateColumn, viewModel);
        }

        public IList<TipoColumna> GetListColumnTypes()
        {
            return new List<TipoColumna>()
            {
                //new TipoColumna() { Codigo = null, Descripcion = "Seleccione una opcion" },
                new TipoColumna() { Codigo = 1, Descripcion = "Numero" },
                new TipoColumna() { Codigo = 2, Descripcion = "Texto" },
                new TipoColumna() { Codigo = 3, Descripcion = "Fecha" }
            };
        }

    }

    public class TipoColumna
    {
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
    }

}