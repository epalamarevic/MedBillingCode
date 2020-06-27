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
    public class ProcedureController : Controller
    {
        private ApplicationDbContext _ctx = new ApplicationDbContext();

        // GET: LIST of Procedure
        public ActionResult Index()
        {
            return View();
        }


        //CREATE Procedure
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Procedure procedure)
        {
            if (ModelState.IsValid)
            {
                _ctx.Procedures.Add(procedure);
                _ctx.SaveChanges();
            }
            return View(procedure);
        }

        // GET Procedure DETAILS/ID
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //FIRST: Find the procedure by ID
            Procedure procedure = _ctx.Procedures.Find(id);
            if (procedure == null)
            {
                return HttpNotFound();
            }
            return View(procedure);
        }


        //EDIT Procedure DETAILS
        public ActionResult Edit()
        {
            return View();
        }
        [HttpPut]
        public ActionResult Edit(Procedure procedure)
        {
            if (ModelState.IsValid)
            {
                _ctx.Entry(procedure).State = System.Data.Entity.EntityState.Modified;
                _ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(procedure);
        }

        //DELETE Procedure by ID
        public ActionResult Delete(int? id)
        {
            return View();
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            Procedure procedure = _ctx.Procedures.Find();
            _ctx.Procedures.Remove(procedure);
            _ctx.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}