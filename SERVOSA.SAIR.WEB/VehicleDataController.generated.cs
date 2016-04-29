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
    public partial class VehicleDataController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected VehicleDataController(Dummy d) { }

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
        public virtual System.Web.Mvc.ActionResult Data()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Data);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult CabeceraVehiculo()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.CabeceraVehiculo);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult DatosVariableVehiculo()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.DatosVariableVehiculo);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public VehicleDataController Actions { get { return MVC.VehicleData; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "VehicleData";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "VehicleData";
        [GeneratedCode("T4MVC", "2.0")]
        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string Data = "Data";
            public readonly string CabeceraVehiculo = "CabeceraVehiculo";
            public readonly string DatosVariableVehiculo = "DatosVariableVehiculo";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string Data = "Data";
            public const string CabeceraVehiculo = "CabeceraVehiculo";
            public const string DatosVariableVehiculo = "DatosVariableVehiculo";
        }


        static readonly ActionParamsClass_Data s_params_Data = new ActionParamsClass_Data();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Data DataParams { get { return s_params_Data; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Data
        {
            public readonly string vehicleCode = "vehicleCode";
        }
        static readonly ActionParamsClass_CabeceraVehiculo s_params_CabeceraVehiculo = new ActionParamsClass_CabeceraVehiculo();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_CabeceraVehiculo CabeceraVehiculoParams { get { return s_params_CabeceraVehiculo; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_CabeceraVehiculo
        {
            public readonly string vehicleCode = "vehicleCode";
        }
        static readonly ActionParamsClass_DatosVariableVehiculo s_params_DatosVariableVehiculo = new ActionParamsClass_DatosVariableVehiculo();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_DatosVariableVehiculo DatosVariableVehiculoParams { get { return s_params_DatosVariableVehiculo; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_DatosVariableVehiculo
        {
            public readonly string vehicleCode = "vehicleCode";
            public readonly string variableName = "variableName";
            public readonly string model = "model";
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
                public readonly string CabeceraVehiculo = "CabeceraVehiculo";
                public readonly string Data = "Data";
                public readonly string DatosVariableVehiculo = "DatosVariableVehiculo";
            }
            public readonly string CabeceraVehiculo = "~/Views/VehicleData/CabeceraVehiculo.cshtml";
            public readonly string Data = "~/Views/VehicleData/Data.cshtml";
            public readonly string DatosVariableVehiculo = "~/Views/VehicleData/DatosVariableVehiculo.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_VehicleDataController : SERVOSA.SAIR.WEB.Controllers.VehicleDataController
    {
        public T4MVC_VehicleDataController() : base(Dummy.Instance) { }

        [NonAction]
        partial void DataOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int vehicleCode);

        [NonAction]
        public override System.Web.Mvc.ActionResult Data(int vehicleCode)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Data);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "vehicleCode", vehicleCode);
            DataOverride(callInfo, vehicleCode);
            return callInfo;
        }

        [NonAction]
        partial void CabeceraVehiculoOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int vehicleCode);

        [NonAction]
        public override System.Web.Mvc.ActionResult CabeceraVehiculo(int vehicleCode)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.CabeceraVehiculo);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "vehicleCode", vehicleCode);
            CabeceraVehiculoOverride(callInfo, vehicleCode);
            return callInfo;
        }

        [NonAction]
        partial void DatosVariableVehiculoOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int vehicleCode, string variableName);

        [NonAction]
        public override System.Web.Mvc.ActionResult DatosVariableVehiculo(int vehicleCode, string variableName)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.DatosVariableVehiculo);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "vehicleCode", vehicleCode);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "variableName", variableName);
            DatosVariableVehiculoOverride(callInfo, vehicleCode, variableName);
            return callInfo;
        }

        [NonAction]
        partial void DatosVariableVehiculoOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, SERVOSA.SAIR.WEB.Controllers.TempHeadModel model);

        [NonAction]
        public override System.Web.Mvc.ActionResult DatosVariableVehiculo(SERVOSA.SAIR.WEB.Controllers.TempHeadModel model)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.DatosVariableVehiculo);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "model", model);
            DatosVariableVehiculoOverride(callInfo, model);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591, 3008, 3009, 0108, 0114