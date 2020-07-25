using MedicalBilling.Data;
using MedicalBilling.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MedicalBilling.WebMVC.Controllers
{
    public class ICD10CodesController : Controller
    {
        private ApplicationDbContext _ctx = new ApplicationDbContext();

        // GET: ICD10Codes
        public ActionResult Index()
        {
            return View();
        }
    }
}