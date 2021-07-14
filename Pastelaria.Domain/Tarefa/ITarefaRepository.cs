﻿using Pastelaria.Domain.Tarefa.Dto;
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

    }
}