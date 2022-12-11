using LetiSec.Models.DbModel;
using MimeKit;

using System.Net.Mail;

namespace SocialApp.Services
{
    public class EmailService
    {

        

        public void SendEmail(SuppMessage suppMessage)
        {
            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress("Тех. Поддержка", "LetiSecSupp@gmail.com"));
            message.To.Add(new MailboxAddress("",suppMessage.Email));
            message.Subject = suppMessage.ShortDescription;
            message.Body = new BodyBuilder { TextBody = suppMessage.Answers[suppMessage.Answers.Count - 1] }.ToMessageBody();

           

        }
    }
}