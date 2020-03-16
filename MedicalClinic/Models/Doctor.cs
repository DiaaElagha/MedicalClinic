using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalClinic.Models
{
    public class Doctor : Base
    {
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "اسم الدكتور")]
        public String FullName { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "رقم الموبايل")]
        public String Phone { get; set; }

        [Display(Name = "عنوان المهنة")]
        public String TitleJob { get; set; }

        [Display(Name = "جامعة التخرح")]
        public String StudyUniversity { get; set; }

        [Display(Name = "سنوات الخبرة")]
        public int? YearsExperience { get; set; }

        [Display(Name = "معلومات عامة")]
        public String Information { get; set; }

        [Display(Name = "العنوان")]
        public String Address { get; set; }
    }
}
