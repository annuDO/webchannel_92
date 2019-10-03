using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Mail;

namespace Trelleborg.Utilities.Helpers
{
  //TODO: Integrate Email
  //public class EmailHelper
  //  {
  //      /// <summary>
  //      /// Sends email 
  //      /// </summary>
  //      /// <param name="msgFrom"></param>
  //      /// <param name="msgTo"></param>
  //      /// <param name="bodyText"></param>
  //      /// <param name="subject"></param>
  //      /// <param name="MailClientSmtp"></param>
  //      /// <returns>Returns true if email is sent successfully</returns>
  //      public bool sendmail(string msgFrom, string msgTo, string bodyText, string subject, string MailClientSmtp)
  //      {
  //          try
  //          {
  //              MailMessage emailMessage = new MailMessage();
  //              emailMessage.From = new MailAddress(msgFrom);
  //              emailMessage.To.Add(new MailAddress(msgTo));
  //              emailMessage.Subject = subject;
  //              emailMessage.Body = bodyText;
  //              emailMessage.Priority = MailPriority.High;
  //              SmtpClient MailClient = new SmtpClient(MailClientSmtp);
  //              MailClient.Send(emailMessage);
  //              return true;
  //          }

  //          catch
  //          {
  //              return false;
  //          }

  //      }

  //  }
}