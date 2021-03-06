﻿using Contracts;
using MedicalBilling.Data;
using MedicalBilling.Data.Entities;
using MedicalBilling.Models.DiagnosisModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalBilling.Services
{
   public class DiagnosisService : IDiagnosisService

    {
        private readonly ApplicationDbContext _ctx = new ApplicationDbContext();

        //CREATE
        //Create a Diagnosis
        public void CreateDiagnosis(DiagnosisCreate model)
        {
            var entity = new Diagnosis()
            {
                Name = model.Name,
                Description = model.Description,
                Symptoms = model.Symptoms,
                Treatments = model.Treatments
            };
            _ctx.Diagnoses.Add(entity);
            _ctx.SaveChanges();
        }

        //READ
        //Get All Diagnoses
        public IEnumerable<DiagnosisDetail> GetAllDiagnoses()
        {
            var diagnosisEntities = _ctx.Diagnoses.ToList();
            var diagnosisList = diagnosisEntities.Select(d => new DiagnosisDetail
            {
                DiagnosisId = d.DiagnosisId,
                Name = d.Name,
                Description = d.Description
            });
            return diagnosisList;
        }

        //Get Diagnosis by Id
        public DiagnosisDetail GetDiagnosisById(int diagnosisId)
        {
            var diagnosisEntity = _ctx.Diagnoses.Single(e => e.DiagnosisId == diagnosisId);
            return new DiagnosisDetail
            {
                DiagnosisId = diagnosisEntity.DiagnosisId,
                Name = diagnosisEntity.Name,
                Description = diagnosisEntity.Description,
                Symptoms = diagnosisEntity.Symptoms,
                Treatments = diagnosisEntity.Treatments
            };
           
        }
        
        //UPDATE
        //Update Diagnosis By Id
        public bool UpdateDiagnosis (DiagnosisDetail detail)
        {
            var entity = _ctx.Diagnoses.Single(e => e.DiagnosisId == detail.DiagnosisId);
            entity.Name = detail.Name;
            entity.Description = detail.Description;
            entity.Symptoms = detail.Symptoms;
            entity.Treatments = detail.Treatments;
           return _ctx.SaveChanges() == 1;
        }

        //DELETE
        //Remove Diagnosis by Id
        public bool RemoveDiagnosis(int diagnosisId)
        {
            var entity = _ctx.Diagnoses.Single(e => e.DiagnosisId == diagnosisId);
            _ctx.Diagnoses.Remove(entity);
            return _ctx.SaveChanges() == 1;
        }

    }
}
