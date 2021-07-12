using _5_Pastelaria.Repository.Repositories;
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

        public TarefaController()
        {
            _tarefaRepository = new TarefaRepository();
            _disparoEmailRepository = new DisparoEmailRepository();
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
                var tarefa = _tarefaRepository.Post(tarefaDto);
                var disparoEmail = _disparoEmailRepository.GetDisparoEmailPorIdTarefa(tarefa);
                _disparoEmailRepository.Post(disparoEmail);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Falha ao inserir tarefa!" + ex.Message);
            }
        }
        
    }
}