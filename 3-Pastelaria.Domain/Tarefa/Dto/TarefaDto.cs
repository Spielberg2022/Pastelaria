using System;
using System.Collections.Generic;
using System.Text;

namespace _3_Pastelaria.Domain.Tarefa.Dto
{
    class TarefaDto
    {
        public int Id { get; set; }
        public int IdGestor { get; set; }
        public int IdUsuario { get; set; }
        public string TarefaDescricao { get; set; }
        public DateTime DataAgendamento { get; set; }
        public DateTime DataLimiteExecucao { get; set; }
        public DateTime DataExecucao { get; set; }
    }
}
