using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalBilling.Data.Entities
{
    public class DiagnosticCode
    {   
        [Key]
        public int DiagnosticCodeId { get; set; }
        public string Name { get; set; }
        public string ICD10Code { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        [DisplayName("Price")]
        public decimal Price { get; set; }

        [ForeignKey("Diagnosis")]
        public int DiagnosisId { get; set; }
        public virtual Diagnosis Diagnosis { get; set; }
    }
}
