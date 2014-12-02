using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Web.Configuration;
using ProjectBase.Utils.Commons;

namespace ProjectBase.Utils.Commons
{
    public class SendEmail : ISendEmail
    {
        private string EmailStaff
        {
            get { return WebConfigurationManager.AppSettings["EmailAdmin"]; }
        }

        private string EmailStaffPass
        {
            get { return WebConfigurationManager.AppSettings["EmailPass"]; }
        }

        private string SmtpConfig
        {
            get { return WebConfigurationManager.AppSettings["SmtpConfig"]; }
        }

        //private MailAddressCollection mailSendTo;
        //public MailAddressCollection MailSendTo
        //{
        //    set
        //    {
        //        mailSendTo = value;
        //    }
        //}

        public SendEmail()
        {
        }


        #region Email
        public bool SendEmailNoAttachFile(string mailSendTo, string receiveName, string SendName, string SubjectEmail, string BodyEmail)
        {

            bool sendResult = true;
            MailAddressCollection ListMail = new MailAddressCollection();

            try
            {
                SmtpClient mySmtpClient = new SmtpClient(SmtpConfig);

                // set smtp-client with basicAuthentication
                mySmtpClient.UseDefaultCredentials = false;
                NetworkCredential basicAuthenticationInfo = new NetworkCredential(EmailStaff, EmailStaffPass);
                mySmtpClient.Credentials = basicAuthenticationInfo;

                // add from,to mailaddresses
                MailAddress from = new MailAddress(EmailStaff, "UAE-NoReply");
                MailAddress to = new MailAddress(mailSendTo, receiveName);
                MailMessage myMail = new MailMessage(from, to);

                // set subject and encoding
                myMail.Subject = SubjectEmail;
                myMail.SubjectEncoding = System.Text.Encoding.UTF8;

                // set body-message and encoding
                myMail.Body = BodyEmail;// "<b>Test Mail</b><br>using <b>HTML</b>.";
                myMail.BodyEncoding = System.Text.Encoding.UTF8;
                myMail.IsBodyHtml = true;
                mySmtpClient.Send(myMail);
                myMail.Dispose();

                return sendResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool SendEmailNoAttachFile(MailAddressCollection Receiver, MailAddressCollection ReceiverCc, string SendName, string SubjectEmail, string BodyEmail)
        {
            bool sendResult = true;
            MailAddressCollection ListMail = new MailAddressCollection();

            try
            {
                SmtpClient mySmtpClient = new SmtpClient(SmtpConfig);

                // set smtp-client with basicAuthentication
                mySmtpClient.UseDefaultCredentials = false;
                NetworkCredential basicAuthenticationInfo = new NetworkCredential(EmailStaff, EmailStaffPass);
                mySmtpClient.Credentials = basicAuthenticationInfo;

                // add from,to mailaddresses
                MailAddress from = new MailAddress(EmailStaff, "UAE-NoReply");
                MailMessage myMail = new MailMessage();
                myMail.From = from;

                foreach (var m in Receiver)
                {
                    myMail.To.Add(m);
                }

                foreach (var m in ReceiverCc)
                {
                    myMail.CC.Add(m);
                }

                // set subject and encoding
                myMail.Subject = SubjectEmail;
                myMail.SubjectEncoding = System.Text.Encoding.UTF8;

                // set body-message and encoding
                myMail.Body = BodyEmail;// "<b>Test Mail</b><br>using <b>HTML</b>.";
                myMail.BodyEncoding = System.Text.Encoding.UTF8;
                myMail.IsBodyHtml = true;
                mySmtpClient.EnableSsl = true;
                mySmtpClient.Send(myMail);
                myMail.Dispose();

                return sendResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool SendEmailNoAttachFile(MailAddressCollection Receiver, MailAddressCollection ReceiverCc, string SendName, string SubjectEmail, string BodyEmail, string EmailSender, string EmailSenderPass, string NameSender)
        {
            bool sendResult = true;

            try
            {
                SmtpClient mySmtpClient = new SmtpClient(SmtpConfig);
                
                // set smtp-client with basicAuthentication
                mySmtpClient.UseDefaultCredentials = false;
                // Type1
                //NetworkCredential basicAuthenticationInfo = new NetworkCredential(EmailSender, EmailSenderPass);
                //mySmtpClient.Credentials = basicAuthenticationInfo;
                // Type2
                mySmtpClient.Credentials = new NetworkCredential(EmailSender, EmailSenderPass);

                // add from,to mailaddresses
                MailAddress from = new MailAddress(EmailSender, NameSender);
                MailMessage myMail = new MailMessage();
                myMail.From = from;

                foreach (var m in Receiver)
                {
                    myMail.To.Add(m);
                }

                foreach (var m in ReceiverCc)
                {
                    myMail.CC.Add(m);
                }

                // set subject and encoding
                myMail.Subject = SubjectEmail;
                myMail.SubjectEncoding = System.Text.Encoding.UTF8;

                // set body-message and encoding
                myMail.Body = BodyEmail;
                myMail.BodyEncoding = System.Text.Encoding.UTF8;
                myMail.IsBodyHtml = true;
                mySmtpClient.EnableSsl = true;
                mySmtpClient.Send(myMail);
                myMail.Dispose();

                return sendResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 
        #endregion

        #region Email have AttachFile
        public bool SendEmailWithAttachFile(MailAddressCollection mailSendTo, MailAddressCollection mailSendCc, string receiveName, string SendName, string SubjectEmail, string BodyEmail,
           Attachment PathFileAttachment)
        {
            bool sendResult = true;
            try
            {
                SmtpClient mySmtpClient = new SmtpClient(SmtpConfig);

                // set smtp-client with basicAuthentication
                mySmtpClient.UseDefaultCredentials = false;
                NetworkCredential basicAuthenticationInfo = new NetworkCredential(EmailStaff, EmailStaffPass);
                mySmtpClient.Credentials = basicAuthenticationInfo;

                // add from,to mailaddresses
                MailAddress from = new MailAddress(EmailStaff, "UAE-NoReply");
                //MailAddress to = new MailAddress(mailSendTo, receiveName);
                MailMessage myMail = new MailMessage();
                myMail.From = from;

                foreach (var m in mailSendTo)
                {
                    myMail.To.Add(m);
                }

                foreach (var cc in mailSendCc)
                {
                    myMail.CC.Add(cc);
                }

                // set subject and encoding
                myMail.Subject = SubjectEmail;
                myMail.SubjectEncoding = System.Text.Encoding.UTF8;

                //System.Net.Mail.Attachment attachment;
                //attachment = new System.Net.Mail.Attachment(PathFileAttachment);
                myMail.Attachments.Add(PathFileAttachment);

                // set body-message and encoding
                myMail.Body = BodyEmail;// "<b>Test Mail</b><br>using <b>HTML</b>.";
                myMail.BodyEncoding = System.Text.Encoding.UTF8;
                myMail.IsBodyHtml = true;
                mySmtpClient.EnableSsl = true;
                mySmtpClient.Send(myMail);
                myMail.Dispose();

                return sendResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool SendEmailWithAttachFile(MailAddressCollection mailSendTo, MailAddressCollection mailSendCc, string receiveName, string SendName, string SubjectEmail, string BodyEmail,
            Attachment PathFileAttachment, string EmailSender, string EmailSenderPass, string NameSender)
        {
            bool sendResult = true;
            try
            {
                SmtpClient mySmtpClient = new SmtpClient(SmtpConfig);

                // set smtp-client with basicAuthentication
                mySmtpClient.UseDefaultCredentials = false;
                NetworkCredential basicAuthenticationInfo = new NetworkCredential(EmailSender, EmailSenderPass);
                mySmtpClient.Credentials = basicAuthenticationInfo;


                // add from,to mailaddresses
                MailAddress from = new MailAddress(EmailSender, NameSender);
                MailMessage myMail = new MailMessage();
                myMail.From = from;

                foreach (var m in mailSendTo)
                {
                    myMail.To.Add(m);
                }

                foreach (var cc in mailSendCc)
                {
                    myMail.CC.Add(cc);
                }

                // set subject and encoding
                myMail.Subject = SubjectEmail;
                myMail.SubjectEncoding = System.Text.Encoding.UTF8;

                //System.Net.Mail.Attachment attachment;
                //attachment = new System.Net.Mail.Attachment(PathFileAttachment);
                myMail.Attachments.Add(PathFileAttachment);

                // set body-message and encoding
                myMail.Body = BodyEmail;
                myMail.BodyEncoding = System.Text.Encoding.UTF8;
                myMail.IsBodyHtml = true;
                mySmtpClient.EnableSsl = true;
                mySmtpClient.Send(myMail);
                myMail.Dispose();

                return sendResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 
        #endregion
    }
}