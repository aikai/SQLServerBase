using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;

namespace ProjectBase.Utils.Commons
{
    public interface ISendEmail
    {
        bool SendEmailNoAttachFile(string mailSendTo, string receiveName, string SendName, string SubjectEmail, string BodyEmail);
        bool SendEmailNoAttachFile(MailAddressCollection Receiver, MailAddressCollection ReceiverCc, string SendName, string SubjectEmail, string BodyEmail);
        bool SendEmailNoAttachFile(MailAddressCollection Receiver, MailAddressCollection ReceiverCc, string SendName, string SubjectEmail, string BodyEmail, string EmailSender, string EmailSenderPass, string NameSender);

        bool SendEmailWithAttachFile(MailAddressCollection mailSendTo, MailAddressCollection mailSendCc, string receiveName, string SendName, string SubjectEmail, string BodyEmail, Attachment PathFileAttachment);
        bool SendEmailWithAttachFile(MailAddressCollection mailSendTo, MailAddressCollection mailSendCc, string receiveName, string SendName, string SubjectEmail, string BodyEmail, Attachment PathFileAttachment, string EmailSender, string EmailSenderPass, string NameSender);
    }
}
