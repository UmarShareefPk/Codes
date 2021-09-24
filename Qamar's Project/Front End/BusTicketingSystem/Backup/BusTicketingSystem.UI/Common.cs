using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using BusTicketingSystem.CL;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace BusTicketingSystem.UI
{
    public class Common
    {
        public static bool IsUserAdmin()
        {
           User user = (User)HttpContext.Current.Session["User"];
          
           if (user != null && user.Role.Name.ToUpper() == "ADMIN")
               return true;
          
               return false;
        }

        public static string UserRole()
        {
            User user = (User)HttpContext.Current.Session["User"];

            if (user != null )
                return user.Role.Name;

            return "";
        }

        public  static User ImportUser()
        {
            User user = (User)HttpContext.Current.Session["User"];
            return user;
        }

    
        public static string SendEmail(string to , string subject, string body, List<string> attachments )
        {
            string smtpAddress = "smtp.mail.yahoo.com";
            int portNumber = 587;
            bool enableSSL = true;

            string emailFrom = "mr.qamarsharif@yahoo.com";
            string password = "123AA456";


            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(emailFrom);
                    mail.To.Add(to);
                    mail.Subject = subject;
                    mail.Body = body;
                    mail.IsBodyHtml = true;
                    // Can set to false, if you are sending pure text.

                    //mail.Attachments.Add(new Attachment("C:\\SomeFile.txt"));
                    //mail.Attachments.Add(new Attachment("C:\\SomeZip.zip"));

                    if (attachments != null)
                    {
                        foreach (var file in attachments)
                        {
                            
                            mail.Attachments.Add(new Attachment(file));
                        }
                    }

                    using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                    {
                        smtp.Credentials = new NetworkCredential(emailFrom, password);
                        smtp.EnableSsl = enableSSL;
                        smtp.Send(mail);
                    }
                }

                return "sent";
            }
            catch (Exception ex)
            {

                return "Error : \n" + ex.Message ;
            }
           
        }

    }//end of class
}