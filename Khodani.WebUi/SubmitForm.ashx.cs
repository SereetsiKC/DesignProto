using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Email.Exporter;

namespace Khodani.WebUi
{
    /// <summary>
    /// Summary description for SubmitForm
    /// </summary>
    public class SubmitForm : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
            
            string Applicant = context.Request.Form["ApplicantData"];
           
            for (int i = 0; i < context.Request.Files.Count; i++)
            {
                HttpPostedFile file = context.Request.Files[i];
            }
            Email.Exporter.Email _service = new Email.Exporter.Email();
            _service.SendComfirmation(context, Applicant);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}