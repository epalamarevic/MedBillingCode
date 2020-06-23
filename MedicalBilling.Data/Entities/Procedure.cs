using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalBilling.Data.Entities
{
    public class Procedure
    {   
        [Key]
        public int ProcedureId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
