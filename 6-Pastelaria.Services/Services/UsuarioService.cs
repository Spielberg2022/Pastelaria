using _5_Pastelaria.Repository;
using Pastelaria.Domain.Usuario.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pastelaria.Domain.Usuario.Services
{

    public class UsuarioService
    {
        private readonly UsuarioRepository _usuarioRepository;

        public UsuarioService()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        public string Post(UsuarioDto usuarioDto)
        {
            var usuario = _usuarioRepository.GetUsuarioPorEmail(usuarioDto.Email);

            if(usuario != null)
            {
                return "Usuário já cadastrado!";
            }
            _usuarioRepository.Post(usuarioDto);

            return string.Empty;
        }
    }
}
