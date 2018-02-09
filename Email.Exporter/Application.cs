using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Email.Exporter
{

    public class ApplicantData
    {
        public Director[] Directors { get; set; }
        public Companydetail[] CompanyDetails { get; set; }
        public Productsselected[] ProductsSelected { get; set; }
        public Product[] Products { get; set; }
    }

    public class Director
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

    public class Companydetail
    {
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string URL { get; set; }
        public string PhysicalAddress { get; set; }
        public string PostalAddress { get; set; }
    }

    public class Productsselected
    {
        public bool CompanyRegistration { get; set; }
        public bool Taxclearancecertificate { get; set; }
        public bool logo { get; set; }
        public bool Letterhead { get; set; }
        public bool Businesscard { get; set; }
        public bool Businessprofile { get; set; }
        public bool website { get; set; }
    }

    public class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }
    }

}
