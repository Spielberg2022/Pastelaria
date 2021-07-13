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
            PSP_SelTarefaPorId,
            PSP_UpdDataExecucaoTarefa
        }

        public int Post(TarefaDto tarefa)
        {
            conexao.ExecuteProcedure(Procedures.PSP_InsTarefa);
            conexao.AddParameter("@IdGestor", tarefa.IdGestor);
            conexao.AddParameter("@IdUsuario", tarefa.IdUsuario);
            conexao.AddParameter("@TarefaDescricao", tarefa.TarefaDescricao);
            conexao.AddParameter("@DataAgendamento", tarefa.DataAgendamento);
            conexao.AddParameter("@DataLimiteExecucao", tarefa.DataLimiteExecucao);
            conexao.AddParameter("@DataExecucao", tarefa.DataExecucao);

            return conexao.ExecuteNonQueryWithReturn();
        }

        public void PutDataExecucao(int id)
        {
            conexao.ExecuteProcedure(Procedures.PSP_UpdDataExecucaoTarefa);
            conexao.AddParameter("@Id", id);
            conexao.ExecuteNonQuery();
        }

        public TarefaDto GetTarefaPorId(int id)
        {
            conexao.ExecuteProcedure(Procedures.PSP_SelTarefaPorId);
            conexao.AddParameter("@Id", id);
            using (var r = conexao.ExecuteReader())
            {
                if (r.Read())
                {
                    DateTime dataExecucao;
                    try
                    {
                        dataExecucao = Convert.ToDateTime(r["DataExecucao"]?.ToString());
                    }
                    catch (Exception)
                    {
                        dataExecucao = Convert.ToDateTime("1900-01-01");
                    }

                    return new TarefaDto
                    {
                        Id = int.Parse(r["Id"].ToString()),
                        IdGestor = int.Parse(r["IdGestor"].ToString()),
                        IdUsuario = int.Parse(r["IdUsuario"].ToString()),
                        TarefaDescricao = r["TarefaDescricao"].ToString(),
                        DataAgendamento = DateTime.Parse(r["DataAgendamento"].ToString()),
                        DataLimiteExecucao = DateTime.Parse(r["DataLimiteExecucao"].ToString()),
                        DataExecucao = dataExecucao
                    };
                }
            }
            return null;
        }
    }
}
