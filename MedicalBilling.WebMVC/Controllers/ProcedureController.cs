using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MedicalBilling.WebMVC.Controllers
{
    public class ProcedureController : Controller
    {
        // GET: LIST of Procedure
        public ActionResult Index()
        {
            return View();
        }
    }
}