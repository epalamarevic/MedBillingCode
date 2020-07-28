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
    public class ProcedureCode
    {
        [Key]
        public int ProcedureCodeId { get; set; }
        public string Name { get; set; }
        public string ICD10Code { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        [DisplayName("Price")]
        public decimal Price { get; set; }

        [ForeignKey("Procedure")]
        public int ProcedureId { get; set; }
        public virtual Procedure Procedure { get; set; }
        
    }
}
