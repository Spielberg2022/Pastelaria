using _5_Pastelaria.Repository.Repositories;
using _6_Pastelaria.Services;
using Pastelaria.Domain.DisparoEmail;
using Pastelaria.Domain.DisparoEmail.Dto;
using Pastelaria.Domain.Usuario.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Pastelaria.Services.Services
{
    public class DisparoEmailService : IDisparoEmailService
    {
        private readonly IDisparoEmailRepository _disparoEmailRepository;

        public DisparoEmailService(IDisparoEmailRepository disparoEmailRepository)
        {
            _disparoEmailRepository = disparoEmailRepository;
        }

        public string Post(DisparoEmailDto disparoEmailDto)
        {
            try
            {
                MailMessage _mailMessage = new MailMessage();

                _mailMessage.From = new MailAddress("wesleysmn2021@gmail.com");

                _mailMessage.CC.Add(disparoEmailDto.Email);
                _mailMessage.Subject = disparoEmailDto.Assunto;
                _mailMessage.IsBodyHtml = true;
                _mailMessage.Body = disparoEmailDto.Mensagem;

                SmtpClient _smtpClient = new SmtpClient("smtp.gmail.com", 587);
                _smtpClient.EnableSsl = true;
                _smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                _smtpClient.UseDefaultCredentials = false;
                _smtpClient.Credentials = new NetworkCredential("wesleysmn2021@gmail.com", "wsly1987");

                _smtpClient.Send(_mailMessage);
                _disparoEmailRepository.Post(disparoEmailDto);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return string.Empty;
        }
    }
}
