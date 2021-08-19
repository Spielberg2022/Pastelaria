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
            PSP_UpdDataExecucaoTarefa,
            PSP_DeleteTarefaPorId,
            PSP_UpdSituacaoTarefa
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
            _conexao.AddParameter("@Situacao", tarefa.Situacao);

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

                    TarefaDto tarefa = new TarefaDto(int.Parse(r["Id"].ToString()), 
                                                        int.Parse(r["IdGestor"].ToString()), 
                                                        int.Parse(r["IdUsuario"].ToString()), 
                                                        r["TarefaDescricao"].ToString(),
                                                        DateTime.Parse(r["DataAgendamento"].ToString()), 
                                                        DateTime.Parse(r["DataLimiteExecucao"].ToString()),
                                                        dataExecucao,
                                                        "",
                                                        "",
                                                        r["Situacao"].ToString());

                    return tarefa;
                }
            }
            return null;
        }

        public void Delete(int id)
        {
            _conexao.ExecuteProcedure(Procedures.PSP_DeleteTarefaPorId);
            _conexao.AddParameter("@Id", id);
            _conexao.ExecuteNonQuery();
        }

        public void PutSituacaoPorID(int idTarefa, string situacao)
        {
            _conexao.ExecuteProcedure(Procedures.PSP_UpdSituacaoTarefa);
            _conexao.AddParameter("@Id", idTarefa);
            _conexao.AddParameter("@Situacao", situacao);
            _conexao.ExecuteNonQuery();
        }
    }
}
