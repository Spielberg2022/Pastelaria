using _5_Pastelaria.Repository.Repositories;
using Pastelaria.Domain.Tarefa.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_Pastelaria.Services.Services
{
    class TarefaService
    {
        private readonly TarefaRepository _tarefaRepository;

        public TarefaService()
        {
            _tarefaRepository = new TarefaRepository();
        }
    }
}
