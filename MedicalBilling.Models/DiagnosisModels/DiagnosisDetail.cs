using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalBilling.Models.DiagnosisModels
{
    public class DiagnosisDetail
    {
        public int DiagnosisId { get; set; }

        public string Name { get; set; }
       
        public string Description { get; set; }

        public string Symptoms { get; set; }
        public string Treatments { get; set; }

        
    }
}
