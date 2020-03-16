using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalClinic.Models
{
    public class DoctorDays : Base
    {
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "اليوم")]
        public DayOfWeek Day { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "اسم الدكتور")]
        public int DoctorId { get; set; }
        [ForeignKey("DoctorId")]
        public Doctor Doctor { get; set; }
    }
}
