using MedicalBilling.Data;
using MedicalBilling.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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
            return View();
        }

        //CREATE diagnosisCode
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(DiagnosticCode diagnosisCode)
        {
            if (ModelState.IsValid)
            {
                _ctx.DiagnosticCodes.Add(diagnosisCode);
                _ctx.SaveChanges();
            }
            return View(diagnosisCode);
        }

        // GET DIAGNOSTIC CODE DETAILS/ID
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //FIRST: Find the diagnostic Code by ID
            DiagnosticCode diagnosticCode = _ctx.DiagnosticCodes.Find(id);
            if (diagnosticCode == null)
            {
                return HttpNotFound();
            }
            return View(diagnosticCode);
        }


        //EDIT Diagnostic Code DETAILS
        public ActionResult Edit()
        {
            return View();
        }
        [HttpPut]
        public ActionResult Edit(DiagnosticCode diagnosticCode)
        {
            if (ModelState.IsValid)
            {
                _ctx.Entry(diagnosticCode).State = System.Data.Entity.EntityState.Modified;
                _ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(diagnosticCode);
        }

        //DELETE diagnosticCode by ID
        public ActionResult Delete(int? id)
        {
            return View();
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            DiagnosticCode diagnostic = _ctx.DiagnosticCodes.Find(id);
            _ctx.DiagnosticCodes.Remove(diagnostic);
            _ctx.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}