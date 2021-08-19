using Pastelaria.Domain.DisparoEmail.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pastelaria.Domain.Tarefa.Dto
{
    public class TarefaDto
    {
        private IList<DisparoEmailDto> _disparoEmailDtos;
        public TarefaDto(int id, 
                            int idGestor, 
                            int idUsuario, 
                            string tarefaDescricao, 
                            DateTime dataAgendamento, 
                            DateTime dataLimiteExecucao, 
                            DateTime? dataExecucao, 
                            string assunto, 
                            string mensagem,
                            string situacao)
        {
            Id = id;
            IdGestor = idGestor;
            IdUsuario = idUsuario;
            TarefaDescricao = tarefaDescricao;
            DataAgendamento = dataAgendamento;
            DataLimiteExecucao = dataLimiteExecucao;
            DataExecucao = dataExecucao;
            Assunto = assunto;
            Mensagem = mensagem;
            Situacao = situacao;
            _disparoEmailDtos = new List<DisparoEmailDto>();
        }

        public int Id { get; private set; }
        public int IdGestor { get; private set; }
        public int IdUsuario { get; private set; }
        public string TarefaDescricao { get; private set; }
        public DateTime DataAgendamento { get; private set; }
        public DateTime DataLimiteExecucao { get; private set; }
        public DateTime? DataExecucao { get; private set; }
        public string Assunto { get; private set; }
        public string Mensagem { get; private set; }
        public string Situacao { get; private set; }
        public IReadOnlyCollection<DisparoEmailDto> disparoEmails { get { return _disparoEmailDtos.ToArray(); } }

        public void AddDisparoEmail(DisparoEmailDto disparoEmailDto)
        {
            _disparoEmailDtos.Add(disparoEmailDto);
        }
    }
}
