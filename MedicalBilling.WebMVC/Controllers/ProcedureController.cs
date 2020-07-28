using MedicalBilling.Data;
using MedicalBilling.Data.Entities;
using MedicalBilling.Models.ProcedureModel;
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
    public class ProcedureController : Controller
    {
        private ApplicationDbContext _ctx = new ApplicationDbContext();

        // GET: Procedure
        [HttpGet]
        public ActionResult Index(string search)
        {
            var service = new ProcedureService();
            var model = service.GetProcedures();
            if (!String.IsNullOrEmpty(search))
            {
                model = model.Where(s => s.Name.Contains(search));
            }
            return View(model);
        }


        //Create Procedure
        [Authorize(Roles ="Admin")]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ProcedureCreate model)
        {
            var service = new ProcedureService();
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            service.CreateProcedure(model);
            return RedirectToAction("Index");
        }

        // GET Procedure DETAILS/ID
        [HttpGet]
        public ActionResult Details(int id)
        {
            var service = new ProcedureService();
            var model = service.GetProcedureById(id);
            return View(model);
        }


        //EDIT Procedure DETAILS
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            var service = new ProcedureService();
            var detail = service.GetProcedureById(id);
            var model = new ProcedureDetail
            {
                ProcedureId = detail.ProcedureId,
                Name = detail.Name,
                Description = detail.Description,
                Preperation = detail.Preperation,
                Risks = detail.Risks
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Procedure procedure)
        {
            if (ModelState.IsValid)
            {
                _ctx.Entry(procedure).State = EntityState.Modified;
                _ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(procedure);
        }

        //DELETE Procedure by ID
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            ProcedureService service = new ProcedureService();
            var model = service.GetProcedureById(id);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        { 
            Procedure procedure = _ctx.Procedures.Find(id);
           if(procedure != null) _ctx.Procedures.Remove(procedure);
            _ctx.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}