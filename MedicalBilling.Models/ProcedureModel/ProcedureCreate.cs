using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalBilling.Models.ProcedureModel
{
    public class ProcedureCreate
    {
        [Display(Name = "Procedure Name") ]
        public string Name { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}
