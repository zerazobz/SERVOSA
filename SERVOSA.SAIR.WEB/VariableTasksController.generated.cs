// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments and CLS compliance
// 0108: suppress "Foo hides inherited member Foo. Use the new keyword if hiding was intended." when a controller and its abstract parent are both processed
// 0114: suppress "Foo.BarController.Baz()' hides inherited member 'Qux.BarController.Baz()'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword." when an action (with an argument) overrides an action in a parent controller
#pragma warning disable 1591, 3008, 3009, 0108, 0114
#region T4MVC

using System;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;
namespace SERVOSA.SAIR.WEB.Controllers
{
    public partial class VariableTasksController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public VariableTasksController() { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected VariableTasksController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(Task<ActionResult> taskResult)
        {
            return RedirectToAction(taskResult.Result);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoutePermanent(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(Task<ActionResult> taskResult)
        {
            return RedirectToActionPermanent(taskResult.Result);
        }


        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public VariableTasksController Actions { get { return MVC.VariableTasks; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "VariableTasks";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "VariableTasks";
        [GeneratedCode("T4MVC", "2.0")]
        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string CreateTable = "CreateTable";
            public readonly string CreateColumn = "CreateColumn";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string CreateTable = "CreateTable";
            public const string CreateColumn = "CreateColumn";
        }


        static readonly ActionParamsClass_CreateTable s_params_CreateTable = new ActionParamsClass_CreateTable();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_CreateTable CreateTableParams { get { return s_params_CreateTable; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_CreateTable
        {
            public readonly string viewModel = "viewModel";
        }
        static readonly ActionParamsClass_CreateColumn s_params_CreateColumn = new ActionParamsClass_CreateColumn();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_CreateColumn CreateColumnParams { get { return s_params_CreateColumn; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_CreateColumn
        {
            public readonly string viewModel = "viewModel";
        }
        static readonly ViewsClass s_views = new ViewsClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewsClass Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewsClass
        {
            static readonly _ViewNamesClass s_ViewNames = new _ViewNamesClass();
            public _ViewNamesClass ViewNames { get { return s_ViewNames; } }
            public class _ViewNamesClass
            {
                public readonly string CreateColumn = "CreateColumn";
                public readonly string CreateTable = "CreateTable";
            }
            public readonly string CreateColumn = "~/Views/VariableTasks/CreateColumn.cshtml";
            public readonly string CreateTable = "~/Views/VariableTasks/CreateTable.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_VariableTasksController : SERVOSA.SAIR.WEB.Controllers.VariableTasksController
    {
        public T4MVC_VariableTasksController() : base(Dummy.Instance) { }

        [NonAction]
        partial void CreateTableOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult CreateTable()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.CreateTable);
            CreateTableOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void CreateTableOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, SERVOSA.SAIR.SERVICE.Models.TableViewModel viewModel);

        [NonAction]
        public override System.Web.Mvc.ActionResult CreateTable(SERVOSA.SAIR.SERVICE.Models.TableViewModel viewModel)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.CreateTable);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "viewModel", viewModel);
            CreateTableOverride(callInfo, viewModel);
            return callInfo;
        }

        [NonAction]
        partial void CreateColumnOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult CreateColumn()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.CreateColumn);
            CreateColumnOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void CreateColumnOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, SERVOSA.SAIR.SERVICE.Models.ColumnViewModel viewModel);

        [NonAction]
        public override System.Web.Mvc.ActionResult CreateColumn(SERVOSA.SAIR.SERVICE.Models.ColumnViewModel viewModel)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.CreateColumn);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "viewModel", viewModel);
            CreateColumnOverride(callInfo, viewModel);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591, 3008, 3009, 0108, 0114
