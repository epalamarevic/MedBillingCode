using MedicalBilling.Data;
using MedicalBilling.Data.Entities;
using MedicalBilling.Models.ProcedureModel;
using MedicalBilling.Services;
using System;
using System.Collections.Generic;
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
        public ActionResult Index()
        {
            var service = new ProcedureService();
            var model = service.GetProcedures();
            return View(model);
        }

        [Authorize(Roles ="Admin")]
        //CREATE Procedure
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
        public ActionResult Details(int id)
        {
            var service = new ProcedureService();
            var model = service.GetProcedureById(id);
            return View(model);
        }


        //EDIT Procedure DETAILS
        public ActionResult Edit(int id)
        {
            var service = new ProcedureService();
            var detail = service.GetProcedureById(id);
            var model = new ProcedureDetail
            {
                ProcedureId = detail.ProcedureId,
                Name = detail.Name,
                Description = detail.Description
            };
            return View(model);
        }
        [HttpPut]
        public ActionResult Edit(int id, ProcedureDetail detail)
        {
            if (ModelState.IsValid) return View(detail);

            if (detail.ProcedureId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(detail);
            }
            var service = new ProcedureService();
            service.UpdateProcedure(detail);
            return View(detail);
        }

        //DELETE Procedure by ID
        public ActionResult Delete(int id)
        {
            var service = new ProcedureService();
            var model = service.GetProcedureById(id);
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProcedure(int id)
        {
            ProcedureService service = new ProcedureService();
            service.RemoveProcedure(id);
            return RedirectToAction("Index");
        }

    }
}