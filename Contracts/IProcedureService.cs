using MedicalBilling.Models.ProcedureModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IProcedureService
    {
        void CreateProcedure(ProcedureCreate model);
        IEnumerable<ProcedureDetail> GetProcedures();
        ProcedureDetail GetProcedureById(int procedureId);
        bool UpdateProcedure(ProcedureDetail detail);
        bool RemoveProcedure(int procedureId);
    }
}
