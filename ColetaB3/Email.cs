using ColetaB3.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ColetaB3
{
    public class Email : IEmail
    {
        public MailMessage _emailSender { get; private set; }


        public Email(string to)
        {
            this._emailSender = new MailMessage();
            this._emailSender.From = new MailAddress("testeinoa@gmail.com");
            this._emailSender.To.Add(to);
            this._emailSender.Sender = new MailAddress("testeinoa@gmail.com");
        }

        public async Task<bool> SenderMail(string subject, string body, SmtpClient sender)
        {
            try
            {
                this._emailSender.Subject = subject;
                this._emailSender.Body = body;
                sender.EnableSsl = true;
                sender.Credentials = new NetworkCredential("", "");
                await sender.SendMailAsync(this._emailSender);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("Method: {0}, Message: {1}",
                     System.Reflection.MethodBase.GetCurrentMethod().Name, e.Message));
                return false;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public string GetFrom() => this._emailSender.From != null ? this._emailSender.From.Address : string.Empty;


        public IList<string> GetTo() => this._emailSender.To.Select(x => x.Address).ToList();
        
    }
}
