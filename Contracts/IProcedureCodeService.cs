using MedicalBilling.Models.ProcedureCodeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IProcedureCodeService
    {
        void CreateProcedureCode(ProcedureCodeCreate model);
        IEnumerable<ProcedureCodeDetail> GetProcedureCodes();
        ProcedureCodeDetail GetProcedureCodeById(int procedureCodeId);
        void UpdateProcedureCode(ProcedureCodeDetail detail);
        void RemoveProcedureCode(int procedureCodeId);
    }
}
