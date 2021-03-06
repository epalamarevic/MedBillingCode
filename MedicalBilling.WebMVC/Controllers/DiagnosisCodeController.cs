﻿using MedicalBilling.Data;
using MedicalBilling.Data.Entities;
using MedicalBilling.Models.DiagnosticCodeModels;
using MedicalBilling.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        [HttpGet]
        public ActionResult Index()
        {
            var service = new DiagnosticCodeService();
            var model = service.GetDiagnosticCodes();
            return View(model);
        }
        //Get DiagnosisCode List and Search
        [HttpGet]
        public ActionResult Index1(string search)
        {
            var service = new DiagnosticCodeService();
            var model = service.GetDiagnosticCodes();
            if (!String.IsNullOrEmpty(search))
            {
                model = model.Where(s => s.ICD10Code.Contains(search));
            }
            return View(model);
        }


        //Create DiagnosticCode
        [Authorize(Roles ="Admin")]
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
            return RedirectToAction("Index");
        }

        // GET DIAGNOSTIC CODE DETAILS/ID
        public ActionResult Details(int id)
        {
            DiagnosticCodeService service = new DiagnosticCodeService();
            var model = service.GetDiagnosticCodeById(id);
            return PartialView("Details", model);
        }


        //EDIT Diagnostic Code DETAILS
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            var service = new DiagnosticCodeService();
            var detail = service.GetDiagnosticCodeById(id);
            var model = new DiagnosticCodeDetail
            {
                DiagnosticCodeId = detail.DiagnosticCodeId,
                Name = detail.Name,
                ICD10Code = detail.ICD10Code,
                Price = detail.Price,
                DiagnosisId = detail.DiagnosisId
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DiagnosticCode diagnosticCode)
        {
            if (ModelState.IsValid)
            {
                _ctx.Entry(diagnosticCode).State = EntityState.Modified;
                _ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(diagnosticCode);

        }

        //DELETE diagnosticCode by ID
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            var service = new DiagnosticCodeService();
            var model = service.GetDiagnosticCodeById(id);
            return View(model);
        }
        [HttpDelete]
        public ActionResult DeleteDiagnoticCode(int id)
        {
            DiagnosticCode diagnosticCode = _ctx.DiagnosticCodes.Find(id);
            if (diagnosticCode != null) _ctx.DiagnosticCodes.Remove(diagnosticCode);
            _ctx.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}