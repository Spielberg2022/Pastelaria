using Pastelaria.Domain.Tarefa.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_Pastelaria.Services
{
    public interface ITarefaService
    {
        string Post(TarefaDto tarefaDto);
        void PutDataExecucao(int id);
        void Delete(int id);
        void PutTarefaPorId(int id, string tarefaDescricao, DateTime dataLimiteExecucao);
    }
}
