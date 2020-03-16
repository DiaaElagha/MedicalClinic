using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalClinic.Models.Dto
{
    public class APIResponse
    {
        public Boolean Status { get; set; }
        public Object Message { get; set; }
        public Object Data { get; set; }
        public int HttpResponse { get; set; }
    }
}
