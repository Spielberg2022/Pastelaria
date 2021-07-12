using _5_Pastelaria.Repository.Repositories;
using _6_Pastelaria.Services.Services;
using Pastelaria.Domain.Tarefa.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _4_Pastelaria.Api.Controllers
{
    [RoutePrefix("api/Tarefa")]
    public class TarefaController : ApiController
    {
        private readonly TarefaRepository _tarefaRepository;
        private readonly DisparoEmailRepository _disparoEmailRepository;
        private readonly TarefaService _tarefaService;

        public TarefaController()
        {
            _tarefaRepository = new TarefaRepository();
            _disparoEmailRepository = new DisparoEmailRepository();
            _tarefaService = new TarefaService();
        }

        public IHttpActionResult GetTarefaPorId(int id)
        {
            try
            {
                var tarefa = _tarefaRepository.GetTarefaPorId(id);
                return Ok(tarefa);
            }
            catch (Exception ex)
            {
                return BadRequest("Falha ao retornar tarefa!" + ex.Message);
            }
        }

        public IHttpActionResult Post(TarefaDto tarefaDto)
        {
            try
            {
                var tarefa = _tarefaService.Post(tarefaDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Falha ao inserir tarefa!" + ex.Message);
            }
        }
        
    }
}