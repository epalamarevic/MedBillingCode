using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalBilling.Models.ProcedureCodeModels
{
    public class ProcedureCodeDetail
    {

        public int ProcedureCodeId { get; set; }
        public string ICD10Code { get; set; }
        public decimal Price { get; set; }
        public int ProcedureId { get; set; }
    }
}
