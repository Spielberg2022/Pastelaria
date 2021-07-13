using _5_Pastelaria.Repository;
using _5_Pastelaria.Repository.Repositories;
using Pastelaria.Domain.Tarefa.Dto;
using Pastelaria.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_Pastelaria.Services.Services
{
    public class TarefaService
    {
        private readonly TarefaRepository _tarefaRepository;
        private readonly UsuarioRepository _usuarioRepository;
        private readonly DisparoEmailRepository _disparoEmailRepository;
        private readonly DisparoEmailService _disparoEmailService;

        public TarefaService()
        {
            _tarefaRepository = new TarefaRepository();
            _usuarioRepository = new UsuarioRepository();
            _disparoEmailRepository = new DisparoEmailRepository();
            _disparoEmailService = new DisparoEmailService();
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
                Mensagem = tarefaDto.TarefaDescricao,
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
                Mensagem = "Tarefa Id: '"+ tarefa.Id + "' Assunto:'"+ disparoEmail.Assunto +"' concluída.",
                Assunto = "Tarefa concluída",
                Email = usuario.Email
            });
        }
    }
}
