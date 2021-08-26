using Pastelaria.Domain.Tarefa.Dto;
using Pastelaria.Domain.Usuario.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pastelaria.Domain.Tarefa
{
    public interface ITarefaRepository
    {
        int Post(TarefaDto tarefa);
        void PutDataExecucao(int id);
        TarefaDto GetTarefaPorId(int id);
        void Delete(int id);
        void PutSituacaoPorID(int idTarefa, string situacao);
        void PutTarefaPorId(int id, string tarefaDescricao, DateTime dataLimiteExecucao);
        IEnumerable<TarefaDto> GetTarefas(int idUsuario);
        IEnumerable<TarefaDto> GetTarefasPorIdGestor(int idGestor);
    }
}
