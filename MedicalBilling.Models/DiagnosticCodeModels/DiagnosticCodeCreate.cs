using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalBilling.Models.DiagnosticCodeModels
{
    public class DiagnosticCodeCreate
    {
        public string Name { get; set; }
        public string ICD10Code { get; set; }
        public decimal Price { get; set; }
        public int DiagnosisId { get; set; }
    }
}
