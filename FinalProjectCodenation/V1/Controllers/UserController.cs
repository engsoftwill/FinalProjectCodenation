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
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repo;
        private readonly IMapper _mapper;

        public UserController(IUserRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }
        /// <summary>
        /// Método retorna lista de todos os Usuários Cadastrados
        /// </summary>
        /// <returns></returns>
        // GET: api/<UserController>
        [HttpGet]
        public IActionResult GetAll()
        {
            var user = _repo.GetAllUsers();
            var userDto = _mapper.Map<IEnumerable<UserDto>>(user);
            return Ok(userDto);
        }
        /// <summary>
        /// Método retorna o Usuário relacionado ao id informado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/<UserController>/5
        [HttpGet("{id:int}")]
        public IActionResult GetbyId(int id)
        {
            var user = _repo.GetUserbyId(id);
            var userDto = _mapper.Map<IEnumerable<UserDto>>(user);
            return Ok(userDto);
        }

        /// <summary>
        /// Adiciona novo usuario
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        // POST api/<UserController>
        [HttpPost]
        public IActionResult Post(UserDto model)
        {
            var user = _mapper.Map<User>(model);
            _repo.Add(user);
            if (_repo.SaveChanges())
                return Created($"api/user/{model.Id}", _mapper.Map<UserDto>(user));
            return BadRequest("sector not added");

        }
        /// <summary>
        /// atualiza o usuario que possuir o id informado
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        // PUT api/<UserController>/5
        [HttpPut("{id:int}")]
        public IActionResult Put(int id, UserDto model)
        {
            var user = _repo.GetUserbyId(id);
            if (user == null) return BadRequest("id not found");
            _mapper.Map(model, user);
            _repo.Update(user);
            if (_repo.SaveChanges())
                return Created($"api/user/{model.Id}", _mapper.Map<UserDto>(user));
            return BadRequest("user not updated");

        }

        /// <summary>
        /// deleta o usuario com o id informado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _repo.GetUserbyId(id);
            if (user == null) return BadRequest("id not found");
            _repo.Delete(user);
            if (_repo.SaveChanges())
                return Ok("user Deleted");
            return BadRequest("user not deleted");
        }
    }
}
