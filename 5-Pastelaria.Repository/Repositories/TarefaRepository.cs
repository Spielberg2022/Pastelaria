using Pastelaria.Domain.Tarefa;
using Pastelaria.Domain.Tarefa.Dto;
using ProjetoBanco.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_Pastelaria.Repository.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly Conexao _conexao;

        public TarefaRepository(Conexao conexao)
        {
            _conexao = conexao;
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
            _conexao.ExecuteProcedure(Procedures.PSP_InsTarefa);
            _conexao.AddParameter("@IdGestor", tarefa.IdGestor);
            _conexao.AddParameter("@IdUsuario", tarefa.IdUsuario);
            _conexao.AddParameter("@TarefaDescricao", tarefa.TarefaDescricao);
            _conexao.AddParameter("@DataAgendamento", tarefa.DataAgendamento);
            _conexao.AddParameter("@DataLimiteExecucao", tarefa.DataLimiteExecucao);
            _conexao.AddParameter("@DataExecucao", tarefa.DataExecucao);

            return _conexao.ExecuteNonQueryWithReturn();
        }

        public void PutDataExecucao(int id)
        {
            _conexao.ExecuteProcedure(Procedures.PSP_UpdDataExecucaoTarefa);
            _conexao.AddParameter("@Id", id);
            _conexao.ExecuteNonQuery();
        }

        public TarefaDto GetTarefaPorId(int id)
        {
            _conexao.ExecuteProcedure(Procedures.PSP_SelTarefaPorId);
            _conexao.AddParameter("@Id", id);
            using (var r = _conexao.ExecuteReader())
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
