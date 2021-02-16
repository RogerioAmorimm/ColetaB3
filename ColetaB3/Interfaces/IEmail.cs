using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ColetaB3.Interfaces
{
    public interface IEmail : IDisposable
    {
        Task<bool> SenderMail(string subject, string body, SmtpClient sender);

        string GetFrom();

        IList<string> GetTo();

    }
}
