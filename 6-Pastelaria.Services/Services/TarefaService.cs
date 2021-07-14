using _5_Pastelaria.Repository;
using _5_Pastelaria.Repository.Repositories;
using Pastelaria.Domain.Tarefa.Dto;
using Pastelaria.Domain.Tarefa;
using Pastelaria.Domain.Usuario;
using Pastelaria.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pastelaria.Domain.DisparoEmail;

namespace _6_Pastelaria.Services.Services
{
    public class TarefaService : ITarefaService
    {
        private readonly ITarefaRepository _tarefaRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IDisparoEmailRepository _disparoEmailRepository;
        private readonly IDisparoEmailService _disparoEmailService;

        public TarefaService(IUsuarioRepository usuarioRepository, ITarefaRepository tarefaRepository, IDisparoEmailRepository disparoEmailRepository, IDisparoEmailService disparoEmailService)
        {
            _tarefaRepository = tarefaRepository;
            _usuarioRepository = usuarioRepository;
            _disparoEmailRepository = disparoEmailRepository;
            _disparoEmailService = disparoEmailService;
        }

        public string Post(TarefaDto tarefaDto)
        {
            var usuario = _usuarioRepository.GetUsuarioPorId(tarefaDto.IdUsuario);

            var idTarefa = _tarefaRepository.Post(tarefaDto);

            _disparoEmailService.Post(new Pastelaria.Domain.DisparoEmail.Dto.DisparoEmailDto
            {
                IdTarefa = idTarefa,
                IdUsuarioDestinatario = tarefaDto.IdUsuario,
                CodigoTipoEmail = 1,
                Mensagem = tarefaDto.TarefaDescricao + " Tarefa expira em: " + tarefaDto.DataLimiteExecucao,
                Assunto = tarefaDto.Assunto,
                Email = usuario.Email
            });

            return string.Empty;
        }

        public void PutDataExecucao(int id)
        {
            _tarefaRepository.PutDataExecucao(id);

            var tarefa = _tarefaRepository.GetTarefaPorId(id);
            var disparoEmail = _disparoEmailRepository.GetDisparoEmailPorIdTarefa(id);
            var usuario = _usuarioRepository.GetUsuarioPorId(tarefa.IdGestor);

            _disparoEmailService.Post(new Pastelaria.Domain.DisparoEmail.Dto.DisparoEmailDto
            {
                IdTarefa = tarefa.Id,
                IdUsuarioDestinatario = tarefa.IdGestor,
                CodigoTipoEmail = 2,
                Assunto = "Tarefa concluída",
                Mensagem = "Tarefa Id: '"+ tarefa.Id + "' Assunto:'Tarefa concluída' concluída.",
                Email = usuario.Email
            });
        }
    }
}
