using MedicalBilling.Data;
using MedicalBilling.Data.Entities;
using MedicalBilling.Models.DiagnosticCodeModels;
using MedicalBilling.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MedicalBilling.WebMVC.Controllers
{
    public class DiagnosisCodeController : Controller
    {
        private ApplicationDbContext _ctx = new ApplicationDbContext();

        // GET: DiagnosisCode
        public ActionResult Index()
        {
            var service = new DiagnosticCodeService();
            var model = service.GetDiagnosticCodes();
            return View(model);
        }

        [Authorize(Roles ="admin")]
        //CREATE diagnosisCode
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(DiagnosticCodeCreate model)
        {
            var service = new DiagnosticCodeService();
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            service.CreateDiagnosisCode(model);
            return View(model);
        }

        // GET DIAGNOSTIC CODE DETAILS/ID
        public ActionResult Details(int id)
        {
            DiagnosticCodeService service = new DiagnosticCodeService();
            var model = service.GetDiagnosticCodeById(id);
            return View(model);
        }


        //EDIT Diagnostic Code DETAILS
        public ActionResult Edit(int id)
        {
            var service = new DiagnosticCodeService();
            var detail = service.GetDiagnosticCodeById(id);
            var model = new DiagnosticCodeDetail
            {
                DiagnosticCodeId = detail.DiagnosticCodeId,
                ICD10Code = detail.ICD10Code,
                Price = detail.Price,
                DiagnosisId = detail.DiagnosisId
            };
            return View(model);
        }
        [HttpPut]
        public ActionResult Edit(int id, DiagnosticCodeDetail detail)
        {
            if (ModelState.IsValid) return View(detail);
            if(detail.DiagnosticCodeId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(detail);
            }
            var service = new DiagnosticCodeService();
            service.UpdateDiagnosticCode(detail);
            return View(detail);

        }

        //DELETE diagnosticCode by ID
        public ActionResult Delete(int id)
        {
            var service = new DiagnosticCodeService();
            var model = service.GetDiagnosticCodeById(id);
            return View(model);
        }
        [HttpDelete]
        public ActionResult DeleteDiagnoticCode(int id)
        {
            var service = new DiagnosticCodeService();
            service.RemoveDiagnosticCode(id);
            return RedirectToAction("Index");
        }



    }
}