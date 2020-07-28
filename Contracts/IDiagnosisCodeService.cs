using MedicalBilling.Models.DiagnosticCodeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
   public interface IDiagnosisCodeService
    {
        void CreateDiagnosisCode(DiagnosticCodeCreate model);
        IEnumerable<DiagnosticCodeDetail> GetDiagnosticCodes();
        DiagnosticCodeDetail GetDiagnosticCodeById(int diagnosticCodeId);
        void UpdateDiagnosticCode(DiagnosticCodeDetail detail);
        void RemoveDiagnosticCode(int diagnosisCodeId);
    }
}
