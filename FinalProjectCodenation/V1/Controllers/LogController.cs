using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FinalProjectCodenation.Interfaces;
using FinalProjectCodenation.Models;
using FinalProjectCodenation.V1.Dtos;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProjectCodenation.V1.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class LogController : ControllerBase
    {

        private readonly ILogRepository _repo;
        private readonly IMapper _mapper;

        public LogController(ILogRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }
        
        /// <summary>
        /// Método retorna os parametros do Log informado por meio de seu id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/<LogController>/5
        [HttpGet("{id:int}")]
        public IActionResult GetbyId(int id)
        {
            var logs = _repo.GetLogbyId(id);
            var logDto = _mapper.Map<IEnumerable<LogDto>>(logs);
            return Ok(logDto);
        }

        /// <summary>
        /// Método retorna lista de todos os Logs salvos provenientes do Setor com o id informado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{sectorid:int}")]
        public IActionResult GetbySectorId(int id)
        {
            var logs = _repo.GetLogsbySector(id);
            var logDto = _mapper.Map<IEnumerable<LogDto>>(logs);
            return Ok(logDto);
        }

        /// <summary>
        /// Método retorna lista de todos os Logs salvos provenientes do Setor com o level informado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{level}")]
        public IActionResult Getbylevel(string level)
        {
            var logs = _repo.GetLogbyLevel(level);
            var logDto = _mapper.Map<IEnumerable<LogDto>>(logs);
            return Ok(logDto);
        }

        /// <summary>
        /// Método retorna lista de todos os Logs salvos provenientes do Setor com o description informado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{description}")]
        public IActionResult GetbyDescription(string description)
        {
            var logs = _repo.GetLogbyDescription(description);
            var logDto = _mapper.Map<IEnumerable<LogDto>>(logs);
            return Ok(logDto);
        }


        /// <summary>
        /// Método retorna lista de todos os Logs salvos provenientes do Setor com o origin informado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{origin}")]
        public IActionResult GetbyOrigin(string origin)
        {
            var logs = _repo.GetLogbyOrigin(origin);
            var logDto = _mapper.Map<IEnumerable<LogDto>>(logs);
            return Ok(logDto);
        }



        /// <summary>
        /// Salva novo Log de Erro
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        // POST api/<LogController>
        [HttpPost]
        public IActionResult Post(LogDto model)
        {
            var log = _mapper.Map<Log>(model);
            _repo.Add(log);
            if (_repo.SaveChanges())
                return Created($"api/logs/{model.Id}", _mapper.Map<LogDto>(log));
            return BadRequest("log not added");

        }

        /// <summary>
        /// Atualiza novo Log de Erro
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        // PUT api/<LogController>/5
        [HttpPut("{id:int}")]
        public IActionResult Put(int id, LogDto model)
        {
            var log = _repo.GetLogbyId(id);
            if (log == null) return BadRequest("id not found");
            _mapper.Map(model, log);
            _repo.Update(log);
            if (_repo.SaveChanges())
                return Created($"api/logs/{model.Id}", _mapper.Map<LogDto>(log));
            return BadRequest("Professor not updated");

        }

        /// <summary>
        /// Deleta Erro com o id informado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE api/<LogController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var log = _repo.GetLogbyId(id);
            if (log == null) return BadRequest("id not found");
            _repo.Delete(log);
            if (_repo.SaveChanges())
                return Ok("Log Deleted");
            return BadRequest("Log not deleted");
        }
    }
}
