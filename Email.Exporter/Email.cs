using DevExpress.XtraReports.UI;
using Newtonsoft.Json;
using Reports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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
        #region Variables
        private string FilePath()
        {
            //return @"C:\\DEPLOYMENT\\Khodani.WebUi\\Khodani.WebUi\\FileToSend\\";
            return AppDomain.CurrentDomain.BaseDirectory;
            
        }
        #endregion Viriables

        #region Public Methods
        public bool SendComfirmation(HttpContext context, string jsonString)
        {
            try
            {
                Reports.ApplicantData _inputs = JsonConvert.DeserializeObject<Reports.ApplicantData>(jsonString);
                //SendMailSMTP(_inputs, context);
                SendMailCDO(_inputs, context);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return false;
        }
        #endregion Public Methods

        #region Private methods

        #region Generate Report

        #region Generate Report Byte[]
        private Byte[] GenerateReportByte(Reports.ApplicantData _inputsL, FormatTypes.ReportFormat ReportFormat)
        {
            Byte[] bytes = null;
            try
            {
                XtraReport oCompanyReport = new XtraReport();
                MemoryStream oMemoryStream = new MemoryStream();
                if (_inputsL.Directors.Count() > 0)
                {
                    oCompanyReport = new CompanyReport(_inputsL);
                }
                switch (ReportFormat)
                {
                    case FormatTypes.ReportFormat.pdf:
                        {
                            oCompanyReport.ExportToPdf(oMemoryStream);
                            oMemoryStream.Seek(0, System.IO.SeekOrigin.Begin);
                            break;
                        }
                    case FormatTypes.ReportFormat.html:
                        {
                            oCompanyReport.ExportToMht(oMemoryStream);
                            oMemoryStream.Seek(0, System.IO.SeekOrigin.Begin);
                            break;
                        }
                    case FormatTypes.ReportFormat.image:
                        {
                            oCompanyReport.ExportToImage(oMemoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                            oMemoryStream.Seek(0, System.IO.SeekOrigin.Begin);
                            break;
                        }
                }
                bytes = oMemoryStream.ToArray();
                oMemoryStream = null;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return bytes;
        }
        #endregion Generate Report Byte[]

        #region Generate & Save Report To Folder
        private bool GenerateReportAndSaveToFolder(Reports.ApplicantData _inputs, FormatTypes.ReportFormat ReportFormat)
        {
            bool success = true;
            try
            {
                XtraReport oCompanyReport = new XtraReport();
                MemoryStream oMemoryStream = new MemoryStream();
                if (_inputs.Directors.Count() > 0)
                {
                    oCompanyReport = new CompanyReport(_inputs);
                }
                switch (ReportFormat)
                {
                    case FormatTypes.ReportFormat.pdf:
                        {
                            oCompanyReport.ExportToPdf(FilePath() + string.Concat(GetReferenceNum(_inputs), ".pdf"));
                            break;
                        }
                    case FormatTypes.ReportFormat.html:
                        {
                            oCompanyReport.ExportToMht(FilePath() + string.Concat(GetReferenceNum(_inputs), ".html"));
                            break;
                        }
                    case FormatTypes.ReportFormat.image:
                        {
                            oCompanyReport.ExportToImage(FilePath() + string.Concat(GetReferenceNum(_inputs), ".jpg"));
                            oMemoryStream.Seek(0, System.IO.SeekOrigin.Begin);
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                success = false;
                throw (ex);
            }
            return success;
        }
        #endregion Generate & Save Report To Folder

        #endregion Generate Report

        #region Send Emails

        #region Send Email Using Gmail SMPT
        private bool SendMailSMTP(Reports.ApplicantData _inputs, HttpContext context)
        {
            bool success = false;
            try
            {
                MemoryStream oMemoryStream = null;
                oMemoryStream = new MemoryStream(GenerateReportByte(_inputs, FormatTypes.ReportFormat.pdf));
                string ReportName = GetReferenceNum(_inputs);
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("sereetsikc@gmail.com", "Kopano@047");
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("Company@designProto.co.za", "sereetsikc@gmail.com");
                mail.To.Add(new MailAddress("Company@designProto.co.za"));
                mail.CC.Add(new MailAddress(_inputs.Directors[0].Email));
                mail.CC.Add(new MailAddress("sereetsikc@gmail.com"));
                mail.Attachments.Add(new Attachment(oMemoryStream, string.Concat(ReportName.Replace('-', '_'), ".pdf"), "application/pdf"));
                for (int i = 0; i < context.Request.Files.Count; i++)
                {
                    HttpPostedFile file = context.Request.Files[i];
                    mail.Attachments.Add(new Attachment(file.InputStream, file.FileName, file.ContentType));
                }
                mail.Subject = "BitCode Report : RefNo: " + ReportName;
                mail.IsBodyHtml = true;
                mail.BodyEncoding = Encoding.UTF8;
                mail.Body = "tell me what to send here";
                smtp.Send(mail);
                success = true;
            }
            catch (SmtpFailedRecipientsException ex)
            {
                throw (ex);
            }
            catch (SmtpFailedRecipientException ex)
            {
                throw (ex);
            }
            catch (SmtpException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return success;
        }
        #endregion Send Email Using Gmail SMPT

        #region Send Email Using Micosoft CDO
        private bool SendMailCDO(Reports.ApplicantData _inputs, HttpContext context)
        {
            DeleteFiles();
            bool success = false;
            try
            {
                CDO.Message oMsg = new CDO.Message();
                CDO.IConfiguration iConfg;

                iConfg = oMsg.Configuration;

                ADODB.Fields oFields;
                oFields = iConfg.Fields;

                // Set configuration.
                ADODB.Field oField = oFields["http://schemas.microsoft.com/cdo/configuration/sendusing"];
                oField.Value = 2;

                oField = oFields["http://schemas.microsoft.com/cdo/configuration/smtpserver"];
                oField.Value = "mail.designproto.co.za";

                oField = oFields["http://schemas.microsoft.com/cdo/configuration/smtpserverport"];
                oField.Value = 25;

                oField = oFields["http://schemas.microsoft.com/cdo/configuration/smtpusessl"];
                oField.Value = false;

                oField = oFields["http://schemas.microsoft.com/cdo/configuration/smtpconnectiontimeout"];
                oField.Value = 60;

                oField = oFields["http://schemas.microsoft.com/cdo/configuration/smtpauthenticate"];
                oField.Value = 1;

                oField = oFields["http://schemas.microsoft.com/cdo/configuration/sendusername"];
                oField.Value = "company@designproto.co.za";

                oField = oFields["http://schemas.microsoft.com/cdo/configuration/sendpassword"];
                oField.Value = "Company18?";

                oFields.Update();

                List<string> FileNames = new List<string>();
                if (GenerateReportAndSaveToFolder(_inputs, FormatTypes.ReportFormat.pdf))
                {
                    for (int i = 0; i < context.Request.Files.Count; i++)
                    {
                        HttpPostedFile _inFile = context.Request.Files[i];
                        if(FileNames.Count() > 0)
                        {
                            bool exists = false;
                            foreach(var name in FileNames)
                            {
                                if(name == _inFile.FileName)
                                {
                                    exists = true;
                                }
                            }
                            if (!exists)
                            {
                                FileNames.Add(_inFile.FileName);
                                _inFile.SaveAs(FilePath()+ "FileToSend\\" + _inFile.FileName);
                                oMsg.AddAttachment(FilePath() + "FileToSend\\" + _inFile.FileName);
                            }
                        }
                        else
                        {
                            FileNames.Add(_inFile.FileName);
                            _inFile.SaveAs(FilePath() + "FileToSend\\" + _inFile.FileName);
                            oMsg.AddAttachment(FilePath() + "FileToSend\\" + _inFile.FileName);
                        }
                       
                    }
                    oMsg.AddAttachment(FilePath() + string.Concat(GetReferenceNum(_inputs), ".pdf"));
                    oMsg.CC = _inputs.Directors[0].Email;
                    oMsg.To = "company@designproto.co.za";
                    oMsg.BCC = "sereetsikc@gmail.com";
                    oMsg.ReplyTo = "company@designproto.co.za";
                    oMsg.Subject = GetReferenceNum(_inputs);
                    oMsg.From = "company@designproto.co.za";
                    oMsg.TextBody = "tell me what to send here";
                    oMsg.Send();
                   
                    success = true;
                }
                else
                {
                    success = false;
                }


            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return success;
        }
        #endregion Send Email Using Micosoft CDO

        #endregion Send Emails

        #region Generate Report Reference Number
        private string GetReferenceNum(Reports.ApplicantData _inputs)
        {
            string referenceNum = "report";
            return string.Concat(referenceNum, "_", DateFormatChange(),"_", _inputs.CompanyDetails[0].Name1);
        }
        #endregion Generate Report Reference Number

        #region Deleting Posted Files
        private bool DeleteFiles()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;


            System.IO.DirectoryInfo di = new DirectoryInfo(FilePath() + "FileToSend\\");

            foreach (FileInfo _file in di.GetFiles())
            {
                _file.Delete();
            }
            foreach (DirectoryInfo _folder in di.GetDirectories())
            {
                _folder.Delete(true);
            }

            return true;
        }
        #endregion Deleting Posted Files

        #region Get Today's Date As String DDMMYYYY
        private static string DateFormatChange()
        {
            string returnedValue = string.Empty;
            try
            {
                DateTime dt = DateTime.Now;
                returnedValue = dt.ToString(@"MMddyyyy");
            }
            catch (Exception ex)
            {
                throw(ex);
            }
            return returnedValue;
        }
        #endregion Get Today's Date As String DDMMYYYY

        #endregion Private methods
    }

    #region Helper Classes


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
    #endregion Helper Classes

}
