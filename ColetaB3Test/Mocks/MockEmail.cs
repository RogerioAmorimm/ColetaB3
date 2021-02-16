using ColetaB3.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ColetaB3Test.Mocks
{
    class MockEmail : IEmail
    {
        public MockEmail()
        {
            
        }

        public MailMessage _emailSender { get;  set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public string GetFrom() => this._emailSender.From != null ? this._emailSender.From.Address : string.Empty;
        public IList<string> GetTo() => _emailSender.To.Select(x => x.Address).ToList();

        public async Task<bool> SenderMail(string subject, string body, SmtpClient sender)
        {
            if (this._emailSender.To.Count > 0 && this._emailSender.From != null && sender != null ) return true;

            return false;
        }
    }

}
