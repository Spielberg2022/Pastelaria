using _5_Pastelaria.Repository;
using Pastelaria.Domain.Usuario;
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

        private readonly IUsuarioRepository _iUsuarioRespository;

        public UsuarioController(IUsuarioRepository iUsuarioRespository)
        {
            _iUsuarioRespository = iUsuarioRespository;
        }

        /// <summary>
        /// Método que faz o login no sitema.
        /// </summary>
        /// <param name="email">Email do login do usuário</param>
        /// <param name="senha">Senha do login do usuário</param>
        /// <returns>Se login e senha foram válidos retorna o objeto usuário</returns>
        public IHttpActionResult GetLogin(string email, string senha)
        {
            try
            {
                var usuario = _iUsuarioRespository.GetLogin(email, senha);
                return Ok(usuario);
            }
            catch(Exception ex)
            {
                return BadRequest("Falha ao fazer login!" + ex.Message);
            }
        }
        
        /// <summary>
        /// Método que insere um novo usuário
        /// </summary>
        /// <param name="usuario">Objeto que recebe os dados do usuário a ser inserido</param>
        /// <returns>Se for inserido com sucesso retorna os dados do usuário</returns>
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
