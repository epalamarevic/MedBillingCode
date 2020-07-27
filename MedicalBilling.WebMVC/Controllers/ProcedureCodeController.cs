using MedicalBilling.Data;
using MedicalBilling.Data.Entities;
using MedicalBilling.Models.ProcedureCodeModels;
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
    public class ProcedureCodeController : Controller
    {
        private ApplicationDbContext _ctx = new ApplicationDbContext();

        // GET: ProcedureCode
        public ActionResult Index()
        {
            var service = new ProcedureCodeService();
            var model = service.GetProcedureCodes();
            return View(model);
        }
        public ActionResult Index1()
        {
            var service = new ProcedureCodeService();
            var model = service.GetProcedureCodes();
            return View(model);
        }

        [Authorize(Roles ="Admin")]
        //CREATE ProcedureCode
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ProcedureCodeCreate model)
        {
            var service = new ProcedureCodeService();
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            service.CreateProcedureCode(model);
            return RedirectToAction("Index");
        }

        // GET ProcedureCode DETAILS/ID
        public ActionResult Details(int id)
        {
           
            var service = new ProcedureCodeService();
            var model = service.GetProcedureCodeById(id);
            return PartialView("Details", model);
        }


        //EDIT ProcedureCode DETAILS
        public ActionResult Edit(int id)
        {

            var service = new ProcedureCodeService();
            var detail = service.GetProcedureCodeById(id);
            var model = new ProcedureCodeDetail
            {
                ProcedureCodeId = detail.ProcedureCodeId,
                ICD10Code = detail.ICD10Code,
                Price = detail.Price,
                ProcedureId = detail.ProcedureId
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(ProcedureCode procedureCode)
        {
            if (ModelState.IsValid)
            {
                _ctx.Entry(procedureCode).State = EntityState.Modified;
                _ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(procedureCode);
        }

        //DELETE procedureCode by ID
        public ActionResult Delete(int id)
        {
            var service = new ProcedureCodeService();
            var model = service.GetProcedureCodeById(id);
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProcedureCode(int id)
        {
            ProcedureCode procedureCode = _ctx.ProcedureCodes.Find(id);
            if (procedureCode != null) _ctx.ProcedureCodes.Remove(procedureCode);
            _ctx.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}