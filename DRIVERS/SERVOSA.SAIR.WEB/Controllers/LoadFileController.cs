using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SERVOSA.SAIR.WEB.Controllers
{
    [Authorize]
    public partial class LoadFileController : Controller
    {

        // GET: LoadFile
        public virtual ActionResult Index()
        {
            return View();
        }

    }
}