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
        public CompanyReport(string strXML)
        {

            strXML = XmlFormatNodesDate(strXML, "Date");
            System.IO.StringReader Objsr = new System.IO.StringReader(strXML);
            DataSet dsXML = new DataSet();
            dsXML.ReadXml(Objsr);
            InitializeComponent();
            decimal total = 0;
            if (dsXML.Tables.Contains("Product"))
            {
                DataTable dt = dsXML.Tables["Product"];
                DataTable dt2 = dsXML.Tables["Productsselected"];

                foreach (DataRow dr in dt2.Rows)
                {
                    if (Convert.ToBoolean(dr["CompanyRegistration"].ToString()))
                    {
                        CompanyRegistrationYes.Visible = true;
                        CompanyRegistrationNo.Visible = false;
                        foreach (DataRow dr1 in dt.Rows)
                        {
                            if (dr1["Name"].ToString() == "CompanyRegistration")
                            {
                                total = total + Convert.ToDecimal(dr1["Price"].ToString());
                            }
                        }
                    }
                    else
                    {
                        CompanyRegistrationYes.Visible = false;
                        CompanyRegistrationNo.Visible = true;
                    }

                    if (Convert.ToBoolean(dr["Taxclearancecertificate"].ToString()))
                    {
                        TaxclearancecertificateYes.Visible = true;
                        TaxclearancecertificateNo.Visible = false;
                        foreach (DataRow dr1 in dt.Rows)
                        {
                            if (dr1["Name"].ToString() == "Taxclearancecertificate")
                            {
                                total = total + Convert.ToDecimal(dr1["Price"].ToString());
                            }
                        }
                    }
                    else
                    {
                        TaxclearancecertificateYes.Visible = false;
                        TaxclearancecertificateNo.Visible = true;
                    }

                    if (Convert.ToBoolean(dr["logo"].ToString()))
                    {
                        logoYes.Visible = true;
                        logoNo.Visible = false;
                        foreach (DataRow dr1 in dt.Rows)
                        {
                            if (dr1["Name"].ToString() == "logo")
                            {
                                total = total + Convert.ToDecimal(dr1["Price"].ToString());
                            }
                        }
                    }
                    else
                    {
                        logoYes.Visible = false;
                        logoNo.Visible = true;
                    }


                    if (Convert.ToBoolean(dr["Letterhead"].ToString()))
                    {
                        LetterheadYes.Visible = true;
                        LetterheadNo.Visible = false;
                        foreach (DataRow dr1 in dt.Rows)
                        {
                            if (dr1["Name"].ToString() == "Letterhead")
                            {
                                total = total + Convert.ToDecimal(dr1["Price"].ToString());
                            }
                        }
                    }
                    else
                    {
                        LetterheadYes.Visible = false;
                        LetterheadNo.Visible = true;
                    }

                    if (Convert.ToBoolean(dr["Businesscard"].ToString()))
                    {
                        BusinesscardYes.Visible = true;
                        BusinesscardNo.Visible = false;
                        foreach (DataRow dr1 in dt.Rows)
                        {
                            if (dr1["Name"].ToString() == "Businesscard")
                            {
                                total = total + Convert.ToDecimal(dr1["Price"].ToString());
                            }
                        }
                    }
                    else
                    {
                        BusinesscardYes.Visible = false;
                        BusinesscardNo.Visible = true;
                    }

                    if (Convert.ToBoolean(dr["Businessprofile"].ToString()))
                    {
                        BusinessprofileYes.Visible = true;
                        BusinessprofileNo.Visible = false;
                        foreach (DataRow dr1 in dt.Rows)
                        {
                            if (dr1["Name"].ToString() == "Businessprofile")
                            {
                                total = total + Convert.ToDecimal(dr1["Price"].ToString());
                            }
                        }
                    }
                    else
                    {
                        BusinessprofileYes.Visible = false;
                        BusinessprofileNo.Visible = true;
                    }

                    if (Convert.ToBoolean(dr["website"].ToString()))
                    {
                        websiteYes.Visible = true;
                        websiteNo.Visible = false;
                        foreach (DataRow dr1 in dt.Rows)
                        {
                            if (dr1["Name"].ToString() == "website")
                            {
                                total = total + Convert.ToDecimal(dr1["Price"].ToString());
                            }
                        }
                    }
                    else
                    {
                        websiteYes.Visible = false;
                        websiteNo.Visible = true;
                    }
                }
            }

            GrandTotal.Text = total.ToString("N2");

            this.DataSource = dsXML;
            dsXML.Dispose();
        }
        private string XmlFormatNodesCurrencyNoCent(string strXML, string nodetofind)//, string formaat)
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(strXML);  // suppose that str string contains "<Names>...</Names>"

            XmlNodeList xnList = xml.SelectNodes("//*[contains(name(),'" + nodetofind + "')]");
            foreach (XmlNode xn in xnList)
            {
                try
                {
                    if (!String.IsNullOrEmpty(xn.FirstChild.Value))
                    {
                        String Source = xn.FirstChild.Value;
                        int Lengte = Source.LastIndexOf(".");
                        String pretemp = Source.Substring(0, Lengte);
                        int lengte2 = pretemp.Length;
                        Int32 temp = Convert.ToInt32(pretemp);

                        switch (lengte2)
                        {
                            case 1:
                                xn.FirstChild.Value = String.Format("{0,0:R 0}", temp);
                                break;

                            case 2:
                                xn.FirstChild.Value = String.Format("{0,0:R 00}", temp);
                                break;

                            case 3:
                                xn.FirstChild.Value = String.Format("{0,0:R 000}", temp);
                                break;

                            case 4:
                                xn.FirstChild.Value = String.Format("{0,0:R 0 000}", temp);
                                break;

                            case 5:
                                xn.FirstChild.Value = String.Format("{0,0:R 00 000}", temp);
                                break;

                            case 6:
                                xn.FirstChild.Value = String.Format("{0,0:R 000 000}", temp);
                                break;

                            case 7:
                                xn.FirstChild.Value = String.Format("{0,0:R 0 000 000}", temp);
                                break;

                            case 8:
                                xn.FirstChild.Value = String.Format("{0,0:R 00 000 000}", temp);
                                break;

                            case 9:
                                xn.FirstChild.Value = String.Format("{0,0:R 000 000 000}", temp);
                                break;
                        }

                    }
                }
                catch (Exception ex) { }
            }


            StringWriter sw = new StringWriter();
            XmlTextWriter tx = new XmlTextWriter(sw);
            xml.WriteTo(tx);

            strXML = sw.ToString();
            return strXML;
        }

        private string XmlFormatNodesDate(string strXML, string nodetofind)
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(strXML);  // suppose that str string contains "<Names>...</Names>"

            XmlNodeList xnList = xml.SelectNodes("//*[contains(name(),'" + nodetofind + "')]");
            foreach (XmlNode xn in xnList)
            {
                try
                {
                    if (!String.IsNullOrEmpty(xn.FirstChild.Value))
                    {
                        if (!(xn.Name == "EnquiryDate") && !(xn.ParentNode.Name == "SubscriberInputDetails"))
                        {
                            xn.FirstChild.Value = xn.FirstChild.Value.Replace("-", "/");
                        }
                        else
                        {
                            string Source;
                            string Datum;
                            string Tyd;
                            int Begin;
                            int Lengte;
                            Source = xn.FirstChild.Value.Replace("-", "/");
                            Datum = Source.Substring(0, 10);
                            Begin = Source.LastIndexOf("T") + 1;
                            Lengte = Source.LastIndexOf(".") - Begin;
                            Tyd = Source.Substring(Begin, Lengte);

                            xn.FirstChild.Value = Datum + " " + Tyd;
                        }
                    }
                    else
                    {

                        xn.FirstChild.Value = xn.FirstChild.Value.Replace("-", "/");
                    }
                }
                catch (Exception ex) { }
            }

            StringWriter sw = new StringWriter();
            XmlTextWriter tx = new XmlTextWriter(sw);
            xml.WriteTo(tx);
            strXML = sw.ToString();
            return strXML;
        }

        private string XmlFormatNodesInt(string strXML, string nodetofind)
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(strXML);  // suppose that str string contains "<Names>...</Names>"

            XmlNodeList xnList = xml.SelectNodes("//*[contains(name(),'" + nodetofind + "')]");
            foreach (XmlNode xn in xnList)
            {
                try
                {
                    if (!String.IsNullOrEmpty(xn.FirstChild.Value))
                    {
                        int Lengte = xn.FirstChild.Value.LastIndexOf(".");

                        if (!(Convert.ToString(Lengte) == "0"))
                        {
                            xn.FirstChild.Value = xn.FirstChild.Value.Substring(0, Lengte);
                        }
                        else
                        {
                            xn.FirstChild.Value = xn.FirstChild.Value;
                        }
                    }
                }
                catch (Exception ex) { }
            }
            StringWriter sw = new StringWriter();
            XmlTextWriter tx = new XmlTextWriter(sw);
            xml.WriteTo(tx);

            strXML = sw.ToString();
            return strXML;
        }

    }
}
