using DevExpress.XtraReports.UI;
using Newtonsoft.Json;
using Reports;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using System.Xml.Serialization;


namespace Email.Exporter
{
    public class Email
    {
        public Byte[] GenerateReport(string ReportXML, FormatTypes.ReportFormat ReportFormat)
        {

            Byte[] bytes = null;

            try
            {
                string XmlData = ReportXML;
               
               

                XtraReport oCompanyReport = new XtraReport();
                MemoryStream oMemoryStream = new MemoryStream();

                DataSet ds = new DataSet();
                StringReader xmlSR = new StringReader(XmlData);
                DataTable oReportInformation = null;


                if (!string.IsNullOrEmpty(XmlData))
                {
                    oCompanyReport = new CompanyReport(XmlData);   
                }
                
                switch (ReportFormat)
                {
                    case FormatTypes.ReportFormat.pdf:

                        oCompanyReport.ExportToPdf(oMemoryStream);
                        oMemoryStream.Seek(0, System.IO.SeekOrigin.Begin);

                        break;

                    case FormatTypes.ReportFormat.html:
                        oCompanyReport.ExportToMht(oMemoryStream);
                        oMemoryStream.Seek(0, System.IO.SeekOrigin.Begin);
                        break;

                    case FormatTypes.ReportFormat.image:
                        oCompanyReport.ExportToImage(oMemoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                        oMemoryStream.Seek(0, System.IO.SeekOrigin.Begin);
                        break;
                }

                bytes = oMemoryStream.ToArray();

                oMemoryStream = null;
            }
            catch (Exception e)
            {
                //Do something to log the error (esay to maintain)
            }
            return bytes;
        }

        private string GetReferenceNum(ApplicantData _inputs)
        {
            // temp function to get reference number
            string referenceNum = "report";


            return string.Concat(referenceNum,"-",_inputs.CompanyDetails[0].Name);
        }

        public bool EmailReport( string ReportXML, ApplicantData _inputs, HttpContext context)
        {
            bool success = false;
            try
            {
                MemoryStream oMemoryStream = null;

                oMemoryStream = new MemoryStream(GenerateReport(ReportXML, FormatTypes.ReportFormat.pdf));

                string ReportName = GetReferenceNum(_inputs);

                SmtpClient smtp = new SmtpClient();

                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("sereetsikc@gmail.com", "Kopano@047");
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                MailMessage mail = new MailMessage();


                mail.From = new MailAddress("Company@designProto.co.za", "Company@designProto.co.za");
                mail.To.Add(new MailAddress("sereetsikc@gmail.com"));

                mail.CC.Add(new MailAddress(_inputs.Directors[0].Email));

                //if (!string.IsNullOrEmpty("SmtpReportsBccEmail"))
                //{ mail.Bcc.Add(new MailAddress("SmtpReportsBccEmail")); }


                mail.Attachments.Add(new Attachment(oMemoryStream, string.Concat(ReportName.Replace('-', '_'), ".pdf"), "application/pdf"));


                for (int i = 0; i < context.Request.Files.Count; i++)
                {
                    HttpPostedFile file = context.Request.Files[i];
                    mail.Attachments.Add(new Attachment(file.InputStream, file.FileName, file.ContentType));
                }

                // Specify other e-mail options.
                mail.Subject = "BitCode Report : RefNo: " + ReportName;

                mail.IsBodyHtml = true;
                mail.BodyEncoding = Encoding.UTF8;
                mail.Body = "tell me what to send here";

                //Send the e-mail message via the specified SMTP server.                                
                smtp.Send(mail);

                success = true;
            }
            catch (SmtpFailedRecipientsException ex)
            {
                throw (ex); //log to SP joe will provide the error log table
            }
            catch (SmtpFailedRecipientException ex)
            {
                throw (ex); //log to SP joe will provide the error log table
            }
            catch (SmtpException ex)
            {
                throw (ex); //log to SP joe will provide the error log table
            }
            catch (Exception ex)
            {
                throw (ex); //log to SP joe will provide the error log table
            }



            return success;


        }

		public bool SendComfirmation(HttpContext context, string jsonString)
        {
            try
            {
                ApplicantData _inputs =  JsonConvert.DeserializeObject<ApplicantData>(jsonString);

                string xmldata = _inputs.ToXMLString();
                EmailReport(xmldata, _inputs, context);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return false;
        }
    }

    public static class FormatTypes
    {
        public enum ReportFormat
        {
            html,
            pdf,
            image
        }
    }

    public static class ToJsonString
    {
        public static string ToJson(this object obj)
        {
            string json = JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented);
            return "{\"data\":" + json + "}";
        }

        public static Object ToClassObject(this string XMLString, Object YourClassObject)
        {
            XmlSerializer oXmlSerializer = new XmlSerializer(YourClassObject.GetType());
            YourClassObject = oXmlSerializer.Deserialize(new StringReader(XMLString));
            return YourClassObject;
        }

        public static string ToXMLString(this Object _object)
        {
            var _stringWriter = new StringWriter();
            var _xmlSerializer = new XmlSerializer(_object.GetType());
            _xmlSerializer.Serialize(_stringWriter, _object);
            return _stringWriter.ToString();
        }


    }


}
