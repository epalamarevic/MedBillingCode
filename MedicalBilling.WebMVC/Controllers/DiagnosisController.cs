using MedicalBilling.Data;
using MedicalBilling.Data.Entities;
using MedicalBilling.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MedicalBilling.WebMVC.Controllers
{
    public class DiagnosisController : Controller
    {
        private ApplicationDbContext _ctx = new ApplicationDbContext();
       
        // GET: LIST of Diagnosis
        public ActionResult Index()
        {
            return View(_ctx.Diagnoses.ToList());
        }
        
        
        //CREATE diagnosis
        public ActionResult Create()
        {
            return View();
        }
       [HttpPost]
       public ActionResult Create(Diagnosis diagnosis)
        {
            if (ModelState.IsValid)
            {
                _ctx.Diagnoses.Add(diagnosis);
                _ctx.SaveChanges();
            }
            return View(diagnosis);
        }

       // GET DIAGNOSIS DETAILS/ID
       public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //FIRST: Find the diagnosis by ID
            Diagnosis diagnosis = _ctx.Diagnoses.Find(id);
            if(diagnosis == null)
            {
                return HttpNotFound();
            }
            return View(diagnosis);
        }


        //EDIT DIAGNOSIS DETAILS
        public ActionResult Edit()
        {
            return View();
        }
        [HttpPut]
        public ActionResult Edit(Diagnosis diagnosis)
        {
            if (ModelState.IsValid)
            {
                _ctx.Entry(diagnosis).State = System.Data.Entity.EntityState.Modified;
                _ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(diagnosis);
        }

        //DELETE diagnosis by ID
        public ActionResult Delete(int? id)
        {
            return View();
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            Diagnosis diagnosis = _ctx.Diagnoses.Find();
            _ctx.Diagnoses.Remove(diagnosis);
            _ctx.SaveChanges();
            return RedirectToAction("Index");
        }
      
    }
}