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
            TableViewModel model = null;
            return View(MVC.VariableTasks.Views.CreateTable, model);
        }

        [HttpPost]
        public virtual ActionResult CreateTable(TableViewModel viewModel)
        {
            return View(MVC.VariableTasks.Views.CreateTable, viewModel);
        }
    }
}