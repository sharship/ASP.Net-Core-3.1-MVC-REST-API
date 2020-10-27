using System.Diagnostics.Contracts;
using System.Collections.Generic;
using AutoMapper;
using Command_Management_Tool.Data;
using Command_Management_Tool.Dtos;
using Command_Management_Tool.Models;
using Microsoft.AspNetCore.Mvc;

namespace Command_Management_Tool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICMTRepo _repo;
        private readonly IMapper _mapper;

        public CommandsController(ICMTRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // GET: api/commands
        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commandItems = _repo.GetAllCommands();
            var commandReadDtoItems = _mapper.Map<IEnumerable<CommandReadDto>>(commandItems);

            return Ok(commandReadDtoItems);
        }

        // GET: api/commands/{id}
        [HttpGet("{id}", Name = "GetCommandById")]
        public ActionResult<CommandReadDto> GetCommandById(int id)
        {
            var command = _repo.GetCommandById(id);

            if (command is null)
                return NotFound();

            var commandReadDto = _mapper.Map<CommandReadDto>(command);
            return commandReadDto;
        }

        // POST: api/commands
        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto cmdCreateDto)
        {
            // transfer Input DTO to Command obj
            var cmd = _mapper.Map<Command>(cmdCreateDto);
            
            _repo.CreateCommand(cmd);
            var isSaved = _repo.SaveChanges();

            if (!isSaved)
                return BadRequest();
                
            var cmdReadDto = _mapper.Map<CommandReadDto>(cmd);

            return CreatedAtRoute(
                nameof(GetCommandById),  // routeName: The name of the route to use for generating the URL, here we use GetById
                new {Id = cmd.Id},  // routeValues: The route data to use for generating the URL
                cmdReadDto  // content: The content value to format in the entity body
            );
        }
              
    }


}