using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalBilling.Models.ProcedureModel
{
    public class ProcedureDetail
    {
        public int ProcedureId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Preperation { get; set; }
        public string Risks { get; set; }
    }
}
