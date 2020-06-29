using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalBilling.Models.DiagnosisModels
{
    public class DiagnosisCreate
    {
        [Display(Name="Diagnosis Name")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}
