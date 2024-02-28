using EMSDAL;
using EMSENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMSBLL
{
    public class RegistrationService
    {
        private RegistrationRepo rr;
        public RegistrationService()
        {
            rr = new RegistrationRepo();
        }
        public List<Registration> GetRegistrations()
        {
            return rr.GetRegistrations();
        }
        public Registration GetRegistrationById(int registrationID)
        {
            return rr.GetRegistrationById(registrationID);
        }

        public bool AddRegistration(Registration registration)
        {
            return rr.CreateRegistration(registration);
        }

        public bool UpdateRegistration(Registration registration)
        {
            return rr.UpdateRegistration(registration);
        }

        public bool DeleteRegistration(int registrationID)
        {
            return rr.DeleteRegistration(registrationID);
        }
    }
}
