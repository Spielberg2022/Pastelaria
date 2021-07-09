using Pastelaria.Domain.Tarefa.Dto;
using ProjetoBanco.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_Pastelaria.Repository.Repositories
{
    public class TarefaRepository
    {
        private readonly Conexao conexao;

        public TarefaRepository()
        {
            conexao = new Conexao();
        }

        private enum Procedures
        {
            PSP_InsTarefa,
            PSP_SelTarefaPorUsuario,
            PSP_SelTarefaPorId
        }

        public void Post(TarefaDto tarefa)
        {
            conexao.ExecuteProcedure(Procedures.PSP_InsTarefa);
            conexao.AddParameter("@IdGestor", tarefa.IdGestor);
            conexao.AddParameter("@IdUsuario", tarefa.IdUsuario);
            conexao.AddParameter("@TarefaDescricao", tarefa.TarefaDescricao);
            conexao.AddParameter("@DataAgendamento", tarefa.DataAgendamento);
            conexao.AddParameter("@DataLimiteExecucao", tarefa.DataLimiteExecucao);
            conexao.AddParameter("@DataExecucao", tarefa.DataExecucao);
            conexao.ExecuteNonQuery();
        }

        public TarefaDto GetTarefaPorIdUsuario(int idUsuario)
        {
            conexao.ExecuteProcedure(Procedures.PSP_SelTarefaPorUsuario);
            conexao.AddParameter("@IdUsuario", idUsuario);
            using (var r = conexao.ExecuteReader())
            {
                if(r.Read())
                {
                    return new TarefaDto
                    {

                    };
                }
            }
            return null;
        }

        public TarefaDto GetTarefaPorId(int id)
        {
            conexao.ExecuteProcedure(Procedures.PSP_SelTarefaPorId);
            conexao.AddParameter("@Id", id);
            using (var r = conexao.ExecuteReader())
            {
                if (r.Read())
                {
                    return new TarefaDto
                    {
                        Id = int.Parse(r["Id"].ToString()),
                        IdGestor = int.Parse(r["IdGestor"].ToString()),
                        IdUsuario = int.Parse(r["IdUsuario"].ToString()),
                        TarefaDescricao = r["TarefaDescricao"].ToString(),
                        DataAgendamento = DateTime.Parse(r["DataAgendamento"].ToString()),
                        DataLimiteExecucao = DateTime.Parse(r["DataLimiteExecucao"].ToString()),
                        DataExecucao = DateTime.Parse(r["DataExecucao"].ToString())
                    };
                }
            }
            return null;
        }
    }
}
