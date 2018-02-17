using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using System.Xml;
using System.IO;

namespace Reports
{
    public partial class CompanyReport : DevExpress.XtraReports.UI.XtraReport
    {
        public CompanyReport(ApplicantData _inputs)
        {
            InitializeComponent();

            #region Hide All Directors
            DirectorOne.Visible = false;
            DirectorTwo.Visible = false;
            DirectorThree.Visible = false;
            DirectorFour.Visible = false;
            DirectorFive.Visible = false;
            #endregion Hide All Directors

            #region Directors
            foreach (var _dr in _inputs.Directors)
            {
                switch (_dr.DrectorNo)
                {
                    case 1:
                        {
                            DirectorOne.Visible = true;
                            DirectorOneName.Text = _dr.Name;
                            DirectorOneSurname.Text = _dr.Surname;
                            DirectorOneIDNumber.Text = _dr.IDNumber;
                            DirectorOneEmailAddres.Text = _dr.Email;
                            DirectorOneCellNo.Text = _dr.Cell;
                            DirectorOnePhysicalAddress.Text = _dr.PhysicalAddress;
                            DirectorOnePostalAddress.Text = _dr.PostalAddress;
                            break;
                        }
                    case 2:
                        {
                            DirectorTwo.Visible = true;
                            DirectorTwoName.Text = _dr.Name;
                            DirectorTwoSurname.Text = _dr.Surname;
                            DirectorTwoIDNumber.Text = _dr.IDNumber;
                            DirectorTwoEmailAddres.Text = _dr.Email;
                            DirectorTwoCellNo.Text = _dr.Cell;
                            DirectorTwoPhysicalAddress.Text = _dr.PhysicalAddress;
                            DirectorTwoPostalAddress.Text = _dr.PostalAddress;
                            break;
                        }
                    case 3:
                        {
                            DirectorThree.Visible = true;
                            DirectorThreeName.Text = _dr.Name;
                            DirectorThreeSurname.Text = _dr.Surname;
                            DirectorThreeIDNumber.Text = _dr.IDNumber;
                            DirectorThreeEmailAddres.Text = _dr.Email;
                            DirectorThreeCellNo.Text = _dr.Cell;
                            DirectorThreePhysicalAddress.Text = _dr.PhysicalAddress;
                            DirectorThreePostalAddress.Text = _dr.PostalAddress;
                            break;
                        }
                    case 4:
                        {
                            DirectorFour.Visible = true;
                            DirectorFourName.Text = _dr.Name;
                            DirectorFourSurname.Text = _dr.Surname;
                            DirectorFourIDNumber.Text = _dr.IDNumber;
                            DirectorFourEmailAddres.Text = _dr.Email;
                            DirectorFourCellNo.Text = _dr.Cell;
                            DirectorFourPhysicalAddress.Text = _dr.PhysicalAddress;
                            DirectorFourPostalAddress.Text = _dr.PostalAddress;
                            break;
                        }
                    case 5:
                        {
                            DirectorFive.Visible = true;
                            DirectorFiveName.Text = _dr.Name;
                            DirectorFiveSurname.Text = _dr.Surname;
                            DirectorFiveIDNumber.Text = _dr.IDNumber;
                            DirectorFiveEmailAddres.Text = _dr.Email;
                            DirectorFiveCellNo.Text = _dr.Cell;
                            DirectorFivePhysicalAddress.Text = _dr.PhysicalAddress;
                            DirectorFivePostalAddress.Text = _dr.PostalAddress;
                            break;
                        }
                }
            }
            #endregion Directors

            #region CompanyDetails
            foreach(var _company in _inputs.CompanyDetails)
            {
                NameOne.Text = _company.Name1;
                NameTwo.Text = _company.Name2;
                NameThree.Text = _company.Name3;
                NameFour.Text = _company.Name4;
                EmailAddress.Text = _company.EmailAddress;
                URL.Text = _company.URL;
                PhysicalAddress.Text = _company.PhysicalAddress;
                PostalAddress.Text = _company.PostalAddress;
            }
            #endregion CompanyDetails

            #region Products Selected
            decimal total = 0;
            foreach (var _product in _inputs.ProductsSelected)
            {
                if (_product.CompanyRegistration)
                {
                    CompanyRegistrationYes.Visible = true;
                    CompanyRegistrationNo.Visible = false;
                    foreach(var _price in _inputs.Products)
                    {
                        if(_price.Name == "CompanyRegistration")
                        {
                            total = total + _price.Price;
                        }
                    }
                }
                else
                {
                    CompanyRegistrationYes.Visible = false;
                    CompanyRegistrationNo.Visible = true;
                }

                if (_product.Taxclearancecertificate)
                {
                    TaxclearancecertificateYes.Visible = true;
                    TaxclearancecertificateNo.Visible = false;
                    foreach (var _price in _inputs.Products)
                    {
                        if (_price.Name == "Taxclearancecertificate")
                        {
                            total = total + _price.Price;
                        }
                    }
                }
                else
                {
                    TaxclearancecertificateYes.Visible = false;
                    TaxclearancecertificateNo.Visible = true;
                }

                if (_product.website)
                {
                    websiteYes.Visible = true;
                    websiteNo.Visible = false;
                    foreach (var _price in _inputs.Products)
                    {
                        if (_price.Name == "website")
                        {
                            total = total + _price.Price;
                        }
                    }
                }
                else
                {
                    websiteYes.Visible = false;
                    websiteNo.Visible = true;
                }

                if (_product.logo)
                {
                    logoYes.Visible = true;
                    logoNo.Visible = false;
                    foreach (var _price in _inputs.Products)
                    {
                        if (_price.Name == "logo")
                        {
                            total = total + _price.Price;
                        }
                    }
                }
                else
                {
                    logoYes.Visible = false;
                    logoNo.Visible = true;
                }

                if (_product.Letterhead)
                {
                    LetterheadYes.Visible = true;
                    LetterheadNo.Visible = false;
                    foreach (var _price in _inputs.Products)
                    {
                        if (_price.Name == "Letterhead")
                        {
                            total = total + _price.Price;
                        }
                    }
                }
                else
                {
                    LetterheadYes.Visible = false;
                    LetterheadNo.Visible = true;
                }

                if (_product.Businesscard)
                {
                    BusinesscardYes.Visible = true;
                    BusinesscardNo.Visible = false;
                    foreach (var _price in _inputs.Products)
                    {
                        if (_price.Name == "Businesscard")
                        {
                            total = total + _price.Price;
                        }
                    }
                }
                else
                {
                    BusinesscardYes.Visible = false;
                    BusinesscardNo.Visible = true;
                }

                if (_product.Businessprofile)
                {
                    BusinessprofileYes.Visible = true;
                    BusinessprofileNo.Visible = false;
                    foreach (var _price in _inputs.Products)
                    {
                        if (_price.Name == "Businessprofile")
                        {
                            total = total + _price.Price;
                        }
                    }
                }
                else
                {
                    BusinessprofileYes.Visible = false;
                    BusinessprofileNo.Visible = true;
                }
            }

            GrandTotal.Text = "R"+total.ToString("N2");
            #endregion Products Selected         
        }
    }
}
