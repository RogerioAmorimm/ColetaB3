using ColetaB3.Interfaces;
using ColetaB3Test.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ColetaB3Test
{
    [TestClass]
    public class EmailTest
    {
        private const string _body = "body";
        private const string _subject = "subject";
        private const string _email = "teste@teste.com";

        IEmail _emailWithoutFromAndWithoutTo;
        IEmail _emailWithFromAndWithTo;
        IEmail _validEmail;
        
        public EmailTest()
        {
            this._emailWithoutFromAndWithoutTo = new MockEmail() { _emailSender = new MailMessage() };
            this._emailWithFromAndWithTo = new MockEmail() { _emailSender = new MailMessage(_email, _email) };
            this._validEmail = new MockEmail() { _emailSender = new MailMessage(_email, _email) };
        }

        [TestMethod]
        public void Email_without_from()
        {
            Assert.AreEqual(string.IsNullOrEmpty(_emailWithoutFromAndWithoutTo.GetFrom()), true);
        }

        [TestMethod]
        public void Email_with_from()
        {
            Assert.AreEqual(string.IsNullOrEmpty(_emailWithFromAndWithTo.GetFrom()), false);
        }

        [TestMethod]
        public void Email_without_to()
        {
            Assert.AreEqual(_emailWithoutFromAndWithoutTo.GetTo().Count > 0, false); 
        }

        [TestMethod]
        public void Email_with_to()
        {
            Assert.AreEqual(_emailWithFromAndWithTo.GetTo().Count > 0, true);
        }

        [TestMethod]
        public async Task Failed_send_email()
        {
            var assert = await _validEmail.SenderMail(_body, _subject, null);
            Assert.AreEqual(assert, false);
        }

        [TestMethod]
        public async Task Success_send_email()
        {
            var assert = await _validEmail.SenderMail(_body, _subject, new SmtpClient());
            Assert.AreEqual(assert, true);
        }
    }
}
