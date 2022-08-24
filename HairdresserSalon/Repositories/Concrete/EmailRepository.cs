using HairdresserSalon.Repositories.Abstract;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace HairdresserSalon.Repositories.Concrete
{
    public class EmailRepository : IEmailRepository
    {
        
        public void SendEmail(string email, string subject, string htmlString)
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            var config = builder.Build();
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            message.From = new MailAddress(config["Smtp:Username"]);
            message.To.Add(new MailAddress(email));
            message.Subject = subject;
            message.IsBodyHtml = true; //to make message body as html  
            message.Body = htmlString;
            smtp.Port = int.Parse(config["Smtp:Port"]);
            smtp.Host = config["Smtp:Host"]; //for gmail host  
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(config["Smtp:Username"], config["Smtp:Password"]);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(message);
        }
    }
}
