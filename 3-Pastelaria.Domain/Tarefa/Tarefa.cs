using _3_Pastelaria.Domain.DisparoEmail.Dto;
using _3_Pastelaria.Domain.Tarefa.Dto;
using _3_Pastelaria.Domain.TipoEmail.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace _3_Pastelaria.Domain.Tarefa
{
    class Tarefa
    {
        private TarefaDto _tarefa;

        public Tarefa(TarefaDto tarefa, UsuarioDto gestor, UsuarioDto usuario, string tarefaDescricao, DateTime dataAgendamento, DateTime dataLimiteExecucao)
        {
            _tarefa.IdGestor = gestor.Id;
            _tarefa.IdUsuario = usuario.Id;
            _tarefa.TarefaDescricao = tarefaDescricao;
            _tarefa.DataAgendamento = dataAgendamento;
            _tarefa.DataLimiteExecucao = dataLimiteExecucao;
        }
    }
}
