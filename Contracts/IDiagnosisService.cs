using MedicalBilling.Models.DiagnosisModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IDiagnosisService
    {
        void CreateDiagnosis(DiagnosisCreate model);
        IEnumerable<DiagnosisDetail> GetAllDiagnoses();
        DiagnosisDetail GetDiagnosisById(int diagnosisId);
        bool UpdateDiagnosis(DiagnosisDetail detail);
        bool RemoveDiagnosis(int diagnosisId);
    }
}
