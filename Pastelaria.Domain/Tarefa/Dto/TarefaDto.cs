using Pastelaria.Domain.DisparoEmail.Dto;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pastelaria.Domain.Tarefa.Dto
{
    public class TarefaDto
    {
        public int Id { get; set; }
        public int IdGestor { get;  set; }
        public int IdUsuario { get;  set; }
        public string TarefaDescricao { get;  set; }
        public DateTime DataAgendamento { get;  set; }
        public DateTime DataLimiteExecucao { get;  set; }
        public DateTime? DataExecucao { get;  set; }
        public string Assunto { get;  set; }
        public string Mensagem { get;  set; }
        public string Situacao { get;  set; }
    }
}
