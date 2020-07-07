using MedicalBilling.Data;
using MedicalBilling.Data.Entities;
using MedicalBilling.Models.ProcedureCodeModels;
using MedicalBilling.Services;
using System;
using System.Collections.Generic;
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

        [Authorize(Roles ="admin")]
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
            return View(model);
        }

        // GET ProcedureCode DETAILS/ID
        public ActionResult Details(int id)
        {
            var service = new ProcedureCodeService();
            var model = service.GetProcedureCodeById(id);
            return View(model);
        }


        //EDIT ProcedureCode DETAILS
        public ActionResult Edit(int id)
        {

            var service = new ProcedureCodeService();
            var detail = service.GetProcedureCodeById(id);
            var model = new ProcedureCodeDetail
            {
                Name = detail.Name,
                ProcedureCodeId = detail.ProcedureCodeId,
                ICD10Code = detail.ICD10Code,
                Price = detail.Price,
                ProcedureId = detail.ProcedureId
            };
            return View(model);
        }
        [HttpPut]
        public ActionResult Edit(int id, ProcedureCodeDetail detail)
        {
            if (ModelState.IsValid) return View(detail);
            if (detail.ProcedureCodeId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(detail);
            }
            var service = new ProcedureCodeService();
            service.UpdateProcedureCode(detail);
            return View(detail);
        }

        //DELETE procedureCode by ID
        public ActionResult Delete(int id)
        {
            var service = new ProcedureCodeService();
            var model = service.GetProcedureCodeById(id);
            return View(model);
        }
        [HttpDelete]
        public ActionResult DeleteProcedureCode(int id)
        {
            var service = new ProcedureCodeService();
            service.RemoveProcedureCode(id);
            return RedirectToAction("Index");
        }

    }
}