
using _5_Pastelaria.Repository;
using Pastelaria.Domain.Usuario.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _4_Pastelaria.Api.Controllers
{
    [RoutePrefix("api/Usuario")]
    public class UsuarioController : ApiController
    {
        private readonly UsuarioRepository _usuarioRepository;

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();

        }

        public IHttpActionResult GetLogin(string email, string senha)
        {
            try
            {
                var usuario = _usuarioRepository.GetLogin(email, senha);
                return Ok(usuario);
            }
            catch(Exception ex)
            {
                return BadRequest("Falha o fazer login!");
            }
        }
        
        public IHttpActionResult Post(UsuarioDto usuario)
        {
            try
            {
                _usuarioRepository.Post(usuario);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest("Falha ao inserir usuário!");
            }
        }
    }
}
