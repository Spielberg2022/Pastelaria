using _5_Pastelaria.Repository.Repositories;
using Pastelaria.Domain.DisparoEmail.Dto;
using Pastelaria.Domain.Usuario.Dto;
using Pastelaria.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _4_Pastelaria.Api.Controllers
{
    [RoutePrefix("api/DisparoEmail")]
    public class DisparoEmailController : ApiController
    {
        private readonly DisparoEmailRepository _disparoEmailRepository;
        private readonly DisparoEmailService _disparoEmailService;

        public DisparoEmailController()
        {
            _disparoEmailRepository = new DisparoEmailRepository();
            _disparoEmailService = new DisparoEmailService();
        }

        public IHttpActionResult GetDisparoEmailPorIdTarefa(int idTarefa)
        {
            try
            {
                var disparoEmail = _disparoEmailRepository.GetDisparoEmailPorIdTarefa(idTarefa);
                return Ok(disparoEmail);
            }
            catch (Exception ex)
            {
                return BadRequest("Falha ao localizar usuário por IdTarefa!" + ex.Message);
            }
        }
    }
}