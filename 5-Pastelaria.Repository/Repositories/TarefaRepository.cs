using Pastelaria.Domain.Tarefa;
using Pastelaria.Domain.Tarefa.Dto;
using Pastelaria.Domain.Usuario.Dto;
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
            PSP_UpdSituacaoTarefa,
            PSP_UPDTarefaPorId,
            PSP_SelTarefasUsuario,
            PSP_SelTarefasUsuarioPorIdGestor
        }

        public int Post(TarefaDto tarefa)
        {
            _conexao.ExecuteProcedure(Procedures.PSP_InsTarefa);
            _conexao.AddParameter("@IdGestor", tarefa.IdGestor);
            _conexao.AddParameter("@IdUsuario", tarefa.IdUsuario);
            _conexao.AddParameter("@TarefaDescricao", tarefa.TarefaDescricao);
            //_conexao.AddParameter("@DataAgendamento", tarefa.DataAgendamento);
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
                    var tarefa = new TarefaDto {
                        Id = int.Parse(r["Id"].ToString()),
                        IdGestor = int.Parse(r["IdGestor"].ToString()),
                        IdUsuario = int.Parse(r["IdUsuario"].ToString()),
                        TarefaDescricao = r["TarefaDescricao"].ToString(),
                        DataAgendamento = DateTime.Parse(r["DataAgendamento"].ToString()),
                        DataLimiteExecucao = DateTime.Parse(r["DataLimiteExecucao"].ToString()),
                        DataExecucao = string.IsNullOrEmpty(r["DataExecucao"]?.ToString()) ? new DateTime() : DateTime.Parse(r["DataExecucao"].ToString()),
                        Assunto = "",
                        Mensagem = "",
                        Situacao = r["Situacao"].ToString()
                        };

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

        public void PutTarefaPorId(int id, string tarefaDescricao, DateTime dataLimiteExecucao)
        {
            _conexao.ExecuteProcedure(Procedures.PSP_UPDTarefaPorId);
            _conexao.AddParameter("@Id", id);
            _conexao.AddParameter("@TarefaDescricao", tarefaDescricao);
            _conexao.AddParameter("@DataLimiteExecucao", dataLimiteExecucao);
            _conexao.ExecuteNonQuery();
        }

        public IEnumerable<TarefaDto> GetTarefas(int idUsuario)
        {
            var tarefas = new List<TarefaDto>();
            _conexao.ExecuteProcedure(Procedures.PSP_SelTarefasUsuario);
            _conexao.AddParameter("@IdUsuario", idUsuario);
            using (var r = _conexao.ExecuteReader())
                while (r.Read())
                {
                    var tarefa = new TarefaDto
                    {
                        Id = int.Parse(r["Id"].ToString()),
                        IdGestor = int.Parse(r["IdGestor"].ToString()),
                        IdUsuario = int.Parse(r["IdUsuario"].ToString()),
                        TarefaDescricao = r["TarefaDescricao"].ToString(),
                        DataAgendamento = DateTime.Parse(r["DataAgendamento"].ToString()),
                        DataLimiteExecucao = DateTime.Parse(r["DataLimiteExecucao"].ToString()),
                        DataExecucao = string.IsNullOrEmpty(r["DataExecucao"]?.ToString()) ? new DateTime() : DateTime.Parse(r["DataExecucao"].ToString()),
                        Situacao = r["Situacao"].ToString()
                    };

                    tarefas.Add(tarefa);
                }
            return tarefas;
        }

        public IEnumerable<TarefaDto> GetTarefasPorIdGestor(int idGestor)
        {
            var tarefas = new List<TarefaDto>();
            _conexao.ExecuteProcedure(Procedures.PSP_SelTarefasUsuarioPorIdGestor);
            _conexao.AddParameter("@IdGestor", idGestor);
            using (var r = _conexao.ExecuteReader())
                while (r.Read())
                {
                    var tarefa = new TarefaDto
                    {
                        Id = int.Parse(r["Id"].ToString()),
                        IdGestor = int.Parse(r["IdGestor"].ToString()),
                        IdUsuario = int.Parse(r["IdUsuario"].ToString()),
                        TarefaDescricao = r["TarefaDescricao"].ToString(),
                        DataAgendamento = DateTime.Parse(r["DataAgendamento"].ToString()),
                        DataLimiteExecucao = DateTime.Parse(r["DataLimiteExecucao"].ToString()),
                        DataExecucao = string.IsNullOrEmpty(r["DataExecucao"]?.ToString()) ? new DateTime() : DateTime.Parse(r["DataExecucao"].ToString()),
                        Situacao = r["Situacao"].ToString()
                    };

                    tarefas.Add(tarefa);
                }
            return tarefas;
        }
    }
}
