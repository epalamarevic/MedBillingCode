using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalBilling.Models.DiagnosticCodeModels
{
    public class DiagnosticCodeCreate
    {
        public string Name { get; set; }
        public string ICD10Code { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        [DisplayName("Price")]
        public decimal Price { get; set; }
        public int DiagnosisId { get; set; }
    }
}
