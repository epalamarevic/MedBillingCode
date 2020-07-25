using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalBilling.Data.Entities
{
    public class ProcedureCode
    {
        [Key]
        public int ProcedureCodeId { get; set; }
        public string ICD10Code { get; set; }
        public decimal Price { get; set; }

        [ForeignKey("Procedure")]
        public int ProcedureId { get; set; }
        public virtual Procedure Procedure { get; set; }
        
    }
}
