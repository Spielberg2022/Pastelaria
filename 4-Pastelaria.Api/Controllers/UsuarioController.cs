using _5_Pastelaria.Repository;
using Pastelaria.Domain.Usuario.Dto;
using Pastelaria.Domain.Usuario.Services;
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
        private readonly UsuarioService _usuarioService;

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
            _usuarioService = new UsuarioService();
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
                return BadRequest("Falha ao fazer login!" + ex.Message);
            }
        }
        
        public IHttpActionResult Post(UsuarioDto usuario)
        {
            try
            {
                var retorno = _usuarioService.Post(usuario);
                if(!string.IsNullOrEmpty(retorno))
                {
                    return BadRequest(retorno);
                }
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest("Falha ao inserir usuário!" + ex.Message);
            }
        }
    }
}
