using _3_Pastelaria.Domain.DisparoEmail.Dto;
using _3_Pastelaria.Domain.Tarefa.Dto;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace _3_Pastelaria.Domain.DisparoEmail
{
    class DisparoEmailService
    {
        private DisparoEmailDto _email;
        private UsuarioDto _usuario;

        public DisparoEmailService(DisparoEmailDto email, UsuarioDto usuario)
        {
            _email = email;
            _usuario = usuario;
        }

        public bool EnviarEmail()
        {
            //Codigo de envio de email
            try
            {
                MailMessage _mailMessage = new MailMessage();

                _mailMessage.From = new MailAddress("wesleysmn2021@gmail.com");

                _mailMessage.CC.Add(_usuario.Email);
                _mailMessage.Subject = _email.Assunto;
                _mailMessage.IsBodyHtml = true;
                _mailMessage.Body = _email.Mensagem;

                SmtpClient _smtpClient = new SmtpClient("smtp.gmail.com", 587);
                _smtpClient.EnableSsl = true;
                _smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                _smtpClient.UseDefaultCredentials = false;
                _smtpClient.Credentials = new NetworkCredential("wesleysmn2021@gmail.com", "wsly1987");

                _smtpClient.Send(_mailMessage);

                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }           
        }
    }   
}
