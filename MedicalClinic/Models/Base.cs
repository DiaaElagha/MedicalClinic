using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalClinic.Models
{
    public class Base
    {
        [Key]
        public int Id { get; set; }

        [ScaffoldColumn(false)]
        public DateTime CreatedAt { get; set; }
        [ScaffoldColumn(false)]
        public string CreatedBy { get; set; }
        [ScaffoldColumn(false)]
        public DateTime UpdatedAt { get; set; }
        [ScaffoldColumn(false)]
        public string UpdatedBy { get; set; }
    }
}
