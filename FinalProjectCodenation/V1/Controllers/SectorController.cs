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
    public class SectorController : ControllerBase
    {
        private readonly ISectorRepository _repo;
        private readonly IMapper _mapper;

        public SectorController(ISectorRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }
        /// <summary>
        /// Método retorna lista de todos os Setores do Negócio
        /// </summary>
        /// <returns></returns>
        // GET: api/<SectorController>
        [HttpGet]
        public IActionResult GetAll()
        {
            var sector = _repo.GetAllSectors();
            var sectorDto = _mapper.Map<IEnumerable<SectorDto>>(sector);
            return Ok(sectorDto);
        }
        /// <summary>
        /// Método retorna o Setores do Negócio relacionado ao id informado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/<SectorController>/5
        [HttpGet("{id:int}")]
        public IActionResult GetbyId(int id)
        {
            var sector = _repo.GetSectorbyId(id);
            var sectorDto = _mapper.Map<IEnumerable<SectorDto>>(sector);
            return Ok(sectorDto);
        }

        /// <summary>
        /// adiciona novo setor ao Negócio
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        // POST api/<SectorController>
        [HttpPost]
        public IActionResult Post(SectorDto model)
        {
            var sector = _mapper.Map<Sector>(model);
            _repo.Add(sector);
            if (_repo.SaveChanges())
                return Created($"api/sector/{model.Id}", _mapper.Map<SectorDto>(sector));
            return BadRequest("sector not added");

        }
        /// <summary>
        /// atualiza o setor no Negócio com o id informado
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        // PUT api/<SectorController>/5
        [HttpPut("{id:int}")]
        public IActionResult Put(int id, SectorDto model)
        {
            var sector = _repo.GetSectorbyId(id);
            if (sector == null) return BadRequest("id not found");
            _mapper.Map(model, sector);
            _repo.Update(sector);
            if (_repo.SaveChanges())
                return Created($"api/logs/{model.Id}", _mapper.Map<SectorDto>(sector));
            return BadRequest("sector not updated");

        }

        /// <summary>
        /// Deleta setor no Negocio com o id informado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE api/<SectorController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var sector = _repo.GetSectorbyId(id);
            if (sector == null) return BadRequest("id not found");
            _repo.Delete(sector);
            if (_repo.SaveChanges())
                return Ok("sector Deleted");
            return BadRequest("sector not deleted");
        }
    }
}
