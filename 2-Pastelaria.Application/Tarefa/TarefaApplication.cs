using _2_Pastelaria.Application.Infra;
using _2_Pastelaria.Application.Model;
using _2_Pastelaria.Application.Tarefa.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace _2_Pastelaria.Application.Tarefa
{
    public class TarefaApplication : BaseApplication
    {
        public TarefaApplication() : base("https://localhost:44311/api/Tarefa/")
        {
        }
        public HttpResponseMessage Get(int idUsuario) => _httpClient.GetAsync($"selecionar-tarefas/{idUsuario}").Result;
        public HttpResponseMessage GetPorIdGestor(int idGestor) => _httpClient.GetAsync($"selecionar-tarefas-gestor/{idGestor}").Result;
        public HttpResponseMessage Post(TarefaModel tarefa) => _httpClient.PostAsJsonAsync("Post", tarefa).Result;
    }
}
