using MedicalBilling.Data;
using MedicalBilling.Data.Entities;
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
            return View();
        }

        //CREATE ProcedureCode
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ProcedureCode procedureCode)
        {
            if (ModelState.IsValid)
            {
                _ctx.ProcedureCodes.Add(procedureCode);
                _ctx.SaveChanges();
            }
            return View(procedureCode);
        }

        // GET ProcedureCode DETAILS/ID
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //FIRST: Find the ProcedureCode by ID
            ProcedureCode procedureCode = _ctx.ProcedureCodes.Find(id);
            if (procedureCode == null)
            {
                return HttpNotFound();
            }
            return View(procedureCode);
        }


        //EDIT ProcedureCode DETAILS
        public ActionResult Edit()
        {
            return View();
        }
        [HttpPut]
        public ActionResult Edit(ProcedureCode procedureCode)
        {
            if (ModelState.IsValid)
            {
                _ctx.Entry(procedureCode).State = System.Data.Entity.EntityState.Modified;
                _ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(procedureCode);
        }

        //DELETE procedureCode by ID
        public ActionResult Delete(int? id)
        {
            return View();
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            ProcedureCode procedureCode = _ctx.ProcedureCodes.Find();
            _ctx.ProcedureCodes.Remove(procedureCode);
            _ctx.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}