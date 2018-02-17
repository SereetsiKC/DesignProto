using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reports
{

    public class Application
    {
        public List<DDirector> director { get; set; }
        public CompanyDetails companyDetail { get; set; }
    }
    public class CompanyDetails
    {
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public string Name3 { get; set; }
        public string Name4 { get; set; }
        public string EmailAddress { get; set; }
        public string URL { get; set; }
        public string PhysicalAddress { get; set; }
        public string PostalAddress { get; set; }
    }

    public class DDirector
    {
        public int DrectorNo { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Cell { get; set; }
        public string Email { get; set; }
        public string IDNumber { get; set; }
        public string PhysicalAddress { get; set; }
        public string PostalAddress { get; set; }
    }
}
