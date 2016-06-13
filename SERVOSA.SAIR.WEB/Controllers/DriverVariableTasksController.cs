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
    public partial class DriverVariableTasksController : Controller
    {
        private readonly IDriverDBServices _dbService;

        public DriverVariableTasksController(IDriverDBServices  injectedDbService)
        {
            _dbService = injectedDbService;
        }

        [HttpGet]
        public virtual ActionResult DriverCreateTable()
        {
            DriverTableServiceModel model = new DriverTableServiceModel();
            return PartialView(MVC.DriverVariableTasks.Views.DriverCreateTable, model);
        }

        [HttpPost]
        public virtual ActionResult DriverCreateTable(DriverTableServiceModel viewModel)
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

            return PartialView(MVC.DriverVariableTasks.Views.DriverCreateTable, viewModel);
        }

        [HttpGet]
        public virtual ActionResult DriverCreateColumn()
        {
            DriverColumnServiceModel viewModel = new DriverColumnServiceModel();
            viewModel.ListaTipos = new SelectList(GetListColumnTypes(), "Codigo", "Descripcion");
            return PartialView(MVC.DriverVariableTasks.Views.DriverCreateColumn, viewModel);
        }

        [HttpPost]
        public virtual ActionResult DriverCreateColumn(DriverColumnServiceModel viewModel)
        {
            viewModel.ListaTipos = new SelectList(GetListColumnTypes(), "Codigo", "Descripcion");
            if (ModelState.IsValid)
            {
                var resultCreation = _dbService.CreateColumn(viewModel);

                viewModel.IsSuccessful = !String.IsNullOrWhiteSpace(resultCreation.Item2.ColumnNormalizedName);
                viewModel.ColumnNormalizedName = resultCreation.Item2.ColumnNormalizedName;
                viewModel.Message = viewModel.IsSuccessful ? "Se creo correctamente la columna" : "No se pudo crear la columna.";
            }
            else
            {
                viewModel.IsSuccessful = false;
                viewModel.Message = "Por favor revise los campos requeridos.";
            }

            return PartialView(MVC.DriverVariableTasks.Views.DriverCreateColumn, viewModel);
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