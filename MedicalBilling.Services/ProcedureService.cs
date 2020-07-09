using MedicalBilling.Data;
using MedicalBilling.Data.Entities;
using MedicalBilling.Models.ProcedureModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalBilling.Services
{
    public class ProcedureService
    {
        private readonly ApplicationDbContext _ctx = new ApplicationDbContext();

        //Create a Procedure
        public void CreateProcedure(ProcedureCreate model)
        {
            var entity = new Procedure()
            {
                Name = model.Name,
                Description = model.Description
            };
            _ctx.Procedures.Add(entity);
            _ctx.SaveChanges();
        }


        //Get all Procedures
        public IEnumerable<ProcedureDetail> GetProcedures()
        {
            var procedureEntities = _ctx.Procedures.ToList();
            var procedureList = procedureEntities.Select(p => new ProcedureDetail
            {
                ProcedureId = p.ProcedureId,
                Name = p.Name,
                Description = p.Description
            });
            return procedureList;
        }
        //Get Procedure by Id
        public ProcedureDetail GetProcedureById(int procedureId)
        {
            var procedureEntity = _ctx.Procedures.Find(procedureId);
            var procedureDetail = new ProcedureDetail
            {
                ProcedureId = procedureEntity.ProcedureId,
                Name = procedureEntity.Name,
                Description = procedureEntity.Description
            };
            return procedureDetail;
        }

        //Update Procedure
        public void UpdateProcedure(ProcedureDetail detail)
        {
            var entity = _ctx.Procedures.Single(e => e.ProcedureId == detail.ProcedureId);
            entity.Name = detail.Name;
            entity.Description = detail.Description;
            _ctx.SaveChanges();
        }

        //Remove Procedure by Id
        
        public void RemoveProcedure (int procedureId)
        {
            using(var _ctx = new ApplicationDbContext())
            {
                var entity = _ctx.Procedures.Single(e => e.ProcedureId == procedureId);
                _ctx.Procedures.Remove(entity);
                _ctx.SaveChanges();
            }
        }
        

    }
}
