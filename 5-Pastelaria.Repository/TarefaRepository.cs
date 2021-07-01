using _3_Pastelaria.Domain;
using _3_Pastelaria.Domain.Tarefa.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace _5_Pastelaria.Repository
{
    public class TarefaRepository
    {
        private TarefaDto _tarefa;

        public TarefaRepository(TarefaDto tarefa, UsuarioDto gestor, UsuarioDto usuario, string tarefaDescricao, DateTime dataAgendamento, DateTime dataLimiteExecucao)
        {
            _tarefa.IdGestor = gestor.Id;
            _tarefa.IdUsuario = usuario.Id;
            _tarefa.TarefaDescricao = tarefaDescricao;
            _tarefa.DataAgendamento = dataAgendamento;
            _tarefa.DataLimiteExecucao = dataLimiteExecucao;
        }

        public bool InserirTarefa()
        {
            try
            {
                //Inserir código para gravar no banco de dados a tarefa criada

                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }
    }
}
