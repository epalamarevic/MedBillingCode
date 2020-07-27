using MedicalBilling.Data;
using MedicalBilling.Data.Entities;
using MedicalBilling.Models.DiagnosisModels;
using MedicalBilling.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MedicalBilling.WebMVC.Controllers
{

    public class DiagnosisController : Controller
    {
        private ApplicationDbContext _ctx = new ApplicationDbContext();

        // GET: LIST of Diagnosis
        [HttpGet]
        public ActionResult Index(string search)
        {
            var service = new DiagnosisService();
            var model = service.GetAllDiagnoses();
            if (!String.IsNullOrEmpty(search))
            {
                model = model.Where(s => s.Name.Contains(search));
            }
            return View(model);
        }



        //CREATE diagnosis
        [Authorize(Roles ="Admin")]
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
            return RedirectToAction("Index");

        }

        // GET DIAGNOSIS DETAILS/ID
        [HttpGet]
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
                Description = detail.Description,
                Symptoms = detail.Symptoms,
                Treatments = detail.Treatments
               
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Diagnosis diagnosis)
        {
            if (ModelState.IsValid)
            {
                _ctx.Entry(diagnosis).State = EntityState.Modified;
                _ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(diagnosis);
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