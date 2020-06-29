using MedicalBilling.Data;
using MedicalBilling.Data.Entities;
using MedicalBilling.Models.ProcedureCodeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalBilling.Services
{
    public class ProcedureCodeService
    {
        private readonly ApplicationDbContext _ctx = new ApplicationDbContext();

        //Create ProcedureCode
        public void CreateProcedureCode(ProcedureCodeCreate model)
        {
            var entity = new ProcedureCode()
            {
                ICD10Code = model.ICD10Code,
                Price = model.Price,
                ProcedureId = model.ProcedureId
            };
            _ctx.ProcedureCodes.Add(entity);
            _ctx.SaveChanges();
        }

        //Get list of All ProcedureCodes
        public IEnumerable<ProcedureCodeDetail> GetProcedureCodes()
        {
            var procedureCodeEntities = _ctx.ProcedureCodes.ToList();
            var procedureCodeList = procedureCodeEntities.Select(pc => new ProcedureCodeDetail
            {
                ProcedureCodeId = pc.ProcedureCodeId,
                ICD10Code = pc.ICD10Code,
                Price = pc.Price,
                ProcedureId = pc.ProcedureId
            });
            return procedureCodeList;
        }

        //Get ProcedureCode by Id
        public ProcedureCodeDetail GetProcedureCodeById(int procedureCodeId)
        {
            var procedureCodeEntity = _ctx.ProcedureCodes.Find(procedureCodeId);
            var procedureCodeDetails = new ProcedureCodeDetail
            {
                ProcedureCodeId = procedureCodeEntity.ProcedureCodeId,
                ICD10Code = procedureCodeEntity.ICD10Code,
                Price = procedureCodeEntity.Price,
                ProcedureId = procedureCodeEntity.ProcedureId,
            };
            return procedureCodeDetails;
        }
        //Update ProcedureCode
        public void UpdateProcedureCode(ProcedureCodeDetail detail)
        {
            var entity = _ctx.ProcedureCodes.Single(e => e.ProcedureCodeId == detail.ProcedureCodeId);
            entity.ICD10Code = detail.ICD10Code;
            entity.Price = detail.Price;
            _ctx.SaveChanges();
        }

        //Remove DiagnosticCode by Id
        public void RemoveProcedureCode(int procedureCodeId)
        {
            var entity = _ctx.ProcedureCodes.Single(e => e.ProcedureCodeId == procedureCodeId);
            _ctx.SaveChanges();
        }
    }
}
