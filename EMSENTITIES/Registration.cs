using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMSENTITIES
{
    public class Registration
    {
        public int RegistrationID { get; set; }
        public int EventID { get; set; }
        public string RegistrationName { get; set; }
        public string RegistrationEmail { get; set; }
        public DateTime RegistrationDate { get; set; }
        public float RegistrationFee { get; set; }
    }
}
