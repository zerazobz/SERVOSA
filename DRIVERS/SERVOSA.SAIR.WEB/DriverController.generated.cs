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
    public partial class DriverController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected DriverController(Dummy d) { }

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

        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult DriverDataTable()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.DriverDataTable);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.JsonResult DeleteDriver()
        {
            return new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.DeleteDriver);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.JsonResult UpdateDriver()
        {
            return new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.UpdateDriver);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.JsonResult CreateDriver()
        {
            return new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.CreateDriver);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult UploadFile()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.UploadFile);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public DriverController Actions { get { return MVC.Driver; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Driver";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "Driver";
        [GeneratedCode("T4MVC", "2.0")]
        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string Index = "Index";
            public readonly string DriversMainData = "DriversMainData";
            public readonly string DriversTable = "DriversTable";
            public readonly string DriverDataTable = "DriverDataTable";
            public readonly string ListDrivers = "ListDrivers";
            public readonly string DeleteDriver = "DeleteDriver";
            public readonly string UpdateDriver = "UpdateDriver";
            public readonly string CreateDriver = "CreateDriver";
            public readonly string UploadFile = "UploadFile";
            public readonly string LoadFiles = "LoadFiles";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string Index = "Index";
            public const string DriversMainData = "DriversMainData";
            public const string DriversTable = "DriversTable";
            public const string DriverDataTable = "DriverDataTable";
            public const string ListDrivers = "ListDrivers";
            public const string DeleteDriver = "DeleteDriver";
            public const string UpdateDriver = "UpdateDriver";
            public const string CreateDriver = "CreateDriver";
            public const string UploadFile = "UploadFile";
            public const string LoadFiles = "LoadFiles";
        }


        static readonly ActionParamsClass_DriverDataTable s_params_DriverDataTable = new ActionParamsClass_DriverDataTable();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_DriverDataTable DriverDataTableParams { get { return s_params_DriverDataTable; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_DriverDataTable
        {
            public readonly string model = "model";
        }
        static readonly ActionParamsClass_ListDrivers s_params_ListDrivers = new ActionParamsClass_ListDrivers();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_ListDrivers ListDriversParams { get { return s_params_ListDrivers; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_ListDrivers
        {
            public readonly string jtStartIndex = "jtStartIndex";
            public readonly string jtPageSize = "jtPageSize";
            public readonly string jtSorting = "jtSorting";
        }
        static readonly ActionParamsClass_DeleteDriver s_params_DeleteDriver = new ActionParamsClass_DeleteDriver();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_DeleteDriver DeleteDriverParams { get { return s_params_DeleteDriver; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_DeleteDriver
        {
            public readonly string CodigoOperario = "CodigoOperario";
        }
        static readonly ActionParamsClass_UpdateDriver s_params_UpdateDriver = new ActionParamsClass_UpdateDriver();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_UpdateDriver UpdateDriverParams { get { return s_params_UpdateDriver; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_UpdateDriver
        {
            public readonly string model = "model";
        }
        static readonly ActionParamsClass_CreateDriver s_params_CreateDriver = new ActionParamsClass_CreateDriver();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_CreateDriver CreateDriverParams { get { return s_params_CreateDriver; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_CreateDriver
        {
            public readonly string model = "model";
        }
        static readonly ActionParamsClass_UploadFile s_params_UploadFile = new ActionParamsClass_UploadFile();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_UploadFile UploadFileParams { get { return s_params_UploadFile; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_UploadFile
        {
            public readonly string excelFile = "excelFile";
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
                public readonly string DriverDataTable = "DriverDataTable";
                public readonly string DriversMainData = "DriversMainData";
                public readonly string DriversTable = "DriversTable";
                public readonly string Index = "Index";
                public readonly string Operarios = "Operarios";
            }
            public readonly string DriverDataTable = "~/Views/Driver/DriverDataTable.cshtml";
            public readonly string DriversMainData = "~/Views/Driver/DriversMainData.cshtml";
            public readonly string DriversTable = "~/Views/Driver/DriversTable.cshtml";
            public readonly string Index = "~/Views/Driver/Index.cshtml";
            public readonly string Operarios = "~/Views/Driver/Operarios.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_DriverController : SERVOSA.SAIR.WEB.Controllers.DriverController
    {
        public T4MVC_DriverController() : base(Dummy.Instance) { }

        [NonAction]
        partial void IndexOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult Index()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Index);
            IndexOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void DriversMainDataOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult DriversMainData()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.DriversMainData);
            DriversMainDataOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void DriversTableOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult DriversTable()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.DriversTable);
            DriversTableOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void DriverDataTableOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, SERVOSA.SAIR.SERVICE.Models.DriverTableServiceModel model);

        [NonAction]
        public override System.Web.Mvc.ActionResult DriverDataTable(SERVOSA.SAIR.SERVICE.Models.DriverTableServiceModel model)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.DriverDataTable);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "model", model);
            DriverDataTableOverride(callInfo, model);
            return callInfo;
        }

        [NonAction]
        partial void ListDriversOverride(T4MVC_System_Web_Mvc_JsonResult callInfo, int jtStartIndex, int jtPageSize, string jtSorting);

        [NonAction]
        public override System.Web.Mvc.JsonResult ListDrivers(int jtStartIndex, int jtPageSize, string jtSorting)
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.ListDrivers);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "jtStartIndex", jtStartIndex);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "jtPageSize", jtPageSize);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "jtSorting", jtSorting);
            ListDriversOverride(callInfo, jtStartIndex, jtPageSize, jtSorting);
            return callInfo;
        }

        [NonAction]
        partial void DeleteDriverOverride(T4MVC_System_Web_Mvc_JsonResult callInfo, int CodigoOperario);

        [NonAction]
        public override System.Web.Mvc.JsonResult DeleteDriver(int CodigoOperario)
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.DeleteDriver);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "CodigoOperario", CodigoOperario);
            DeleteDriverOverride(callInfo, CodigoOperario);
            return callInfo;
        }

        [NonAction]
        partial void UpdateDriverOverride(T4MVC_System_Web_Mvc_JsonResult callInfo, SERVOSA.SAIR.SERVICE.Models.OldDriverServiceModel model);

        [NonAction]
        public override System.Web.Mvc.JsonResult UpdateDriver(SERVOSA.SAIR.SERVICE.Models.OldDriverServiceModel model)
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.UpdateDriver);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "model", model);
            UpdateDriverOverride(callInfo, model);
            return callInfo;
        }

        [NonAction]
        partial void CreateDriverOverride(T4MVC_System_Web_Mvc_JsonResult callInfo, SERVOSA.SAIR.SERVICE.Models.OldDriverServiceModel model);

        [NonAction]
        public override System.Web.Mvc.JsonResult CreateDriver(SERVOSA.SAIR.SERVICE.Models.OldDriverServiceModel model)
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.CreateDriver);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "model", model);
            CreateDriverOverride(callInfo, model);
            return callInfo;
        }

        [NonAction]
        partial void UploadFileOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, System.Web.HttpPostedFileBase excelFile);

        [NonAction]
        public override System.Web.Mvc.ActionResult UploadFile(System.Web.HttpPostedFileBase excelFile)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.UploadFile);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "excelFile", excelFile);
            UploadFileOverride(callInfo, excelFile);
            return callInfo;
        }

        [NonAction]
        partial void LoadFilesOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult LoadFiles()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.LoadFiles);
            LoadFilesOverride(callInfo);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591, 3008, 3009, 0108, 0114
