using _5_Pastelaria.Repository;
using _6_Pastelaria.Services;
using Pastelaria.Domain.Tarefa;
using Pastelaria.Domain.Usuario.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pastelaria.Domain.Usuario.Services
{

    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ITarefaRepository _tarefaRespository;

        public UsuarioService(IUsuarioRepository usuarioRepository, ITarefaRepository tarefaRepository)
        {
            _usuarioRepository = usuarioRepository;
            _tarefaRespository = tarefaRepository;
        }

        public string Delete(int idUsuario)
        {
            var usuario = _usuarioRepository.GetUsuarioPorId(idUsuario);

            if(usuario == null)
            {
                return "Usuário não encotrado!";
            }

            _usuarioRepository.Delete(usuario.Id);

            return string.Empty;
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

        public UsuarioDto PostLogin(UsuarioDto usuarioDto)
        {
            var usuario = _usuarioRepository.GetLogin(usuarioDto.Email, usuarioDto.Senha);
            //usuario.Tarefas = _tarefaRespository.GetTarefas(usuario.Id);

            return usuario;
        }
    }
}
