using MedicalBilling.Data;
using MedicalBilling.Data.Entities;
using MedicalBilling.Models.DiagnosticCodeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalBilling.Services
{
    public class DiagnosticCodeService
    {
        private readonly ApplicationDbContext _ctx = new ApplicationDbContext();

        //Create DiagnosisCode
        public void CreateDiagnosisCode (DiagnosticCodeCreate model)
        {
            var entity = new DiagnosticCode()
            {
                Name = model.Name,
                ICD10Code = model.ICD10Code,
                Price = model.Price,
                DiagnosisId = model.DiagnosisId
            };
            _ctx.DiagnosticCodes.Add(entity);
            _ctx.SaveChanges();
        }

        //Get list of All DiagnoticCodes
        public IEnumerable<DiagnosticCodeDetail> GetDiagnosticCodes()
        {
            var diagnosticCodeEntities = _ctx.DiagnosticCodes.ToList();
            var diagnositicCodeList = diagnosticCodeEntities.Select(dc => new DiagnosticCodeDetail
            {
                DiagnosticCodeId = dc.DiagnosticCodeId,
                Name =dc.Name,
                ICD10Code = dc.ICD10Code,
                Price = dc.Price,
                DiagnosisId = dc.DiagnosisId
            });
            return diagnositicCodeList;
        }

        //Get DiagnosticCode by Id
        public DiagnosticCodeDetail GetDiagnosticCodeById (int diagnosticCodeId)
        {
            var diagnosticCodeEntity = _ctx.DiagnosticCodes.Find(diagnosticCodeId);
            var diagnosticCodeDetails = new DiagnosticCodeDetail
            {
                DiagnosticCodeId = diagnosticCodeEntity.DiagnosticCodeId,
                ICD10Code = diagnosticCodeEntity.ICD10Code,
                Price = diagnosticCodeEntity.Price,
                DiagnosisId = diagnosticCodeEntity.DiagnosisId,
            };
            return diagnosticCodeDetails;
        }
        //Update DiagnosticCode
        public void UpdateDiagnosticCode (DiagnosticCodeDetail detail)
        {
            var entity = _ctx.DiagnosticCodes.Single(e => e.DiagnosticCodeId == detail.DiagnosticCodeId);
            entity.Name = detail.Name;
            entity.ICD10Code = detail.ICD10Code;
            entity.Price = detail.Price;
            _ctx.SaveChanges();
        }

        //Remove DiagnosticCode by Id
        public void RemoveDiagnosticCode(int diagnosisCodeId)
        {
            var entity = _ctx.DiagnosticCodes.Single(e => e.DiagnosticCodeId == diagnosisCodeId);
            _ctx.SaveChanges();
        }

    }
}
