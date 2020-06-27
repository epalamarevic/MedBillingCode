using MedicalBilling.Data;
using MedicalBilling.Data.Entities;
using MedicalBilling.Models.DiagnosisModels;
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
            var service = new DiagnosisService();
            var model = service.GetAllDiagnoses();
            return View(model);
        }
        
        
        //CREATE diagnosis
        public ActionResult Create()
        {
            return View();
        }
       [HttpPost]
       public ActionResult Create(DiagnosisCreate model)
        {
            DiagnosisService service = new DiagnosisService();
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            service.CreateDiagnosis(model);
                return View(model);
           
        }

       // GET DIAGNOSIS DETAILS/ID
       public ActionResult Details(int id)
        {
            DiagnosisService service = new DiagnosisService();
            var model = service.GetDiagnosisById(id);
            return View(model);
        }


        //EDIT DIAGNOSIS 
        public ActionResult Edit(int id)
        {
            DiagnosisService service = new DiagnosisService();
            var detail = service.GetDiagnosisById(id);
            var model = new DiagnosisDetail
            {
                DiagnosisId = detail.DiagnosisId,
                Name = detail.Name,
                Description = detail.Description
            };
            return View(model);
        }
        [HttpPut]
        public ActionResult Edit(int id, DiagnosisDetail detail)
        {
            if (ModelState.IsValid) return View(detail);

            if(detail.DiagnosisId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(detail);
            }
            DiagnosisService service = new DiagnosisService();
            service.UpdateDiagnosis(detail);
            return View(detail);
        }

        //DELETE diagnosis by ID
        public ActionResult Delete(int id)
        {
            DiagnosisService service = new DiagnosisService();
            var model = service.GetDiagnosisById(id);
            return View(model);
        }
        [HttpDelete]
        public ActionResult DeleteDiagnosis(int id)
        {
            DiagnosisService service = new DiagnosisService();
            service.RemoveDiagnosis(id);
            return RedirectToAction("Index");
        }
      
    }
}